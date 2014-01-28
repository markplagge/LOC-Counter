using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LineCount.CodeContainers
{
    /// <summary>
    /// Represents a .NET file containing code: a .vb, .cs, .cpp, or .h file here.
    /// </summary>
    class CodeFile : CodeContainer
    {
        bool isDesignerFile = false;

        #region Constructors
        internal CodeFile(string fullName)
            : base(fullName)
        {
            isDesignerFile = IsDesignerFile();
        }
        internal CodeFile(string fullName, string relativeName)
            : base(fullName, relativeName)
        {
            isDesignerFile = IsDesignerFile();
        }
        private bool IsDesignerFile()
        {
            bool isWebReferenceFile = file.FullName.Contains(@"\Web References\") && file.Name == "Reference.cs";  // Ugh
            return isWebReferenceFile || file.Name.Contains(".Designer.") || file.Name.Contains(".designer.");
        }
        #endregion

        #region Count lines method
        bool inCodeGeneratedRegion = false;
        bool inCommentBlock = false;
        internal override void CountLines()
        {
            InitializeCountLines();
            if (file.Exists)
            {
                StreamReader sr = new StreamReader(file.FullName);
                try
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine().Trim();
                        IncrementLineCountsFromLine(line);
                    }
                }
                finally
                {
                    if (sr != null) sr.Close();
                }

            }
        }

        private void InitializeCountLines()
        {
            SetLineCountsToZero();
            numberCodeFiles = 1;
            inCodeGeneratedRegion = false;
            inCommentBlock = false;
        }

        private void IncrementLineCountsFromLine(string line)
        {
            SetCodeBlockFlags(line);

            this.numberLines++;
            if (inCodeGeneratedRegion || this.isDesignerFile)
                this.numberLinesInDesignerFiles++;
            else if (line == "")
                this.numberBlankLines++;
            else if (inCommentBlock || line.StartsWith("'") || line.StartsWith(@"//"))
                this.numberCommentsLines++;

            ResetCodeBlockFlags(line);
        }

        private void SetCodeBlockFlags(string line)
        {
            // The number of code-generated lines is an approximation at best, particularly
            // with VS 2003 code.  Change code here if you don't like the way it's working.
            // if (line.Contains("Designer generated code") // Might be cleaner
            if (line.StartsWith("#region Windows Form Designer generated code") ||
                line.StartsWith("#Region \" Windows Form Designer generated code") ||
                line.StartsWith("#region Component Designer generated code") ||
                line.StartsWith("#Region \" Component Designer generated code \"") ||
                line.StartsWith("#region Web Form Designer generated code") ||
                line.StartsWith("#Region \" Web Form Designer Generated Code \"")
                )
                inCodeGeneratedRegion = true;
            if (line.StartsWith("/*"))
                inCommentBlock = true;
        }

        private void ResetCodeBlockFlags(string line)
        {
            if (inCodeGeneratedRegion && (line.Contains("#endregion") || line.Contains("#End Region")))
                inCodeGeneratedRegion = false;
            if (inCommentBlock && line.Contains("*/"))
                inCommentBlock = false;
        }
        #endregion

        #region Methods for getting results
        internal override ResultsDataSet PopulateResults(ResultsDataSet results)
        {
            ResultsDataSet.ResultsRow row = (ResultsDataSet.ResultsRow)results.Results.NewRow();
            row = PopulateResultsRow(row);
            results.Results.AddResultsRow(row);
            return results;
        }

        internal ResultsDataSet.ResultsRow PopulateResultsRow(ResultsDataSet.ResultsRow row)
        {
            row.ShortName = file.Name;
            row.RelativeName = this.relativeFileName;
            row.Lines = this.numberLines;
            row.BlankLines = this.numberBlankLines;
            row.DesignerLines = this.numberLinesInDesignerFiles;
            row.CommentsLines = this.numberCommentsLines;
            return row;
        }

        internal override ResultsDataSet PopulateResultsProjectsOnly(ResultsDataSet results)
        {
            return results;
        }
        #endregion

        internal static new bool CheckValidExtension(string fileName)
        {
            return fileName.EndsWith(".cs") || fileName.EndsWith(".vb") || 
                fileName.EndsWith(".cpp") || fileName.EndsWith(".h") || fileName.EndsWith(".hpp");
        }
    }
}
