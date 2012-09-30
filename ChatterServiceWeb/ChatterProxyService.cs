﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using ChatterService.Model;
using System.Configuration;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Web.Script.Serialization;   
using System.Web.Script.Services;
using System.IO;
using System.Collections.Specialized;
using System.Threading;

namespace ChatterService.Web
{
    public class CommonResult {
        public bool Success {get; set;}
        public bool Following { get; set; }
        public string ErrorMessage { get; set; }
        public int Total { get; set; }
        public string AccessToken { get; set; }
        public string URL { get; set; }
    }

    [ServiceContract(Name = "ChatterProxyService")]
    public interface IChatterProxyService   
    {
        [OperationContract]
        [WebGet(UriTemplate = "/activities?count={count}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        Activity[] GetActivities(int count);

        [OperationContract]
        [WebGet(UriTemplate = "/user/{personId}/activities?count={count}&mode={mode}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        Activity[] GetUserActivities(string personId, string mode, int count);

        [OperationContract]
        [WebInvoke(UriTemplate = "/group/new", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        CommonResult CreateGroup(Stream stream);

        [OperationContract]
        [WebGet(UriTemplate = "/user/{viewerId}/isfollowing/{ownerId}?accessToken={accessToken}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        CommonResult IsUserFollowing(string viewerId, string ownerId, string accessToken);

        [OperationContract]
        [WebGet(UriTemplate = "/user/{viewerId}/follow/{ownerId}?accessToken={accessToken}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        CommonResult Follow(string viewerId, string ownerId, string accessToken);

        [OperationContract]
        [WebGet(UriTemplate = "/user/{viewerId}/unfollow/{ownerId}?accessToken={accessToken}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        CommonResult Unfollow(string viewerId, string ownerId, string accessToken);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                 ConcurrencyMode = ConcurrencyMode.Single, 
                 IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ChatterProxyService : IChatterProxyService
    {
        readonly string url;
        readonly string userName;
        readonly string password;
        readonly string token;
        readonly string clientId;
        readonly string grantType;
        readonly string clientSecret;
        readonly int cacheInterval;
        readonly int cacheCapacity;
        static bool initialized = false;
        Timer activitiesFetcher;
        List<Activity> latestList = new List<Activity>();
        List<Activity> displayList = new List<Activity>();

        IProfilesServices profilesService = null;

        public ChatterProxyService()
        {
            url = ConfigurationSettings.AppSettings["SalesForceUrl"];
            userName = ConfigurationSettings.AppSettings["SalesForceUserName"];
            password = ConfigurationSettings.AppSettings["SalesForcePassword"];
            token = ConfigurationSettings.AppSettings["SalesForceToken"];
            clientId = ConfigurationSettings.AppSettings["SalesForceClientId"];
            grantType = ConfigurationSettings.AppSettings["SalesForceGrantType"];
            clientSecret = ConfigurationSettings.AppSettings["SalesForceClientSecret"];
            cacheInterval = Int32.Parse(ConfigurationSettings.AppSettings["CacheInterval"]);
            cacheCapacity = Int32.Parse(ConfigurationSettings.AppSettings["cacheCapacity"]);
            Init();
        }

        public Activity[] GetActivities(int count)
        {
            try
            {
                lock (latestList)
                {
                    return latestList.Take(count).ToArray();
                }
            }
            catch (Exception e)
            {
                HandleError(e, url);
                return null;
            }
        }

        public void GetActivities(Object stateInfo)
        {
            IChatterSoapService soap = getChatterSoapService();
            Activity lastActivity = latestList.Count > 0 ? latestList[0] : null;
            List<Activity> newActivities = soap.GetProfileActivities(lastActivity, cacheCapacity);
            if (newActivities.Count > 0)
            {
                lock (latestList)
                {
                    latestList.AddRange(newActivities);
                    latestList.Sort(new ActivitiesComparer());
                    if (latestList.Count > cacheCapacity)
                    {
                        latestList.RemoveRange(cacheCapacity, latestList.Count - cacheCapacity);
                    }
                }
            }
        }

        public Activity[] GetUserActivities(string userId, string mode, int count)
        {
            try {
                IChatterSoapService soap = getChatterSoapService();

                bool includeUserActivities = mode.Equals("all", StringComparison.InvariantCultureIgnoreCase);

                var ssUserId = getSalesforceUserId(userId);
                Activity[] result = soap.GetActivities(ssUserId, Int32.Parse(userId), includeUserActivities, count).ToArray();
                return result;
            }
            catch (Exception e)
            {
                HandleError(e, url);
                return null;
            }
        }

        public CommonResult CreateGroup(Stream stream)
        {
            try {
                NameValueCollection p = parseParameters(stream);

                if (string.IsNullOrEmpty(p["name"]))
                {
                    return new CommonResult() { Success = false, ErrorMessage = "Group name is required." };
                }

                if (string.IsNullOrEmpty(p["ownerId"]))
                {
                    return new CommonResult() { Success = false, ErrorMessage = "OwnerId is required." };
                }

                int personId = Int32.Parse(p["ownerId"]);
                string descr = p["description"];
                if (string.IsNullOrEmpty(descr))
                {
                    descr = p["name"];
                }

                string employeeId = profilesService.GetEmployeeId(personId);

                IChatterSoapService soap = getChatterSoapService();
                string groupId = soap.CreateGroup(p["name"], descr, employeeId);

                string users = p["users"];
                if(!string.IsNullOrEmpty(users)) {
                    string[] personList = users.Split(',');
                    List<string> employeeList = new List<string>();
                    foreach (string pId in personList)
                    {
                        try
                        {
                            string eId = profilesService.GetEmployeeId(Int32.Parse(pId));
                            employeeList.Add(eId);
                        }
                        catch (Exception ex)
                        {
                            //TODO: need to report it back to the server
                        }
                    }

                    if (employeeList.Count > 0)
                    {
                        soap.AddUsersToGroup(groupId, employeeList.ToArray<string>());
                    }
                }

                return new CommonResult() { Success = true, URL = url.Replace("/services", "/_ui/core/chatter/groups/GroupProfilePage?g=" + groupId)};
            }
            catch (Exception ex)
            {
                HandleError(ex, url);
                return new CommonResult() { Success = false, ErrorMessage = ex.Message };
            }
        }

        private NameValueCollection parseParameters(Stream stream) {
            string s = "";
            using (StreamReader sr = new StreamReader(stream))
            {
                s = sr.ReadToEnd();
            }

            return HttpUtility.ParseQueryString(s);
        }

        private static bool customXertificateValidation(object sender, X509Certificate cert, X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            return true;
        }

        private void Init()
        {
            lock(this) {
                if (!initialized)
                {
                    ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(customXertificateValidation);
                    activitiesFetcher = new Timer(GetActivities, null, 0, cacheInterval * 1000);
                    profilesService = new ProfilesServices();
                    getChatterSoapService();
                    initialized = true;
                }
            }
        }

        #region REST
        public CommonResult IsUserFollowing(string viewerId, string ownerId, string accessToken)
        {
            try
            {
                var ssOwnerId = getSalesforceUserId(ownerId);
                var ssViewerId = getSalesforceUserId(viewerId);

                ChatterRestService rest = getChatterRestService(accessToken);
                ChatterResponse cresp = rest.GetFollowers(ssOwnerId);
                int total = cresp != null ? cresp.total : 0;

                while (cresp != null && cresp.followers != null)
                {
                    foreach (ChatterSubscription csub in cresp.followers)
                    {
                        if (csub.subscriber != null && ssViewerId.Equals(csub.subscriber.id))
                        {
                            return new CommonResult() { Success = true, Following = true, Total = total, AccessToken = rest.GetAccessToken() };
                        }
                    }
                    cresp = rest.GetNextPage(cresp);
                }

                return new CommonResult() { Success = true, Following = false, Total = total, AccessToken = rest.GetAccessToken() };
            }
            catch (Exception ex)
            {
                HandleError(ex, accessToken);
                return new CommonResult() { Success = false, ErrorMessage = ex.Message };
            }
        }

        public CommonResult Follow(string viewerId, string ownerId, string accessToken)
        {
            try
            {
                var ssOwnerId = getSalesforceUserId(ownerId);
                var ssViewerId = getSalesforceUserId(viewerId);

                ChatterRestService rest = getChatterRestService(accessToken);
                ChatterResponse cresp = rest.Follow(ssViewerId, ssOwnerId);
                return IsUserFollowing(viewerId, ownerId, accessToken);
            }
            catch (Exception ex)
            {
                HandleError(ex, accessToken);
                return new CommonResult() { Success = false, ErrorMessage = ex.Message };
            }
        }

        public CommonResult Unfollow(string viewerId, string ownerId, string accessToken)
        {
            try
            {
                var ssOwnerId = getSalesforceUserId(ownerId);
                var ssViewerId = getSalesforceUserId(viewerId);

                ChatterRestService rest = getChatterRestService(accessToken);
                ChatterResponse cresp = rest.Unfollow(ssViewerId, ssOwnerId);
                return IsUserFollowing(viewerId, ownerId, accessToken);
            }
            catch (Exception ex)
            {
                HandleError(ex, accessToken);
                return new CommonResult() { Success = false, ErrorMessage = ex.Message };
            }
        }
        #endregion

        private string getSalesforceUserId(string profilesId)
        {
            Object objUserId = HttpRuntime.Cache[profilesId];

            if (objUserId == null)
            {
                IChatterSoapService soap = getChatterSoapService();
                objUserId = soap.GetUserId(profilesService.GetEmployeeId(Int32.Parse(profilesId)));
                HttpRuntime.Cache.Insert(profilesId, objUserId);
            }
            return Convert.ToString(objUserId);
        }

        private IChatterSoapService getChatterSoapService()
        {
            IChatterSoapService soap = (IChatterSoapService)HttpRuntime.Cache[url];
            if (soap == null)
            {
                lock (this)
                {
                    soap = new ChatterSoapService(url);
                    soap.Login(userName, password, token);
                    HttpRuntime.Cache.Insert(url, soap);
                }
            }
            return soap;
        }

        private ChatterRestService getChatterRestService(string accessToken)
        {
            ChatterRestService rest = accessToken !=  null && accessToken.Trim().Length > 0 ? (ChatterRestService)HttpRuntime.Cache[accessToken] : null;

            if (rest == null)
            {
                rest = new ChatterRestService(url);
                accessToken = rest.Login(clientId, grantType, clientSecret, userName, password);
                HttpRuntime.Cache.Insert(accessToken, rest);
            }
            return rest;
        }

        #region IErrorHandler Members
        public bool HandleError(Exception error, string key)
        {
            WriteLogToFile(error.Message);

            // remove what we think may be stale
            if (key != null && key.Trim().Length > 0)
            {
                HttpRuntime.Cache.Remove(key);
            }
            // Returning true indicates you performed your behavior. 
            return true;
        }
        #endregion    

        private void WriteLogToFile(String msg)
        {
            try
            {

                using (StreamWriter w = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "/ChatterProxyService.txt"))
                {
                    // write a line of text to the file
                    w.WriteLine(msg);

                    // close the stream
                    w.Close();

                }
                //EventLog.WriteEntry("ProfilesAPI",
                //  msg,
                //EventLogEntryType.Information);

            }
            catch (Exception ex) { throw ex; }
        }
    }
   
}