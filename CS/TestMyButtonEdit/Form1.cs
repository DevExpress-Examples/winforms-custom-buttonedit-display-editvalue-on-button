using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestMyButtonEdit
{
    public partial class FormMain : Form
    {
        private DataTable dtList;


        public FormMain()
        {
            InitializeComponent();
            InitDataList();
            gridContrl.DataSource = dtList;
        }



        private void InitDataList()
        {
            dtList = new DataTable();
            dtList.Columns.AddRange(new DataColumn[] { new DataColumn("Name"), new DataColumn("Info") });

            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
                dtList.Rows.Add(new object[] { "Name_" + rnd.Next(10, 100).ToString(), "Info_" + rnd.Next(1000, 100000).ToString() });
        }

        private void gridV_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Info")
                e.RepositoryItem = repositoryItemMBE;
        }



    }
}