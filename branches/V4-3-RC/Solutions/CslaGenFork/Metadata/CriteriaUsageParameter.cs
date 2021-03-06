using System;
using System.ComponentModel;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    [TypeConverterAttribute(typeof(CriteriaUsageParameterConverter))]
    public class CriteriaUsageParameter
    {
        private bool _factory;
        private bool _addRemove;
        private bool _dataPortal;
        private bool _runLocal;
        private bool _procedure;
        private string _procedureName = String.Empty;
        private string _factorySuffix = String.Empty;

        public event EventHandler SuffixChanged;

        public void Enable()
        {
            _factory = true;
            _procedure = true;
            _dataPortal = true;
        }

        public void Disable()
        {
            _factory = false;
            _procedure = false;
            _dataPortal = false;
        }

        [Description("Defines whether you want to generate the factory methods or not.")]
        public bool Factory
        {
            get { return _factory; }
            set
            {
                if (_factory == value)
                    return;
                _factory = value;
            }
        }

        [Description("Defines whether you want to generate the collection Add/Remove method for this criteria.\r\n" +
            "This property is set on the collection item although the method is generated in the collection class.\r\n" +
            "Use the \"Create Options\" to set the value for Add method and the the \"Delete Options\" to set the value for Remove method.\r\n" +
            "For Editable Child objects that are collection items, you must specify the Remove setting on \"Use Remove Method\"")]
        [UserFriendlyName("Add/Remove")]
        public bool AddRemove
        {
            get { return _addRemove; }
            set
            {
                if (_addRemove == value)
                    return;
                _addRemove = value;
            }
        }

        [Description("Defines whether you want to generate the DataPortal methods or not. If set to false, the criteria classes won't be generated.")]
        public bool DataPortal
        {
            get { return _dataPortal; }
            set { _dataPortal = value; }
        }

        [Description("Defines whether you want to add a RunLocal attribute to the DataPortal method or not.")]
        public bool RunLocal
        {
            get { return _runLocal; }
            set { _runLocal = value; }
        }

        [Description("Defines whether you want to generate the stored procedure or not.\r\n" +
            "You might need to specify the stored procedure name, as the DataPortal method will use.")]
        public bool Procedure
        {
            get { return _procedure; }
            set
            {
                if (_procedure == value)
                    return;
                _procedure = value;
                if (value)
                    OnSuffixChanged();
            }
        }

        [Description("Defines the name of the stored procedure. This will be used for generating the DataPortal method and the stored procedure itself.")]
        [UserFriendlyName("Procedure Name")]
        public string ProcedureName
        {
            get { return _procedureName; }
            set
            {
                if (_procedureName == PropertyHelper.Tidy(value))
                    return;
                _procedureName = PropertyHelper.Tidy(value);
            }
        }

        [Description("When generating factory methods, they will be named [Get/Delete/Create] + ObjectName + Suffix.\r\n" +
            "For instance for an object named Project and empty suffix: GetProject(). Sample with 'ByName': GetProjectByName().\r\n"+
            "This suffix will also be added to the SProc name.")]
        [UserFriendlyName("Factory Suffix")]
        public string FactorySuffix
        {
            get { return _factorySuffix; }
            set
            {
                if (!_factorySuffix.Equals(PropertyHelper.Tidy(value)))
                {
                    _factorySuffix = PropertyHelper.Tidy(value);
                    OnSuffixChanged();
                }
            }
        }

        void OnSuffixChanged()
        {
            if (SuffixChanged != null)
                SuffixChanged(this, EventArgs.Empty);
        }

        internal static CriteriaUsageParameter Clone(CriteriaUsageParameter masterUsageParam)
        {
            var newUsageParam = new CriteriaUsageParameter();

            newUsageParam.Factory = masterUsageParam.Factory;
            newUsageParam.AddRemove = masterUsageParam.AddRemove;
            newUsageParam.DataPortal = masterUsageParam.DataPortal;
            newUsageParam.RunLocal = masterUsageParam.RunLocal;
            newUsageParam.Procedure = masterUsageParam.Procedure;
            newUsageParam.ProcedureName = masterUsageParam.ProcedureName;
            newUsageParam.FactorySuffix = masterUsageParam.FactorySuffix;

            return newUsageParam;
        }
    }
}
