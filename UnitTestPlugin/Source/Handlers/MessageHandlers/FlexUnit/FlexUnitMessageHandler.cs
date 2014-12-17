using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestPlugin.Model.Handlers.trace.flexunit {

    class FlexUnitMessageHandler : ITraceMessageHandler {
        
        private PluginUI ui;

        private Regex testResultPattern;
        private Regex testErrorPattern;
        private Regex testErrorFilePattern;
        private Regex testTimePattern;

        public FlexUnitMessageHandler( PluginUI pluginUI ) {
            this.ui = pluginUI;

            testResultPattern = new Regex( "([A-Z]{1}[A-Za-z0-9.]{5,}) ([.|F])$" );
            testErrorPattern = new Regex( "^[0-9]+ [a-zA-Z]*::([a-zA-Z0-9.]+) ([a-zA-Z0-9:<> ]+)" );
            testErrorFilePattern = new Regex( "([a-zA-Z0-9]*/([a-zA-Z0-9]*))[()]{2}.(.*.as):([0-9]+)]" );
            testTimePattern = new Regex( "Time: ([0-9/.]*)" );
        }

        public void ProcessMessage( string message ) {

            if ( testResultPattern.IsMatch( message ) )
                ProcessTestResult( message );

            if ( testErrorPattern.IsMatch( message ) )
                ProcessTestError( message );

            if ( testErrorFilePattern.IsMatch( message ) )
                ProcessFileError( message );

            if ( testTimePattern.IsMatch( message ) )
                ProcessTestTime( message );
        }

        private void ProcessFileError( string message ) {
            Match match = testErrorFilePattern.Match( message );

            TestInformation info = new TestInformation();
            info.name = match.Groups[ 1 ].Value;
            info.functionName = match.Groups[ 2 ].Value;
            info.path = match.Groups[ 3 ].Value;
            info.line = int.Parse( match.Groups[ 4 ].Value );

            if ( ui.IsTesting( info.functionName ) )
                ui.SetTestPathAndLine( info );
        }

        private void ProcessTestResult( string message ) {
            Match match = testResultPattern.Match( message );

            TestInformation info = new TestInformation();
            info.name = match.Groups[ 1 ].Value;
            info.result = TestResultFromString( match.Groups[ 2 ].Value );

            if( info.result == TestResult.PASSED )
                ui.AddTest( info );
        }

        private void ProcessTestError( string message ) {
            Match match = testErrorPattern.Match( message );

            string name = match.Groups[ 1 ].Value;
            string error = match.Groups[ 2 ].Value;

            TestResult result = TestResult.FAILED;

            if ( Regex.IsMatch( error , "Error:" ) )
                result = TestResult.ERROR;

            TestInformation info = new TestInformation();
            info.name = name;
            info.tooltip = error;
            info.result = result;

            ui.AddTest( info );
        }

        private void ProcessTestTime( string message ) {
            Match match = testTimePattern.Match( message );

            ui.SetRunTime( match.Groups[ 1 ].Value );
        }

        private TestResult TestResultFromString( String result ) {
            if ( result == "." )
                return TestResult.PASSED;

            return TestResult.FAILED;
        }

    }
}
