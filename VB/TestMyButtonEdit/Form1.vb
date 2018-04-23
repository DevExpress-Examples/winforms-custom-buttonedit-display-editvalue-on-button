Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace TestMyButtonEdit
    Partial Public Class FormMain
        Inherits Form

        Private dtList As DataTable


        Public Sub New()
            InitializeComponent()
            InitDataList()
            gridContrl.DataSource = dtList
        End Sub



        Private Sub InitDataList()
            dtList = New DataTable()
            dtList.Columns.AddRange(New DataColumn() { _
                New DataColumn("Name"), _
                New DataColumn("Info") _
            })

            Dim rnd As New Random()
            For i As Integer = 0 To 9
                dtList.Rows.Add(New Object() { "Name_" & rnd.Next(10, 100).ToString(), "Info_" & rnd.Next(1000, 100000).ToString() })
            Next i
        End Sub

        Private Sub gridV_CustomRowCellEdit(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles gridV.CustomRowCellEdit
            If e.Column.FieldName = "Info" Then
                e.RepositoryItem = repositoryItemMBE
            End If
        End Sub



    End Class
End Namespace