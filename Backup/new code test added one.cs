namespace CodeCounterLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Text;
    using IronRuby;
    using IronRuby.Runtime;
    using Microsoft.Scripting;
    using Microsoft.Scripting.Hosting;
    using Microsoft.Scripting.Hosting.Providers;
    using SERFS;
    using BooLibs;
    using System.Text.RegularExpressions;
    ////using Boo.Lang;

    public class CodeText
    {
		private this is a new line of code!!!!
		
		and this is another line of code!!
        /**
         * DataMembers
         * */
        #region stringParameters
        
        //private string pathOfFile;
        private List<string> linesOfText;
        /// <summary>
        /// public var for reading code.
        /// </summary>
        public string ReadCodeText
        {
            get
            {
                return this.fullText;
            }
        }
        /// <summary
        /// theCode sets and gets this class' string variables.
        /// </summary>
        protected string TheCode
        {
            get
            {
                return this.fullText;
            }
            set
            {
                this.fullText = value;
                var textArray = value.Split(new string[] { Environment.NewLine }, System.StringSplitOptions.None).ToArray();
                this.linesOfText = new List<string>(textArray);
                var textArray2 = fullText.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                this.linesOfText = new List<string>(textArray2);
            }
        }
        internal List<String> CodeLines
        {
            get
            {
                var result = Regex.Split(this.TheCode, "\r\n|\r|\n");
                return result.ToList();
            }
            set
            {
                string newCode = "";
                foreach (string item in value)
                {
                    if (item.Length > 0)
                        newCode = newCode + item + "\n";
                }

                this.TheCode = newCode;
            }
        }
        /// <summary>
        /// Lines of Code - Managed by the Property
        /// </summary>
        private int baseLOC;
        public int LinesOfCode
        {
            get
            {
                this.countLines();
                return baseLOC;
            }
        }
        private int baseComments;
        private BooLibs.regexDef regexTools;
        private List<string> comments;
        private List<string> nonCommentCode;
        #endregion
        /// <summary>
        /// Creates a new CodText object using a  block of text to seed.
        /// </summary>
        /// <param name="p">the block of code to be counted</param>
        public CodeText(string p)
        {
            // TODO: Complete member initialization
            this.TheCode = p;
            Console.Write("End of constructor with only a string");
           
            initCodeText();
        }
        /// <summary>
        /// Inits the code text internal stuff so that we can use the data.
        /// </summary>
        private void initCodeText()
        {
            //prevent this shit from throwing null exceptions:
            regexTools = new regexDef();
            comments = new List<string>();
            nonCommentCode = new List<string>();
            linesOfText = new List<string>();
            baseLOC = 0;

        }

        // properties:
        public Boo.Lang.Hash RegexStrings
        {
            get
            {
                var reg = this.regexTools.getCSComments();
                return reg;
            }
        }
  
  

        private void InitCount()
        {
            this.baseLOC = 0;
            this.baseComments = 0;
        }
       
        //Dispite the public getter for the LOC, this will remain public until I can figure out how to
        //thread gets.
        public void countLines()
        {
            
            removeNonCountedDeclarations();
            removeBlankLines();
            removeWhiteSpace();
            removeComments();
            removeNonCountedDeclarations();
            removeBlankLines();
            removeWhiteSpace();
            //Next, count the lines of the code

        }
        

        private void doCount()
        {
            //set up the counting machine!!
           // List<string> codeList = nonCommentCode.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
           // List<string> codeList = TheCode.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            this.baseLOC = this.CodeLines.Count;
            this.baseComments = -1;

        }

        private void removeComments()
        {
            // remove block comments and place them into the count.
            this.comments = new List<string>();
            this.nonCommentCode = new List<string>();
            string blockCode = this.regexTools.extractBlockComments(this.TheCode);
            string nonCommentCode = this.regexTools.removeBlockComments(this.TheCode);
            this.TheCode = nonCommentCode;
            //remove line comments, (lines with comments)

            //create a temp variable - damn the memory usage:
            //List<string> codeList = nonCommentCode.Split(-}, StringSplitOptions.None).ToList();
            //List<string> codeList = this.CodeLines;


             

            //string newCode = "";
            //foreach (string item in codeList)
            //{
            //    if (item.Length > 0)
            //        newCode = newCode + item + "\n";
            //}

            //this.TheCode = newCode;
            removeSingleLineComments();
        }
        private void removeSingleLineComments()
        {
            List<string> codeList = this.linesOfText;
            IEnumerable<string> trimmedList = codeList.Select(n => n.Trim());
            IEnumerable<string> codeNoComments = trimmedList.Where(line => !line.TrimStart().StartsWith("//"));
            this.CodeLines = codeNoComments.ToList<string>();
            
        }

        public void removeNonCountedDeclarations()
        {
            //non counted decs include" USING { <- when by itself, { <- when by itself
            
                this.TheCode = Regex.Replace(this.TheCode, @"{*", "", RegexOptions.Multiline);
                this.TheCode = Regex.Replace(this.TheCode, @"}*", "", RegexOptions.Multiline);
             //   this.TheCode = Regex.Replace(this.TheCode, @"/*", "", RegexOptions.Multiline);
               // this.TheCode = Regex.Replace(this.TheCode, @"\s*", "", RegexOptions.Multiline);
            this.TheCode = Regex.Replace(this.TheCode, @"\p{Zs}", "", RegexOptions.Multiline);    
            this.TheCode = Regex.Replace(this.TheCode, @"}*", "", RegexOptions.Multiline);
                this.TheCode = Regex.Replace(this.TheCode, @"\t*", "", RegexOptions.Multiline);
            
            
           // List<string> codeList = TheCode.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                List<string> codeList = this.CodeLines;
            codeList.ForEach(n => n.Replace('{', ' '));
            codeList.ForEach(n => n.Replace('}', ' '));
            //codeList.Remove("{");
            //codeList.Remove("}");
            //codeList.Remove("/////");
            //codeList.Remove("////");
            //codeList.Remove("///");
            //codeList.Remove("//");
            //next remove non-code items.
            //TODO: Make this a class variable:
            string[] nonCodeItems = {"get","put","import","using"};
            //for (int i = 0; i < codeList.Count; i++)
            //{
            //    foreach (var item in nonCodeItems)
            //    {
            //        if (codeList.ElementAt(i).Contains(item))
            //            codeList.RemoveAt(i);
            //    }
            //}
            string newCode = "";
            foreach (string item in codeList)
            {
                item.Trim();
                if (item.Length > 0)
                {
                    newCode = newCode + item + "\n";
                    }
                    
            }

            this.TheCode = newCode;

        }
        public void removeWhiteSpace()
        {

            //List<string> codeList = TheCode.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            List<string> codeList = this.CodeLines;
            codeList.ForEach(n => n.Trim());
            string newCode = "";
            foreach (string item in codeList)
            {
                item.Trim();
                if (item.Length > 0)
                {
                    newCode = newCode + item + "\n";
                }

            }

            this.TheCode = newCode;


            //damn i'm good and crap - bit this is not needed.


        }
        public void removeBlankLines()
        {
            this.TheCode = Regex.Replace(this.TheCode, @"^\s+$[\r\n]*", "", RegexOptions.Multiline).TrimEnd();
            
        }

    }

    public class CodeComparison
    {

        private int addedLOC;
        public int newLOC
        {
            get { return addedLOC; }
        }
        private int delLOC;
        public int deletedLOC 
        {
            get { return delLOC; }
        }
        private CodeText oldCode;
        private CodeText newCode;

        public CodeComparison(CodeText oldCode, CodeText newCode)
        {

            this.oldCode = oldCode;
            this.newCode = newCode;
            this.processCode();
        }

        private void processCode()
        {
            //compare the codes.
            System.Collections.Stack newLinesStack = new System.Collections.Stack();
            System.Collections.Stack delLinesStack = new System.Collections.Stack();
            List<string> oldCodeLines = oldCode.CodeLines;
            List<string> newCodeLines = newCode.CodeLines;
            
            //we are going to find all of the deleted items

            IEnumerable<string> deletedLines = oldCodeLines.Except(newCodeLines);
            IEnumerable<string> newLines = newCodeLines.Except(oldCodeLines);
            foreach (var item in deletedLines)
            {
                delLinesStack.Push(item);
            }
            foreach (var item in newLines)
            {
                newLinesStack.Push(item);
            }
            addedLOC = newLinesStack.Count;
            delLOC = delLinesStack.Count;
        }
        
    }

}
