namespace UnitTestPlugin {

    partial class PluginUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.LabelsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FailuresLabel = new System.Windows.Forms.Button();
            this.RunsLabel = new System.Windows.Forms.Label();
            this.ErrorsLabel = new System.Windows.Forms.Button();
            this.TestsTreeView = new System.Windows.Forms.TreeView();
            this.TestProgress = new UnitTestPlugin.View.CustomProgressBar();
            this.MainTable.SuspendLayout();
            this.LabelsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTable
            // 
            this.MainTable.ColumnCount = 1;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTable.Controls.Add(this.LabelsPanel, 0, 0);
            this.MainTable.Controls.Add(this.TestsTreeView, 0, 2);
            this.MainTable.Controls.Add(this.TestProgress, 0, 1);
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(10, 10);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 3;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTable.Size = new System.Drawing.Size(288, 271);
            this.MainTable.TabIndex = 0;
            // 
            // LabelsPanel
            // 
            this.LabelsPanel.ColumnCount = 3;
            this.LabelsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LabelsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LabelsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LabelsPanel.Controls.Add(this.FailuresLabel, 2, 0);
            this.LabelsPanel.Controls.Add(this.RunsLabel, 0, 0);
            this.LabelsPanel.Controls.Add(this.ErrorsLabel, 1, 0);
            this.LabelsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelsPanel.Location = new System.Drawing.Point(3, 3);
            this.LabelsPanel.Name = "LabelsPanel";
            this.LabelsPanel.RowCount = 1;
            this.LabelsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LabelsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.LabelsPanel.Size = new System.Drawing.Size(282, 29);
            this.LabelsPanel.TabIndex = 0;
            // 
            // FailuresLabel
            // 
            this.FailuresLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FailuresLabel.FlatAppearance.BorderSize = 0;
            this.FailuresLabel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.FailuresLabel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.FailuresLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FailuresLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FailuresLabel.Location = new System.Drawing.Point(191, 3);
            this.FailuresLabel.Name = "FailuresLabel";
            this.FailuresLabel.Size = new System.Drawing.Size(88, 23);
            this.FailuresLabel.TabIndex = 2;
            this.FailuresLabel.TabStop = false;
            this.FailuresLabel.Text = "Failures : 0";
            this.FailuresLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FailuresLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FailuresLabel.UseVisualStyleBackColor = true;
            // 
            // RunsLabel
            // 
            this.RunsLabel.AutoSize = true;
            this.RunsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RunsLabel.Location = new System.Drawing.Point(3, 0);
            this.RunsLabel.Name = "RunsLabel";
            this.RunsLabel.Size = new System.Drawing.Size(88, 29);
            this.RunsLabel.TabIndex = 0;
            this.RunsLabel.Text = "Runs: 12/12";
            this.RunsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ErrorsLabel
            // 
            this.ErrorsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorsLabel.FlatAppearance.BorderSize = 0;
            this.ErrorsLabel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.ErrorsLabel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.ErrorsLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ErrorsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ErrorsLabel.Location = new System.Drawing.Point(97, 3);
            this.ErrorsLabel.Name = "ErrorsLabel";
            this.ErrorsLabel.Size = new System.Drawing.Size(88, 23);
            this.ErrorsLabel.TabIndex = 1;
            this.ErrorsLabel.TabStop = false;
            this.ErrorsLabel.Text = "Errors : 0";
            this.ErrorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ErrorsLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ErrorsLabel.UseVisualStyleBackColor = true;
            // 
            // TestsTreeView
            // 
            this.TestsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestsTreeView.Location = new System.Drawing.Point(3, 63);
            this.TestsTreeView.Name = "TestsTreeView";
            this.TestsTreeView.PathSeparator = ".";
            this.TestsTreeView.ShowNodeToolTips = true;
            this.TestsTreeView.Size = new System.Drawing.Size(282, 205);
            this.TestsTreeView.TabIndex = 3;
            this.TestsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnTestMouseClick);
            // 
            // TestProgress
            // 
            this.TestProgress.BackColor = System.Drawing.SystemColors.Control;
            this.TestProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestProgress.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.TestProgress.Location = new System.Drawing.Point(3, 38);
            this.TestProgress.MarqueeAnimationSpeed = 0;
            this.TestProgress.Name = "TestProgress";
            this.TestProgress.Size = new System.Drawing.Size(282, 19);
            this.TestProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.TestProgress.TabIndex = 2;
            this.TestProgress.Value = 50;
            // 
            // PluginUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTable);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PluginUI";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(308, 291);
            this.Load += new System.EventHandler(this.OnPluginUILoad);
            this.MainTable.ResumeLayout(false);
            this.LabelsPanel.ResumeLayout(false);
            this.LabelsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTable;
        private System.Windows.Forms.TableLayoutPanel LabelsPanel;
        private System.Windows.Forms.Label RunsLabel;
        private System.Windows.Forms.TreeView TestsTreeView;
        private UnitTestPlugin.View.CustomProgressBar TestProgress;
        private System.Windows.Forms.Button ErrorsLabel;
        private System.Windows.Forms.Button FailuresLabel;





    }
}