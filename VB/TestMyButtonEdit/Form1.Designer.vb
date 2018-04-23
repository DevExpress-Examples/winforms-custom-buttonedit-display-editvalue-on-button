Namespace TestMyButtonEdit
    Partial Public Class FormMain
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.gridContrl = New DevExpress.XtraGrid.GridControl()
            Me.gridV = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.repositoryItemMBE = New DevExpress.MyControl.RepositoryItemMyButtonEdit()
            Me.myButtonEdit1 = New DevExpress.MyControl.MyButtonEdit()
            Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            CType(Me.gridContrl, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridV, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repositoryItemMBE, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.myButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridContrl
            ' 
            Me.gridContrl.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.gridContrl.Location = New System.Drawing.Point(12, 12)
            Me.gridContrl.MainView = Me.gridV
            Me.gridContrl.Name = "gridContrl"
            Me.gridContrl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemMBE})
            Me.gridContrl.Size = New System.Drawing.Size(539, 387)
            Me.gridContrl.TabIndex = 0
            Me.gridContrl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridV})
            ' 
            ' gridV
            ' 
            Me.gridV.GridControl = Me.gridContrl
            Me.gridV.Name = "gridV"
            Me.gridV.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
            ' 
            ' repositoryItemMBE
            ' 
            Me.repositoryItemMBE.AutoHeight = False
            Me.repositoryItemMBE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { _
                New DevExpress.XtraEditors.Controls.EditorButton(), _
                New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) _
            })
            Me.repositoryItemMBE.Name = "repositoryItemMBE"
            ' 
            ' myButtonEdit1
            ' 
            Me.myButtonEdit1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.myButtonEdit1.Location = New System.Drawing.Point(12, 405)
            Me.myButtonEdit1.Name = "myButtonEdit1"
            Me.myButtonEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { _
                New DevExpress.XtraEditors.Controls.EditorButton(), _
                New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) _
            })
            Me.myButtonEdit1.Size = New System.Drawing.Size(539, 20)
            Me.myButtonEdit1.TabIndex = 1
            ' 
            ' defaultLookAndFeel1
            ' 
            Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
            ' 
            ' FormMain
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(563, 437)
            Me.Controls.Add(Me.myButtonEdit1)
            Me.Controls.Add(Me.gridContrl)
            Me.Name = "FormMain"
            Me.Text = "Main form"
            CType(Me.gridContrl, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridV, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repositoryItemMBE, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.myButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private gridContrl As DevExpress.XtraGrid.GridControl
        Private WithEvents gridV As DevExpress.XtraGrid.Views.Grid.GridView
        Private myButtonEdit1 As DevExpress.MyControl.MyButtonEdit
        Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
        Private repositoryItemMBE As DevExpress.MyControl.RepositoryItemMyButtonEdit
    End Class
End Namespace

