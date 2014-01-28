namespace CodeCounterLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Text;
    //  using IronRuby;
    //  using IronRuby.Runtime;
    // using Microsoft.Scripting;
    //using Microsoft.Scripting.Hosting;
    //  using Microsoft.Scripting.Hosting.Providers;
    using SERFS;
    using BooLibs;
    using System.Text.RegularExpressions;
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
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using CodeCounterLibrary;



namespace GraphicalInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread code1Thread;
        Thread code2Thread;
        private CodeCounterLibrary.CodeText code1;
        private CodeCounterLibrary.CodeText code2;
        public MainWindow()
        {
            this.InitializeComponent();
        }
        private void btnLoadFile1_Click(object sender, RoutedEventArgs e)
        {
            string code = loadFile();
            txtCode.Text = code;
            code1 = new CodeCounterLibrary.CodeText(code);
            this.checkLoaded();

        }
        private void btnLoadFileTwo_Click(object sender, RoutedEventArgs e)
        {
            string code = loadFile();
            codeText2.Text = code;
            code2 = new CodeCounterLibrary.CodeText(code);
            this.checkLoaded();
        }
        private void checkLoaded()
        {
            if ((txtCode.Text.Count() > 5 && codeText2.Text.Count() > 5))
            {
                loadedFile.IsChecked = true;
                var sb = (Storyboard)this.FindResource("unBlurBoard");
                sb.Begin();
                // gridAnalyzingCode.IsEnabled = true;
                btn_removeComments.IsEnabled = true;
            }
            else
            {
                if (loadedFile.IsChecked == true)
                {
                    var sb = (Storyboard)this.FindResource("blurBoard");
                    sb.Begin();
                    loadedFile.IsChecked = false;
                    //   gridAnalyzingCode.IsEnabled = false;
                }

            }
        }
        /// <summary>
        /// Loads a file into a string.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string loadFile()
        {
            System.Windows.Forms.OpenFileDialog filedlg = new System.Windows.Forms.OpenFileDialog();
            filedlg.Filter = "cs code (*.cs) | *.cs";
            filedlg.Multiselect = false;
            string lines = "ER";
            if (filedlg.ShowDialog() == (System.Windows.Forms.DialogResult.OK))
            {
                try
                {
                    lines = File.ReadAllText(filedlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return lines;
        }
        private void multiThreadCodeCount()
        {
            code1Thread = new Thread(new ThreadStart(code1.countLines));
            code2Thread = new Thread(new ThreadStart(code2.countLines));
            code1Thread.Start();
            code2Thread.Start();
            while (!code1Thread.IsAlive) ;
            while (!code2Thread.IsAlive) ;
            code1Thread.Join();
            code2Thread.Join();
        }
        private void CodeCount()
        {
            code1.countLines();
            code2.countLines();
        }
        private void btn_removeComments_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtCode.Text.Length > 10 && codeText2.Text.Length > 10)
            {

               Thread counter = new Thread(new ThreadStart(this.multiThreadCodeCount));
                counter.Start();
                while (!counter.IsAlive) ;
                counter.Join();
                txtCode.Text = code1.ReadCodeText;
                codeText2.Text = code2.ReadCodeText;
                //Prevent multi-use.
                btn_removeComments.IsEnabled = false;
                btnCompareCode.IsEnabled = true;

            }
            else
            {
                MessageBox.Show("Error, plz load files into both");
            }
        }

        private void btnCompareCode_Click(object sender, RoutedEventArgs e)
        {
            CodeComparison comp = new CodeComparison(code1, code2);
            textBaseCode.Text = "";
            textBaseCode.Inlines.Add(new Bold(new Run("Original Lines of Code: ")));
            textBaseCode.Inlines.Add(new Run(txtCode.LineCount.ToString()));
            textAddedCode.Text = "";
            textAddedCode.Inlines.Add(new Bold(new Run("Added Lines of Code: ")));
            textAddedCode.Inlines.Add(new Run(comp.newLOC.ToString()));
            textDeletedCode.Text = "";
            textDeletedCode.Inlines.Add(new Bold(new Run("Deleted Lines of Code: ")));
            textDeletedCode.Inlines.Add(new Run(comp.deletedLOC.ToString()));
            textDeletedCode.Inlines.Add(new Bold(new Run("\nTotal Lines of Code: ")));
            textDeletedCode.Inlines.Add(new Run(codeText2.LineCount.ToString()));

            btnCompareCode.IsEnabled = false;
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }
    }
}

