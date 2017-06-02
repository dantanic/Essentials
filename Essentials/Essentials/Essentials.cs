
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
using Essentials.Command.Teleport;

using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

using YamlDotNet;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

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
            Context.PluginManager.LoadCommands(new Tpall(this));
            Context.PluginManager.LoadCommands(new ClearInventory(this));
            EIO();
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
            Deserializer des = new Deserializer();
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
        public void tpall(Player player)
        {
            foreach (var i in Context.LevelManager.Levels)
            {
                foreach (var item in i.Players.ToList())
                {
                    if (player.Level != item.Value.Level)
                    {
                        item.Value.Level.RemovePlayer(player);
                        player.Level.AddPlayer(item.Value,true);
                        item.Value.Teleport(new PlayerLocation()
                        {
                            X = player.KnownPosition.X,
                            Y = player.KnownPosition.Y,
                            Z = player.KnownPosition.Z
                        });
                    }
                    else
                    {
                        item.Value.Teleport(new PlayerLocation()
                        {
                            X = player.KnownPosition.X,
                            Y = player.KnownPosition.Y,
                            Z = player.KnownPosition.Z
                        });
                    }
                }
                i.BroadcastMessage("모든 플레이어가 텔레포트 되었습니다.");
            }
        }
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
        public void serbroadcast(string msg)
        {
            foreach (var i in Context.LevelManager.Levels)
            {
                i.BroadcastMessage(msg);
            }
        }
        public string GetDataFolder() => Path.Combine(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath, "Essentials");
        public void EIO()
        {
            CTDT(GetDataFolder());
            //TODO
        }
        public void CTDT(string name)
        {
            DirectoryInfo temp = new DirectoryInfo(name);
            if (!temp.Exists)
            {
                temp.Create();
            }
        }
        public void CTFL(string name)
        {
            FileInfo temp = new FileInfo(name);
            if (!temp.Exists)
            {
                FileStream fs = temp.Create();
                fs.Close();
            }
        }
    }
}
