
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
using System.Collections.Generic;
namespace Essentials
{
    public class Essentials
    {
        private List<string> AFKList = new List<string>();

        public Essentials()
        {

        }

        public void SetAFK(Player player)
        {
            AFKList.Add(player.Username);
        }

        public void RemoveAFK(Player player)
        {
            AFKList.Remove(player.Username);
        }

        public bool IsAFK(Player player)
        {
            return AFKList.Contains(player.Username);
        }
    }
}
