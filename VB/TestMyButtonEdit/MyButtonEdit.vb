Imports System
Imports System.ComponentModel
Imports DevExpress.XtraEditors




Namespace DevExpress.MyControl
    Public Class MyButtonEdit
        Inherits ButtonEdit

        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return RepositoryItemMyButtonEdit.EDITORTypeName_Renamed
            End Get
        End Property



        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Shadows ReadOnly Property Properties() As RepositoryItemMyButtonEdit
            Get
                Return TryCast(MyBase.Properties, RepositoryItemMyButtonEdit)
            End Get
        End Property



        Shared Sub New()
            RepositoryItemMyButtonEdit.RegisterMyButtonEdit()
        End Sub



        Public Sub New()
            MyBase.New()
        End Sub


        Protected Overrides Sub OnEditValueChanged()
            MyBase.OnEditValueChanged()

            If Properties.Buttons.Count >= 2 Then
                Dim str_value As String = TryCast(EditValue, String)
                Properties.Buttons(1).Caption = (If(str_value Is Nothing, String.Empty, str_value))
            End If
        End Sub
    End Class
End Namespace





