
/*
     ________  ___  _______   ________     
    |\   __  \|\  \|\  ___ \ |\   __  \    
    \ \  \|\  \ \  \ \   __/|\ \  \|\  \   
     \ \   ____\ \  \ \  \_|/_\ \   __  \  
      \ \  \___|\ \  \ \  \_|\ \ \  \ \  \ 
       \ \__\    \ \__\ \_______\ \__\ \__\
        \|__|     \|__|\|_______|\|__|\|__|          
    
    PIEA, The MiNET plugins development organization.         
*//*

using MiNET;
using MiNET.Plugins.Attributes;

namespace Essentials.Command
{
    public class list
    {
        private Essentials Plugin;

        public list(Essentials plugin)
        {
            Plugin = plugin;
        }
        [Command(Name = "list")]
        public void Execute(Player sender)
        {
            var msg = "";
            foreach (var i in Plugin.plist())
            {
                msg += i.Username+",";
            }
            sender.SendMessage("플레이어 목록 :");
            sender.SendMessage(msg);
        }
    }
}
*/