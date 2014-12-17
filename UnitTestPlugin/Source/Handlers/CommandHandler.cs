using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PluginCore;

namespace UnitTestPlugin.Model.Handlers {

    class CommandHandler : IEventHandler {

        private PluginUI ui;

        public CommandHandler( PluginUI pluginUI ) {
            this.ui = pluginUI;
        }

        public void HandleEvent( object sender , PluginCore.NotifyEvent e , PluginCore.HandlingPriority priority ) {

        }
    }
}
