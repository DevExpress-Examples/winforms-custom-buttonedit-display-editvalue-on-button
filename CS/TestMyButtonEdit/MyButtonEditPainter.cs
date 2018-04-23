using System;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Skins;




namespace DevExpress.MyControl
{
    public class MyButtonEditPainter : ButtonEditPainter
    {
        private int CalcButtonsWidth(ControlGraphicsInfoArgs info)
        {
            ButtonEditViewInfo vi = info.ViewInfo as ButtonEditViewInfo;
            int iResult = 0;

            if (vi.RightButtons.Count > 0)
            {
                for (int i = 0; i < vi.RightButtons.Count; i++)
                    iResult += vi.RightButtons[i].Bounds.Width;

            }
            return iResult;
        }

        protected override void DrawString(ControlGraphicsInfoArgs info, Rectangle bounds, string text, AppearanceObject appearance)
        {
            ButtonEditViewInfo vi = info.ViewInfo as ButtonEditViewInfo;


            int buttonsWidth = CalcButtonsWidth(info);

            int text_width = vi.Bounds.Width - buttonsWidth;
            if (text_width <= 1)
                text_width = vi.ClientRect.Width;


            bounds = new Rectangle(bounds.X, bounds.Y, text_width, bounds.Height);
            appearance.DrawString(info.Cache, text, bounds, appearance.GetForeBrush(info.Cache), appearance.GetTextOptions().GetStringFormat(info.ViewInfo.DefaultTextOptions));
        }



        protected override void DrawButton(ButtonEditViewInfo viewInfo, EditorButtonObjectInfoArgs info)
        {
            if (info.Bounds.Width == 0 || viewInfo.RightButtons.Count == 0) return;
            if (info.Button.Index == 1)
            {
                base.DrawButton(viewInfo, info);
                string str_value = viewInfo.EditValue as string;
                Color captionColor = EditorsSkins.GetSkin(viewInfo.LookAndFeel.ActiveLookAndFeel)[EditorsSkins.SkinEditorButton].Color.GetForeColor();
                info.Cache.DrawString(str_value, viewInfo.Appearance.Font, new SolidBrush(captionColor), info.Bounds, info.Appearance.GetStringFormat());
                return;
            }

            base.DrawButton(viewInfo, info);
        }
    }
}
