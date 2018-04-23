Imports System
Imports System.Drawing
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Drawing



Namespace DevExpress.MyControl
    Public Class MyButtonEditViewInfo
        Inherits ButtonEditViewInfo

        Public Sub New(ByVal item As RepositoryItem)
            MyBase.New(item)
        End Sub

        Protected Overrides Function CalcButtons(ByVal cache As GraphicsCache) As Rectangle
            Dim rect As Rectangle = MyBase.CalcButtons(cache)
            If OwnerEdit Is Nothing Then
                CalculateButtonsRect(cache.Graphics)
            End If

            Return rect
        End Function


        Protected Overrides Sub OnEditValueChanged()
            MyBase.OnEditValueChanged()

            If OwnerEdit Is Nothing Then
                GInfo.AddGraphics(Nothing)
                Try
                    CalculateButtonsRect(GInfo.Graphics)
                Finally
                    GInfo.ReleaseGraphics()
                End Try
            End If
        End Sub


        Private Sub CalculateButtonsRect(ByVal graph As Graphics)
            Dim currentRightBorder As Integer = ClientRect.Right
            Dim baseXPos As Integer = 0, buttonWidth As Integer = 0
            Dim cRect As Rectangle = Rectangle.Empty
            Dim totalWidthOfButtonRects As Integer = 0
            For n As Integer = RightButtons.Count - 1 To 0 Step -1
                cRect = Rectangle.Empty
                Dim objectInfo As EditorButtonObjectInfoArgs = RightButtons(n)
                buttonWidth = objectInfo.Bounds.Width
                If objectInfo.Button.Index = 1 Then
                    Dim str_val As String = TryCast(EditValue, String)

                    If str_val Is Nothing OrElse str_val.Length = 0 Then
                        buttonWidth = CalcMinButtonBounds(objectInfo).Width
                    Else
                        buttonWidth = CalcObjectMinBounds(graph, objectInfo, str_val).Width
                    End If
                End If

                baseXPos = currentRightBorder - buttonWidth
                If baseXPos > ClientRect.X Then
                    cRect = New Rectangle(baseXPos, objectInfo.Bounds.Y, buttonWidth, objectInfo.Bounds.Height)
                End If

                objectInfo.Bounds = cRect
                totalWidthOfButtonRects += buttonWidth
                currentRightBorder -= buttonWidth
            Next n
        End Sub



        Private Function CalcCaptionSize(ByVal graph As Graphics, ByVal e As EditorButtonObjectInfoArgs, ByVal caption As String) As Size
            Dim res As Size = Size.Empty
            Using cache As New GraphicsCache(graph)
                res = e.Appearance.CalcTextSize(cache, caption, 0).ToSize()
            End Using
            res.Width += 1
            res.Height += 1
            Return res
        End Function


        Private Function CalcObjectMinBounds(ByVal graph As Graphics, ByVal e As EditorButtonObjectInfoArgs, ByVal caption As String) As Rectangle
            Dim eb_painter As EditorButtonPainter = TryCast(GetButtonPainter(e), EditorButtonPainter)
            Dim kSize As Size = eb_painter.CalcKindMinSize(e)
            Dim tSize As Size = CalcCaptionSize(graph, e, caption)
            Dim res As Size = kSize
            If Not tSize.IsEmpty Then
                res.Width += tSize.Width + (If(kSize.Width > 0, TextGlyphIndent, 0))
                Dim height As Integer = res.Height
                res.Height = Math.Max(tSize.Height, height)
            End If
            If e.Button.Width > 0 Then
                res.Width = e.Button.Width
            End If

            res.Width += 2
            Dim rect As Rectangle, saveBounds As Rectangle = e.Bounds
            e.Bounds = New Rectangle(Point.Empty, res)
            rect = eb_painter.CalcBoundsByClientRectangle(e)
            e.Bounds = saveBounds
            Return rect
        End Function
    End Class
End Namespace
