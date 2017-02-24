
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

namespace Essentials.Command.Teleport
{
    public class Tpdeny : Command
    {
        /*[Command]
        public void tpdeny(Player sender)
        {
            if (!VerifyPermission(sender, "tpdenny"))
            {
                return;
            }
            foreach (var item in tpalist)
            {
                string[] pitem = item.Split(',');
                if (pitem[1] == sender.Username)
                {
                    var ServerPlayers = sender.Level.Players;
                    var target = ServerPlayers.ToList().Find(x => x.Value.Username == pitem[0]).Value;
                    sender.SendMessage($"{Prefix}{ChatColors.Gold}{StringResources.Tp_D1}");
                    target.SendMessage($"{Prefix}{ChatColors.Gold}{StringResources.Tp_D2.Replace("{{sender}}", sender.Username)}");
                    tpalist.Remove(item);
                    return;
                }
                else
                {
                    sender.SendMessage($"{Prefix}{ChatColors.Red}{StringResources.Tp_P}");
                    return;
                }
            }
            sender.SendMessage($"{Prefix}{ChatColors.Red}{StringResources.Tp_P}");
        }*/
    }
}
