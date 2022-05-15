using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp1.DataConverter
{
    public class JsonConverter<T>
    {
        public static T JsonToObject(string JsonContent)
        {
            T Obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(JsonContent);
            return Obj;
        }
        public static string ObjectToJson(string JsonContent)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(JsonContent);
        }
    }
}
