﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Essentials.Resources;
using System.Threading;

namespace Essentials
{
    internal class ResourceManager
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
