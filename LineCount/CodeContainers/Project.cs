using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace LineCount.CodeContainers
{
    /// <summary>
    /// Represents a .NET project: contains a reference to the project
    /// file (in the base class) and allows the number of lines in the project overall to be
    /// counted (not just the lines in the project file).
    /// </summary>
    class Project : CodeContainer
    {
        #region Constructor
        internal Project(string fullName) : base(fullName) { }
        internal Project(string fullName, string relativeName) : base(fullName, relativeName) { }
        #endregion

        #region Count lines method
        internal override void CountLines()
        {
            childCodeContainers = new List<CodeContainer>();
            FindCodeFilesAndAddToChildContainersList();
            CountLinesInChildCodeContainers();
        }

        #region FindCodeFilesAndAddToChildContainersList method
        private void FindCodeFilesAndAddToChildContainersList()
        {
            XPathDocument document = new XPathDocument(file.FullName);
            XPathNavigator navigator = document.CreateNavigator();

            XPathNodeIterator iterator = ConstructIterator(navigator);

            while (iterator.MoveNext())
                AddCodeFileToList(iterator.Current.Value);
        }

        private XPathNodeIterator ConstructIterator(XPathNavigator navigator)
        {
            XPathNavigator node = navigator.SelectSingleNode("//@ProductVersion");
            bool version2003 = node != null && node.Value.StartsWith("7");
            bool isCpp = file.Name.EndsWith(".vcproj");

            XPathNodeIterator iterator;
            if (isCpp)
            {
                iterator = navigator.Select("//Files/Filter[@Name=\"Source Files\" or @Name=\"Header Files\"]/File/@RelativePath");
            }
            else if (version2003)
            {
                // 'File' nodes with attribute BuildAction set to "Compile", RelPath attribute on that
                iterator = navigator.Select("//Files/Include/File[@BuildAction=\"Compile\"]/@RelPath");
            }
            else
            {
                XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
                manager.AddNamespace("ns", "http://schemas.microsoft.com/developer/msbuild/2003");

                // 'Include' attribute on 'Compile' nodes in the namespace
                iterator = navigator.Select("//ns:ItemGroup/ns:Compile/@Include", manager);
            }
            return iterator;
        }

        private void AddCodeFileToList(string codeFileRelativeName)
        {
            if (CodeFile.CheckValidExtension(codeFileRelativeName))
            {
                if (codeFileRelativeName.StartsWith(".")) codeFileRelativeName = codeFileRelativeName.Substring(2);
                string codeFileFullName = Path.Combine(file.Directory.FullName, codeFileRelativeName);
                CodeFile lineCountCodeFile = new CodeFile(codeFileFullName, codeFileRelativeName);
                this.childCodeContainers.Add(lineCountCodeFile);
            }
        }
        #endregion

        #endregion

        #region Methods for getting results
        internal override ResultsDataSet PopulateResults(ResultsDataSet results)
        {
            //foreach (CodeContainerBase baseFile in this.childCodeContainers)
            foreach (CodeFile codeFile in this.childCodeContainers)
            {
                //CodeFile codeFile = baseFile as CodeFile;
                ResultsDataSet.ResultsRow row = (ResultsDataSet.ResultsRow)results.Results.NewRow();
                row = codeFile.PopulateResultsRow(row);
                row = this.PopulateResultsRow(row);
                results.Results.AddResultsRow(row);
            }
            return results;
        }

        internal ResultsDataSet.ResultsRow PopulateResultsRow(ResultsDataSet.ResultsRow row)
        {
            row.ProjectShortName = file.Name;
            row.ProjectRelativeName = this.relativeFileName;
            row.ProjectLines = this.numberLines;
            row.ProjectBlankLines = this.numberBlankLines;
            row.ProjectDesignerLines = this.numberLinesInDesignerFiles;
            row.ProjectCommentsLines = this.numberCommentsLines;
            return row;
        }

        internal override ResultsDataSet PopulateResultsProjectsOnly(ResultsDataSet results)
        {
            ResultsDataSet.ResultsRow row = (ResultsDataSet.ResultsRow)results.Results.NewRow();
            row = this.PopulateResultsRow(row);
            results.Results.AddResultsRow(row);
            return results;
        }
        #endregion

        internal static new bool CheckValidExtension(string fileName)
        {
            return fileName.EndsWith(".csproj") || fileName.EndsWith(".vbproj") || fileName.EndsWith(".vcproj");
        }
    }
}
