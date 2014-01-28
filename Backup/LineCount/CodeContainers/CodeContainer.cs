using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LineCount.CodeContainers
{
    /// <summary>
    /// Abstract base class for things that can have their lines counted.
    /// Currently these can be CodeFile, Project or Solution classes.
    /// </summary>
    /// <remarks>
    /// Struggled to come up with a sensible name for this.
    /// </remarks>
    abstract class CodeContainer
    {
        #region Member variables
        protected FileInfo file;
        protected string relativeFileName = "";
        protected List<CodeContainer> childCodeContainers = new List<CodeContainer>();

        protected int numberLines = 0;
        protected int numberBlankLines = 0;
        protected int numberLinesInDesignerFiles = 0;
        protected int numberCommentsLines = 0;

        protected int numberCodeFiles = 0;

#endregion

        #region Getters
        internal int NumberLines { get { return numberLines; } }
        internal int NumberBlankLines { get { return numberBlankLines; } }
        internal int NumberLinesInDesignerFiles { get { return numberLinesInDesignerFiles; } }
        internal int NumberCommentsLines { get { return numberCommentsLines; } }
        #endregion

        #region Constructors
        internal CodeContainer(string fullName)
        {
            file = new FileInfo(fullName);
        }
        internal CodeContainer(string fullName, string relativeName)
        {
            file = new FileInfo(fullName);
            this.relativeFileName = relativeName;
        }
        #endregion

        #region Count lines method
        internal abstract void CountLines();

        #region CountLines support
        protected void SetLineCountsToZero()
        {
            numberLines = 0;
            numberBlankLines = 0;
            numberLinesInDesignerFiles = 0;
            numberCommentsLines = 0;
            numberCodeFiles = 0;
        }

        protected void CountLinesInChildCodeContainers()
        {
            SetLineCountsToZero();
            foreach (CodeContainer childCodeContainer in this.childCodeContainers)
            {
                childCodeContainer.CountLines();
                AddChildLineCountsToLineCountTotals(childCodeContainer);
            }
        }

        private void AddChildLineCountsToLineCountTotals(CodeContainer childCodeContainer)
        {
            numberLines += childCodeContainer.NumberLines;
            numberBlankLines += childCodeContainer.NumberBlankLines;
            numberLinesInDesignerFiles += childCodeContainer.NumberLinesInDesignerFiles;
            numberCommentsLines += childCodeContainer.NumberCommentsLines;
            numberCodeFiles += childCodeContainer.numberCodeFiles;
        }
        #endregion

        #endregion

        #region Methods for getting results

        internal string ToResultString()
        {
            string resultString = ToShortResultString() + ", ";
            resultString += "number of code-generated lines = " + numberLinesInDesignerFiles.ToString("N0") + ", ";
            resultString += "number of user-entered blank lines = " + numberBlankLines.ToString("N0") + ", ";
            resultString += "number of user-entered comments = " + numberCommentsLines.ToString("N0");
            return resultString;
        }

        internal string ToShortResultString()
        {
            string resultString = file.FullName + ":  \r\n";
            resultString += "Number of lines = " + numberLines.ToString("N0") + ", ";
            resultString += "number of code files = " + numberCodeFiles.ToString("N0");
            return resultString;
        }

        internal abstract ResultsDataSet PopulateResults(ResultsDataSet results);

        internal abstract ResultsDataSet PopulateResultsProjectsOnly(ResultsDataSet results);

        #endregion

        internal static bool CheckValidExtension(string fileName)
        {
            return Solution.CheckValidExtension(fileName) || Project.CheckValidExtension(fileName) || CodeFile.CheckValidExtension(fileName);
        }
    }
}
