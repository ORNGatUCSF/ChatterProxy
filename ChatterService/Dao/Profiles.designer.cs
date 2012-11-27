﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatterService.Dao
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="profiles_102")]
	public partial class ProfilesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPerson(Person instance);
    partial void UpdatePerson(Person instance);
    partial void DeletePerson(Person instance);
    #endregion
		
		public ProfilesDataContext() : 
				base(global::ChatterService.Properties.Settings.Default.profiles_102ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ProfilesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProfilesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProfilesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProfilesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Person> Persons
		{
			get
			{
				return this.GetTable<Person>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="[Profile.Data].Person")]
	public partial class Person : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PersonID;
		
		private System.Nullable<int> _UserID;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _MiddleName;
		
		private string _DisplayName;
		
		private string _Suffix;
		
		private System.Nullable<bool> _IsActive;
		
		private string _EmailAddr;
		
		private string _Phone;
		
		private string _Fax;
		
		private string _AddressLine1;
		
		private string _AddressLine2;
		
		private string _AddressLine3;
		
		private string _AddressLine4;
		
		private string _City;
		
		private string _State;
		
		private string _Zip;
		
		private string _Building;
		
		private System.Nullable<int> _Floor;
		
		private string _Room;
		
		private string _AddressString;
		
		private System.Nullable<decimal> _Latitude;
		
		private System.Nullable<decimal> _Longitude;
		
		private System.Nullable<byte> _GeoScore;
		
		private System.Nullable<int> _FacultyRankID;
		
		private string _InternalUsername;
		
		private System.Nullable<bool> _Visible;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPersonIDChanging(int value);
    partial void OnPersonIDChanged();
    partial void OnUserIDChanging(System.Nullable<int> value);
    partial void OnUserIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnMiddleNameChanging(string value);
    partial void OnMiddleNameChanged();
    partial void OnDisplayNameChanging(string value);
    partial void OnDisplayNameChanged();
    partial void OnSuffixChanging(string value);
    partial void OnSuffixChanged();
    partial void OnIsActiveChanging(System.Nullable<bool> value);
    partial void OnIsActiveChanged();
    partial void OnEmailAddrChanging(string value);
    partial void OnEmailAddrChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnFaxChanging(string value);
    partial void OnFaxChanged();
    partial void OnAddressLine1Changing(string value);
    partial void OnAddressLine1Changed();
    partial void OnAddressLine2Changing(string value);
    partial void OnAddressLine2Changed();
    partial void OnAddressLine3Changing(string value);
    partial void OnAddressLine3Changed();
    partial void OnAddressLine4Changing(string value);
    partial void OnAddressLine4Changed();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    partial void OnStateChanging(string value);
    partial void OnStateChanged();
    partial void OnZipChanging(string value);
    partial void OnZipChanged();
    partial void OnBuildingChanging(string value);
    partial void OnBuildingChanged();
    partial void OnFloorChanging(System.Nullable<int> value);
    partial void OnFloorChanged();
    partial void OnRoomChanging(string value);
    partial void OnRoomChanged();
    partial void OnAddressStringChanging(string value);
    partial void OnAddressStringChanged();
    partial void OnLatitudeChanging(System.Nullable<decimal> value);
    partial void OnLatitudeChanged();
    partial void OnLongitudeChanging(System.Nullable<decimal> value);
    partial void OnLongitudeChanged();
    partial void OnGeoScoreChanging(System.Nullable<byte> value);
    partial void OnGeoScoreChanged();
    partial void OnFacultyRankIDChanging(System.Nullable<int> value);
    partial void OnFacultyRankIDChanged();
    partial void OnInternalUsernameChanging(string value);
    partial void OnInternalUsernameChanged();
    partial void OnVisibleChanging(System.Nullable<bool> value);
    partial void OnVisibleChanged();
    #endregion
		
		public Person()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PersonID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PersonID
		{
			get
			{
				return this._PersonID;
			}
			set
			{
				if ((this._PersonID != value))
				{
					this.OnPersonIDChanging(value);
					this.SendPropertyChanging();
					this._PersonID = value;
					this.SendPropertyChanged("PersonID");
					this.OnPersonIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int")]
		public System.Nullable<int> UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)")]
		public string MiddleName
		{
			get
			{
				return this._MiddleName;
			}
			set
			{
				if ((this._MiddleName != value))
				{
					this.OnMiddleNameChanging(value);
					this.SendPropertyChanging();
					this._MiddleName = value;
					this.SendPropertyChanged("MiddleName");
					this.OnMiddleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DisplayName", DbType="NVarChar(255)")]
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				if ((this._DisplayName != value))
				{
					this.OnDisplayNameChanging(value);
					this.SendPropertyChanging();
					this._DisplayName = value;
					this.SendPropertyChanged("DisplayName");
					this.OnDisplayNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Suffix", DbType="NVarChar(50)")]
		public string Suffix
		{
			get
			{
				return this._Suffix;
			}
			set
			{
				if ((this._Suffix != value))
				{
					this.OnSuffixChanging(value);
					this.SendPropertyChanging();
					this._Suffix = value;
					this.SendPropertyChanged("Suffix");
					this.OnSuffixChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="Bit")]
		public System.Nullable<bool> IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailAddr", DbType="NVarChar(255)")]
		public string EmailAddr
		{
			get
			{
				return this._EmailAddr;
			}
			set
			{
				if ((this._EmailAddr != value))
				{
					this.OnEmailAddrChanging(value);
					this.SendPropertyChanging();
					this._EmailAddr = value;
					this.SendPropertyChanged("EmailAddr");
					this.OnEmailAddrChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NVarChar(35)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fax", DbType="NVarChar(25)")]
		public string Fax
		{
			get
			{
				return this._Fax;
			}
			set
			{
				if ((this._Fax != value))
				{
					this.OnFaxChanging(value);
					this.SendPropertyChanging();
					this._Fax = value;
					this.SendPropertyChanged("Fax");
					this.OnFaxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressLine1", DbType="NVarChar(255)")]
		public string AddressLine1
		{
			get
			{
				return this._AddressLine1;
			}
			set
			{
				if ((this._AddressLine1 != value))
				{
					this.OnAddressLine1Changing(value);
					this.SendPropertyChanging();
					this._AddressLine1 = value;
					this.SendPropertyChanged("AddressLine1");
					this.OnAddressLine1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressLine2", DbType="NVarChar(255)")]
		public string AddressLine2
		{
			get
			{
				return this._AddressLine2;
			}
			set
			{
				if ((this._AddressLine2 != value))
				{
					this.OnAddressLine2Changing(value);
					this.SendPropertyChanging();
					this._AddressLine2 = value;
					this.SendPropertyChanged("AddressLine2");
					this.OnAddressLine2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressLine3", DbType="NVarChar(255)")]
		public string AddressLine3
		{
			get
			{
				return this._AddressLine3;
			}
			set
			{
				if ((this._AddressLine3 != value))
				{
					this.OnAddressLine3Changing(value);
					this.SendPropertyChanging();
					this._AddressLine3 = value;
					this.SendPropertyChanged("AddressLine3");
					this.OnAddressLine3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressLine4", DbType="NVarChar(255)")]
		public string AddressLine4
		{
			get
			{
				return this._AddressLine4;
			}
			set
			{
				if ((this._AddressLine4 != value))
				{
					this.OnAddressLine4Changing(value);
					this.SendPropertyChanging();
					this._AddressLine4 = value;
					this.SendPropertyChanged("AddressLine4");
					this.OnAddressLine4Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="NVarChar(55)")]
		public string City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_State", DbType="NVarChar(50)")]
		public string State
		{
			get
			{
				return this._State;
			}
			set
			{
				if ((this._State != value))
				{
					this.OnStateChanging(value);
					this.SendPropertyChanging();
					this._State = value;
					this.SendPropertyChanged("State");
					this.OnStateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Zip", DbType="NVarChar(50)")]
		public string Zip
		{
			get
			{
				return this._Zip;
			}
			set
			{
				if ((this._Zip != value))
				{
					this.OnZipChanging(value);
					this.SendPropertyChanging();
					this._Zip = value;
					this.SendPropertyChanged("Zip");
					this.OnZipChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Building", DbType="NVarChar(255)")]
		public string Building
		{
			get
			{
				return this._Building;
			}
			set
			{
				if ((this._Building != value))
				{
					this.OnBuildingChanging(value);
					this.SendPropertyChanging();
					this._Building = value;
					this.SendPropertyChanged("Building");
					this.OnBuildingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Floor", DbType="Int")]
		public System.Nullable<int> Floor
		{
			get
			{
				return this._Floor;
			}
			set
			{
				if ((this._Floor != value))
				{
					this.OnFloorChanging(value);
					this.SendPropertyChanging();
					this._Floor = value;
					this.SendPropertyChanged("Floor");
					this.OnFloorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Room", DbType="NVarChar(255)")]
		public string Room
		{
			get
			{
				return this._Room;
			}
			set
			{
				if ((this._Room != value))
				{
					this.OnRoomChanging(value);
					this.SendPropertyChanging();
					this._Room = value;
					this.SendPropertyChanged("Room");
					this.OnRoomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddressString", DbType="NVarChar(1000)")]
		public string AddressString
		{
			get
			{
				return this._AddressString;
			}
			set
			{
				if ((this._AddressString != value))
				{
					this.OnAddressStringChanging(value);
					this.SendPropertyChanging();
					this._AddressString = value;
					this.SendPropertyChanged("AddressString");
					this.OnAddressStringChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Latitude", DbType="Decimal(18,14)")]
		public System.Nullable<decimal> Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				if ((this._Latitude != value))
				{
					this.OnLatitudeChanging(value);
					this.SendPropertyChanging();
					this._Latitude = value;
					this.SendPropertyChanged("Latitude");
					this.OnLatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Longitude", DbType="Decimal(18,14)")]
		public System.Nullable<decimal> Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				if ((this._Longitude != value))
				{
					this.OnLongitudeChanging(value);
					this.SendPropertyChanging();
					this._Longitude = value;
					this.SendPropertyChanged("Longitude");
					this.OnLongitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GeoScore", DbType="TinyInt")]
		public System.Nullable<byte> GeoScore
		{
			get
			{
				return this._GeoScore;
			}
			set
			{
				if ((this._GeoScore != value))
				{
					this.OnGeoScoreChanging(value);
					this.SendPropertyChanging();
					this._GeoScore = value;
					this.SendPropertyChanged("GeoScore");
					this.OnGeoScoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FacultyRankID", DbType="Int")]
		public System.Nullable<int> FacultyRankID
		{
			get
			{
				return this._FacultyRankID;
			}
			set
			{
				if ((this._FacultyRankID != value))
				{
					this.OnFacultyRankIDChanging(value);
					this.SendPropertyChanging();
					this._FacultyRankID = value;
					this.SendPropertyChanged("FacultyRankID");
					this.OnFacultyRankIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InternalUsername", DbType="NVarChar(50)")]
		public string InternalUsername
		{
			get
			{
				return this._InternalUsername;
			}
			set
			{
				if ((this._InternalUsername != value))
				{
					this.OnInternalUsernameChanging(value);
					this.SendPropertyChanging();
					this._InternalUsername = value;
					this.SendPropertyChanged("InternalUsername");
					this.OnInternalUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Visible", DbType="Bit")]
		public System.Nullable<bool> Visible
		{
			get
			{
				return this._Visible;
			}
			set
			{
				if ((this._Visible != value))
				{
					this.OnVisibleChanging(value);
					this.SendPropertyChanging();
					this._Visible = value;
					this.SendPropertyChanged("Visible");
					this.OnVisibleChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
