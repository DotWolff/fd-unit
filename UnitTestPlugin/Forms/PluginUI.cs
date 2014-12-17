using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PluginCore;
using PluginCore.FRService;
using System.IO;
using ScintillaNet;

namespace UnitTestPlugin {

    public enum TestResult {
        PASSED ,
        FAILED ,
        ERROR
    }

    public struct TestInformation {
        public string name;
        public string functionName;
        public string path;
        public string tooltip;
        public int line;
        public TestResult result;
    }

    public partial class PluginUI : DockPanelControl {

        #region Images Indexes Constants

        private const int IMAGE_PASSED_INDEX = 0;
        private const int IMAGE_ERROR_INDEX = 1;
        private const int IMAGE_FAILED_INDEX = 2;

        #endregion

        private PluginMain main;
        private ImageList imageList;

        private int totalPassed;
        private int totalFailed;
        private int totalError;

        private string runTime;

        public PluginUI( PluginMain main ) {

            this.main = main;

            totalPassed = 0;
            totalFailed = 0;
            totalError = 0;

            runTime = "0";

            InitializeComponent();
        }

        #region Update Information

        public void BeginUpdate() {
            this.TestsTreeView.Nodes.Clear();

            totalPassed = 0;
            totalFailed = 0;
            totalError = 0;

            runTime = "0";

            this.TestsTreeView.BeginUpdate();
        }

        public void EndUpdate() {
            this.TestsTreeView.EndUpdate();

            UpdateProgress();
        }

        public void UpdateProgress() {
            int totalTests = totalError + totalFailed + totalPassed;

            this.RunsLabel.Text = "Runs: " + totalPassed + " / " + totalTests + " (" + runTime + "s)";
            this.ErrorsLabel.Text = "Errors: " + totalError;
            this.FailuresLabel.Text = "Failures: " + totalFailed;

            if ( totalTests == 0 ) {
                this.TestProgress.Value = 0;
            } else {
                this.TestProgress.Maximum = totalTests;
                this.TestProgress.Minimum = 0;

                this.TestProgress.Value = totalPassed;
            }
        }

        #endregion

        #region Test Manipulation

        public void AddTest( TestInformation info ) {
            TreeNode node = GetNode( info.name );
            node.ToolTipText = info.tooltip;
            node.Tag = info;

            SetStyleBasedOnResult( node , info.result );

            AddTestResultToStatistics( info.result );
        }

        public void SetRunTime( string time ) {
            this.runTime = time;
        }

        public bool IsTesting( string name ) {
            return TestsTreeView.Nodes.Find( name , true ).Length > 0;
        }

        public void SetTestPathAndLine( TestInformation testInfo ) {

            testInfo.name = testInfo.name.Replace( '/' , '.' );

            TreeNode testNode = GetNode( testInfo.name );

            TestInformation info = ( TestInformation ) testNode.Tag;
            info.functionName = testInfo.functionName;
            info.path = testInfo.path;
            info.line = testInfo.line;

            testNode.Tag = info;

            TreeNode errorNode = testNode.Nodes.Add( info.tooltip );

            SetStyleBasedOnResult( errorNode , info.result );
        }

        private void AddTestResultToStatistics( TestResult result ) {

            switch ( result ) {
                case TestResult.PASSED:
                totalPassed++;
                break;

                case TestResult.FAILED:
                totalFailed++;
                break;

                case TestResult.ERROR:
                totalError++;
                break;
            }
        }

        #endregion

        #region TreeNode Manipulation

        private TreeNode GetNode( String name ) {

            string[] groups = name.Split( '.' );

            TreeNode lastNode = null;

            foreach ( string group in groups )
                lastNode = GetChildrenNode( lastNode , group );

            return lastNode;
        }

        private TreeNode GetChildrenNode( TreeNode node , string name ) {
            TreeNodeCollection searchCollection;

            if ( node == null )
                searchCollection = TestsTreeView.Nodes;
            else
                searchCollection = node.Nodes;

            if ( searchCollection.ContainsKey( name ) )
                return searchCollection.Find( name , true )[ 0 ];

            return searchCollection.Add( name , name );
        }

        private void SetStyleBasedOnResult( TreeNode node , TestResult result ) {

            switch ( result ) {
                case TestResult.PASSED:
                node.ImageIndex = IMAGE_PASSED_INDEX;
                node.SelectedImageIndex = IMAGE_PASSED_INDEX;
                node.ForeColor = Color.Green;
                break;

                case TestResult.FAILED:
                node.ImageIndex = IMAGE_FAILED_INDEX;
                node.SelectedImageIndex = IMAGE_FAILED_INDEX;
                node.ForeColor = Color.Blue;
                node.EnsureVisible();
                break;

                case TestResult.ERROR:
                node.ImageIndex = IMAGE_ERROR_INDEX;
                node.SelectedImageIndex = IMAGE_ERROR_INDEX;
                node.ForeColor = Color.Red;
                node.EnsureVisible();
                break;
            }

            if ( node.Level > 0 )
                SetStyleBasedOnResult( node.Parent , result );
        }

        #endregion

        #region Event Handling

        private void OnTestMouseClick( object sender , TreeNodeMouseClickEventArgs clickEvent ) {
            TreeNode clickedNode = clickEvent.Node;

            TestInformation info;

            try {
                info = ( TestInformation ) clickedNode.Tag;
            } catch ( InvalidCastException excpt ) {
                info = new TestInformation();
            } catch ( NullReferenceException excpt ) {
                info = new TestInformation();
            }

            SelectTextOnFileLine( info.path , info.line , info.functionName );
        }

        private void OnPluginUILoad( object sender , EventArgs e ) {
            this.TestProgress.Value = 0;

            this.TestsTreeView.Nodes.Clear();

            UpdateProgress();

            imageList = new ImageList();
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.TransparentColor = Color.Transparent;

            imageList.Images.Add( PluginBase.MainForm.FindImage( "32" ) ); // passed
            imageList.Images.Add( PluginBase.MainForm.FindImage( "197" ) ); // error
            imageList.Images.Add( PluginBase.MainForm.FindImage( "196" ) ); // failed

            TestsTreeView.ImageList = imageList;

            ErrorsLabel.Image = imageList.Images[ IMAGE_ERROR_INDEX ];
            FailuresLabel.Image = imageList.Images[ IMAGE_FAILED_INDEX ];
        }

        #endregion

        #region Document Hightlight

        private void SelectTextOnFileLine( string path , int line , String text ) {
            if ( !File.Exists( path ) )
                return;

            PluginBase.MainForm.OpenEditableDocument( path );

            ScintillaControl sci = PluginBase.MainForm.CurrentDocument.SciControl;
            sci.RemoveHighlights();

            List<SearchMatch> matches = GetResults( sci , text );

            sci.AddHighlights( matches , 0xff0000 );
        }

        private List<SearchMatch> GetResults( ScintillaControl sci , String text ) {
            String pattern = text;
            FRSearch search = new FRSearch( pattern );
            search.Filter = SearchFilter.OutsideCodeComments;
            search.NoCase = true;
            search.WholeWord = true;
            return search.Matches( sci.Text );
        }

        #endregion
    }
}
