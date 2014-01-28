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
    using LineCount;
    ////using Boo.Lang;

    public class CodeText
    {
        /**
         * DataMembers
         * */

        private string fullText;
        private List<string> linesOfText;
        private int baseLOC;

        private int baseComments;
        private BooLibs.regexDef regexTools;
        private List<string> comments;
        private List<string> nonCommentCode;
        private CodeContainer theCode;
    
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
        /// Creates a code text pointing at a file.
        /// </summary>
        /// <param name="Filename"></param>
        public CodeText(string Filename, string code)
        {
            initCodeText();
            LineCount.CodeContainers.CodeContainerFactory theFactory = new LineCount.CodeContainers.CodeContainerFactory();
            theCode = theFactory.CreateCodeContainer(Filename);
            this.CodeText(code);
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
        /// <summary
        /// theCode sets and gets this class' string variables.
        /// </summary>
        public string TheCode
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
            }
        }

        private void InitCount()
        {
            this.baseLOC = 0;
            this.baseComments = 0;
        }
        public void countLines()
        {

            removeWhiteSpace();
            removeNonCountedDeclarations();
            removeBlankLines();
            removeComments();
        }
        public void removeComments()
        {
            // remove block comments and place them into the count.
            this.comments = new List<string>();
            this.nonCommentCode = new List<string>();
            string blockCode = this.regexTools.extractBlockComments(this.fullText);
            string nonCommentCode = this.regexTools.removeBlockComments(this.fullText);
            //remove line comments, (lines with comments)
            
            //create a temp variable - damn the memory usage:
            List<string> codeList = nonCommentCode.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            IEnumerable<string> trimmedList = codeList.Select (n=> n.Trim());
            IEnumerable<string> codeNoComments = trimmedList.Where( n => !(n.StartsWith("//")));
            restoreString(codeNoComments);

        }

        public void removeNonCountedDeclarations()
        {
            //non counted decs include" USING { <- when by itself, { <- when by itself
            this.fullText = Regex.Replace(this.fullText, @"^{", "", RegexOptions.Multiline);
            List<string> codeList = splitInternalString();
            codeList.ForEach(n=>n.Replace('{', ' '));
            codeList.ForEach(n => n.Replace('}', ' '));
            restoreString(codeList);

        }
        public void removeWhiteSpace()
        {

            List<string> codeList = splitInternalString();
            codeList.ForEach(n => n.Trim());
            //damn i'm good and crap - bit this is not needed.
            restoreString(codeList);
 
        }
        public void removeBlankLines()
        {
            this.fullText = Regex.Replace(this.fullText, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
        }

        private List<string> splitInternalString()
        {
            
            List<string> list = new List<string>(
                           this.fullText.Split(new string[] { "\r\n" },
                           StringSplitOptions.RemoveEmptyEntries));
            if (list.Count == 1) // the split failed:
                list = new List<string>(
                    this.fullText.Split(new string[] { "\n" },
                    StringSplitOptions.RemoveEmptyEntries));
            return list;
        }
        private void restoreString(IEnumerable<string> splicedText)
        {
            string newCode = "";
            foreach (string item in splicedText)
            {
                if (item.Length > 0)
                    newCode = newCode + item + "\n";
            }

            this.fullText = newCode;
        }
    }

}
