
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

using System;
using System.IO;
using System.Reflection;

namespace Essentials.Util
{
    public class IO
    {
        private static string assembly = Assembly.GetExecutingAssembly().GetName().CodeBase;

        public static string GetDrectoryPath(string directoryName)
        {
            var path = Path.Combine(new Uri(Path.GetDirectoryName(assembly)).LocalPath, directoryName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetFilePath(string directoryName, string fileName)
        {
            return Path.Combine(GetDrectoryPath(directoryName), fileName);
        }
    }
}
