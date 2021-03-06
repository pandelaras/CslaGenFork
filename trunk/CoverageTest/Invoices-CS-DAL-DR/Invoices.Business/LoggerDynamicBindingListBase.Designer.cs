using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerDynamicBindingListBase (base class).<br/>
    /// This is a generated base class of <see cref="LoggerDynamicBindingListBase"/> business object.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerDynamicBindingListBase<T> : DynamicBindingListBase<T>, IListLog
        where T : LoggerBusinessBase<T>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerDynamicBindingListBase"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LoggerDynamicBindingListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

    }
}
