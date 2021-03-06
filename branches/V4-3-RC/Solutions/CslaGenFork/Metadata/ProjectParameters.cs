using System;
using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public class ProjectParameters : INotifyPropertyChanged
    {
        #region State Fields Stored Procedures

        string _spGeneralPrefix = string.Empty;
        string _spGetPrefix = "Get";
        string _spDeletePrefix = "Delete";
        string _spUpdatePrefix = "Update";
        string _spAddPrefix = "Add";
        string _spGeneralSuffix = string.Empty;
        string _spGetSuffix = string.Empty;
        string _spDeleteSuffix = string.Empty;
        string _spUpdateSuffix = string.Empty;
        string _spAddSuffix = string.Empty;
        bool _regenSpNameOnObjectRename = true;
        string _spBoolSoftDeleteColumn = string.Empty;
        string _spIntSoftDeleteColumn = string.Empty;
        bool _spIgnoreFilterWhenSoftDeleteIsParam = true;
        bool _spRemoveChildBeforeParent = true;

        private string _orbChildPropertySuffix = string.Empty;
        private string _orbCollectionSuffix = string.Empty;
        private string _orbSingleSPSuffix = string.Empty;
        private bool _orbItemsUseSingleSP;

        #endregion

        #region State Fields New Object Defaults

        private string _defaultNamespace = String.Empty;
        private string _defaultFolder = String.Empty;
        bool _smartDateDefault = true;
        private bool _autoCriteria = true;
        private bool _autoTimestampCriteria = true;
        private bool _datesDefaultStringWithTypeConversion = true;
        private PropertyDeclaration _createTimestampPropertyMode = PropertyDeclaration.NoProperty;
        private bool _readOnlyObjectsCopyAuditing;
        private bool _readOnlyObjectsCopyTimestamp;
        private PropertyDeclaration _createReadOnlyObjectsPropertyMode = PropertyDeclaration.AutoProperty;
        TransactionType _defaultTransactionType = TransactionType.None;
        PersistenceType _defaultPersistenceType = PersistenceType.SqlConnectionManager;
        private string _defaultDatabaseContextObject = string.Empty;
        private string _defaultDataBase = String.Empty;

        #endregion

        #region State Fields Advanced

        private string _idGuidDefaultValue = "Guid.NewGuid()";
        private string _idInt16DefaultValue = "-1";
        private string _idInt32DefaultValue = "-1";
        private string _idInt64DefaultValue = "-1";
        private string _fieldNamePrefix = "m_";
        private string _delegateNamePrefix = "d_";
        private string _creationDateColumn = string.Empty;
        private string _creationUserColumn = string.Empty;
        private string _changedDateColumn = string.Empty;
        private string _changedUserColumn = string.Empty;
        private bool _logDateAndTime = true;
        private string _getUserMethod = string.Empty;

        #endregion

        #region Properties New Object Defaults

        public string DefaultNamespace
        {
            get { return _defaultNamespace; }
            set
            {
                value = PropertyHelper.TidyFilename(value);
                if (_defaultNamespace == value)
                    return;
                _defaultNamespace = value;
                OnPropertyChanged("");
            }
        }

        public string DefaultFolder
        {
            get { return _defaultFolder; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_defaultFolder == value)
                    return;
                _defaultFolder = value;
                OnPropertyChanged("");
            }
        }

        public bool SmartDateDefault
        {
            get { return _smartDateDefault; }
            set
            {
                if (_smartDateDefault == value)
                    return;
                _smartDateDefault = value;
                OnPropertyChanged("");
            }
        }

        public bool AutoCriteria
        {
            get { return _autoCriteria; }
            set
            {
                if (_autoCriteria == value)
                    return;
                _autoCriteria = value;
                OnPropertyChanged("");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to add a Delete CriteriaTS whem DB type "timestamp" is found.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [auto timestamp criteria]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoTimestampCriteria
        {
            get { return _autoTimestampCriteria; }
            set
            {
                if (_autoTimestampCriteria == value)
                    return;
                _autoTimestampCriteria = value;
                OnPropertyChanged("");
            }
        }

        public bool DatesDefaultStringWithTypeConversion
        {
            get { return _datesDefaultStringWithTypeConversion; }
            set
            {
                if (_datesDefaultStringWithTypeConversion == value)
                    return;
                _datesDefaultStringWithTypeConversion = value;
                OnPropertyChanged("");
            }
        }

        /// <summary>
        /// Gets or sets the PropertyMode for timestamp Value Property creation.
        /// </summary>
        /// <value>
        /// The create timestamp property mode.
        /// </value>
        public PropertyDeclaration CreateTimestampPropertyMode
        {
            get { return _createTimestampPropertyMode; }
            set
            {
                if (_createTimestampPropertyMode == value)
                    return;
                _createTimestampPropertyMode = value;
                OnPropertyChanged("");
            }
        }

        public bool ReadOnlyObjectsCopyAuditing
        {
            get { return _readOnlyObjectsCopyAuditing; }
            set
            {
                if (_readOnlyObjectsCopyAuditing == value)
                    return;
                _readOnlyObjectsCopyAuditing = value;
                OnPropertyChanged("");
            }
        }

        public bool ReadOnlyObjectsCopyTimestamp
        {
            get { return _readOnlyObjectsCopyTimestamp; }
            set
            {
                if (_readOnlyObjectsCopyTimestamp == value)
                    return;
                _readOnlyObjectsCopyTimestamp = value;
                OnPropertyChanged("");
            }
        }

        public PropertyDeclaration CreateReadOnlyObjectsPropertyMode
        {
            get { return _createReadOnlyObjectsPropertyMode; }
            set
            {
                if (_createReadOnlyObjectsPropertyMode == value)
                    return;
                _createReadOnlyObjectsPropertyMode = value;
                OnPropertyChanged("");
            }
        }

        public string DefaultDataBase
        {
            get { return _defaultDataBase; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_defaultDataBase == value)
                    return;
                _defaultDataBase = value;
                GeneratorController.Current.CurrentUnit.GenerationParams.DatabaseConnection = value;
                OnPropertyChanged("");
            }
        }

        public TransactionType DefaultTransactionType
        {
            get
            {
                if (GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                    if (_defaultTransactionType == TransactionType.ADO)
                        DefaultTransactionType = TransactionType.TransactionScope;

                return _defaultTransactionType;
            }
            set
            {
                if (value == TransactionType.TransactionalAttribute)
                {
                    _defaultTransactionType = TransactionType.TransactionScope;
                }
                else if (value == TransactionType.ADO &&
                    GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                {
                        _defaultTransactionType = TransactionType.TransactionScope;
                }
                else
                {
                    if (_defaultTransactionType == value)
                        return;
                    _defaultTransactionType = value;
                }
                OnPropertyChanged("");
            }
        }

        public PersistenceType DefaultPersistenceType
        {
            get
            {
                if (GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                    if (_defaultPersistenceType == PersistenceType.SqlConnectionUnshared)
                        DefaultPersistenceType = PersistenceType.SqlConnectionManager;

                return _defaultPersistenceType;
            }
            set
            {
                if (value == PersistenceType.SqlConnectionUnshared &&
                    GeneratorController.Current.CurrentUnit.GenerationParams.UseDal)
                {
                        _defaultPersistenceType = PersistenceType.SqlConnectionManager;
                }
                else
                {
                    if (_defaultPersistenceType == value)
                        return;
                    _defaultPersistenceType = value;
                }
                OnPropertyChanged("");

                if (_defaultPersistenceType == value)
                    return;
                _defaultPersistenceType = value;
                OnPropertyChanged("");
            }
        }

        public string DefaultDatabaseContextObject
        {
            get { return _defaultDatabaseContextObject; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_defaultDatabaseContextObject == value)
                    return;
                _defaultDatabaseContextObject = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Object Relations Builder

        public string ORBChildPropertySuffix
        {
            get { return _orbChildPropertySuffix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_orbChildPropertySuffix == value)
                    return;
                _orbChildPropertySuffix = value;
                OnPropertyChanged("");
            }
        }

        public string ORBCollectionSuffix
        {
            get { return _orbCollectionSuffix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_orbCollectionSuffix == value)
                    return;
                _orbCollectionSuffix = value;
                OnPropertyChanged("");
            }
        }

        public string ORBSingleSPSuffix
        {
            get { return _orbSingleSPSuffix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_orbSingleSPSuffix == value)
                    return;
                _orbSingleSPSuffix = value;
                OnPropertyChanged("");
            }
        }

        public bool ORBItemsUseSingleSP
        {
            get { return _orbItemsUseSingleSP; }
            set
            {
                if (_orbItemsUseSingleSP == value)
                    return;
                _orbItemsUseSingleSP = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region Properties Stored Procedures

        public string SpAddPrefix
        {
            get { return _spAddPrefix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spAddPrefix == value)
                    return;
                _spAddPrefix = value;
                OnPropertyChanged("");
            }
        }

        public string SpDeletePrefix
        {
            get { return _spDeletePrefix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spDeletePrefix == value)
                    return;
                _spDeletePrefix = value;
                OnPropertyChanged("");
            }
        }

        public string SpUpdatePrefix
        {
            get { return _spUpdatePrefix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spUpdatePrefix == value)
                    return;
                _spUpdatePrefix = value;
                OnPropertyChanged("");
            }
        }

        public string SpGetPrefix
        {
            get { return _spGetPrefix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spGetPrefix == value)
                    return;
                _spGetPrefix = value;
                OnPropertyChanged("");
            }
        }

        public string SpGeneralPrefix
        {
            get { return _spGeneralPrefix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spGeneralPrefix == value)
                    return;
                _spGeneralPrefix = value;
                OnPropertyChanged("");
            }
        }

        public string SpAddSuffix
        {
            get { return _spAddSuffix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spAddSuffix == value)
                    return;
                _spAddSuffix = value;
                OnPropertyChanged("");
            }
        }

        public string SpDeleteSuffix
        {
            get { return _spDeleteSuffix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spDeleteSuffix == value)
                    return;
                _spDeleteSuffix = value;
                OnPropertyChanged("");
            }
        }

        public string SpUpdateSuffix
        {
            get { return _spUpdateSuffix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spUpdateSuffix == value)
                    return;
                _spUpdateSuffix = value;
                OnPropertyChanged("");
            }
        }

        public string SpGetSuffix
        {
            get { return _spGetSuffix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spGetSuffix == value)
                    return;
                _spGetSuffix = value;
                OnPropertyChanged("");
            }
        }

        public string SpGeneralSuffix
        {
            get { return _spGeneralSuffix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spGeneralSuffix == value)
                    return;
                _spGeneralSuffix = value;
                OnPropertyChanged("");
            }
        }

        public bool RegenSpNameOnObjectRename
        {
            get { return _regenSpNameOnObjectRename; }
            set
            {
                if (_regenSpNameOnObjectRename == value)
                    return;
                _regenSpNameOnObjectRename = value;
                OnPropertyChanged("");
            }
        }

        public string SpBoolSoftDeleteColumn
        {
            get { return _spBoolSoftDeleteColumn; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spBoolSoftDeleteColumn == value)
                    return;
                _spBoolSoftDeleteColumn = value;
                OnPropertyChanged("");
            }
        }

        public string SpIntSoftDeleteColumn
        {
            get { return _spIntSoftDeleteColumn; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_spIntSoftDeleteColumn == value)
                    return;
                _spIntSoftDeleteColumn = value;
                OnPropertyChanged("");
            }
        }

        public bool SpIgnoreFilterWhenSoftDeleteIsParam
        {
            get { return _spIgnoreFilterWhenSoftDeleteIsParam; }
            set
            {
                if (_spIgnoreFilterWhenSoftDeleteIsParam == value)
                    return;
                _spIgnoreFilterWhenSoftDeleteIsParam = value;
                OnPropertyChanged("");
            }
        }

        public bool SpRemoveChildBeforeParent
        {
            get { return _spRemoveChildBeforeParent; }
            set
            {
                if (_spRemoveChildBeforeParent == value)
                    return;
                _spRemoveChildBeforeParent = value;
                OnPropertyChanged("");
            }
        }

        public string GetDeleteProcName(string name)
        {
            return string.Concat(_spGeneralPrefix, _spDeletePrefix,
                name, _spDeleteSuffix, _spGeneralSuffix);
        }

        public string GetAddProcName(string name)
        {
            return string.Concat(_spGeneralPrefix, _spAddPrefix,
                name, _spAddSuffix, _spGeneralSuffix);
        }

        public string GetGetProcName(string name)
        {
            return string.Concat(_spGeneralPrefix, _spGetPrefix,
                name, _spGetSuffix, _spGeneralSuffix);
        }

        public string GetUpdateProcName(string name)
        {
            return string.Concat(_spGeneralPrefix, _spUpdatePrefix,
                name, _spUpdateSuffix, _spGeneralSuffix);
        }

        #endregion

        #region Properties Advanced

        public string IDGuidDefaultValue
        {
            get { return _idGuidDefaultValue; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_idGuidDefaultValue == value)
                    return;
                _idGuidDefaultValue = value;
                OnPropertyChanged("");
            }
        }

        public string IDInt16DefaultValue
        {
            get { return _idInt16DefaultValue; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_idInt16DefaultValue == value)
                    return;
                _idInt16DefaultValue = value;
                OnPropertyChanged("");
            }
        }

        public string IDInt32DefaultValue
        {
            get { return _idInt32DefaultValue; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_idInt32DefaultValue == value)
                    return;
                _idInt32DefaultValue = value;
                OnPropertyChanged("");
            }
        }

        public string IDInt64DefaultValue
        {
            get { return _idInt64DefaultValue; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_idInt64DefaultValue == value)
                    return;
                _idInt64DefaultValue = value;
                OnPropertyChanged("");
            }
        }

        public string FieldNamePrefix
        {
            get { return _fieldNamePrefix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_fieldNamePrefix == value)
                    return;
                _fieldNamePrefix = value;
                OnPropertyChanged("");
            }
        }

        public string DelegateNamePrefix
        {
            get { return _delegateNamePrefix; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_delegateNamePrefix == value)
                    return;
                _delegateNamePrefix = value;
                OnPropertyChanged("");
            }
        }

        public string CreationDateColumn
        {
            get { return _creationDateColumn; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_creationDateColumn == value)
                    return;
                _creationDateColumn = value;
                OnPropertyChanged("");
            }
        }

        public string CreationUserColumn
        {
            get { return _creationUserColumn; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_creationUserColumn == value)
                    return;
                _creationUserColumn = value;
                OnPropertyChanged("");
            }
        }

        public string ChangedDateColumn
        {
            get { return _changedDateColumn; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_changedDateColumn == value)
                    return;
                _changedDateColumn = value;
                OnPropertyChanged("");
            }
        }

        public string ChangedUserColumn
        {
            get { return _changedUserColumn; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_changedUserColumn == value)
                    return;
                _changedUserColumn = value;
                OnPropertyChanged("");
            }
        }

        public bool LogDateAndTime
        {
            get { return _logDateAndTime; }
            set
            {
                if (_logDateAndTime == value)
                    return;
                _logDateAndTime = value;
                OnPropertyChanged("");
            }
        }

        public string GetUserMethod
        {
            get { return _getUserMethod; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_getUserMethod == value)
                    return;
                _getUserMethod = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        [Browsable(false)]
        internal bool Dirty { get; set; }

        internal ProjectParameters Clone()
        {
            ProjectParameters obj = null;
            try
            {
                obj = (ProjectParameters)Util.ObjectCloner.CloneShallow(this);
                obj.Dirty = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            Dirty = true;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
