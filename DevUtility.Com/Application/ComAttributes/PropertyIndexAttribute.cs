using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Application.ComAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class PropertyIndexAttribute : Attribute
    {
        #region Properties

        public int Index { set; get; }

        #endregion

        #region Constructor

        public PropertyIndexAttribute()
        {
            Index = 0;
        }

        public PropertyIndexAttribute(int index) : this()
        {
            Index = index;
        }

        #endregion

        #region Sort by index

        public static List<PropertyInfo> SortByIndex(List<PropertyInfo> properties)
        {
            Dictionary<int, PropertyInfo> dictionary = new Dictionary<int, PropertyInfo>();

            foreach (var property in properties)
            {
                var attribute = PropertyHelper.GetAttribute<PropertyIndexAttribute>(property);

                if (attribute != null && !dictionary.ContainsKey(attribute.Index))
                {
                    dictionary.Add(attribute.Index, property);
                }
            }

            var query = from q in dictionary
                        orderby q.Key
                        select q.Value;

            return query.ToList();
        }

        #endregion
    }
}