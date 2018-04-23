using System;
using System.ComponentModel;
using DevExpress.XtraEditors;




namespace DevExpress.MyControl
{
    public class MyButtonEdit : ButtonEdit
    {
        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemMyButtonEdit.EDITORTypeName;
            }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyButtonEdit Properties
        {
            get
            {
                return base.Properties as RepositoryItemMyButtonEdit;
            }
        }



        static MyButtonEdit()
        {
            RepositoryItemMyButtonEdit.RegisterMyButtonEdit();
        }



        public MyButtonEdit()
            : base()
        {
        }


        protected override void OnEditValueChanged()
        {
            base.OnEditValueChanged();

            if (Properties.Buttons.Count >= 2)
            {
                string str_value = EditValue as string;
                Properties.Buttons[1].Caption = (str_value == null ? string.Empty : str_value);
            }
        }
    }
}





