using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

using PluginCore;
using PluginCore.Managers;

using UnitTestPlugin.Model.Handlers.trace;
using UnitTestPlugin.Model.Handlers.trace.flexunit;

namespace UnitTestPlugin.Model.Handlers {

    class TraceHandler : IEventHandler {

        private PluginUI ui;

        private ITraceMessageHandler implementation;

        private Int32 lastLogIndex;

        public TraceHandler( PluginUI pluginUI ) {
            this.ui = pluginUI;

            implementation = new FlexUnitMessageHandler( pluginUI );

            lastLogIndex = 0;
        }

        public void HandleEvent( object sender , PluginCore.NotifyEvent e , PluginCore.HandlingPriority priority ) {
            switch ( e.Type ) {
                case EventType.Trace:
                    ProcessTraces();
                    ui.EndUpdate();
                break;
            }
        }

        private void ProcessTraces() {
            IList<TraceItem> log = TraceManager.TraceLog;

            for ( Int32 i = lastLogIndex ; i < log.Count ; i++ )
                implementation.ProcessMessage( log[ i ].Message );

            lastLogIndex = log.Count;
        }

    }
}
