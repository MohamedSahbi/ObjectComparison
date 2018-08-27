using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectComparison
{
    static class Comparer<T> where T : class
    {

        ///<summary>
        /// This function can be used to Compare two instances of the same Entity 
        /// This function return an object that can be  stored in the HistoryAudit table
        ///</summary>
        ///<param name="originalObject">Instance of the T entity, the first object to be used in the comparison</param>
        ///<param name="changedObject">Instance of the T entity, to be compared with the first param</param>
        ///<returns>ComparisonResult type. </returns>
        public static ComparisonResult GenerateAuditLogComaprisonObject(T originalObject, T changedObject)
        {
            ComparisonResult result = new ComparisonResult
            {
                ClassName = originalObject.GetType().Name
            };

            foreach (PropertyInfo property in originalObject.GetType().GetProperties())
            {

                object originalPropertyValue =
                    property.GetValue(originalObject, null);
                object newPropertyValue =
                    property.GetValue(changedObject, null);

                if (!Equals(originalPropertyValue, newPropertyValue))
                {
                    result.ChangedProperties += "// " + property.Name;
                    result.OldValue += "// " + originalPropertyValue;
                    result.NewValue += "// " + newPropertyValue;
                }
            }

            return result;
        }

        ///<summary>
        /// This function can be used to Compare two instances of the same Entity 
        /// This function returns an IList that can be displayed in the console line
        ///</summary>
        ///<param name="originalObject">Instance of the T entity, the first object to be used in the comparison</param>
        ///<param name="changedObject">Instance of the T entity, to be compared with the first param</param>
        ///<returns>IList type. </returns>
        public static IList GenerateAuditLogMessages(T originalObject, T changedObject)
        {
            IList list = new List<string>();
            string className = string.Concat("[", originalObject.GetType().Name, "] ");

            foreach (PropertyInfo property in originalObject.GetType().GetProperties())
            {

                object originalPropertyValue =
                    property.GetValue(originalObject, null);
                object newPropertyValue =
                    property.GetValue(changedObject, null);

                if (!Equals(originalPropertyValue, newPropertyValue))
                {
                    list.Add(string.Concat(className, property.Name,
                        " changed from '", originalPropertyValue,
                        "' to '", newPropertyValue, "'"));
                }
            }

            return list;
        }

        ///<summary>
        /// This function can be used to Compare two instances of the same Entity with the possibility to exclude some propererties 
        /// if the collection param is not empty.
        ///</summary>
        ///<param name="originalObject">Instance of the T entity, the first object to be used in the comparison</param>
        ///<param name="changedObject">Instance of the T entity, to be compared with the first param</param>
        ///<param name="collection">Array of type string, it includes the properties to be excluded from the comparison</param>
        ///<returns>ComparisonResult type. </returns>
        public static ComparisonResult GenerateAuditLogComaprisonObject(T originalObject, T changedObject, string[] collection = default(string[]))
        {
            IEnumerable<PropertyInfo> props;
            ComparisonResult result = new ComparisonResult
            {
                ClassName = originalObject.GetType().Name
            };

            //Properties to be excluded
            if (collection != null && collection.Count() > 0)
            {
                var toExclude = new HashSet<string>(collection);
                props = originalObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(property => !toExclude.Contains(property.Name));
            }
            else
            {
                props = originalObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }

            foreach (PropertyInfo property in props)
            {

                object originalPropertyValue =
                    property.GetValue(originalObject, null);
                object newPropertyValue =
                    property.GetValue(changedObject, null);

                if (!Equals(originalPropertyValue, newPropertyValue))
                {
                    result.ChangedProperties += property.Name + " ";
                    result.OldValue += originalPropertyValue + " ";
                    result.NewValue += newPropertyValue + " ";
                }
            }

            return result;
        }


    }


}
