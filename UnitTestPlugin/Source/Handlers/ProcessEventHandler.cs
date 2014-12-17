using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PluginCore;

namespace UnitTestPlugin.Model.Handlers {

    class ProcessEventHandler : IEventHandler {

        private PluginUI ui;

        public ProcessEventHandler( PluginUI pluginUI ) {
            this.ui = pluginUI;
        }

        public void HandleEvent( object sender , PluginCore.NotifyEvent e , PluginCore.HandlingPriority priority ) {

            switch ( e.Type ) {
                case EventType.ProcessStart:
                    ui.BeginUpdate();
                break;

                case EventType.ProcessEnd:
                    ui.EndUpdate();
                break;
            }
        }
    }
}
