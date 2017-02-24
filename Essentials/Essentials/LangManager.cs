
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

using Essentials.Resources;
using System.Globalization;

namespace Essentials
{
    internal class LangManager
    {
        public const string neutral = "en-US";

        public static void SetLanguage(string culture)
        {
            try
            {
                if (culture == null)
                {
                    StringResources.Culture = new CultureInfo(neutral);
                }
                else
                {
                    StringResources.Culture = new CultureInfo(culture);
                }
            }
            catch (CultureNotFoundException)
            {
                StringResources.Culture = new CultureInfo(neutral);
            }
        }
    }
}
