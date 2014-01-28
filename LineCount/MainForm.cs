using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LineCount.CodeContainers;
using System.IO;

namespace LineCount
{
    /// <summary>
    /// The main display form of the application
    /// </summary>
    public partial class MainForm : Form
    {
        string path = "";
        CodeContainer rootCodeContainer = null;

        #region Initialization - constructor
        public MainForm()
        {
            InitializeComponent();
            try
            {
                SetGridColor();
                GetPath();
                SelectNewFile();
            }
            catch (Exception e)
            {
                Program.HandleError(e);
            }
        }

        private void SetGridColor()
        {
            resultsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            resultsDataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(221, 247, 221);
            resultsDataGridView.Refresh();
        }

        /// <summary>
        /// Get the path last used by this program from the user settings
        /// </summary>
        /// <remarks>
        /// In general I'm not a big fan of the user settings in .NET 2.0.  I can
        /// never work out where they're getting stored.
        /// </remarks>
        private void GetPath()
        {
            try
            {
                path = Properties.Settings.Default.Path;
            }
            catch { }  // Don't blow up if config file not available
        }
        #endregion

        #region Select New File
        private void SelectNewFile()
        {
            openFileDialog.FileName = path;
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.Cancel)
            {
                SetPath(openFileDialog.FileName);
                if (ValidatePath())
                    CalculateAndShowResults();
            }
        }

        private void SetPath(string path)
        {
            this.path = path;
            SavePathToSettings();
        }

        private void SavePathToSettings()
        {
            try
            {
                Properties.Settings.Default.Path = this.path;
                Properties.Settings.Default.Save();
            }
            catch { }  // Don't blow up if config file not available
        }

        private bool ValidatePath()
        {
            bool valid = false;
            if (!File.Exists(path))
                MessageBox.Show("File " + path + " does not exist");
            else if (!PathFileHasValidExtension())
                MessageBox.Show("File " + path + " is not a project or solution or code file");
            else
                valid = true;
            return valid;
        }

        private bool PathFileHasValidExtension()
        {
            return CodeContainer.CheckValidExtension(path);
        }
 
        #endregion

        #region Calculate and Show Results
        private void CalculateAndShowResults()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // The CodeContainerFactory ensures the right type of class (Solution, Project or
                // CodeFile) is instantiated based on the file extension
                rootCodeContainer = new CodeContainerFactory().CreateCodeContainer(path);
                rootCodeContainer.CountLines();
                ShowResults();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ShowResults()
        {
            if (rootCodeContainer is Solution)
                SetGridToShowProjectsAndCodeFiles();
            else
                SetGridToShowCodeFilesOnly();
            ShowResultsText();
            ShowResultsDataInGrid();
        }

        private void ShowResultsText()
        {
            if (rootCodeContainer != null)
            {
                if (showBreakdownToolStripMenuItem.Checked)
                    topLevelResultsTextBox.Text = rootCodeContainer.ToResultString();
                else
                    topLevelResultsTextBox.Text = rootCodeContainer.ToShortResultString();
            }
        }

        private void ShowResultsDataInGrid()
        {
            if (rootCodeContainer != null)
            {
                ResultsDataSet results = new ResultsDataSet();
                if (showProjectsOnly)
                    results = rootCodeContainer.PopulateResultsProjectsOnly(results);
                else
                    results = rootCodeContainer.PopulateResults(results);
                this.resultsDataSet.Clear();
                this.resultsDataSet.Merge(results);
            }
        }

       #endregion

        #region Menu events

        private void selectNewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectNewFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void showProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Don't let our user clear the grid entirely
            if (!showProjectsToolStripMenuItem.Checked && !showCodeFilesToolStripMenuItem.Checked)
                showProjectsToolStripMenuItem.Checked = true;
            else
            {
                showProjectsToolStripDropDownItem.Checked = showProjectsToolStripMenuItem.Checked;
                ShowCorrectGridAfterMenuChange();
            }
        }

        private void showCodeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showProjectsToolStripMenuItem.Checked && !showCodeFilesToolStripMenuItem.Checked)
                showCodeFilesToolStripMenuItem.Checked = true;
            else
            {
                showCodeFilesToolStripDropDownItem.Checked = showCodeFilesToolStripMenuItem.Checked;
                ShowCorrectGridAfterMenuChange();
            }
        }

        private void showProjectsToolStripDropDownItem_Click(object sender, EventArgs e)
        {
            if (!showProjectsToolStripDropDownItem.Checked && !showCodeFilesToolStripDropDownItem.Checked)
                showProjectsToolStripDropDownItem.Checked = true;
            else
            {
                showProjectsToolStripMenuItem.Checked = showProjectsToolStripDropDownItem.Checked;
                ShowCorrectGridAfterMenuChange();
            }
        }

        private void showCodeFilesToolStripDropDownItem_Click(object sender, EventArgs e)
        {
            if (!showProjectsToolStripDropDownItem.Checked && !showCodeFilesToolStripDropDownItem.Checked)
                showCodeFilesToolStripDropDownItem.Checked = true;
            else
            {
                showCodeFilesToolStripMenuItem.Checked = showCodeFilesToolStripDropDownItem.Checked;
                ShowCorrectGridAfterMenuChange();
            }
        }

        private void showBreakdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showBreakdownToolStripDropDownItem.Checked = showBreakdownToolStripMenuItem.Checked;
            ShowCorrectGridAfterMenuChange();
            ShowResultsText();
        }

        private void showBreakdownToolStripDropDownItem_Click(object sender, EventArgs e)
        {
            showBreakdownToolStripMenuItem.Checked = showBreakdownToolStripDropDownItem.Checked;
            ShowCorrectGridAfterMenuChange();
            ShowResultsText();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "LINE COUNT 2.0\n\nAuthor: Rich Newman\n";
            message += "http://richnewman.wordpress.com" + "\n\n";
            message += "Released under the MIT licence:\n\n";
            message += "Copyright (c) 2007 Richard John Newman\n\nPermission is hereby granted, free of charge, to any person obtaining a copy\nof this software and associated documentation files (the \"Software\"), to deal\nin the Software without restriction, including without limitation the rights\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\ncopies of the Software, and to permit persons to whom the Software is\nfurnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in\nall copies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN\nTHE SOFTWARE.";
            MessageBox.Show(message, "Line Count");
        }

        #endregion

        #region Show correct grid after menu change
        bool showProjectsOnly = false;

        private void ShowCorrectGridAfterMenuChange()
        {
            ShowOrHideColumnsBasedOnMenu();
            RegenerateGridFromCachedResultsIfNecessary();
        }

        private void RegenerateGridFromCachedResultsIfNecessary()
        {
            // Regenerate the grid only if there's a change in the level at
            // which we're showing stuff: if we're showing projects only we don't
            // want a line for every code file
            if (showProjectsOnly && this.showCodeFilesToolStripMenuItem.Checked)
            {
                showProjectsOnly = false;
                ShowResultsDataInGrid();
            }
            else if ((!showProjectsOnly) && this.showProjectsToolStripMenuItem.Checked
                && !this.showCodeFilesToolStripMenuItem.Checked)
            {
                showProjectsOnly = true;
                ShowResultsDataInGrid();
            }
        }

        private void ShowOrHideColumnsBasedOnMenu()
        {
            // Change which columns we're showing based on the checked/unchecked
            // state of the menu items
            ShowOrHideCodeFilesColumns(showCodeFilesToolStripMenuItem.Checked, showBreakdownToolStripMenuItem.Checked);
            ShowOrHideProjectsColumns(showProjectsToolStripMenuItem.Checked, showBreakdownToolStripMenuItem.Checked);
        }

        private void ShowOrHideCodeFilesColumns(bool showColumns, bool showBreakdown)
        {
            this.resultsDataGridView.Columns["shortNameDataGridViewTextBoxColumn"].Visible = showColumns;
            this.resultsDataGridView.Columns["relativeNameDataGridViewTextBoxColumn"].Visible = showColumns;
            this.resultsDataGridView.Columns["linesDataGridViewTextBoxColumn"].Visible = showColumns;
            ShowOrHideBreakdownCodeFilesColumns(showColumns && showBreakdown);
        }

        private void ShowOrHideBreakdownCodeFilesColumns(bool show)
        {
            this.resultsDataGridView.Columns["blankLinesDataGridViewTextBoxColumn"].Visible = show;
            this.resultsDataGridView.Columns["designerLinesDataGridViewTextBoxColumn"].Visible = show;
            this.resultsDataGridView.Columns["commentsLinesDataGridViewTextBoxColumn"].Visible = show;

        }

        private void ShowOrHideProjectsColumns(bool showColumns, bool showBreakdown)
        {
            this.resultsDataGridView.Columns["projectShortNameDataGridViewTextBoxColumn"].Visible = showColumns;
            this.resultsDataGridView.Columns["projectRelativeNameDataGridViewTextBoxColumn"].Visible = showColumns;
            this.resultsDataGridView.Columns["projectLinesDataGridViewTextBoxColumn"].Visible = showColumns;
            ShowOrHideBreakdownProjectsColumns(showColumns && showBreakdown);
        }

        private void ShowOrHideBreakdownProjectsColumns(bool show)
        {
            this.resultsDataGridView.Columns["projectBlankLinesDataGridViewTextBoxColumn"].Visible = show;
            this.resultsDataGridView.Columns["projectDesignerLinesDataGridViewTextBoxColumn"].Visible = show;
            this.resultsDataGridView.Columns["projectCommentsLinesDataGridViewTextBoxColumn"].Visible = show;
        }
        #endregion

        #region Grid set up
        private void SetGridToShowCodeFilesOnly()
        {
            showProjectsOnly = false;
            this.showProjectsToolStripDropDownItem.Checked = false;
            this.showProjectsToolStripMenuItem.Checked = false;
            this.showCodeFilesToolStripDropDownItem.Checked = true;
            this.showCodeFilesToolStripMenuItem.Checked = true;
            ShowOrHideColumnsBasedOnMenu();
        }

        private void SetGridToShowProjectsAndCodeFiles()
        {
            showProjectsOnly = false;
            this.showProjectsToolStripDropDownItem.Checked = true;
            this.showProjectsToolStripMenuItem.Checked = true;
            this.showCodeFilesToolStripDropDownItem.Checked = true;
            this.showCodeFilesToolStripMenuItem.Checked = true;
            ShowOrHideColumnsBasedOnMenu();
        }

        #endregion
   }
}