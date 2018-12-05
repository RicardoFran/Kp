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
using PlagiarismObserver;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;

namespace Kp
{
    public partial class Window1 : Window
    {
        private string[] arrayTextEditor1;
        private string[] arrayTextEditor2;
        private string[] arrayLineString1;
        private string[] arrayLineString2;
        private string[] arrayColorLine;
        private string[] arrayColorBox1;
        private string[] arrayColorBox2;
        private string[] arrayHasilMatchTuple;
        private int[] arrayLine1;
        private int[] arrayIndex1;
        private int[] arrayLine2;
        private int[] arrayIndex2;
        private string[] isiListBox;
        private string[,] matrikstuple;
        private string[] listselected;
        private bool reset = false;
        private OffsetColorizer[] arrayColorTuple1;
        private OffsetColorizer[] arrayColorTuple2;
        private DocumentLine lineSTART;
        private DocumentLine lineEND;

        public Window1()
        {
            // Load our custom highlighting definition
            IHighlightingDefinition customHighlighting;
            using (Stream s = typeof(Window1).Assembly.GetManifestResourceStream("PlagiarismObserver.CustomHighlighting.xshd"))
            {
                if (s == null)
                    throw new InvalidOperationException("Could not find embedded resource");
                using (XmlReader reader = new XmlTextReader(s))
                {
                    customHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.
                        HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
            // and register it in the HighlightingManager
            HighlightingManager.Instance.RegisterHighlighting("Custom Highlighting", new string[] { ".cool" }, customHighlighting);


            InitializeComponent();


            TextEditor_1.TextArea.TextEntering += textEditor_TextArea_TextEntering;

            TextEditor_2.TextArea.TextEntering += textEditor_TextArea_TextEntering;

            DispatcherTimer foldingUpdateTimer1 = new DispatcherTimer();
            foldingUpdateTimer1.Interval = TimeSpan.FromSeconds(2);
            foldingUpdateTimer1.Tick += foldingUpdateTimer_Tick1;
            foldingUpdateTimer1.Start();

            DispatcherTimer foldingUpdateTimer2 = new DispatcherTimer();
            foldingUpdateTimer2.Interval = TimeSpan.FromSeconds(2);
            foldingUpdateTimer2.Tick += foldingUpdateTimer_Tick2;
            foldingUpdateTimer2.Start();

            #region arraycolor
            arrayColorLine = new string[51];
            arrayColorBox2 = new string[51];
            arrayColorLine[0] = "#a67c00";
            arrayColorLine[1] = "#f08080";
            arrayColorLine[2] = "#ffbf00";
            arrayColorLine[3] = "#ff6666";
            arrayColorLine[4] = "#b3ecec";
            arrayColorLine[5] = "#ff7f50";
            arrayColorLine[6] = "#43e8d8";
            arrayColorLine[7] = "#fe5757";
            arrayColorLine[8] = "#fe8181";
            arrayColorLine[9] = "#77ab59";
            arrayColorLine[10] = "#c9df8a";
            arrayColorLine[11] = "#ffa500";
            arrayColorLine[12] = "#00ff00";
            arrayColorLine[13] = "#c0d6e4";
            arrayColorLine[14] = "#ffff66";
            arrayColorLine[15] = "#ccff00";
            arrayColorLine[16] = "#81d8d0";
            arrayColorLine[17] = "#ff4040";
            arrayColorLine[18] = "#ff7f50";
            arrayColorLine[19] = "#c39797";
            arrayColorLine[20] = "#ffc0cb";
            arrayColorLine[21] = "#bada55";
            arrayColorLine[22] = "#00ced1";
            arrayColorLine[23] = "#d9534f";
            arrayColorLine[24] = "#caff70";
            arrayColorLine[25] = "#ff8c00";
            arrayColorLine[26] = "#c1ffc1";
            arrayColorLine[27] = "#97ffff";
            arrayColorLine[28] = "#cdcdc1";
            arrayColorLine[29] = "#ffa07a";
            arrayColorLine[30] = "#87cefa";
            arrayColorLine[31] = "#00fa9a";
            arrayColorLine[32] = "#b3ee3a";
            arrayColorLine[33] = "#ff4500";
            arrayColorLine[34] = "#98fb98";
            arrayColorLine[35] = "#436eee";
            arrayColorLine[36] = "#836fff";
            arrayColorLine[37] = "#63b8ff";
            arrayColorLine[38] = "#ee82ee";
            arrayColorLine[39] = "#eeee00";
            arrayColorLine[40] = "#00ff7f";
            arrayColorLine[41] = "#ee7942";
            arrayColorLine[42] = "#ffefd5";
            arrayColorLine[43] = "#ffa500";
            arrayColorLine[44] = "#00fa9a";
            arrayColorLine[45] = "#b0c4de";
            arrayColorLine[46] = "#ffa07a";
            arrayColorLine[47] = "#ffec8b";
            arrayColorLine[48] = "#ff6a6a";
            arrayColorLine[49] = "#00ff00";
            arrayColorLine[50] = "#ff7f00";
            #endregion
        }
        CompletionWindow completionWindow;
        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // do not set e.Handled=true - we still want to insert the character that was typed
        }

        #region Folding
        FoldingManager foldingManager1;
        AbstractFoldingStrategy foldingStrategy1;

        FoldingManager foldingManager2;
        AbstractFoldingStrategy foldingStrategy2;

        void HighlightingComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            if (TextEditor_1.SyntaxHighlighting == null)
            {
                foldingStrategy1 = null;
            }
            else
            {
                switch (TextEditor_1.SyntaxHighlighting.Name)
                {
                    case "XML":
                        foldingStrategy1 = new XmlFoldingStrategy();
                        TextEditor_1.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                        break;
                    case "C#":
                    case "C++":
                    case "PHP":
                    case "Java":
                        TextEditor_1.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(TextEditor_1.Options);
                        foldingStrategy1 = new BraceFoldingStrategy();
                        break;
                    default:
                        TextEditor_1.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                        foldingStrategy1 = null;
                        break;
                }
            }
            if (foldingStrategy1 != null)
            {
                if (foldingManager1 == null)
                    foldingManager1 = FoldingManager.Install(TextEditor_1.TextArea);
                foldingStrategy1.UpdateFoldings(foldingManager1, TextEditor_1.Document);
            }
            else
            {
                if (foldingManager1 != null)
                {
                    FoldingManager.Uninstall(foldingManager1);
                    foldingManager1 = null;
                }
            }
        }
        void HighlightingComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            if (TextEditor_2.SyntaxHighlighting == null)
            {
                foldingStrategy2 = null;
            }
            else
            {
                switch (TextEditor_2.SyntaxHighlighting.Name)
                {
                    case "XML":
                        foldingStrategy2 = new XmlFoldingStrategy();
                        TextEditor_2.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                        break;
                    case "C#":
                    case "C++":
                    case "PHP":
                    case "Java":
                        TextEditor_2.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(TextEditor_2.Options);
                        foldingStrategy2 = new BraceFoldingStrategy();
                        break;
                    default:
                        TextEditor_2.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
                        foldingStrategy2 = null;
                        break;
                }
            }
            if (foldingStrategy2 != null)
            {
                if (foldingManager2 == null)
                    foldingManager2 = FoldingManager.Install(TextEditor_2.TextArea);
                foldingStrategy2.UpdateFoldings(foldingManager2, TextEditor_2.Document);
            }
            else
            {
                if (foldingManager2 != null)
                {
                    FoldingManager.Uninstall(foldingManager2);
                    foldingManager2 = null;
                }
            }
        }
        void foldingUpdateTimer_Tick1(object sender, EventArgs e)
        {
            if (foldingStrategy1 != null)
            {
                foldingStrategy1.UpdateFoldings(foldingManager1, TextEditor_1.Document);
            }
        }
        void foldingUpdateTimer_Tick2(object sender, EventArgs e)
        {
            if (foldingStrategy2 != null)
            {
                foldingStrategy2.UpdateFoldings(foldingManager2, TextEditor_2.Document);
            }
        }
        #endregion

        #region TextEditor 1 & 2
        private void TextEditor_1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextEditor_1.Text))
            {
                TotalLine_TextEditor1.Content = TextEditor_1.Document.LineCount;
            }
            else if (string.IsNullOrEmpty(TextEditor_1.Text))
            {
                TotalLine_TextEditor1.Content = "";
            }
        }
        private void TextEditor_2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextEditor_2.Text))
            {
                TotalLine_TextEditor2.Content = TextEditor_2.Document.LineCount;
            }
            else if (string.IsNullOrEmpty(TextEditor_2.Text))
            {
                TotalLine_TextEditor2.Content = "";
            }
        }
        private void TextEditor_1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MulticolorCheckBox.IsChecked == true)
            {
                FullColorizeTextEditorFull();
            }
            else
            {
                ColorizeTextEditorFull();
            }
            DocumentLine line = TextEditor_1.Document.GetLineByOffset(TextEditor_1.CaretOffset);
            for (int i = isiListBox.Length - 1; i >= 0; i--)
            {
                lineSTART = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                lineEND = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);
                if (line.LineNumber <= lineEND.LineNumber && line.LineNumber >= lineSTART.LineNumber)
                {
                    if (TextEditor_1.CaretOffset <= lineEND.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length && TextEditor_1.CaretOffset >= lineSTART.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0])])
                    {
                        #region ColorizeSelectedMatchTuple
                        DocumentLine lineSTART1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                        DocumentLine lineEND1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                        OffsetColorizer ColorTuple1 = new OffsetColorizer();
                        TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple1);
                        ColorTuple1.StartOffset = lineSTART1.Offset - 1;
                        ColorTuple1.EndOffset = lineEND1.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                        ColorTuple1.R = Convert.ToByte("#6666ff".Substring(1, 2), 16);
                        ColorTuple1.G = Convert.ToByte("#6666ff".Substring(3, 2), 16);
                        ColorTuple1.B = Convert.ToByte("#6666ff".Substring(5, 2), 16);

                        OffsetColorizer ColorTuple2 = new OffsetColorizer();
                        TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple2);
                        ColorTuple2.StartOffset = lineSTART1.Offset - 1;
                        ColorTuple2.EndOffset = lineSTART1.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0])];
                        ColorTuple2.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                        ColorTuple2.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                        ColorTuple2.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);

                        DocumentLine lineSTART2 = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                        DocumentLine lineEND2 = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                        OffsetColorizer ColorTuple3 = new OffsetColorizer();
                        TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTuple3);
                        ColorTuple3.StartOffset = lineSTART2.Offset - 1;
                        ColorTuple3.EndOffset = lineEND2.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                        ColorTuple3.R = Convert.ToByte("#6666ff".Substring(1, 2), 16);
                        ColorTuple3.G = Convert.ToByte("#6666ff".Substring(3, 2), 16);
                        ColorTuple3.B = Convert.ToByte("#6666ff".Substring(5, 2), 16);

                        OffsetColorizer ColorTuple4 = new OffsetColorizer();
                        TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTuple4);
                        ColorTuple4.StartOffset = lineSTART2.Offset - 1;
                        ColorTuple4.EndOffset = lineSTART2.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1])];
                        ColorTuple4.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                        ColorTuple4.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                        ColorTuple4.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                        #endregion
                        ListBoxMatchTuple.SelectedItem = matrikstuple[i, 0] + ":" + matrikstuple[i, 1] + ":" + matrikstuple[i, 2];
                        TextEditor_2.ScrollToLine(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                        break;
                    }
                }
            }
        }
        private void TextEditor_2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MulticolorCheckBox.IsChecked == true)
            {
                FullColorizeTextEditorFull();
            }
            else
            {
                ColorizeTextEditorFull();
            }
            DocumentLine line = TextEditor_2.Document.GetLineByOffset(TextEditor_2.CaretOffset);
            for (int i = isiListBox.Length - 1; i >= 0; i--)
            {
                lineSTART = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                lineEND = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);
                if (line.LineNumber <= lineEND.LineNumber && line.LineNumber >= lineSTART.LineNumber)
                {
                    if (TextEditor_2.CaretOffset <= lineEND.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length && TextEditor_2.CaretOffset >= lineSTART.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1])])
                    {
                        #region Colorize SelectedMatchTuple
                        DocumentLine lineSTART1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                        DocumentLine lineEND1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                        OffsetColorizer ColorTuple1 = new OffsetColorizer();
                        TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple1);
                        ColorTuple1.StartOffset = lineSTART1.Offset - 1;
                        ColorTuple1.EndOffset = lineEND1.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                        ColorTuple1.R = Convert.ToByte("#6666ff".Substring(1, 2), 16);
                        ColorTuple1.G = Convert.ToByte("#6666ff".Substring(3, 2), 16);
                        ColorTuple1.B = Convert.ToByte("#6666ff".Substring(5, 2), 16);

                        OffsetColorizer ColorTuple2 = new OffsetColorizer();
                        TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple2);
                        ColorTuple2.StartOffset = lineSTART1.Offset - 1;
                        ColorTuple2.EndOffset = lineSTART1.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0])];
                        ColorTuple2.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                        ColorTuple2.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                        ColorTuple2.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);

                        DocumentLine lineSTART2 = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                        DocumentLine lineEND2 = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                        OffsetColorizer ColorTuple3 = new OffsetColorizer();
                        TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTuple3);
                        ColorTuple3.StartOffset = lineSTART2.Offset - 1;
                        ColorTuple3.EndOffset = lineEND2.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                        ColorTuple3.R = Convert.ToByte("#6666ff".Substring(1, 2), 16);
                        ColorTuple3.G = Convert.ToByte("#6666ff".Substring(3, 2), 16);
                        ColorTuple3.B = Convert.ToByte("#6666ff".Substring(5, 2), 16);

                        OffsetColorizer ColorTuple4 = new OffsetColorizer();
                        TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTuple4);
                        ColorTuple4.StartOffset = lineSTART2.Offset - 1;
                        ColorTuple4.EndOffset = lineSTART2.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1])];
                        ColorTuple4.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                        ColorTuple4.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                        ColorTuple4.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                        #endregion
                        ListBoxMatchTuple.SelectedItem = matrikstuple[i, 0] + ":" + matrikstuple[i, 1] + ":" + matrikstuple[i, 2];
                        TextEditor_1.ScrollToLine(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                        break;
                    }
                }
            }
        }
        #endregion
        private void ListBoxMatchTuple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (reset == true)
            {
            }
            else
            {
                if (MulticolorCheckBox.IsChecked == true)
                {
                    FullColorizeTextEditorFull();
                }
                else
                {
                    ColorizeTextEditorFull();
                }
                #region ColorizeFromListBoxSelection
                OffsetColorizer ColorTuple1 = new OffsetColorizer();
                OffsetColorizer ColorTuple2 = new OffsetColorizer();
                OffsetColorizer ColorTuple3 = new OffsetColorizer();
                OffsetColorizer ColorTuple4 = new OffsetColorizer();

                listselected = ListBoxMatchTuple.SelectedItem.ToString().Split(':');
                DocumentLine lineSTART1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(listselected[0])]);
                DocumentLine lineEND1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(listselected[0]) + Convert.ToInt32(listselected[2]) - 1]);

                ColorTuple1 = new OffsetColorizer();
                TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple1);
                ColorTuple1.StartOffset = lineSTART1.Offset - 1;
                ColorTuple1.EndOffset = lineEND1.Offset + arrayIndex1[Convert.ToInt32(listselected[0]) + Convert.ToInt32(listselected[2]) - 1] + arrayLineString1[Convert.ToInt32(listselected[0]) + Convert.ToInt32(listselected[2]) - 1].Length;
                ColorTuple1.R = Convert.ToByte("#6666ff".Substring(1, 2), 16);
                ColorTuple1.G = Convert.ToByte("#6666ff".Substring(3, 2), 16);
                ColorTuple1.B = Convert.ToByte("#6666ff".Substring(5, 2), 16);

                ColorTuple2 = new OffsetColorizer();
                TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple2);
                ColorTuple2.StartOffset = lineSTART1.Offset - 1;
                ColorTuple2.EndOffset = lineSTART1.Offset + arrayIndex1[Convert.ToInt32(listselected[0])];
                ColorTuple2.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                ColorTuple2.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                ColorTuple2.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);

                TextEditor_1.ScrollToLine(lineSTART1.LineNumber);

                DocumentLine lineSTART2 = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(listselected[1])]);
                DocumentLine lineEND2 = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(listselected[1]) + Convert.ToInt32(listselected[2]) - 1]);

                ColorTuple3 = new OffsetColorizer();
                TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTuple3);
                ColorTuple3.StartOffset = lineSTART2.Offset - 1;
                ColorTuple3.EndOffset = lineEND2.Offset + arrayIndex2[Convert.ToInt32(listselected[1]) + Convert.ToInt32(listselected[2]) - 1] + arrayLineString2[Convert.ToInt32(listselected[1]) + Convert.ToInt32(listselected[2]) - 1].Length;
                ColorTuple3.R = Convert.ToByte("#6666ff".Substring(1, 2), 16);
                ColorTuple3.G = Convert.ToByte("#6666ff".Substring(3, 2), 16);
                ColorTuple3.B = Convert.ToByte("#6666ff".Substring(5, 2), 16);

                ColorTuple4 = new OffsetColorizer();
                TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTuple4);
                ColorTuple4.StartOffset = lineSTART2.Offset - 1;
                ColorTuple4.EndOffset = lineSTART2.Offset + arrayIndex2[Convert.ToInt32(listselected[1])];
                ColorTuple4.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                ColorTuple4.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                ColorTuple4.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                #endregion
                TextEditor_2.ScrollToLine(lineSTART2.LineNumber);
            }
        }

        #region Button
        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo(txtBox_BatFile.Text);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;

            var p = Process.Start(psi);
            p.StandardInput.WriteLine(txtBox_FileInput1.Text);
            p.StandardInput.WriteLine(txtBox_FileInput2.Text);
            string hasil = p.StandardOutput.ReadToEnd();

            #region arrayTextEditor1 & TextEditor2
            string[] array1 = new string[hasil.Length];
            array1 = hasil.Split('\n');
            string[] array2 = new string[array1.Length];
            int j = 2;
            for (int i = 0; i < array2.Length - 5; i++)
            {
                array2[i] = array1[j];
                j++;

            }
            arrayTextEditor1 = new string[array2.Length];
            int counterTextEditor = 0;
            arrayTextEditor1[0] = array2[0];
            for (int i = 0; i < array2.Length; i++)
            {
                counterTextEditor = i;
                if (array2[i].Contains("=EndOfFile="))
                {
                    break;
                }
                else
                {
                    arrayTextEditor1[i] = array2[i];
                }
            }
            counterTextEditor += 1;
            arrayTextEditor2 = new string[array2.Length];
            for (int i = 0; i < array2.Length; i++)
            {
                if (array2[counterTextEditor] == null)
                {
                    break;
                }
                else
                {
                    arrayTextEditor2[i] = array2[counterTextEditor];
                    counterTextEditor++;
                }
            }
            #endregion
            #region MatchTuple
            arrayHasilMatchTuple = new string[array2.Length];
            arrayHasilMatchTuple[0] = array1[array1.Length - 3];
            for (int i = 0; i < array2.Length; i++)
            {
                if (arrayTextEditor1[i] == null)
                {
                    break;
                }
                else if (arrayTextEditor1[i] != null)
                {
                    arrayTextEditor1[i] = arrayTextEditor1[i].Replace("\n", String.Empty);
                    arrayTextEditor1[i] = arrayTextEditor1[i].Replace("\r", String.Empty);
                    arrayTextEditor1[i] = arrayTextEditor1[i].Replace("\t", String.Empty);
                }
            }
            for (int i = 0; i < array2.Length; i++)
            {
                if (arrayTextEditor2[i] == null)
                {
                    break;
                }
                else if (arrayTextEditor2[i] != null)
                {
                    arrayTextEditor2[i] = arrayTextEditor2[i].Replace("\n", String.Empty);
                    arrayTextEditor2[i] = arrayTextEditor2[i].Replace("\r", String.Empty);
                    arrayTextEditor2[i] = arrayTextEditor2[i].Replace("\t", String.Empty);
                }
            }

            #endregion
            #region array line + index
            string[] arrayLineIndex1 = new string[arrayTextEditor1.Length];
            arrayLineString1 = new string[arrayTextEditor1.Length];
            arrayLine1 = new int[arrayLineIndex1.Length];
            arrayIndex1 = new int[arrayLineIndex1.Length];
            for (int i = 0; i < arrayTextEditor1.Length; i++)
            {
                if (arrayTextEditor1[i] == "=EndOfFile=")
                {
                    break;
                }
                else if (arrayTextEditor1[i] == "=EndOfString=")
                {
                    int counterString1 = 0;
                    int counterString2 = 0;
                    for (counterString1 = i + 1; counterString1 < arrayTextEditor1.Length; counterString1++)
                    {
                        if (arrayTextEditor1[counterString1] == "=EndOfLine=")
                        {
                            i = counterString1 - 1;
                            break;
                        }
                        else
                        {
                            arrayLine1[counterString2] = Convert.ToInt32(arrayTextEditor1[counterString1]);
                            counterString2++;
                        }
                    }
                }
                else if (arrayTextEditor1[i] == "=EndOfLine=")
                {
                    int counterString1 = 0;
                    int counterString2 = 0;
                    for (counterString1 = i + 1; counterString1 < arrayTextEditor1.Length; counterString1++)
                    {
                        if (arrayTextEditor1[counterString1] == "=EndOfFile=")
                        {
                            i = counterString1;
                            break;
                        }
                        else
                        {
                            arrayIndex1[counterString2] = Convert.ToInt32(arrayTextEditor1[counterString1]);
                            counterString2++;
                        }
                    }
                }
                else
                {
                    arrayLineString1[i] = arrayTextEditor1[i];
                }
            }


            string[] arrayLineIndex2 = new string[arrayTextEditor2.Length];
            arrayLine2 = new int[arrayTextEditor2.Length];
            arrayLineString2 = new string[arrayTextEditor2.Length];
            arrayIndex2 = new int[arrayTextEditor2.Length];
            for (int i = 0; i < arrayTextEditor2.Length; i++)
            {
                if (arrayTextEditor2[i] == "=EndOfFile=")
                {
                    break;
                }
                else if (arrayTextEditor2[i] == "=EndOfString=")
                {
                    int counterString1 = 0;
                    int counterString2 = 0;
                    for (counterString1 = i + 1; counterString1 < arrayTextEditor2.Length; counterString1++)
                    {
                        if (arrayTextEditor2[counterString1] == "=EndOfLine=")
                        {
                            i = counterString1 - 1;
                            break;
                        }
                        else
                        {
                            arrayLine2[counterString2] = Convert.ToInt32(arrayTextEditor2[counterString1]);
                            counterString2++;
                        }
                    }
                }
                else if (arrayTextEditor2[i] == "=EndOfLine=")
                {
                    int counterString1 = 0;
                    int counterString2 = 0;
                    for (counterString1 = i + 1; counterString1 < arrayTextEditor2.Length; counterString1++)
                    {
                        if (arrayTextEditor2[counterString1] == "=EndOfFile=")
                        {
                            i = counterString1;
                            break;
                        }
                        else
                        {
                            arrayIndex2[counterString2] = Convert.ToInt32(arrayTextEditor2[counterString1]);
                            counterString2++;
                        }
                    }
                }
                else
                {
                    arrayLineString2[i] = arrayTextEditor2[i];
                }
            }
            #endregion
            #region matrikstuple
            arrayHasilMatchTuple[0] = arrayHasilMatchTuple[0].Replace("[", String.Empty);
            arrayHasilMatchTuple[0] = arrayHasilMatchTuple[0].Replace("]", String.Empty);
            isiListBox = arrayHasilMatchTuple[0].Split(',');
            for (int i = 0; i < isiListBox.Length; i++)
            {
                isiListBox[i] = isiListBox[i].Replace("\t", String.Empty);
                isiListBox[i] = isiListBox[i].Replace("\n", String.Empty);
                isiListBox[i] = isiListBox[i].Replace("\r", String.Empty);
                isiListBox[i] = isiListBox[i].Replace(" ", String.Empty);
            }
            if (isiListBox == null)
            {
                isiListBox[0] = arrayHasilMatchTuple[0];
            }
            ListBoxMatchTuple.ItemsSource = isiListBox;
            matrikstuple = new string[isiListBox.Length, 3];
            for (int i = 0; i < isiListBox.Length; i++)
            {
                string[] tuple = isiListBox[i].Split(':');
                for (int k = 0; k < 3; k++)
                {
                    matrikstuple[i, k] = tuple[k];
                    matrikstuple[i, k] = matrikstuple[i, k].Replace("\t", String.Empty);
                    matrikstuple[i, k] = matrikstuple[i, k].Replace("\n", String.Empty);
                    matrikstuple[i, k] = matrikstuple[i, k].Replace("\r", String.Empty);
                    matrikstuple[i, k] = matrikstuple[i, k].Replace(" ", String.Empty);
                }
            }
            #endregion

            if (MulticolorCheckBox.IsChecked == true)
            {
                FullColorizeTextEditorFull();
            }
            else
            {
                ColorizeTextEditorFull();
            }
            reset_button.IsEnabled = true;
        }
        private void Button_Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".bat";
            ofd.Filter = "Text Document (.bat)|*.bat*";
            if (ofd.ShowDialog() == true)
            {
                string file = ofd.FileName;
                txtBox_BatFile.Text = file;
            }
            CekInput();
        }
        private void reset_button_Click(object sender, RoutedEventArgs e)
        {
            if(MulticolorCheckBox.IsChecked==true)
            {
                FullColorizeTextEditorFull();
            }
            else
            {
                ColorizeTextEditorFull();
            }
            TextEditor_1.ScrollToHome();
            TextEditor_2.ScrollToHome();
            reset = true;
            ListBoxMatchTuple.UnselectAll();
            reset = false;
        }
        private void btn_FileInput2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() ?? false)
            {
                if (!string.IsNullOrEmpty(TextEditor_2.Text))
                {
                    arrayTextEditor1 = null;
                    arrayTextEditor2 = null;
                    arrayLineString1 = null;
                    arrayLineString2 = null;
                    arrayHasilMatchTuple = null;
                    arrayLine1 = null;
                    arrayIndex1 = null;
                    arrayLine2 = null;
                    arrayIndex2 = null;
                    isiListBox = null;
                    matrikstuple = null;
                    listselected = null;
                    reset = true;
                    ListBoxMatchTuple.UnselectAll();
                    ListBoxMatchTuple.ItemsSource = isiListBox;
                    reset = false;

                }
                string currentFileName = dlg.FileName;
                txtBox_FileInput2.Text = currentFileName;

                TextEditor_2.Load(txtBox_FileInput2.Text);

                if (string.IsNullOrEmpty(TextEditor_2.Text))
                {
                    MessageBox.Show(".java file must not be empty !", "Error", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                    txtBox_FileInput2.Text = null;
                }
                else
                {
                    TextEditor_2.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(txtBox_FileInput2.Text));
                    TextEditor_2.ShowLineNumbers = true;

                    DocumentLine lineSTART1 = TextEditor_2.Document.GetLineByNumber(1);
                    DocumentLine lineEND1 = TextEditor_2.Document.GetLineByNumber(TextEditor_2.Document.LineCount);
                    OffsetColorizer ColorTupleInput1 = new OffsetColorizer();
                    ColorTupleInput1 = new OffsetColorizer();
                    TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTupleInput1);
                    ColorTupleInput1.StartOffset = lineSTART1.Offset;
                    ColorTupleInput1.EndOffset = lineEND1.EndOffset;
                    ColorTupleInput1.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                    ColorTupleInput1.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                    ColorTupleInput1.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                }
            }
            CekInput();
        }
        private void btn_FileInput1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() ?? false)
            {
                if (!string.IsNullOrEmpty(TextEditor_1.Text))
                {
                    arrayTextEditor1 = null;
                    arrayTextEditor2 = null;
                    arrayLineString1 = null;
                    arrayLineString2 = null;
                    arrayHasilMatchTuple = null;
                    arrayLine1 = null;
                    arrayIndex1 = null;
                    arrayLine2 = null;
                    arrayIndex2 = null;
                    isiListBox = null;
                    matrikstuple = null;
                    listselected = null;
                    reset = true;
                    ListBoxMatchTuple.UnselectAll();
                    ListBoxMatchTuple.ItemsSource = isiListBox;
                    reset = false;
                }

                string currentFileName = dlg.FileName;
                txtBox_FileInput1.Text = currentFileName;

                TextEditor_1.Load(txtBox_FileInput1.Text);
                if (string.IsNullOrEmpty(TextEditor_1.Text))
                {
                    MessageBox.Show(".java file must not be empty !", "Error", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                    txtBox_FileInput1.Text = null;
                }
                else
                {
                    TextEditor_1.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(txtBox_FileInput1.Text));
                    TextEditor_1.ShowLineNumbers = true;

                    DocumentLine lineSTART1 = TextEditor_1.Document.GetLineByNumber(1);
                    DocumentLine lineEND1 = TextEditor_1.Document.GetLineByNumber(TextEditor_1.Document.LineCount);
                    OffsetColorizer ColorTupleInput1 = new OffsetColorizer();
                    ColorTupleInput1 = new OffsetColorizer();
                    TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTupleInput1);
                    ColorTupleInput1.StartOffset = lineSTART1.Offset;
                    ColorTupleInput1.EndOffset = lineEND1.EndOffset;
                    ColorTupleInput1.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                    ColorTupleInput1.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                    ColorTupleInput1.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                }

            }
            CekInput();
        }
        private void questionButton_FileInput1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Upload the first file for plagiarism proofing", "Upload", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
        }
        private void questionButton_FileInput2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Upload the second file for plagiarism proofing", "Upload", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
        }
        private void questionButton_BatFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Upload the .bat file for plagiarism algorithm.\nWith the output format : \n[Token] end with '=EndOfString='\n[Token Line]end with '=EndOfLine='\n[Token Index]end with '=EndOfFile='\nFollowed by :\n[s1],[s2],[jumlah token]", "Upload", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
        }
        #endregion

        #region Function
        public void FullColorizeTextEditorFull()
        {
            for (int i = 0; i < isiListBox.Length; i++)
            {
                string temp0;
                string temp1;
                string temp2;
                for (int k = 0; k < isiListBox.Length - 1; k++)
                {
                    if (matrikstuple[k, 0] == null)
                    {
                        break;
                    }
                    else
                    {
                        if (Convert.ToInt32(matrikstuple[k + 1, 0]) > Convert.ToInt32(matrikstuple[k, 0]))
                        {
                            temp0 = matrikstuple[k, 0];
                            temp1 = matrikstuple[k, 1];
                            temp2 = matrikstuple[k, 2];
                            matrikstuple[k, 0] = matrikstuple[k + 1, 0];
                            matrikstuple[k, 1] = matrikstuple[k + 1, 1];
                            matrikstuple[k, 2] = matrikstuple[k + 1, 2];

                            matrikstuple[k + 1, 0] = temp0;
                            matrikstuple[k + 1, 1] = temp1;
                            matrikstuple[k + 1, 2] = temp2;
                        }
                    }
                }
            }
            arrayColorTuple1 = new OffsetColorizer[isiListBox.Length * 2];
            arrayColorTuple2 = new OffsetColorizer[isiListBox.Length * 2];
            int counterarraycolorline = 0;
            int counterarraycolor = 1;
            for (int i = 0; i < isiListBox.Length; i++)
            {
                lineSTART = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                lineEND = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                arrayColorTuple1[i] = new OffsetColorizer();
                TextEditor_1.TextArea.TextView.LineTransformers.Add(arrayColorTuple1[i]);
                arrayColorTuple1[i].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple1[i].EndOffset = lineEND.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                arrayColorTuple1[i].R = Convert.ToByte(arrayColorLine[counterarraycolorline].Substring(1, 2), 16);
                arrayColorTuple1[i].G = Convert.ToByte(arrayColorLine[counterarraycolorline].Substring(3, 2), 16);
                arrayColorTuple1[i].B = Convert.ToByte(arrayColorLine[counterarraycolorline].Substring(5, 2), 16);

                arrayColorTuple1[counterarraycolor] = new OffsetColorizer();
                TextEditor_1.TextArea.TextView.LineTransformers.Add(arrayColorTuple1[counterarraycolor]);
                arrayColorTuple1[counterarraycolor].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple1[counterarraycolor].EndOffset = lineSTART.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0])];
                arrayColorTuple1[counterarraycolor].R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                arrayColorTuple1[counterarraycolor].G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                arrayColorTuple1[counterarraycolor].B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);

                arrayColorBox2[counterarraycolorline] = arrayColorLine[counterarraycolorline];
                counterarraycolor++;
                if (counterarraycolorline == 50)
                {
                    counterarraycolorline = 0;
                }
                counterarraycolorline++;
            }
            int tempcolorbox2 = 0;
            for (int i = 0; i < isiListBox.Length; i++)
            {
                string temp0;
                string temp1;
                string temp2;
                string temp3;
                for (int k = 0; k < isiListBox.Length - 1; k++)
                {
                    if (matrikstuple[k, 1] == null)
                    {
                        break;
                    }
                    else
                    {
                        if (Convert.ToInt32(matrikstuple[k + 1, 1]) > Convert.ToInt32(matrikstuple[k, 1]))
                        {
                            temp0 = matrikstuple[k, 0];
                            temp1 = matrikstuple[k, 1];
                            temp2 = matrikstuple[k, 2];
                            matrikstuple[k, 0] = matrikstuple[k + 1, 0];
                            matrikstuple[k, 1] = matrikstuple[k + 1, 1];
                            matrikstuple[k, 2] = matrikstuple[k + 1, 2];

                            matrikstuple[k + 1, 0] = temp0;
                            matrikstuple[k + 1, 1] = temp1;
                            matrikstuple[k + 1, 2] = temp2;

                            temp3 = arrayColorBox2[k];
                            arrayColorBox2[k] = arrayColorBox2[k + 1];
                            arrayColorBox2[k + 1] = temp3;
                        }
                    }
                }
            }
                counterarraycolorline = 0;
            int counterarraycolor2 = 1;
            for (int i = 0; i < isiListBox.Length; i++)
            {
                lineSTART = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                lineEND = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                arrayColorTuple2[i] = new OffsetColorizer();
                TextEditor_2.TextArea.TextView.LineTransformers.Add(arrayColorTuple2[i]);
                arrayColorTuple2[i].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple2[i].EndOffset = lineEND.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                arrayColorTuple2[i].R = Convert.ToByte(arrayColorBox2[counterarraycolorline].Substring(1, 2), 16);
                arrayColorTuple2[i].G = Convert.ToByte(arrayColorBox2[counterarraycolorline].Substring(3, 2), 16);
                arrayColorTuple2[i].B = Convert.ToByte(arrayColorBox2[counterarraycolorline].Substring(5, 2), 16);

                arrayColorTuple2[counterarraycolor2] = new OffsetColorizer();
                TextEditor_2.TextArea.TextView.LineTransformers.Add(arrayColorTuple2[counterarraycolor2]);
                arrayColorTuple2[counterarraycolor2].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple2[counterarraycolor2].EndOffset = lineSTART.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1])];
                arrayColorTuple2[counterarraycolor2].R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                arrayColorTuple2[counterarraycolor2].G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                arrayColorTuple2[counterarraycolor2].B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                counterarraycolor2++;
                if (counterarraycolorline == 50)
                {
                    counterarraycolorline = 0;
                }
                counterarraycolorline++;
            }
        }
        public void ColorizeTextEditorFull()
        {
            for (int i = 0; i < isiListBox.Length; i++)
            {
                string temp0;
                string temp1;
                string temp2;
                for (int k = 0; k < isiListBox.Length - 1; k++)
                {
                    if (matrikstuple[k, 0] == null)
                    {
                        break;
                    }
                    else
                    {
                        if (Convert.ToInt32(matrikstuple[k + 1, 0]) > Convert.ToInt32(matrikstuple[k, 0]))
                        {
                            temp0 = matrikstuple[k, 0];
                            temp1 = matrikstuple[k, 1];
                            temp2 = matrikstuple[k, 2];
                            matrikstuple[k, 0] = matrikstuple[k + 1, 0];
                            matrikstuple[k, 1] = matrikstuple[k + 1, 1];
                            matrikstuple[k, 2] = matrikstuple[k + 1, 2];

                            matrikstuple[k + 1, 0] = temp0;
                            matrikstuple[k + 1, 1] = temp1;
                            matrikstuple[k + 1, 2] = temp2;
                        }
                    }
                }
            }

            arrayColorTuple1 = new OffsetColorizer[isiListBox.Length * 2];
            arrayColorTuple2 = new OffsetColorizer[isiListBox.Length * 2];
            int counterarraycolor = 1;
            for (int i = 0; i < isiListBox.Length; i++)
            {
                lineSTART = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                lineEND = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                arrayColorTuple1[i] = new OffsetColorizer();
                TextEditor_1.TextArea.TextView.LineTransformers.Add(arrayColorTuple1[i]);
                arrayColorTuple1[i].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple1[i].EndOffset = lineEND.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                arrayColorTuple1[i].R = Convert.ToByte("#87CEFA".Substring(1, 2), 16);
                arrayColorTuple1[i].G = Convert.ToByte("#87CEFA".Substring(3, 2), 16);
                arrayColorTuple1[i].B = Convert.ToByte("#87CEFA".Substring(5, 2), 16);

                arrayColorTuple1[counterarraycolor] = new OffsetColorizer();
                TextEditor_1.TextArea.TextView.LineTransformers.Add(arrayColorTuple1[counterarraycolor]);
                arrayColorTuple1[counterarraycolor].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple1[counterarraycolor].EndOffset = lineSTART.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0])];
                arrayColorTuple1[counterarraycolor].R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                arrayColorTuple1[counterarraycolor].G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                arrayColorTuple1[counterarraycolor].B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                counterarraycolor++;
            }

            for (int i = 0; i < isiListBox.Length; i++)
            {
                string temp0;
                string temp1;
                string temp2;
                for (int k = 0; k < isiListBox.Length - 1; k++)
                {
                    if (matrikstuple[k, 1] == null)
                    {
                        break;
                    }
                    else
                    {
                        if (Convert.ToInt32(matrikstuple[k + 1, 1]) > Convert.ToInt32(matrikstuple[k, 1]))
                        {
                            temp0 = matrikstuple[k, 0];
                            temp1 = matrikstuple[k, 1];
                            temp2 = matrikstuple[k, 2];
                            matrikstuple[k, 0] = matrikstuple[k + 1, 0];
                            matrikstuple[k, 1] = matrikstuple[k + 1, 1];
                            matrikstuple[k, 2] = matrikstuple[k + 1, 2];

                            matrikstuple[k + 1, 0] = temp0;
                            matrikstuple[k + 1, 1] = temp1;
                            matrikstuple[k + 1, 2] = temp2;
                        }
                    }
                }
            }

            int counterarraycolor2 = 1;
            for (int i = 0; i < isiListBox.Length; i++)
            {
                lineSTART = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                lineEND = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                arrayColorTuple2[i] = new OffsetColorizer();
                TextEditor_2.TextArea.TextView.LineTransformers.Add(arrayColorTuple2[i]);
                arrayColorTuple2[i].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple2[i].EndOffset = lineEND.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayLineString2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                arrayColorTuple2[i].R = Convert.ToByte("#87CEFA".Substring(1, 2), 16);
                arrayColorTuple2[i].G = Convert.ToByte("#87CEFA".Substring(3, 2), 16);
                arrayColorTuple2[i].B = Convert.ToByte("#87CEFA".Substring(5, 2), 16);

                arrayColorTuple2[counterarraycolor2] = new OffsetColorizer();
                TextEditor_2.TextArea.TextView.LineTransformers.Add(arrayColorTuple2[counterarraycolor2]);
                arrayColorTuple2[counterarraycolor2].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple2[counterarraycolor2].EndOffset = lineSTART.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1])];
                arrayColorTuple2[counterarraycolor2].R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                arrayColorTuple2[counterarraycolor2].G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                arrayColorTuple2[counterarraycolor2].B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                counterarraycolor2++;
            }
        }
        public void CekInput()
        {
            if (string.IsNullOrEmpty(txtBox_FileInput1.Text))
            {
            }
            else if (string.IsNullOrEmpty(txtBox_FileInput2.Text))
            {
            }
            else if (string.IsNullOrEmpty(txtBox_BatFile.Text))
            {
            }
            else
            {
                Button_Start.IsEnabled = true;

            }
        }
        #endregion

    }
}