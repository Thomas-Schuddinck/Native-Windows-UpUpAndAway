using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Converters
{
    public class GuessConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Guess).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            
            bool? isLetterGuess = (bool?)jo["IsLetter"];

            Guess item;
            if (isLetterGuess.GetValueOrDefault())
            {
                item = new CharGuess();
            }
            else
            {
                item = new WordGuess();
            }

            serializer.Populate(jo.CreateReader(), item);

            return item;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}
