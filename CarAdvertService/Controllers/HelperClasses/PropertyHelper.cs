using System.Reflection;

namespace CarAdvertService.Controllers.HelperClasses
{
    public class PropertyHelper
    {
        /// <summary>
        /// Get the searched property value of an object.
        /// </summary>
        /// <param name="item">Object item - class, which property value should be provide.</param>
        /// <param name="propName">Name of the searched property</param>
        /// <returns>Value of the searched property (if property exists), otherwise null.</returns>
        public object GetProperty(object item, string propName)
        {
            try
            {
                return item.GetType().GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)?.GetValue(item, null) ?? null;
            }
            catch
            {
                return null;
            }
        }
    }
}