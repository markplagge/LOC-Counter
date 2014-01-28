namespace CodeCounterLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Text;
    using SERFS;
    using BooLibs;
    using System.Text.RegularExpressions;

    using SimMetricsMetricUtilities;

    ////using Boo.Lang;

    public class CodeText
    {
        /**
         * DataMembers
         * */
        #region stringParameters
        private string fullText;
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
        /// Creates a new CodeText object using a  block of text to seed.
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
        //public Boo.Lang.Hash RegexStrings
        //{
        //    get
        //    {
        //        var reg = this.regexTools.getCSComments();
        //        return reg;
        //    }
        //}



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

            List<string> codeList = this.CodeLines;
            codeList.ForEach(n => n.Replace('{', ' '));
            codeList.ForEach(n => n.Replace('}', ' '));
            string[] nonCodeItems = { "get", "put", "import", "using" };
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
        #region helperVariables

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
        private int mLOC;
        public int modifiedLOC
        {
            get { return mLOC; }
        }
        private CodeText oldCode;
        private CodeText newCode;
        private double minSimilarity = .75000001;
        private double maxSimilarity = 1.0;
        /// <summary>
        /// comparison algorithm holder
        /// </summary>
        private SimMetricsApi.AbstractStringMetric comparisonAlgorithm;
        #endregion

        #region constructors
        /// <summary>
        /// Constructor that only takes text values, and uses defaults for the comparison engine.
        /// Defaults are:
        /// Min Sim = .86;
        /// Max Sim = 1.0
        /// 
        /// </summary>
        /// <param name="oldCode">Old Code in a CodeText object</param>
        /// <param name="newCode">New Code in a CodeText object</param>
        public CodeComparison(CodeText oldCode, CodeText newCode)
        {

            this.oldCode = oldCode;
            this.newCode = newCode;

            //Default configuration for algorithm:
            //comparisonAlgorithm = new JaroWinkler();
            comparisonAlgorithm = new MatchingCoefficient();
            this.processCode();
        }
        #endregion


        /// <summary>
        /// This compares two lines of text. It returns true for a match
        /// </summary>
        /// <param name="line1">First line of text</param>
        /// <param name="line2">Second line of text</param>
        /// <returns></returns>
        private bool compareLines(string line1, string line2)
        {

            double probableMatch;
            bool matchedLine = false;
            /*
             * code1Thread = new Thread(new ThreadStart(code1.countLines));
            code2Thread = new Thread(new ThreadStart(code2.countLines));
            code1Thread.Start();
            code2Thread.Start();
            while (!code1Thread.IsAlive) ;
            while (!code2Thread.IsAlive) ;
            code1Thread.Join();
            code2Thread.Join();/*
             * */
            //MatchsMaker ms = new MatchsMaker(line1, line2);
            CompareTool comp = new CompareTool(line1, line2, comparisonAlgorithm);
            
            comp.doCompare();
            //Added this to compare algorithms:
            CompareTool cDiceSimilarity = new CompareTool(line1, line2, new DiceSimilarity());
            CompareTool cEuclideanSim = new CompareTool(line1, line2, new EuclideanDistance());
            CompareTool cChapmanDev = new CompareTool(line1, line2, new ChapmanLengthDeviation());
            //And the output:
            cDiceSimilarity.doCompare();
            cEuclideanSim.doCompare();
            cChapmanDev.doCompare();
            
            
            double comparison = comp.similarity;
            /*
            double aAlgo = runComp(line1, line2,aAlgoCompare);
            double bAlgo = runComp(line1, line2,bAlgoCompare);


            probableMatch = (jaro + aAlgo + bAlgo) / 3;
            */

            //if (ms.Score > minSimilarity && ms.Score < maxSimilarity)
            if (comparison > minSimilarity && comparison < maxSimilarity)
            {
                //We have a match
                matchedLine = true;
                Console.WriteLine("code is modified. Code is: " + line1 + " \n " + line2);
                Console.WriteLine("DiceSim = " + cDiceSimilarity.similarity);
                Console.WriteLine("EuclidSim = " + cEuclideanSim.similarity);
                Console.WriteLine("ChapmanSim= " + cChapmanDev.similarity);

                Console.WriteLine("UsedAlgorithm =" + comp.similarity);

            }
            if (matchedLine == true)
            {
                Console.WriteLine("TRUE!");
            }
            return matchedLine;
        }

        /// <summary>
        /// This method compares the code between the old code and the new code.This will remove any lines not in the new code but in the 
        /// old code. It will then check to see the similarity between the codes - this value is set arbitrarily inside this method. Anything
        /// over a certian line will be removed from the new code lines and the old code lines code, then placed into the modified code list
        /// that is returned after the method is run.
        /// </summary>
        /// <param name="oldCodeLines">Old Code Lines contains the old code lines of code that are not in the new code. Will be modified 
        /// by this method to only contain deleted items (not in the new code and not modified)</param>
        /// <param name="newCodeLines">All of the new lines of code.</param>
        /// <returns>number of modified lines of code</returns>
        private int countModifiedLines(List<string> newCodeLines)
        {
            int numOfMods = 0;
            //Modified lines of code will show up under new lines of code.

            for (int i = 0; i < newCodeLines.Count; i++)
            {
                //For each item in the newCodeLines
                var matchedLines = oldCode.CodeLines.Select(n => compareLines(n, newCodeLines.ElementAt(i)));
                if (matchedLines.Count() != 0)
                {
                    numOfMods++;
                    newCodeLines.RemoveAt(i); // remove the modified line so we don't count it again.
                }

            }
            return numOfMods;
        }


        //var delAndModLines = oldCodeLines.Except(newCodeLines);
        //create the returnvalue here:
        //List<string> modifiedLines = new List<string>();
        //oldCodeLines = delAndModLines.ToList<String>();
        //Felt like using old-style loop here.
        //for (int i = 0; i < delAndModLines.Count(); i++)
        //{
        //    bool matchedLine = false; // only one match allowed.
        //    int j = 0; // Inner loop goes through all of the new lines of code - except for the ones that have been matched.
        //    while(j < newCodeLines.Count && !matchedLine)
        //    {
        //        if (compareLines(delAndModLines.ElementAt(i), newCodeLines[j])) // outsourced the comparison of individual lines to a method
        //        {
        //            matchedLine = true;
        //            modifiedLines.Add(oldCodeLines[i]);
        //            oldCodeLines.RemoveAt(i);
        //            newCodeLines.RemoveAt(j);
        //        }
        //        j++;
        //    }
        //    //remove the stuff from the old code lines:

        //}
        ////return modifiedLines;




        private void processCode()
        { //compare the codes.
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


            //Next find the modifiedLines of code:
            mLOC = countModifiedLines(newLines.ToList());
            addedLOC = newLinesStack.Count - mLOC;
            delLOC = delLinesStack.Count - mLOC;

        }
        private void modifiedFinder()
        {

        }
        /*
        //compare the codes.
        System.Collections.Stack newLinesStack = new System.Collections.Stack();
        System.Collections.Stack delLinesStack = new System.Collections.Stack();
        List<string> oldCodeLines = oldCode.CodeLines;
        List<string> newCodeLines = newCode.CodeLines;
        //Step one. Remove matching lines of code from new lines of code. The resulting set, R2 - R1 = RAdded/Modified.

        var addedModifiedLines = newCodeLines.Except(oldCodeLines);
            
            
        //Next, we check to see if the lines in the old code match the lines in the new code. If they do, then remove them.
        //try this without using the method I wrote previously.



        List<string> modifiedLines = new List<string>();
        for (int i = 0; i < addedModifiedLines.Count(); i++)
        {
            var tR = comparisonAlgorithm.BatchCompareSet(oldCodeLines.ToArray(), addedModifiedLines.ElementAt(i));
            System.Console.WriteLine("Result -- " + tR);  
        }
           
        //var resultBatch = comparisonAlgorithm.BatchCompareSet(oldCode.CodeLines.ToArray(), newCode.CodeLines.ToArray());
        //Console.WriteLine(resultBatch);


        var adTmp = newCodeLines.Except(oldCodeLines);
        var dlTmp= oldCodeLines.Except(newCodeLines);

        var newLines = adTmp.ToList();
        var delLines = dlTmp.ToList();
            

            
        foreach (var item in oldCodeLines)
        {
            delLinesStack.Push(item);
        }
        var tempOldCodeLines = oldCode.CodeLines;
        foreach (var item in newLines)
        {
            if (!tempOldCodeLines.Contains(item))
                newLinesStack.Push(item);
        }
        addedLOC = newLinesStack.Count;
            
        //delLOC = delLinesStack.Count;
            
        mLOC = modifiedLines.Count;
        delLOC = oldCode.LinesOfCode - (addedLOC + mLOC); 
    }*/

    }
    public struct CompareTool
    {
        public double similarity;
        public string line1, line2;
        public SimMetricsApi.AbstractStringMetric metricAlgorithm;

        public CompareTool(string line1, string line2, SimMetricsApi.AbstractStringMetric metricAlgorithm)
        {
            this.line1 = line1;
            this.line2 = line2;
            this.metricAlgorithm = metricAlgorithm;
            similarity = 0;
        }
        public void doCompare()
        {
            similarity = metricAlgorithm.GetSimilarity(line1, line2);
        }
    }

}
