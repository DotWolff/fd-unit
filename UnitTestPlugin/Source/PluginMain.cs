/*
The MIT License (MIT)

Copyright (c) 2014 Gustavo S. Wolff

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using WeifenLuo.WinFormsUI.Docking;

using PluginCore.Localization;
using PluginCore.Utilities;
using PluginCore.Managers;
using PluginCore.Helpers;
using PluginCore;

using UnitTestPlugin.Model.Handlers;
using UnitTestPlugin.Model.Localization;

namespace UnitTestPlugin {

    public class PluginMain : IPlugin {

        #region IPlugin Constants

        public int api = 1;
        public String name = "UnitTests";
        public String guid = "93C76C98-D991-4F19-99EE-6188D7E534E2";
        public String help = "www.flashdevelop.org/community/";
        public String description = "FlashDevelop Plugin for Unit Testing for Haxe and AS3";
        public String author = "Gustavo S. Wolff";

        public String settingsFilename;

        #endregion

        private PluginUI ui;

        private Image image;

        private DockContent panel;

        private IEventHandler processHandler;
        private IEventHandler traceHandler;
        private IEventHandler commandHandler;

        #region IPlugin Getters

        public int Api {
            get { return api; }
        }

        public String Author {
            get { return author; }
        }

        public String Description {
            get { return description; }
        }

        public String Guid {
            get { return guid; }
        }

        public String Help {
            get { return help; }
        }

        public String Name {
            get { return name; }
        }

        public Object Settings {
            get { return settingsFilename; }
        }

        #endregion

        #region IPlugin Implementation

        public void Initialize() {
            this.InitBasics();
            this.InitLocalization();
            this.CreatePluginPanel();
            this.CreateMenuItem();
            this.AddEventHandlers();
        }

        public void Dispose() {}

        public void HandleEvent( object sender , PluginCore.NotifyEvent e , PluginCore.HandlingPriority priority ) {
        }

        #endregion

        #region Custom Methods

        public void InitBasics() {
            String dataPath = Path.Combine( PathHelper.DataDir , "UnitTestPlugin" );

            if ( !Directory.Exists( dataPath ) )
                Directory.CreateDirectory( dataPath );

            this.settingsFilename = Path.Combine( dataPath , "Settings.fdb" );

            this.image = PluginBase.MainForm.FindImage( "101" );
        }

        public void InitLocalization() {
            LocaleVersion language = PluginBase.MainForm.Settings.LocaleVersion;

            switch ( language ) {

                case LocaleVersion.de_DE:
                case LocaleVersion.eu_ES:
                case LocaleVersion.ja_JP:
                case LocaleVersion.zh_CN:

                default:
                LocalizationHelper.Initialize( LocaleVersion.en_US );
                break;
            }

            this.description = LocalizationHelper.GetString( "Description" );
        }

        public void CreatePluginPanel() {
            this.ui = new PluginUI( this );
            this.ui.Text = LocalizationHelper.GetString( "PluginPanel" );

            this.panel = PluginBase.MainForm.CreateDockablePanel( this.ui , this.guid , this.image , DockState.DockRight );

            this.processHandler = new ProcessEventHandler( ui );
            this.traceHandler = new TraceHandler( ui );
            this.commandHandler = new CommandHandler( ui );
        }

        public void CreateMenuItem() {
            String label = LocalizationHelper.GetString( "ViewMenuItem" );

            ToolStripMenuItem viewMenu = ( ToolStripMenuItem ) PluginBase.MainForm.FindMenuItem( "ViewMenu" );
            ToolStripMenuItem newItem = new ToolStripMenuItem( label , this.image , new EventHandler( this.OpenPanel ) );

            viewMenu.DropDownItems.Add( newItem );
        }

        public void AddEventHandlers() {
            EventManager.AddEventHandler( processHandler , EventType.ProcessStart | EventType.ProcessEnd );
            EventManager.AddEventHandler( traceHandler , EventType.Trace );
            EventManager.AddEventHandler( commandHandler , EventType.Command );
        }

        public void OpenPanel( Object sender , System.EventArgs e ) {
            this.panel.Show();
        }

        #endregion
    }
}
