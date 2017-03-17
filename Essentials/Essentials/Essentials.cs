
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

using Essentials.Command;
using Essentials.Command.Home;

using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET.Worlds;
using MiNET.Utils;

using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Essentials
{
    [Plugin(PluginName = "Essentials", Description = "An essential plugin.", PluginVersion = "1.0", Author = "PIEA Organization")]
    public class Essentials : Plugin
    {

        protected override void OnEnable()
        {
            Context.PluginManager.LoadCommands(new Home(this));
            Context.PluginManager.LoadCommands(new SetHome(this));
            Context.PluginManager.LoadCommands(new AFK(this));
            Context.PluginManager.LoadCommands(new Bomb(this));
            Context.PluginManager.LoadCommands(new Broadcast(this));
            Context.PluginManager.LoadCommands(new Fly(this));
            Context.PluginManager.LoadCommands(new Getpos(this));
            Context.PluginManager.LoadCommands(new Heal(this));
            Context.PluginManager.LoadCommands(new Top(this));
            Context.PluginManager.LoadCommands(new Up(this));
            Context.PluginManager.LoadCommands(new Lightning(this));
        }

        /*
             ___  ___  ________  _____ ______   _______      
            |\  \|\  \|\   __  \|\   _ \  _   \|\  ___ \     
            \ \  \\\  \ \  \|\  \ \  \\\__\ \  \ \   __/|    
             \ \   __  \ \  \\\  \ \  \\|__| \  \ \  \_|/__  
              \ \  \ \  \ \  \\\  \ \  \    \ \  \ \  \_|\ \ 
               \ \__\ \__\ \_______\ \__\    \ \__\ \_______\
                \|__|\|__|\|_______|\|__|     \|__|\|_______|
        */

        private Dictionary<Player, PlayerLocation> Home = new Dictionary<Player, PlayerLocation>();

        public void SetHome(Player player, PlayerLocation pos)
        {
            if (Home.ContainsKey(player)) Home.Remove(player);

            Home.Add(player, pos);
        }
        
        public PlayerLocation GetHome(Player player)
        {
            if (!Home.ContainsKey(player)) return null;

            return Home[player];
        }

        /*
             _________  _______   ___       _______   ________  ________  ________  _________   
            |\___   ___\\  ___ \ |\  \     |\  ___ \ |\   __  \|\   __  \|\   __  \|\___   ___\ 
            \|___ \  \_\ \   __/|\ \  \    \ \   __/|\ \  \|\  \ \  \|\  \ \  \|\  \|___ \  \_| 
                 \ \  \ \ \  \_|/_\ \  \    \ \  \_|/_\ \   ____\ \  \\\  \ \   _  _\   \ \  \  
                  \ \  \ \ \  \_|\ \ \  \____\ \  \_|\ \ \  \___|\ \  \\\  \ \  \\  \|   \ \  \ 
                   \ \__\ \ \_______\ \_______\ \_______\ \__\    \ \_______\ \__\\ _\    \ \__\
                    \|__|  \|_______|\|_______|\|_______|\|__|     \|_______|\|__|\|__|    \|__|                                                                                   
        */

        /*
             ________  ________ ___  __       
            |\   __  \|\  _____\\  \|\  \     
            \ \  \|\  \ \  \__/\ \  \/  /|_   
             \ \   __  \ \   __\\ \   ___  \  
              \ \  \ \  \ \  \_| \ \  \\ \  \ 
               \ \__\ \__\ \__\   \ \__\\ \__\
                \|__|\|__|\|__|    \|__| \|__|
        */

        private List<Player> AFK = new List<Player>();

        public void SetAFK(Player player) => AFK.Add(player);

        public void RemoveAFK(Player player) => AFK.Remove(player);

        public bool GetAFK(Player player) => AFK.Contains(player);

        /*
             ________  ________  ________  ___  ___  ___       ________  ________     
            |\   __  \|\   __  \|\   __  \|\  \|\  \|\  \     |\   __  \|\   __  \    
            \ \  \|\  \ \  \|\  \ \  \|\  \ \  \\\  \ \  \    \ \  \|\  \ \  \|\  \   
             \ \   ____\ \  \\\  \ \   ____\ \  \\\  \ \  \    \ \   __  \ \   _  _\  
              \ \  \___|\ \  \\\  \ \  \___|\ \  \\\  \ \  \____\ \  \ \  \ \  \\  \| 
               \ \__\    \ \_______\ \__\    \ \_______\ \_______\ \__\ \__\ \__\\ _\ 
                \|__|     \|_______|\|__|     \|_______|\|_______|\|__|\|__|\|__|\|__|
        */
                                                                          
        private Dictionary<string, int> Popular = new Dictionary<string, int>();

        public void Increase(string player)
        {
            if (!GetPopular(player))
            {
                Popular.Add(player, 1);
                return;
            }

            ++Popular[player];
        }

        public void Decrease(string player)
        {
            if (!GetPopular(player)) return;

            --Popular[player];
        }

        public bool GetPopular(string player) => Popular.ContainsKey(player);

        /*
             ________  _______   ________ ________  ___  ___  ___   _________   
            |\   ___ \|\  ___ \ |\  _____\\   __  \|\  \|\  \|\  \ |\___   ___\ 
            \ \  \_|\ \ \   __/|\ \  \__/\ \  \|\  \ \  \\\  \ \  \\|___ \  \_| 
             \ \  \ \\ \ \  \_|/_\ \   __\\ \   __  \ \  \\\  \ \  \    \ \  \  
              \ \  \_\\ \ \  \_|\ \ \  \_| \ \  \ \  \ \  \\\  \ \  \____\ \  \ 
               \ \_______\ \_______\ \__\   \ \__\ \__\ \_______\ \_______\ \__\
                \|_______|\|_______|\|__|    \|__|\|__|\|_______|\|_______|\|__|
        */

        public Player GetPlayer(string player)
        {
            foreach (var i in Context.LevelManager.Levels)
            {
                return i.Players.ToList().Find(x => x.Value.Username.ToLower().Contains(player)).Value ?? null;
            }
            return null;
        }
    }
}
