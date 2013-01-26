using System;
using System.Collections.Generic;
using Csla;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G05_CountryColl (editable child list).<br/>
    /// This is a generated base class of <see cref="G05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="G04_SubContinent"/> editable child object.<br/>
    /// The items of the collection are <see cref="G06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class G05_CountryColl : BusinessListBase<G05_CountryColl, G06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="G06_Country"/> item from the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to be removed.</param>
        public void Remove(int country_ID)
        {
            foreach (var g06_Country in this)
            {
                if (g06_Country.Country_ID == country_ID)
                {
                    Remove(g06_Country);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="G06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var g06_Country in this)
            {
                if (g06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="G06_Country"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the G06_Country is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int country_ID)
        {
            foreach (var g06_Country in this.DeletedList)
            {
                if (g06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="G05_CountryColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="G05_CountryColl"/> collection.</returns>
        internal static G05_CountryColl NewG05_CountryColl()
        {
            return DataPortal.CreateChild<G05_CountryColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="G05_CountryColl"/> collection, based on given parameters.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent_SubContinent_ID parameter of the G05_CountryColl to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G05_CountryColl"/> collection.</returns>
        internal static G05_CountryColl GetG05_CountryColl(int parent_SubContinent_ID)
        {
            return DataPortal.FetchChild<G05_CountryColl>(parent_SubContinent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G05_CountryColl()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G05_CountryColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        protected void Child_Fetch(int parent_SubContinent_ID)
        {
            var args = new DataPortalHookArgs(parent_SubContinent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG05_CountryCollDal>();
                var data = dal.Fetch(parent_SubContinent_ID);
                Fetch(data);
            }
            OnFetchPost(args);
            foreach (var item in this)
            {
                item.FetchChildren();
            }
        }

        /// <summary>
        /// Loads all <see cref="G05_CountryColl"/> collection items from the given list of G06_CountryDto.
        /// </summary>
        /// <param name="data">The list of <see cref="G06_CountryDto"/>.</param>
        private void Fetch(List<G06_CountryDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(G06_Country.GetG06_Country(dto));
            }
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Pseudo Events

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
