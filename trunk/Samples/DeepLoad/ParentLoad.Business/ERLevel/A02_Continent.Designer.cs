using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A02_Continent (editable root object).<br/>
    /// This is a generated base class of <see cref="A02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A03_SubContinentObjects"/> of type <see cref="A03_SubContinentColl"/> (1:M relation to <see cref="A04_SubContinent"/>)
    /// </remarks>
    [Serializable]
    public partial class A02_Continent : BusinessBase<A02_Continent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "Continent ID");
        /// <summary>
        /// Gets the Continent ID.
        /// </summary>
        /// <value>The Continent ID.</value>
        public int Continent_ID
        {
            get { return GetProperty(Continent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_NameProperty = RegisterProperty<string>(p => p.Continent_Name, "Continent Name");
        /// <summary>
        /// Gets or sets the Continent Name.
        /// </summary>
        /// <value>The Continent Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
            set { SetProperty(Continent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03_Continent_Child> A03_Continent_SingleObjectProperty = RegisterProperty<A03_Continent_Child>(p => p.A03_Continent_SingleObject, "A03 Continent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A03 Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A03 Continent Single Object.</value>
        public A03_Continent_Child A03_Continent_SingleObject
        {
            get { return GetProperty(A03_Continent_SingleObjectProperty); }
            private set { LoadProperty(A03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03_Continent_ReChild> A03_Continent_ASingleObjectProperty = RegisterProperty<A03_Continent_ReChild>(p => p.A03_Continent_ASingleObject, "A03 Continent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A03 Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A03 Continent ASingle Object.</value>
        public A03_Continent_ReChild A03_Continent_ASingleObject
        {
            get { return GetProperty(A03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(A03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03_SubContinentColl> A03_SubContinentObjectsProperty = RegisterProperty<A03_SubContinentColl>(p => p.A03_SubContinentObjects, "A03 SubContinent Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A03 Sub Continent Objects ("parent load" child property).
        /// </summary>
        /// <value>The A03 Sub Continent Objects.</value>
        public A03_SubContinentColl A03_SubContinentObjects
        {
            get { return GetProperty(A03_SubContinentObjectsProperty); }
            private set { LoadProperty(A03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A02_Continent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="A02_Continent"/> object.</returns>
        public static A02_Continent NewA02_Continent()
        {
            return DataPortal.Create<A02_Continent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID parameter of the A02_Continent to fetch.</param>
        /// <returns>A reference to the fetched <see cref="A02_Continent"/> object.</returns>
        public static A02_Continent GetA02_Continent(int continent_ID)
        {
            return DataPortal.Fetch<A02_Continent>(continent_ID);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="A02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the A02_Continent to delete.</param>
        public static void DeleteA02_Continent(int continent_ID)
        {
            DataPortal.Delete<A02_Continent>(continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public A02_Continent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="A02_Continent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(Continent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(A03_Continent_SingleObjectProperty, DataPortal.CreateChild<A03_Continent_Child>());
            LoadProperty(A03_Continent_ASingleObjectProperty, DataPortal.CreateChild<A03_Continent_ReChild>());
            LoadProperty(A03_SubContinentObjectsProperty, DataPortal.CreateChild<A03_SubContinentColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="A02_Continent"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        protected void DataPortal_Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetA02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    FetchChildren(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="A02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, dr.GetInt32("Continent_ID"));
            LoadProperty(Continent_NameProperty, dr.GetString("Continent_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            if (dr.Read())
                LoadProperty(A03_Continent_SingleObjectProperty, A03_Continent_Child.GetA03_Continent_Child(dr));
            dr.NextResult();
            if (dr.Read())
                LoadProperty(A03_Continent_ASingleObjectProperty, A03_Continent_ReChild.GetA03_Continent_ReChild(dr));
            dr.NextResult();
            LoadProperty(A03_SubContinentObjectsProperty, A03_SubContinentColl.GetA03_SubContinentColl(dr));
            dr.NextResult();
            while (dr.Read())
            {
                var child = A05_SubContinent_Child.GetA05_SubContinent_Child(dr);
                var obj = A03_SubContinentObjects.FindA04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A05_SubContinent_ReChild.GetA05_SubContinent_ReChild(dr);
                var obj = A03_SubContinentObjects.FindA04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a05_CountryColl = A05_CountryColl.GetA05_CountryColl(dr);
            a05_CountryColl.LoadItems(A03_SubContinentObjects);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A07_Country_Child.GetA07_Country_Child(dr);
                var obj = a05_CountryColl.FindA06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A07_Country_ReChild.GetA07_Country_ReChild(dr);
                var obj = a05_CountryColl.FindA06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a07_RegionColl = A07_RegionColl.GetA07_RegionColl(dr);
            a07_RegionColl.LoadItems(a05_CountryColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A09_Region_Child.GetA09_Region_Child(dr);
                var obj = a07_RegionColl.FindA08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A09_Region_ReChild.GetA09_Region_ReChild(dr);
                var obj = a07_RegionColl.FindA08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a09_CityColl = A09_CityColl.GetA09_CityColl(dr);
            a09_CityColl.LoadItems(a07_RegionColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A11_City_Child.GetA11_City_Child(dr);
                var obj = a09_CityColl.FindA10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A11_City_ReChild.GetA11_City_ReChild(dr);
                var obj = a09_CityColl.FindA10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a11_CityRoadColl = A11_CityRoadColl.GetA11_CityRoadColl(dr);
            a11_CityRoadColl.LoadItems(a09_CityColl);
        }

        /// <summary>
        /// Inserts a new <see cref="A02_Continent"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", ReadProperty(Continent_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", ReadProperty(Continent_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Continent_IDProperty, (int) cmd.Parameters["@Continent_ID"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="A02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", ReadProperty(Continent_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", ReadProperty(Continent_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="A02_Continent"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(Continent_ID);
        }

        /// <summary>
        /// Deletes the <see cref="A02_Continent"/> object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteA02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(A03_Continent_SingleObjectProperty, DataPortal.CreateChild<A03_Continent_Child>());
            LoadProperty(A03_Continent_ASingleObjectProperty, DataPortal.CreateChild<A03_Continent_ReChild>());
            LoadProperty(A03_SubContinentObjectsProperty, DataPortal.CreateChild<A03_SubContinentColl>());
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
