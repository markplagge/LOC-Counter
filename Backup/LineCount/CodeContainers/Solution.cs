using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LineCount.CodeContainers
{
    /// <summary>
    /// Represents a .NET solution: contains a reference to the solution
    /// file (in the base class) and allows the number of lines in the solution overall to be
    /// counted (not just the lines in the solution file).
    /// </summary>
    class Solution : CodeContainer
    {
        #region Constructor
        internal Solution(string fullName) : base(fullName) { }
        #endregion

        #region Count lines method
        internal override void CountLines()
        {
            childCodeContainers = new List<CodeContainer>(); 
            FindProjectFilesAndAddToChildContainersList();
            CountLinesInChildCodeContainers();
        }

        #region FindProjectFilesAndAddToChildContainersList method

        private void FindProjectFilesAndAddToChildContainersList()
        {
            StreamReader sr = new StreamReader(file.FullName);
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim();
                    CheckLineForProjectFile(line);
                }
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }

        private void CheckLineForProjectFile(string line)
        {
            //System.Diagnostics.Debug.WriteLine(line);
            if (line.StartsWith("Project") &&
                (line.Contains(".csproj") || line.Contains(".vbproj") || line.Contains(".vcproj")))
            {
                //System.Diagnostics.Debug.WriteLine(line);
                int projPosition = line.IndexOf(".csproj");
                if (projPosition == -1) projPosition = line.IndexOf(".vbproj");
                if (projPosition == -1) projPosition = line.IndexOf(".vcproj");
                string truncatedLine = line.Substring(0, projPosition + 7);
                int startPosition = truncatedLine.LastIndexOf('"');
                if (startPosition != -1)
                {
                    string projectRelativeName = truncatedLine.Substring(startPosition + 1);
                    AddProjectFileToChildContainersList(projectRelativeName);
                }
            }
        }

        private void AddProjectFileToChildContainersList(string projectRelativeName)
        {
            //System.Diagnostics.Debug.WriteLine(projectRelativeName);
            string projectFullName = Path.Combine(file.Directory.FullName, projectRelativeName);
            Project project = new Project(projectFullName, projectRelativeName);
            this.childCodeContainers.Add(project);
        }
        #endregion

        #endregion

        #region Methods for getting results
        internal override ResultsDataSet PopulateResults(ResultsDataSet results)
        {
            foreach (Project projectFile in this.childCodeContainers)
            {
                results = projectFile.PopulateResults(results);
            }
            return results;
        }

        internal override ResultsDataSet PopulateResultsProjectsOnly(ResultsDataSet results)
        {
            foreach (Project projectFile in this.childCodeContainers)
            {
                results = projectFile.PopulateResultsProjectsOnly(results);
            }
            return results;
        }
        #endregion

        internal static new bool CheckValidExtension(string fileName)
        {
            return fileName.EndsWith(".sln");
        }
    }
}
