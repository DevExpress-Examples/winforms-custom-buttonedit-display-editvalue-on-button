Imports System
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Skins




Namespace DevExpress.MyControl
    Public Class MyButtonEditPainter
        Inherits ButtonEditPainter

        Private Function CalcButtonsWidth(ByVal info As ControlGraphicsInfoArgs) As Integer
            Dim vi As ButtonEditViewInfo = TryCast(info.ViewInfo, ButtonEditViewInfo)
            Dim iResult As Integer = 0

            If vi.RightButtons.Count > 0 Then
                For i As Integer = 0 To vi.RightButtons.Count - 1
                    iResult += vi.RightButtons(i).Bounds.Width
                Next i

            End If
            Return iResult
        End Function

        Protected Overrides Sub DrawString(ByVal info As ControlGraphicsInfoArgs, ByVal bounds As Rectangle, ByVal text As String, ByVal appearance As AppearanceObject)
            Dim vi As ButtonEditViewInfo = TryCast(info.ViewInfo, ButtonEditViewInfo)


            Dim buttonsWidth As Integer = CalcButtonsWidth(info)

            Dim text_width As Integer = vi.Bounds.Width - buttonsWidth
            If text_width <= 1 Then
                text_width = vi.ClientRect.Width
            End If


            bounds = New Rectangle(bounds.X, bounds.Y, text_width, bounds.Height)
            appearance.DrawString(info.Cache, text, bounds, appearance.GetForeBrush(info.Cache), appearance.GetTextOptions().GetStringFormat(info.ViewInfo.DefaultTextOptions))
        End Sub



        Protected Overrides Sub DrawButton(ByVal viewInfo As ButtonEditViewInfo, ByVal info As EditorButtonObjectInfoArgs)
            If info.Bounds.Width = 0 OrElse viewInfo.RightButtons.Count = 0 Then
                Return
            End If
            If info.Button.Index = 1 Then
                MyBase.DrawButton(viewInfo, info)
                Dim str_value As String = TryCast(viewInfo.EditValue, String)
                Dim captionColor As Color = EditorsSkins.GetSkin(viewInfo.LookAndFeel.ActiveLookAndFeel)(EditorsSkins.SkinEditorButton).Color.GetForeColor()
                info.Cache.DrawString(str_value, viewInfo.Appearance.Font, New SolidBrush(captionColor), info.Bounds, info.Appearance.GetStringFormat())
                Return
            End If

            MyBase.DrawButton(viewInfo, info)
        End Sub
    End Class
End Namespace
