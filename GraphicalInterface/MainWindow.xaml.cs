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
            if((txtCode.Text.Count() > 5 && codeText2.Text.Count() > 5))
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
            //txtCode.Text = "Processing";
            //codeText2.Text = "Processing";


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
                
                //code1.countLines();
                //multiThreadCodeCount();

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

