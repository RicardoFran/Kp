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
using Microsoft.Win32;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;

namespace Kp
{
    public partial class Window1 : Window
    {
        private string[] arrayTextEditor1;
        private string[] arrayTextEditor2;
        private string[] arrayHasilMatchTuple;
        private int[] arrayLine1;
        private int[] arrayIndex1;
        private int[] arrayLine2;
        private int[] arrayIndex2;
        private string[] isiListBox;
        private string[,] matrikstuple;
        private string[] tuple;
        private OffsetColorizer[] arrayColorTuple1;
        private OffsetColorizer[] arrayColorTuple2;
        private DocumentLine lineSTART;
        private DocumentLine lineEND;

        public Window1(string file1 , string file2, string filebat)
        {
            // Load our custom highlighting definition
            IHighlightingDefinition customHighlighting;
            using (Stream s = typeof(Window1).Assembly.GetManifestResourceStream("AvalonEdit.Sample.CustomHighlighting.xshd"))
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
            this.Loaded += Window1_Loaded;
            //propertyGridComboBox.SelectedIndex = 2;

            //textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
            //textEditor.SyntaxHighlighting = customHighlighting;
            // initial highlighting now set by XAML


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

            TextEditor_1.Load(file1);
            TextEditor_1.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(file1));
            TextEditor_1.ShowLineNumbers = true;

            TextEditor_2.Load(file2);
            TextEditor_2.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(file2));
            TextEditor_2.ShowLineNumbers = true;

            TextBox_Upload.Text = filebat;
        }
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            //
            // Create data sources for the SlidingListBoxs.
            //

            Brush[] brushes = new SolidColorBrush[8];
            for (int i = 0; i < 8; ++i)
            {
                byte val = (byte)(255 / (i + 1) * i);
                Color color = System.Windows.Media.Color.FromRgb(val, val, val);
                brushes[i] = new SolidColorBrush(color);
            }

            this.slidingListBoxRight.ItemsSource = new string[]
            {
            };
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
        }

        private void TextEditor_2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextEditor_2.Text))
            {
                TotalLine_TextEditor2.Content = TextEditor_2.Document.LineCount;
            }
        }

        private void TextEditor_1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ColorizeTextEditorFull();
            DocumentLine line = TextEditor_1.Document.GetLineByOffset(TextEditor_1.CaretOffset);
            for (int i = 0; i < isiListBox.Length; i++)
            {
                lineSTART = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                lineEND = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);
                if (line.LineNumber <= lineEND.LineNumber && line.LineNumber >= lineSTART.LineNumber)
                {
                    #region ColorizeSelectedMatchTuple
                    DocumentLine lineSTART1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                    DocumentLine lineEND1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                    OffsetColorizer ColorTuple1 = new OffsetColorizer();
                    TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple1);
                    ColorTuple1.StartOffset = lineSTART1.Offset - 1;
                    ColorTuple1.EndOffset = lineEND1.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayTextEditor1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                    ColorTuple1.R = Convert.ToByte("#00008b".Substring(1, 2), 16);
                    ColorTuple1.G = Convert.ToByte("#00008b".Substring(3, 2), 16);
                    ColorTuple1.B = Convert.ToByte("#00008b".Substring(5, 2), 16);

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
                    ColorTuple3.EndOffset = lineEND2.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayTextEditor2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                    ColorTuple3.R = Convert.ToByte("#00008b".Substring(1, 2), 16);
                    ColorTuple3.G = Convert.ToByte("#00008b".Substring(3, 2), 16);
                    ColorTuple3.B = Convert.ToByte("#00008b".Substring(5, 2), 16);

                    OffsetColorizer ColorTuple4 = new OffsetColorizer();
                    TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTuple4);
                    ColorTuple4.StartOffset = lineSTART2.Offset - 1;
                    ColorTuple4.EndOffset = lineSTART2.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1])];
                    ColorTuple4.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                    ColorTuple4.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                    ColorTuple4.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                    #endregion
                    TextEditor_2.ScrollToLine(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                    break;
                }
            }
        }
        private void TextEditor_2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ColorizeTextEditorFull();
            DocumentLine line = TextEditor_2.Document.GetLineByOffset(TextEditor_2.CaretOffset);
            for (int i = 0; i < isiListBox.Length; i++)
            {
                lineSTART = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                lineEND = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);
                if (line.LineNumber <= lineEND.LineNumber && line.LineNumber >= lineSTART.LineNumber)
                {
                    #region Colorize SelectedMatchTuple
                    DocumentLine lineSTART1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                    DocumentLine lineEND1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                    OffsetColorizer ColorTuple1 = new OffsetColorizer();
                    TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple1);
                    ColorTuple1.StartOffset = lineSTART1.Offset - 1;
                    ColorTuple1.EndOffset = lineEND1.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayTextEditor1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                    ColorTuple1.R = Convert.ToByte("#00008b".Substring(1, 2), 16);
                    ColorTuple1.G = Convert.ToByte("#00008b".Substring(3, 2), 16);
                    ColorTuple1.B = Convert.ToByte("#00008b".Substring(5, 2), 16);

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
                    ColorTuple3.EndOffset = lineEND2.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayTextEditor2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
                    ColorTuple3.R = Convert.ToByte("#00008b".Substring(1, 2), 16);
                    ColorTuple3.G = Convert.ToByte("#00008b".Substring(3, 2), 16);
                    ColorTuple3.B = Convert.ToByte("#00008b".Substring(5, 2), 16);

                    OffsetColorizer ColorTuple4 = new OffsetColorizer();
                    TextEditor_2.TextArea.TextView.LineTransformers.Add(ColorTuple4);
                    ColorTuple4.StartOffset = lineSTART2.Offset - 1;
                    ColorTuple4.EndOffset = lineSTART2.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1])];
                    ColorTuple4.R = Convert.ToByte("#FFFFFF".Substring(1, 2), 16);
                    ColorTuple4.G = Convert.ToByte("#FFFFFF".Substring(3, 2), 16);
                    ColorTuple4.B = Convert.ToByte("#FFFFFF".Substring(5, 2), 16);
                    #endregion
                    TextEditor_1.ScrollToLine(arrayLine1[Convert.ToInt32(matrikstuple[i, 0])]);
                    break;
                }
            }
        }
        #endregion

        #region Button
        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo(TextBox_Upload.Text);
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            var p = Process.Start(psi);

            string hasil = p.StandardOutput.ReadToEnd();

            #region arrayTextEditor1 & TextEditor2
            string[] array1 = new string[hasil.Length];
            array1 = hasil.Split('\n');
            string[] array2 = new string[array1.Length];
            int j = 2;
            for (int i = 0; i < array2.Length - 8; i++)
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
                if (array2[i].Contains("====================================================="))
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
            int counterarrayHasilMatchTuple = 6;
            for (int i = 0; i < 6; i++)
            {
                arrayHasilMatchTuple[i] = array1[array1.Length - counterarrayHasilMatchTuple];
                counterarrayHasilMatchTuple--;
            }



            for (int i = 0; i < array2.Length; i++)
            {
                if (arrayTextEditor1[i] == null)
                {
                }
                if (arrayTextEditor2[i] == null)
                {
                }
                if (arrayTextEditor1[i] != null)
                {
                    arrayTextEditor1[i] = arrayTextEditor1[i].Replace("\n", String.Empty);
                    arrayTextEditor1[i] = arrayTextEditor1[i].Replace("\r", String.Empty);
                    arrayTextEditor1[i] = arrayTextEditor1[i].Replace("\t", String.Empty);
                }
                if (arrayTextEditor2[i] != null)
                {
                    arrayTextEditor2[i] = arrayTextEditor2[i].Replace("\n", String.Empty);
                    arrayTextEditor2[i] = arrayTextEditor2[i].Replace("\r", String.Empty);
                    arrayTextEditor2[i] = arrayTextEditor2[i].Replace("\t", String.Empty);
                }
            }
            #endregion
            #region array line + index
            string[] arrayLineIndex1 = new string[arrayTextEditor1.Length];
            arrayLine1 = new int[arrayTextEditor1.Length];
            arrayIndex1 = new int[arrayTextEditor1.Length];
            for (int i = 0; i < arrayTextEditor1.Length; i++)
            {
                if (arrayTextEditor1[i] == null)
                {
                    break;
                }
                else
                {
                    arrayLineIndex1 = arrayTextEditor1[i].Split(',');
                    arrayTextEditor1[i] = arrayLineIndex1[0];
                    arrayLine1[i] = Convert.ToInt32(arrayLineIndex1[1]);
                    arrayIndex1[i] = Convert.ToInt32(arrayLineIndex1[2]);
                }
            }
            string[] arrayLineIndex2 = new string[arrayTextEditor2.Length];
            arrayLine2 = new int[arrayTextEditor2.Length];
            arrayIndex2 = new int[arrayTextEditor2.Length];
            for (int i = 0; i < arrayTextEditor2.Length; i++)
            {
                if (arrayTextEditor2[i] == null)
                {
                    break;
                }
                else
                {
                    arrayLineIndex2 = arrayTextEditor2[i].Split(',');
                    arrayTextEditor2[i] = arrayLineIndex2[0];
                    arrayLine2[i] = Convert.ToInt32(arrayLineIndex2[1]);
                    arrayIndex2[i] = Convert.ToInt32(arrayLineIndex2[2]);
                }
            }
            #endregion
            #region matrikstuple
            arrayHasilMatchTuple[1] = arrayHasilMatchTuple[1].Replace("[", String.Empty);
            arrayHasilMatchTuple[1] = arrayHasilMatchTuple[1].Replace("]", String.Empty);
            isiListBox = arrayHasilMatchTuple[1].Split(',');
            this.slidingListBoxRight.ItemsSource = isiListBox;
            matrikstuple = new string[isiListBox.Length, isiListBox.Length];
            for (int i = 0; i < isiListBox.Length; i++)
            {
                for (int k = 0; k < isiListBox.Length; k++)
                {
                    tuple = isiListBox[i].Split(':');
                    matrikstuple[i, k] = tuple[k];
                }
            }
            #endregion

            ColorizeTextEditorFull();
            labelAverageSimilarty.Content = arrayHasilMatchTuple[3];
            labelMaxSimilarty.Content = arrayHasilMatchTuple[4];
        }
        private void reset_button_Click(object sender, RoutedEventArgs e)
        {
            ColorizeTextEditorFull();
            TextEditor_1.ScrollToHome();
            TextEditor_2.ScrollToHome();
            testing.Text=slidingListBoxRight.SelectedItem.ToString();
        }
        #endregion

        private void slidingListBoxRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColorizeTextEditorFull();
            #region ColorizeFromListBoxSelection
            OffsetColorizer ColorTuple1 = new OffsetColorizer();
            OffsetColorizer ColorTuple2 = new OffsetColorizer();
            OffsetColorizer ColorTuple3 = new OffsetColorizer();
            OffsetColorizer ColorTuple4 = new OffsetColorizer();

            string[] listselected = slidingListBoxRight.SelectedItem.ToString().Split(':');
            DocumentLine lineSTART1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(listselected[0])]);
            DocumentLine lineEND1 = TextEditor_1.Document.GetLineByNumber(arrayLine1[Convert.ToInt32(listselected[0]) + Convert.ToInt32(listselected[2]) - 1]);

            ColorTuple1 = new OffsetColorizer();
            TextEditor_1.TextArea.TextView.LineTransformers.Add(ColorTuple1);
            ColorTuple1.StartOffset = lineSTART1.Offset - 1;
            ColorTuple1.EndOffset = lineEND1.Offset + arrayIndex1[Convert.ToInt32(listselected[0]) + Convert.ToInt32(listselected[2]) - 1] + arrayTextEditor1[Convert.ToInt32(listselected[0]) + Convert.ToInt32(listselected[2]) - 1].Length;
            ColorTuple1.R = Convert.ToByte("#00008b".Substring(1, 2), 16);
            ColorTuple1.G = Convert.ToByte("#00008b".Substring(3, 2), 16);
            ColorTuple1.B = Convert.ToByte("#00008b".Substring(5, 2), 16);

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
            ColorTuple3.EndOffset = lineEND2.Offset + arrayIndex2[Convert.ToInt32(listselected[1]) + Convert.ToInt32(listselected[2]) - 1] + arrayTextEditor2[Convert.ToInt32(listselected[1]) + Convert.ToInt32(listselected[2]) - 1].Length;
            ColorTuple3.R = Convert.ToByte("#00008b".Substring(1, 2), 16);
            ColorTuple3.G = Convert.ToByte("#00008b".Substring(3, 2), 16);
            ColorTuple3.B = Convert.ToByte("#00008b".Substring(5, 2), 16);

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

        #region Function
        public void ColorizeTextEditorFull()
        {
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
                arrayColorTuple1[i].EndOffset = lineEND.Offset + arrayIndex1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayTextEditor1[Convert.ToInt32(matrikstuple[i, 0]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
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

            int counterarraycolor2 = 1;
            for (int i = 0; i < isiListBox.Length; i++)
            {
                lineSTART = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1])]);
                lineEND = TextEditor_2.Document.GetLineByNumber(arrayLine2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1]);

                arrayColorTuple2[i] = new OffsetColorizer();
                TextEditor_2.TextArea.TextView.LineTransformers.Add(arrayColorTuple2[i]);
                arrayColorTuple2[i].StartOffset = lineSTART.Offset - 1;
                arrayColorTuple2[i].EndOffset = lineEND.Offset + arrayIndex2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1] + arrayTextEditor2[Convert.ToInt32(matrikstuple[i, 1]) + Convert.ToInt32(matrikstuple[i, 2]) - 1].Length;
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
        #endregion


    }
}