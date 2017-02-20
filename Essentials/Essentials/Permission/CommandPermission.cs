using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Essentials.Permission
{
    public class CommandPermission
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions gamemode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions gm { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions tp { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions heal { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions kill { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions kick { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions ban { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions m { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions w { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions t { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions tpa { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions tpaccept { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions tpdeny { get; set; }
    }
}
