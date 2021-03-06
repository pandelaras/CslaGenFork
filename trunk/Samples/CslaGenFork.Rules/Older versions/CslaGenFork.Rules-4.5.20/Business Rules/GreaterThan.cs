﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GreaterThan.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Validates that PrimaryProperty is greater than compareToProperty
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using CslaGenFork.Rules.Properties;

namespace CslaGenFork.Rules.CompareFieldsRules
{
    /// <summary>
    /// Validates that PrimaryProperty is greater than compareToProperty
    /// </summary>
    public class GreaterThan : CommonBusinessRule
    {
        /// <summary>
        /// Gets or sets CompareTo.
        /// </summary>
        private IPropertyInfo CompareTo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GreaterThan"/> class.
        /// </summary>
        /// <param name="primaryProperty">
        /// The primary property.
        /// </param>
        /// <param name="compareToProperty">
        /// The compare to property.
        /// </param>
        public GreaterThan(IPropertyInfo primaryProperty, IPropertyInfo compareToProperty)
            : base(primaryProperty)
        {
            CompareTo = compareToProperty;
            InputProperties = new List<IPropertyInfo> {primaryProperty, compareToProperty};
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>
        /// The error message.
        /// </returns>
        protected override string GetMessage()
        {
            return HasMessageDelegate ? base.GetMessage() : Resources.GreaterThanRule;
        }

        /// <summary>
        /// Does the check for primary property greater than compareTo property
        /// </summary>
        /// <param name="context">
        /// Rule context object.
        /// </param>
        protected override void Execute(RuleContext context)
        {
            var value1 = (IComparable) context.InputPropertyValues[PrimaryProperty];
            var value2 = (IComparable) context.InputPropertyValues[CompareTo];

            if (value1.CompareTo(value2) <= 0)
            {
                context.Results.Add(new RuleResult(RuleName, PrimaryProperty,
                                                   string.Format(GetMessage(), PrimaryProperty.FriendlyName,
                                                                 CompareTo.FriendlyName)) {Severity = Severity});
            }
        }
    }
}
