using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestPlugin.Model.Handlers.trace {

    interface ITraceMessageHandler {

        void ProcessMessage( string message );
    }
}
