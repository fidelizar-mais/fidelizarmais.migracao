using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FidelizarMais.Migracao.Models
{
    public class HeadersModel
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("Type")]
        public int Type { get; set; }

        [JsonProperty("DataFormat")]
        public int DataFormat { get; set; }

        [JsonProperty("ContentType")]
        public object ContentType { get; set; }
    }
}
