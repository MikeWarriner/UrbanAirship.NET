using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace UrbanAirship.NET.Schema
{
    public class ISO8601Time : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTime)
                || objectType==typeof(DateTime[])
                ) return true;
            else
                return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
            if (value == null) return;
            if (value.GetType() == typeof(DateTime[]))
            {
                DateTime[] list = (DateTime[])value;

                writer.WriteStartArray();
                for (int i = 0; i < list.Length; i++)
                {
                    writer.WriteValue(list[i].ToString("yyyy-MM-dd HH:mm:ss"));
                }
                
                writer.WriteEndArray();

            }
            else
            {
                DateTime v = (DateTime)value;
                writer.WriteValue(v.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
    }
}
