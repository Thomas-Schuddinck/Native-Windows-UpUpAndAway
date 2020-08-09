using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.DTOs;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Converters
{
    public class GameConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new GameSpecifiedConcreteClassConverter() };
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(GameDTO));
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            switch (jsonObject["gameType"].Value<int>())
            {
                case 0:
                    return JsonConvert.DeserializeObject<HangmanGameDTO>(jsonObject.ToString(), SpecifiedSubclassConversion);
                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
