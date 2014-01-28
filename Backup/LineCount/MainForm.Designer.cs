namespace LineCount
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.shortNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blankLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designerLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectShortNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectRelativeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectBlankLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectDesignerLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectCommentsLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resultsDataSet = new LineCount.ResultsDataSet();
            this.topLevelResultsLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectNewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCodeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showBreakdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNewFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showProjectsToolStripDropDownItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCodeFilesToolStripDropDownItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showBreakdownToolStripDropDownItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topLevelResultsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataSet)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = resources.GetString("openFileDialog.Filter");
            this.openFileDialog.Title = "Select file for line count...";
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.AllowUserToAddRows = false;
            this.resultsDataGridView.AllowUserToDeleteRows = false;
            this.resultsDataGridView.AllowUserToOrderColumns = true;
            this.resultsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDataGridView.AutoGenerateColumns = false;
            this.resultsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.resultsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultsDataGridView.ColumnHeadersHeight = 45;
            this.resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shortNameDataGridViewTextBoxColumn,
            this.relativeNameDataGridViewTextBoxColumn,
            this.linesDataGridViewTextBoxColumn,
            this.blankLinesDataGridViewTextBoxColumn,
            this.designerLinesDataGridViewTextBoxColumn,
            this.commentsLinesDataGridViewTextBoxColumn,
            this.projectShortNameDataGridViewTextBoxColumn,
            this.projectRelativeNameDataGridViewTextBoxColumn,
            this.projectLinesDataGridViewTextBoxColumn,
            this.projectBlankLinesDataGridViewTextBoxColumn,
            this.projectDesignerLinesDataGridViewTextBoxColumn,
            this.projectCommentsLinesDataGridViewTextBoxColumn});
            this.resultsDataGridView.DataSource = this.resultsBindingSource;
            this.resultsDataGridView.Location = new System.Drawing.Point(-2, 81);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.RowHeadersVisible = false;
            this.resultsDataGridView.Size = new System.Drawing.Size(999, 423);
            this.resultsDataGridView.TabIndex = 6;
            // 
            // shortNameDataGridViewTextBoxColumn
            // 
            this.shortNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.shortNameDataGridViewTextBoxColumn.DataPropertyName = "ShortName";
            this.shortNameDataGridViewTextBoxColumn.HeaderText = "File Name";
            this.shortNameDataGridViewTextBoxColumn.Name = "shortNameDataGridViewTextBoxColumn";
            this.shortNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.shortNameDataGridViewTextBoxColumn.Width = 130;
            // 
            // relativeNameDataGridViewTextBoxColumn
            // 
            this.relativeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.relativeNameDataGridViewTextBoxColumn.DataPropertyName = "RelativeName";
            this.relativeNameDataGridViewTextBoxColumn.HeaderText = "Path";
            this.relativeNameDataGridViewTextBoxColumn.Name = "relativeNameDataGridViewTextBoxColumn";
            this.relativeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.relativeNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // linesDataGridViewTextBoxColumn
            // 
            this.linesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.linesDataGridViewTextBoxColumn.DataPropertyName = "Lines";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.linesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.linesDataGridViewTextBoxColumn.HeaderText = "Lines";
            this.linesDataGridViewTextBoxColumn.Name = "linesDataGridViewTextBoxColumn";
            this.linesDataGridViewTextBoxColumn.ReadOnly = true;
            this.linesDataGridViewTextBoxColumn.Width = 65;
            // 
            // blankLinesDataGridViewTextBoxColumn
            // 
            this.blankLinesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.blankLinesDataGridViewTextBoxColumn.DataPropertyName = "BlankLines";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.blankLinesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.blankLinesDataGridViewTextBoxColumn.HeaderText = "Blank Lines";
            this.blankLinesDataGridViewTextBoxColumn.Name = "blankLinesDataGridViewTextBoxColumn";
            this.blankLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.blankLinesDataGridViewTextBoxColumn.Width = 65;
            // 
            // designerLinesDataGridViewTextBoxColumn
            // 
            this.designerLinesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.designerLinesDataGridViewTextBoxColumn.DataPropertyName = "DesignerLines";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.designerLinesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.designerLinesDataGridViewTextBoxColumn.HeaderText = "Designer Lines";
            this.designerLinesDataGridViewTextBoxColumn.Name = "designerLinesDataGridViewTextBoxColumn";
            this.designerLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.designerLinesDataGridViewTextBoxColumn.Width = 65;
            // 
            // commentsLinesDataGridViewTextBoxColumn
            // 
            this.commentsLinesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.commentsLinesDataGridViewTextBoxColumn.DataPropertyName = "CommentsLines";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.commentsLinesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.commentsLinesDataGridViewTextBoxColumn.HeaderText = "Comments";
            this.commentsLinesDataGridViewTextBoxColumn.Name = "commentsLinesDataGridViewTextBoxColumn";
            this.commentsLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentsLinesDataGridViewTextBoxColumn.Width = 65;
            // 
            // projectShortNameDataGridViewTextBoxColumn
            // 
            this.projectShortNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.projectShortNameDataGridViewTextBoxColumn.DataPropertyName = "ProjectShortName";
            this.projectShortNameDataGridViewTextBoxColumn.HeaderText = "Project Name";
            this.projectShortNameDataGridViewTextBoxColumn.Name = "projectShortNameDataGridViewTextBoxColumn";
            this.projectShortNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectShortNameDataGridViewTextBoxColumn.Width = 115;
            // 
            // projectRelativeNameDataGridViewTextBoxColumn
            // 
            this.projectRelativeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.projectRelativeNameDataGridViewTextBoxColumn.DataPropertyName = "ProjectRelativeName";
            this.projectRelativeNameDataGridViewTextBoxColumn.HeaderText = "Project Path";
            this.projectRelativeNameDataGridViewTextBoxColumn.Name = "projectRelativeNameDataGridViewTextBoxColumn";
            this.projectRelativeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectRelativeNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // projectLinesDataGridViewTextBoxColumn
            // 
            this.projectLinesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.projectLinesDataGridViewTextBoxColumn.DataPropertyName = "ProjectLines";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.projectLinesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.projectLinesDataGridViewTextBoxColumn.HeaderText = "Project - Lines";
            this.projectLinesDataGridViewTextBoxColumn.Name = "projectLinesDataGridViewTextBoxColumn";
            this.projectLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectLinesDataGridViewTextBoxColumn.Width = 65;
            // 
            // projectBlankLinesDataGridViewTextBoxColumn
            // 
            this.projectBlankLinesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.projectBlankLinesDataGridViewTextBoxColumn.DataPropertyName = "ProjectBlankLines";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.projectBlankLinesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.projectBlankLinesDataGridViewTextBoxColumn.HeaderText = "Project - Blank Lines";
            this.projectBlankLinesDataGridViewTextBoxColumn.Name = "projectBlankLinesDataGridViewTextBoxColumn";
            this.projectBlankLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectBlankLinesDataGridViewTextBoxColumn.Width = 65;
            // 
            // projectDesignerLinesDataGridViewTextBoxColumn
            // 
            this.projectDesignerLinesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.projectDesignerLinesDataGridViewTextBoxColumn.DataPropertyName = "ProjectDesignerLines";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.projectDesignerLinesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.projectDesignerLinesDataGridViewTextBoxColumn.HeaderText = "Project - Designer Lines";
            this.projectDesignerLinesDataGridViewTextBoxColumn.Name = "projectDesignerLinesDataGridViewTextBoxColumn";
            this.projectDesignerLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectDesignerLinesDataGridViewTextBoxColumn.Width = 65;
            // 
            // projectCommentsLinesDataGridViewTextBoxColumn
            // 
            this.projectCommentsLinesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.projectCommentsLinesDataGridViewTextBoxColumn.DataPropertyName = "ProjectCommentsLines";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.projectCommentsLinesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.projectCommentsLinesDataGridViewTextBoxColumn.HeaderText = "Project - Comments";
            this.projectCommentsLinesDataGridViewTextBoxColumn.Name = "projectCommentsLinesDataGridViewTextBoxColumn";
            this.projectCommentsLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectCommentsLinesDataGridViewTextBoxColumn.Width = 65;
            // 
            // resultsBindingSource
            // 
            this.resultsBindingSource.DataMember = "Results";
            this.resultsBindingSource.DataSource = this.resultsDataSet;
            // 
            // resultsDataSet
            // 
            this.resultsDataSet.DataSetName = "ResultsDataSet";
            this.resultsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // topLevelResultsLabel
            // 
            this.topLevelResultsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.topLevelResultsLabel.Location = new System.Drawing.Point(6, 34);
            this.topLevelResultsLabel.Name = "topLevelResultsLabel";
            this.topLevelResultsLabel.Size = new System.Drawing.Size(977, 44);
            this.topLevelResultsLabel.TabIndex = 7;
            this.topLevelResultsLabel.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectNewFileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showProjectsToolStripMenuItem,
            this.showCodeFilesToolStripMenuItem,
            this.toolStripSeparator2,
            this.showBreakdownToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(168, 104);
            // 
            // selectNewFileToolStripMenuItem
            // 
            this.selectNewFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectNewFileToolStripMenuItem.Image")));
            this.selectNewFileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.selectNewFileToolStripMenuItem.Name = "selectNewFileToolStripMenuItem";
            this.selectNewFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.selectNewFileToolStripMenuItem.Text = "Select New File";
            this.selectNewFileToolStripMenuItem.Click += new System.EventHandler(this.selectNewFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 6);
            // 
            // showProjectsToolStripMenuItem
            // 
            this.showProjectsToolStripMenuItem.Checked = true;
            this.showProjectsToolStripMenuItem.CheckOnClick = true;
            this.showProjectsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showProjectsToolStripMenuItem.Name = "showProjectsToolStripMenuItem";
            this.showProjectsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showProjectsToolStripMenuItem.Text = "Show Projects";
            this.showProjectsToolStripMenuItem.Click += new System.EventHandler(this.showProjectsToolStripMenuItem_Click);
            // 
            // showCodeFilesToolStripMenuItem
            // 
            this.showCodeFilesToolStripMenuItem.Checked = true;
            this.showCodeFilesToolStripMenuItem.CheckOnClick = true;
            this.showCodeFilesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCodeFilesToolStripMenuItem.Name = "showCodeFilesToolStripMenuItem";
            this.showCodeFilesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showCodeFilesToolStripMenuItem.Text = "Show Code Files";
            this.showCodeFilesToolStripMenuItem.Click += new System.EventHandler(this.showCodeFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // showBreakdownToolStripMenuItem
            // 
            this.showBreakdownToolStripMenuItem.Checked = true;
            this.showBreakdownToolStripMenuItem.CheckOnClick = true;
            this.showBreakdownToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBreakdownToolStripMenuItem.Name = "showBreakdownToolStripMenuItem";
            this.showBreakdownToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showBreakdownToolStripMenuItem.Text = "Show Breakdown";
            this.showBreakdownToolStripMenuItem.Click += new System.EventHandler(this.showBreakdownToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(995, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectNewFileToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectNewFileToolStripMenuItem1
            // 
            this.selectNewFileToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("selectNewFileToolStripMenuItem1.Image")));
            this.selectNewFileToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.selectNewFileToolStripMenuItem1.Name = "selectNewFileToolStripMenuItem1";
            this.selectNewFileToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.selectNewFileToolStripMenuItem1.Text = "Select New File";
            this.selectNewFileToolStripMenuItem1.Click += new System.EventHandler(this.selectNewFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showProjectsToolStripDropDownItem,
            this.showCodeFilesToolStripDropDownItem,
            this.toolStripSeparator1,
            this.showBreakdownToolStripDropDownItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showProjectsToolStripDropDownItem
            // 
            this.showProjectsToolStripDropDownItem.Checked = true;
            this.showProjectsToolStripDropDownItem.CheckOnClick = true;
            this.showProjectsToolStripDropDownItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showProjectsToolStripDropDownItem.Name = "showProjectsToolStripDropDownItem";
            this.showProjectsToolStripDropDownItem.Size = new System.Drawing.Size(167, 22);
            this.showProjectsToolStripDropDownItem.Text = "Show Projects";
            this.showProjectsToolStripDropDownItem.Click += new System.EventHandler(this.showProjectsToolStripDropDownItem_Click);
            // 
            // showCodeFilesToolStripDropDownItem
            // 
            this.showCodeFilesToolStripDropDownItem.Checked = true;
            this.showCodeFilesToolStripDropDownItem.CheckOnClick = true;
            this.showCodeFilesToolStripDropDownItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCodeFilesToolStripDropDownItem.Name = "showCodeFilesToolStripDropDownItem";
            this.showCodeFilesToolStripDropDownItem.Size = new System.Drawing.Size(167, 22);
            this.showCodeFilesToolStripDropDownItem.Text = "Show Code Files";
            this.showCodeFilesToolStripDropDownItem.Click += new System.EventHandler(this.showCodeFilesToolStripDropDownItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // showBreakdownToolStripDropDownItem
            // 
            this.showBreakdownToolStripDropDownItem.Checked = true;
            this.showBreakdownToolStripDropDownItem.CheckOnClick = true;
            this.showBreakdownToolStripDropDownItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBreakdownToolStripDropDownItem.Name = "showBreakdownToolStripDropDownItem";
            this.showBreakdownToolStripDropDownItem.Size = new System.Drawing.Size(167, 22);
            this.showBreakdownToolStripDropDownItem.Text = "Show Breakdown";
            this.showBreakdownToolStripDropDownItem.Click += new System.EventHandler(this.showBreakdownToolStripDropDownItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // topLevelResultsTextBox
            // 
            this.topLevelResultsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.topLevelResultsTextBox.Location = new System.Drawing.Point(6, 34);
            this.topLevelResultsTextBox.Multiline = true;
            this.topLevelResultsTextBox.Name = "topLevelResultsTextBox";
            this.topLevelResultsTextBox.ReadOnly = true;
            this.topLevelResultsTextBox.Size = new System.Drawing.Size(977, 44);
            this.topLevelResultsTextBox.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 502);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.topLevelResultsTextBox);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.resultsDataGridView);
            this.Controls.Add(this.topLevelResultsLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Line Count";
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataSet)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.BindingSource resultsBindingSource;
        private ResultsDataSet resultsDataSet;
        private System.Windows.Forms.Label topLevelResultsLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCodeFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selectNewFileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNewFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showProjectsToolStripDropDownItem;
        private System.Windows.Forms.ToolStripMenuItem showCodeFilesToolStripDropDownItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showBreakdownToolStripDropDownItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showBreakdownToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn blankLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn designerLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectShortNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectRelativeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectBlankLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectDesignerLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectCommentsLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox topLevelResultsTextBox;
    }
}

