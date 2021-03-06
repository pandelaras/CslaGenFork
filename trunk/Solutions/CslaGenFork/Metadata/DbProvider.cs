﻿using System;
using System.ComponentModel;
using CslaGenerator.Attributes;
using CslaGenerator.Controls;

namespace CslaGenerator.Metadata
{
    [Serializable]
    [DefaultProperty("DbProviderName")]
    public class DbProvider : INotifyPropertyChanged
    {
        #region Private Fields

        private string _name = string.Empty;
        private string _dbProviderShortName = string.Empty;
        private string _nuGetPackage = string.Empty;
        private string[] _dbProviderNamespaces = {};
        private string _connectionMethod = string.Empty;
        private string _commandMethod = string.Empty;
        private string _addParameterMethod = string.Empty;
        private bool _hasNativeTimestamp;
        private string _timestampNativeType = string.Empty;
        private string _timestampDbType = string.Empty;
        private string _int64NativeType = "DbType.Int64";

        #endregion

        #region Properties

        internal DbProviderCollection Parent
        {
            get { return GlobalSettings.GlobalParams.DbProviderCollection; }
        }

        #endregion

        #region UI Properties

        [Category("01. Definition")]
        [Description("Common DB provider name.\r\nThis name isn't used by generated code.")]
        [UserFriendlyName("Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                if (Parent.ContainsName(value))
                    return;

                _name = value;
                OnPropertyChanged("");
            }
        }

        [Category("01. Definition")]
        [Description("Generation DB provider will match this name (this is the collection key).")]
        [UserFriendlyName("Short Name")]
        public string DbProviderShortName
        {
            get { return _dbProviderShortName; }
            set
            {
                if (_dbProviderShortName == value)
                    return;
                if (Parent.Contains(value))
                    return;

                _dbProviderShortName = value;
                OnPropertyChanged("");
            }
        }

        [Category("01. Definition")]
        [Description("The NuGet package name.\r\nThis is just a reminder and isn't used by generated code.")]
        [UserFriendlyName("NuGet Package")]
        public string NuGetPackage
        {
            get { return _nuGetPackage; }
            set
            {
                if (_nuGetPackage == value)
                    return;
                _nuGetPackage = value;
                OnPropertyChanged("");
            }
        }

        [Category("02. API")]
        [Description(
            "The Namespaces this DB provider uses (\"using\" in C# or \"Imports\" in VB). Write one namespace per line."
        )]
        [UserFriendlyName("DB Provider Namespaces")]
        public string[] DBProviderNamespaces
        {
            get { return _dbProviderNamespaces; }
            set
            {
                if (_dbProviderNamespaces == value)
                    return;
                _dbProviderNamespaces = value;
                OnPropertyChanged("");
            }
        }

        [Category("02. API")]
        [Description("The 'connection' method name.")]
        [UserFriendlyName("Connection Method")]
        public string ConnectionMethod
        {
            get { return _connectionMethod; }
            set
            {
                if (_connectionMethod == value)
                    return;
                _connectionMethod = value;
                OnPropertyChanged("");
            }
        }

        [Category("02. API")]
        [Description("The 'command' method name.")]
        [UserFriendlyName("Command Method")]
        public string CommandMethod
        {
            get { return _commandMethod; }
            set
            {
                if (_commandMethod == value)
                    return;
                _commandMethod = value;
                OnPropertyChanged("");
            }
        }

        [Category("02. API")]
        [Description("The 'add parameter with value' method name.")]
        [UserFriendlyName("Add Parameter Method")]
        public string AddParameterMethod
        {
            get { return _addParameterMethod; }
            set
            {
                if (_addParameterMethod == value)
                    return;
                _addParameterMethod = value;
                OnPropertyChanged("");
            }
        }

        [Category("03. Data Types")]
        [Description(
            "Whether this DB Provider supports automatic timestamp.\r\nIf set to 'False', the query must update the timestamp."
        )]
        [UserFriendlyName("Has Native Timestamp")]
        public bool HasNativeTimestamp
        {
            get { return _hasNativeTimestamp; }
            set
            {
                if (_hasNativeTimestamp == value)
                    return;
                _hasNativeTimestamp = value;
                OnPropertyChanged("");
            }
        }

        [Category("03. Data Types")]
        [Description("The DB Provider native 'timestamp' type.")]
        [UserFriendlyName("DB Provider Timestamp Type")]
        public string TimestampNativeType
        {
            get { return _timestampNativeType; }
            set
            {
                if (_timestampNativeType == value)
                    return;
                _timestampNativeType = value;
                OnPropertyChanged("");
            }
        }

        [Category("03. Data Types")]
        [Description("The .NET DbType counterpart for the DB native 'timestamp' type.")]
        [UserFriendlyName("Timestamp .NET DbType")]
        public string TimestampDbType
        {
            get { return _timestampDbType; }
            set
            {
                if (_timestampDbType == value)
                    return;
                _timestampDbType = value;
                OnPropertyChanged("");
            }
        }

        [Category("03. Data Types")]
        [Description(
            "The DB Provider native 'int64' type. This is used to emulate RowVersion on columns named 'rowversion' with Int64 data type."
        )]
        [UserFriendlyName("DB Provider Int64 Type")]
        public string Int64NativeType
        {
            get { return _int64NativeType; }
            set
            {
                if (_int64NativeType == value)
                    return;
                _int64NativeType = value;
                OnPropertyChanged("");
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            Parent.Dirty = true;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}