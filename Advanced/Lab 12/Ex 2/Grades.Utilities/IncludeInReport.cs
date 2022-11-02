﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Utilities
{
    /// <summary>
    /// Custom attribute that specifies whether a field or property should be included in a report
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class IncludeInReportAttribute : Attribute
    {
        private bool _include;

        public bool Underline { get; set; }
        public bool Bold { get; set; }

        public string Label { get; set; }

        public IncludeInReportAttribute(bool includeInReport)
        {
            this._include = includeInReport;
            this.Underline = false;
            this.Bold = false;
            this.Label = string.Empty;
        }

        public IncludeInReportAttribute() : this(true) { }
    }

    /// <summary>
    /// Static class that encapsulates processing required by classes with properties and fields tagged with the IncludeInReport attribute
    /// </summary>
    public static class IncludeProcessor
    {
        // Examine the fields and properties in the dataForReport object and determine whether any are tagged with the IncludeInReport attribute
        // For each field or property that is tagged, create a FormatField item that specifies the formatting to apply
        // Return the collection of FormatField items that represents the set of fields and properties to be formatted
        public static List<FormatField> GetItemsToInclude(object dataForReport)
        {
            List<MemberInfo> fieldsAndProperties = new List<MemberInfo>();
            List<FormatField> items = new List<FormatField>();

            Type dataForReportType = dataForReport.GetType();
            fieldsAndProperties.AddRange(dataForReportType.GetFields());
            fieldsAndProperties.AddRange(dataForReportType.GetProperties());

            foreach (MemberInfo member in fieldsAndProperties)
            {
                object[] attributes = member.GetCustomAttributes(false);
                IncludeInReportAttribute attributeFound = Array.Find(attributes, a => a.GetType() == typeof(IncludeInReportAttribute)) as IncludeInReportAttribute;

                if (attributeFound != null)
                {
                    items.Add(new FormatField()
                    {
                        Value = (
                            member is FieldInfo
                                ? (member as FieldInfo)
                                : (member as PropertyInfo)
                        ).GetValue(dataForReport).ToString(),
                        Label = attributeFound.Label,
                        IsBold = attributeFound.Bold,
                        IsUnderlined = attributeFound.Underline
                    });
                }
            }

            // Return the list of FormatField items
            return items;
        }
    }


    public struct FormatField
    {
        public string Value;

        public string Label;

        public bool IsBold;
        public bool IsUnderlined;
    }
}
