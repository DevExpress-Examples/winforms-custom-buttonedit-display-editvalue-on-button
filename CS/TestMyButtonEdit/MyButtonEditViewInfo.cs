using System;
using System.Drawing;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Drawing;



namespace DevExpress.MyControl
{
    public class MyButtonEditViewInfo : ButtonEditViewInfo
    {
        public MyButtonEditViewInfo(RepositoryItem item) : base(item) { }

        protected override Rectangle CalcButtons(GraphicsCache cache)
        {
            Rectangle rect = base.CalcButtons(cache);
            if (OwnerEdit == null)
                CalculateButtonsRect(cache.Graphics);

            return rect;
        }


        protected override void OnEditValueChanged()
        {
            base.OnEditValueChanged();

            if (OwnerEdit == null)
            {
                GInfo.AddGraphics(null);
                try
                {
                    CalculateButtonsRect(GInfo.Graphics);
                }
                finally
                {
                    GInfo.ReleaseGraphics();
                }
            }
        }


        private void CalculateButtonsRect(Graphics graph)
        {
            int currentRightBorder = ClientRect.Right;
            int baseXPos = 0, buttonWidth = 0;
            Rectangle cRect = Rectangle.Empty;
            int totalWidthOfButtonRects = 0;
            for (int n = RightButtons.Count - 1; n >= 0; n--)
            {
                cRect = Rectangle.Empty;
                EditorButtonObjectInfoArgs objectInfo = RightButtons[n];
                buttonWidth = objectInfo.Bounds.Width;
                if (objectInfo.Button.Index == 1)
                {
                    string str_val = EditValue as string;

                    if (str_val == null || str_val.Length == 0)
                        buttonWidth = CalcMinButtonBounds(objectInfo).Width;
                    else
                        buttonWidth = CalcObjectMinBounds(graph, objectInfo, str_val).Width;
                }

                baseXPos = currentRightBorder - buttonWidth;
                if (baseXPos > ClientRect.X)
                    cRect = new Rectangle(baseXPos, objectInfo.Bounds.Y, buttonWidth, objectInfo.Bounds.Height);

                objectInfo.Bounds = cRect;
                totalWidthOfButtonRects += buttonWidth;
                currentRightBorder -= buttonWidth;
            }
        }



        private Size CalcCaptionSize(Graphics graph, EditorButtonObjectInfoArgs e, string caption)
        {
            Size res = Size.Empty;
            using (GraphicsCache cache = new GraphicsCache(graph)) {
                res = e.Appearance.CalcTextSize(cache, caption, 0).ToSize();
            }
            res.Width += 1;
            res.Height += 1;
            return res;
        }


        private Rectangle CalcObjectMinBounds(Graphics graph, EditorButtonObjectInfoArgs e, string caption)
        {
            EditorButtonPainter eb_painter = GetButtonPainter(e) as EditorButtonPainter;
            Size kSize = eb_painter.CalcKindMinSize(e);
            Size tSize = CalcCaptionSize(graph, e, caption);
            Size res = kSize;
            if (!tSize.IsEmpty)
            {
                res.Width += tSize.Width + (kSize.Width > 0 ? TextGlyphIndent : 0);
                int height = res.Height;
                res.Height = Math.Max(tSize.Height, height);
            }
            if (e.Button.Width > 0) res.Width = e.Button.Width;

            res.Width += 2;
            Rectangle rect, saveBounds = e.Bounds;
            e.Bounds = new Rectangle(Point.Empty, res);
            rect = eb_painter.CalcBoundsByClientRectangle(e);
            e.Bounds = saveBounds;
            return rect;
        }
    }
}
