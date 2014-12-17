using System;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Collections.Generic;

using PluginCore.Localization;
using PluginCore;

namespace UnitTestPlugin.Model.Localization {

    class LocalizationHelper {

        private static ResourceManager resources = null;

        public static void Initialize( LocaleVersion locale ) {
            String path = "UnitTestPlugin.Source.Localization." + locale.ToString();
            resources = new ResourceManager( path , Assembly.GetExecutingAssembly() );
        }

        public static String GetString( String identifier ) {
            return resources.GetString( identifier );
        }
    }
}
