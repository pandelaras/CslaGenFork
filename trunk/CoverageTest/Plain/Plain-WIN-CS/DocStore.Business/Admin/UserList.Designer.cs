//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    UserList
// ObjectType:  UserList
// CSLAType:    ReadOnlyCollection

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace DocStore.Business.Admin
{

    /// <summary>
    /// Collection of user's basic information (read only list).<br/>
    /// This is a generated base class of <see cref="UserList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="UserInfo"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class UserList : ReadOnlyBindingListBase<UserList, UserInfo>
#else
    public partial class UserList : ReadOnlyListBase<UserList, UserInfo>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="UserInfo"/> item is in the collection.
        /// </summary>
        /// <param name="userID">The UserID of the item to search for.</param>
        /// <returns><c>true</c> if the UserInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int userID)
        {
            foreach (var userInfo in this)
            {
                if (userInfo.UserID == userID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="UserInfo"/> item of the <see cref="UserList"/> collection, based on a given UserID.
        /// </summary>
        /// <param name="userID">The UserID.</param>
        /// <returns>A <see cref="UserInfo"/> object.</returns>
        public UserInfo FindUserInfoByUserID(int userID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].UserID.Equals(userID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Private Fields

        private static UserList _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory UserList cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(UserList list)
        {
            _list = list;
        }

        internal static bool IsCached
        {
            get { return _list != null; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="UserList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="UserList"/> collection.</returns>
        public static UserList GetUserList()
        {
            if (_list == null)
                _list = DataPortal.Fetch<UserList>();

            return _list;
        }

        /// <summary>
        /// Factory method. Loads a <see cref="UserList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="name">The Name parameter of the UserList to fetch.</param>
        /// <param name="login">The Login parameter of the UserList to fetch.</param>
        /// <param name="email">The Email parameter of the UserList to fetch.</param>
        /// <param name="isActive">The IsActive parameter of the UserList to fetch.</param>
        /// <returns>A reference to the fetched <see cref="UserList"/> collection.</returns>
        public static UserList GetUserList(string name, string login, string email, bool? isActive)
        {
            return DataPortal.Fetch<UserList>(new FilteredCriteria(name, login, email, isActive));
        }

        /// <summary>
        /// Factory method. Loads a <see cref="UserList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="name">The Name parameter of the UserList to fetch.</param>
        /// <returns>A reference to the fetched <see cref="UserList"/> collection.</returns>
        public static UserList GetUserList(string name)
        {
            return DataPortal.Fetch<UserList>(new CriteriaInactive(name));
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="UserList"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetUserList(EventHandler<DataPortalResult<UserList>> callback)
        {
            if (_list == null)
                DataPortal.BeginFetch<UserList>((o, e) =>
                    {
                        _list = e.Object;
                        callback(o, e);
                    });
            else
                callback(null, new DataPortalResult<UserList>(_list, null, null));
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="UserList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="name">The Name parameter of the UserList to fetch.</param>
        /// <param name="login">The Login parameter of the UserList to fetch.</param>
        /// <param name="email">The Email parameter of the UserList to fetch.</param>
        /// <param name="isActive">The IsActive parameter of the UserList to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetUserList(string name, string login, string email, bool? isActive, EventHandler<DataPortalResult<UserList>> callback)
        {
            DataPortal.BeginFetch<UserList>(new FilteredCriteria(name, login, email, isActive), callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="UserList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="name">The Name parameter of the UserList to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetUserList(string name, EventHandler<DataPortalResult<UserList>> callback)
        {
            DataPortal.BeginFetch<UserList>(new CriteriaInactive(name), callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public UserList()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Criteria

        /// <summary>
        /// FilteredCriteria criteria.
        /// </summary>
        [Serializable]
        protected class FilteredCriteria : CriteriaBase<FilteredCriteria>
        {

            /// <summary>
            /// Maintains metadata about <see cref="Name"/> property.
            /// </summary>
            public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name);
            /// <summary>
            /// Gets or sets the Name.
            /// </summary>
            /// <value>The Name.</value>
            public string Name
            {
                get { return ReadProperty(NameProperty); }
                set { LoadProperty(NameProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="Login"/> property.
            /// </summary>
            public static readonly PropertyInfo<string> LoginProperty = RegisterProperty<string>(p => p.Login);
            /// <summary>
            /// Gets or sets the Login.
            /// </summary>
            /// <value>The Login.</value>
            public string Login
            {
                get { return ReadProperty(LoginProperty); }
                set { LoadProperty(LoginProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="Email"/> property.
            /// </summary>
            public static readonly PropertyInfo<string> EmailProperty = RegisterProperty<string>(p => p.Email);
            /// <summary>
            /// Gets or sets the Email.
            /// </summary>
            /// <value>The Email.</value>
            public string Email
            {
                get { return ReadProperty(EmailProperty); }
                set { LoadProperty(EmailProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="IsActive"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool?> IsActiveProperty = RegisterProperty<bool?>(p => p.IsActive);
            /// <summary>
            /// Gets or sets the active or deleted state.
            /// </summary>
            /// <value><c>true</c> if Is Active; <c>false</c> if not Is Active; otherwise, <c>null</c>.</value>
            public bool? IsActive
            {
                get { return ReadProperty(IsActiveProperty); }
                set { LoadProperty(IsActiveProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="FilteredCriteria"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public FilteredCriteria()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="FilteredCriteria"/> class.
            /// </summary>
            /// <param name="name">The Name.</param>
            /// <param name="login">The Login.</param>
            /// <param name="email">The Email.</param>
            /// <param name="isActive">The IsActive.</param>
            public FilteredCriteria(string name, string login, string email, bool? isActive)
            {
                Name = name;
                Login = login;
                Email = email;
                IsActive = isActive;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is FilteredCriteria)
                {
                    var c = (FilteredCriteria) obj;
                    if (!Name.Equals(c.Name))
                        return false;
                    if (!Login.Equals(c.Login))
                        return false;
                    if (!Email.Equals(c.Email))
                        return false;
                    if (!IsActive.Equals(c.IsActive))
                        return false;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("FilteredCriteria", Name.ToString(), Login.ToString(), Email.ToString(), IsActive.ToString()).GetHashCode();
            }
        }

        /// <summary>
        /// CriteriaInactive criteria.
        /// </summary>
        [Serializable]
        protected class CriteriaInactive : CriteriaBase<CriteriaInactive>
        {

            /// <summary>
            /// Maintains metadata about <see cref="Name"/> property.
            /// </summary>
            public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name);
            /// <summary>
            /// Gets or sets the Name.
            /// </summary>
            /// <value>The Name.</value>
            public string Name
            {
                get { return ReadProperty(NameProperty); }
                set { LoadProperty(NameProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="IsActive"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> IsActiveProperty = RegisterProperty<bool>(p => p.IsActive);
            /// <summary>
            /// Gets the active or deleted state.
            /// </summary>
            /// <value><c>true</c> if Is Active; otherwise, <c>false</c>.</value>
            public bool IsActive
            {
                get { return ReadProperty(IsActiveProperty); }
                private set { LoadProperty(IsActiveProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CriteriaInactive"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public CriteriaInactive()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CriteriaInactive"/> class.
            /// </summary>
            /// <param name="name">The Name.</param>
            public CriteriaInactive(string name)
            {
                Name = name;
                IsActive = false;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is CriteriaInactive)
                {
                    var c = (CriteriaInactive) obj;
                    if (!Name.Equals(c.Name))
                        return false;
                    if (!IsActive.Equals(c.IsActive))
                        return false;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("CriteriaInactive", Name.ToString(), IsActive.ToString()).GetHashCode();
            }
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (UserList), new IsInRole(AuthorizationActions.GetObject, "User"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can retrieve UserList's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(UserList));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="UserList"/> collection from the database or from the cache.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetUserList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            _list = this;
        }

        private void LoadCachedList()
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AddRange(_list);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads a <see cref="UserList"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        protected void DataPortal_Fetch(FilteredCriteria crit)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetUserList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", crit.Name == null ? (object)DBNull.Value : crit.Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Login", crit.Login == null ? (object)DBNull.Value : crit.Login).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Email", crit.Email == null ? (object)DBNull.Value : crit.Email).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@IsActive", crit.IsActive == null ? (object)DBNull.Value : crit.IsActive.Value).DbType = DbType.Boolean;
                    var args = new DataPortalHookArgs(cmd, crit);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="UserList"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        protected void DataPortal_Fetch(CriteriaInactive crit)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetUserList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", crit.Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@IsActive", crit.IsActive).DbType = DbType.Boolean;
                    var args = new DataPortalHookArgs(cmd, crit);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="UserList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(UserInfo.GetUserInfo(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}
