
/*
     ________  ___  _______   ________     
    |\   __  \|\  \|\  ___ \ |\   __  \    
    \ \  \|\  \ \  \ \   __/|\ \  \|\  \   
     \ \   ____\ \  \ \  \_|/_\ \   __  \  
      \ \  \___|\ \  \ \  \_|\ \ \  \ \  \ 
       \ \__\    \ \__\ \_______\ \__\ \__\
        \|__|     \|__|\|_______|\|__|\|__|          
    
    PIEA, The MiNET plugins development organization.                          
*/

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Essentials.Permission
{
    public class CommandPermission
    { 
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions heal { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions tell { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions tpa { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions tpaccept { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions tpdeny { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions sethome { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions home { get; set; }
    }
}
