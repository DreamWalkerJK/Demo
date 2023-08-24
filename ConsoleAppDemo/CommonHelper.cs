using System.Data;
using System.Reflection;

namespace ConsoleAppDemo
{
    public class CommonHelper
    {
        private static readonly object _obj = new object();
        private static CommonHelper _commonHelper = null;

        private CommonHelper() { }

        public static CommonHelper GetCommonHelper()
        {
            if(_commonHelper == null)
            {
                lock (_obj)
                {
                    if(_commonHelper == null)
                    {
                        _commonHelper = new CommonHelper();
                    }
                }
            }

            return _commonHelper;
        }

        public static DataTable ListToDataTable<T>(List<T> entitys)
        {
            var dt = new DataTable(typeof(T).Name);

            if(entitys == null || entitys.Count == 0)
            {
                return dt;
            }

            // 获取所有实体里的字段名并加到DataTable中
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(PropertyInfo prop in props)
            {
                Type t = GetType(prop.PropertyType);
                dt.Columns.Add(prop.Name, t);
            }

            // 循环数据加到DataTable中
            foreach(var entity in entitys)
            {
                var values = new object[props.Length];
                for(var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(entity, null);
                }

                dt.Rows.Add(values);
            }

            return dt;
        }

        private static Type GetType(Type t)
        {
            if(t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        private static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
