﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("helloworldModel", "GameSuspect", "Game", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(InterpoolPrototypeWebRole.Game), "Suspect", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(InterpoolPrototypeWebRole.Suspect))]
[assembly: EdmRelationshipAttribute("helloworldModel", "UserGame", "User", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(InterpoolPrototypeWebRole.User), "Game", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(InterpoolPrototypeWebRole.Game))]

#endregion

namespace InterpoolPrototypeWebRole
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class HelloWorldEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new HelloWorldEntities object using the connection string found in the 'HelloWorldEntities' section of the application configuration file.
        /// </summary>
        public HelloWorldEntities() : base("name=HelloWorldEntities", "HelloWorldEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new HelloWorldEntities object.
        /// </summary>
        public HelloWorldEntities(string connectionString) : base(connectionString, "HelloWorldEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new HelloWorldEntities object.
        /// </summary>
        public HelloWorldEntities(EntityConnection connection) : base(connection, "HelloWorldEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<City> Cities
        {
            get
            {
                if ((_Cities == null))
                {
                    _Cities = base.CreateObjectSet<City>("Cities");
                }
                return _Cities;
            }
        }
        private ObjectSet<City> _Cities;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<FacebookUser> FacebookUsers
        {
            get
            {
                if ((_FacebookUsers == null))
                {
                    _FacebookUsers = base.CreateObjectSet<FacebookUser>("FacebookUsers");
                }
                return _FacebookUsers;
            }
        }
        private ObjectSet<FacebookUser> _FacebookUsers;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Suspect> Suspects
        {
            get
            {
                if ((_Suspects == null))
                {
                    _Suspects = base.CreateObjectSet<Suspect>("Suspects");
                }
                return _Suspects;
            }
        }
        private ObjectSet<Suspect> _Suspects;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Game> Games
        {
            get
            {
                if ((_Games == null))
                {
                    _Games = base.CreateObjectSet<Game>("Games");
                }
                return _Games;
            }
        }
        private ObjectSet<Game> _Games;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PrototypeSuspect> PrototypeSuspects
        {
            get
            {
                if ((_PrototypeSuspects == null))
                {
                    _PrototypeSuspects = base.CreateObjectSet<PrototypeSuspect>("PrototypeSuspects");
                }
                return _PrototypeSuspects;
            }
        }
        private ObjectSet<PrototypeSuspect> _PrototypeSuspects;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Cities EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCities(City city)
        {
            base.AddObject("Cities", city);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the FacebookUsers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToFacebookUsers(FacebookUser facebookUser)
        {
            base.AddObject("FacebookUsers", facebookUser);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Suspects EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSuspects(Suspect suspect)
        {
            base.AddObject("Suspects", suspect);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Games EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToGames(Game game)
        {
            base.AddObject("Games", game);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PrototypeSuspects EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPrototypeSuspects(PrototypeSuspect prototypeSuspect)
        {
            base.AddObject("PrototypeSuspects", prototypeSuspect);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="helloworldModel", Name="City")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class City : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new City object.
        /// </summary>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="countryName">Initial value of the CountryName property.</param>
        /// <param name="id">Initial value of the ID property.</param>
        public static City CreateCity(global::System.String name, global::System.String countryName, global::System.Int32 id)
        {
            City city = new City();
            city.Name = name;
            city.CountryName = countryName;
            city.ID = id;
            return city;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                OnCountryNameChanging(value);
                ReportPropertyChanging("CountryName");
                _CountryName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CountryName");
                OnCountryNameChanged();
            }
        }
        private global::System.String _CountryName;
        partial void OnCountryNameChanging(global::System.String value);
        partial void OnCountryNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="helloworldModel", Name="FacebookUser")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class FacebookUser : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new FacebookUser object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="authToken">Initial value of the AuthToken property.</param>
        public static FacebookUser CreateFacebookUser(global::System.Int32 id, global::System.String userId, global::System.String authToken)
        {
            FacebookUser facebookUser = new FacebookUser();
            facebookUser.Id = id;
            facebookUser.UserId = userId;
            facebookUser.AuthToken = authToken;
            return facebookUser;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                OnUserIdChanging(value);
                ReportPropertyChanging("UserId");
                _UserId = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserId");
                OnUserIdChanged();
            }
        }
        private global::System.String _UserId;
        partial void OnUserIdChanging(global::System.String value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String AuthToken
        {
            get
            {
                return _AuthToken;
            }
            set
            {
                OnAuthTokenChanging(value);
                ReportPropertyChanging("AuthToken");
                _AuthToken = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("AuthToken");
                OnAuthTokenChanged();
            }
        }
        private global::System.String _AuthToken;
        partial void OnAuthTokenChanging(global::System.String value);
        partial void OnAuthTokenChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="helloworldModel", Name="Game")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Game : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Game object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static Game CreateGame(global::System.Int32 id)
        {
            Game game = new Game();
            game.Id = id;
            return game;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("helloworldModel", "GameSuspect", "Suspect")]
        public EntityCollection<Suspect> Suspect
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Suspect>("helloworldModel.GameSuspect", "Suspect");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Suspect>("helloworldModel.GameSuspect", "Suspect", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("helloworldModel", "UserGame", "User")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("helloworldModel.UserGame", "User").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("helloworldModel.UserGame", "User").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("helloworldModel.UserGame", "User");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("helloworldModel.UserGame", "User", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="helloworldModel", Name="PrototypeSuspect")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PrototypeSuspect : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PrototypeSuspect object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static PrototypeSuspect CreatePrototypeSuspect(global::System.Int32 id, global::System.String name)
        {
            PrototypeSuspect prototypeSuspect = new PrototypeSuspect();
            prototypeSuspect.Id = id;
            prototypeSuspect.Name = name;
            return prototypeSuspect;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="helloworldModel", Name="Suspect")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Suspect : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Suspect object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static Suspect CreateSuspect(global::System.Int32 id, global::System.String userId, global::System.String name)
        {
            Suspect suspect = new Suspect();
            suspect.Id = id;
            suspect.UserId = userId;
            suspect.Name = name;
            return suspect;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                OnUserIdChanging(value);
                ReportPropertyChanging("UserId");
                _UserId = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserId");
                OnUserIdChanged();
            }
        }
        private global::System.String _UserId;
        partial void OnUserIdChanging(global::System.String value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("helloworldModel", "GameSuspect", "Game")]
        public Game Game
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Game>("helloworldModel.GameSuspect", "Game").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Game>("helloworldModel.GameSuspect", "Game").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Game> GameReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Game>("helloworldModel.GameSuspect", "Game");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Game>("helloworldModel.GameSuspect", "Game", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="helloworldModel", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static User CreateUser(global::System.Int32 id, global::System.String userId, global::System.String name)
        {
            User user = new User();
            user.Id = id;
            user.UserId = userId;
            user.Name = name;
            return user;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                OnUserIdChanging(value);
                ReportPropertyChanging("UserId");
                _UserId = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserId");
                OnUserIdChanged();
            }
        }
        private global::System.String _UserId;
        partial void OnUserIdChanging(global::System.String value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("helloworldModel", "UserGame", "Game")]
        public EntityCollection<Game> Game
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Game>("helloworldModel.UserGame", "Game");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Game>("helloworldModel.UserGame", "Game", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
