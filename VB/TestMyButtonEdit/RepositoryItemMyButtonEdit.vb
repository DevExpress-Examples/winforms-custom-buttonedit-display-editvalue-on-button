Imports System
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Controls


Namespace DevExpress.MyControl
    <UserRepositoryItem("RegisterMyButtonEdit")> _
    Public Class RepositoryItemMyButtonEdit
        Inherits RepositoryItemButtonEdit

        Public Const EDITORTypeName_Renamed As String = "MyButtonEdit"
        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return EDITORTypeName_Renamed
            End Get
        End Property

        <Browsable(False)> _
        Public Shadows ReadOnly Property OwnerEdit() As MyButtonEdit
            Get
                Return TryCast(MyBase.OwnerEdit, MyButtonEdit)
            End Get
        End Property


        Shared Sub New()
            RegisterMyButtonEdit()
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Sub CreateDefaultButton()
            MyBase.CreateDefaultButton()
            Dim eb As New EditorButton(ButtonPredefines.Glyph)
            eb.IsDefaultButton = True
            Buttons.Add(eb)
        End Sub

        Public Shared Sub RegisterMyButtonEdit()
            Dim img As Image = Nothing
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EDITORTypeName_Renamed, GetType(MyButtonEdit), GetType(RepositoryItemMyButtonEdit), GetType(MyButtonEditViewInfo), New MyButtonEditPainter(), True, img))
        End Sub
    End Class
End Namespace
