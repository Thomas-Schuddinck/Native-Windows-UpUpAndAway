using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Converters
{
    public class GameSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            var t = objectType;
            if (typeof(HangmanGameDTO).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)

            return base.ResolveContractConverter(objectType);
        }
    }
}
