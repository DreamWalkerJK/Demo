namespace Demo.CommonHelper
{
    public class ConvertHelper
    {
        private static readonly object _obj = new object();

        private static ConvertHelper _convertHelper;

        private ConvertHelper() { }

        public static ConvertHelper GetConvertHelper()
        {
            if(_convertHelper == null)
            {
                lock (_obj)
                {
                    if(_convertHelper == null)
                    {
                        _convertHelper = new ConvertHelper();
                    }
                }
            }

            return _convertHelper;
        }

        public static T2 ConvertClass<T1, T2>(T1 t1)
        {
            Type type2 = typeof(T2);
            Type type1 = typeof(T1);
            T2 model = Activator.CreateInstance<T2>();

            var nameDicType1 = new Dictionary<string, string>();

            foreach(var prop in type1.GetProperties())
            {
                nameDicType1.Add(prop.Name.ToLower(), prop.Name);
            }

            // 属性赋值
            foreach(var prop in type2.GetProperties())
            {
                var name = prop.Name.ToLower();
                if (nameDicType1.ContainsKey(name))
                {
                    var propInfo = type1.GetProperty(nameDicType1[name]);

                    if (propInfo != null)
                    {
                        var value = propInfo.GetValue(t1);
                        prop.SetValue(model, value);
                    }
                }
            }

            return model;
        }
    }
}
