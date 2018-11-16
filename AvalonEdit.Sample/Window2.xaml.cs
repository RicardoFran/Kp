using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml;
using AvalonEdit.Sample;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Kp;
using Microsoft.Win32;

namespace AvalonEdit.Sample
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void btn_bat_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".bat";
            ofd.Filter = "Text Document (.bat)|*.bat*";
            if (ofd.ShowDialog() == true)
            {
                string file = ofd.FileName;
                txtBox_BatFile.Text = file;
            }
        }

        private void btn_FileInput2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() ?? false)
            {
                string currentFileName = dlg.FileName;
                txtBox_FileInput2.Text = currentFileName;
            }
        }

        private void btn_FileInput1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() ?? false)
            {
                string currentFileName = dlg.FileName;
                txtBox_FileInput1.Text = currentFileName;
            }
        }

        private void questionButton_FileInput1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Upload the first file for plagiarism proofing", "Upload", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
        }

        private void questionButton_FileInput2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Upload the second file for plagiarism proofing", "Upload", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
        }

        private void questionButton_BatFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Upload the .bat file for plagiarism algorithm.\nWith the output format : \n[Token],[Token Line],[Token Index]\nFollowed by :\nHasil match (posisi awal s1, posisi awal s2, jumlah token sama):\n[s1],[s2],[jumlah token]", "Upload", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1(txtBox_FileInput1.Text, txtBox_FileInput2.Text, txtBox_BatFile.Text);
            win1.Show();
            this.Close();
        }
    }
}
