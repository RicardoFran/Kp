using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace AvalonEdit.Sample
{
    public class OffsetColorizer : DocumentColorizingTransformer
    {
        public IList<LineColor> LineColors;
        public int StartOffset { get; set; }
        public int EndOffset { get; set; }
        public byte R;
        public byte G;
        public byte B;
        private SolidColorBrush scb;

        protected override void ColorizeLine(DocumentLine line)
        {
            scb = new SolidColorBrush(Color.FromRgb(R, G, B));
            if (line.Length == 0)
                return;
            if (line.Offset <= StartOffset || line.Offset > EndOffset)
                return;

            int start = line.Offset > StartOffset ? line.Offset : StartOffset;
            int end = EndOffset > line.EndOffset ? line.EndOffset : EndOffset;

            ChangeLinePart(start, end, element => element.TextRunProperties.SetBackgroundBrush(scb));
            //ChangeLinePart(start, end, element => element.TextRunProperties.SetForegroundBrush(Brushes.White));
        }
    }

    public class LineColor
    {
        public int StartOffset { get; set; }
        public int EndOffset { get; set; }
        public SolidColorBrush Colour { get; set; }
    }
}
