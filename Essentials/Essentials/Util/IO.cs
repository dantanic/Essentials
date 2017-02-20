using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
