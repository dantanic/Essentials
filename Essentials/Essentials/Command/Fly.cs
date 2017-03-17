
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

using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiOP;

namespace Essentials.Command
{
    public class Fly
    {
        private Essentials Plugin;

        public Fly(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "fly", Description = "Allow flying.")]
        public void Execute(Player sender)
        {
            if (!sender.AllowFly)
            {
                sender.AllowFly = true;
                sender.SendMessage($"{ChatColors.Green}You can fly.");
            }
            else
            {
                sender.AllowFly = false;
                sender.SendMessage($"{ChatColors.Green}You can't fly.");
            }
        }
        [Command(Name = "fly", Description = "Allow flying.")]
        public void Execute(Player sender, string name)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender)) return;
            var gp = Plugin.GetPlayer(name);
            if (gp == null) sender.SendMessage("플레이어가 존재하지 않습니다.");
            if (!gp.AllowFly)
            {
                gp.AllowFly = true;
                sender.SendMessage($"{ChatColors.Green}{name} can fly.");
                gp.SendMessage($"{ChatColors.Green}You can't fly.");
            }
            else
            {
                gp.AllowFly = false;
                sender.SendMessage($"{ChatColors.Green}{name} can't fly.");
                gp.SendMessage($"{ChatColors.Green}You can't fly.");
            }
        }
    }
}
