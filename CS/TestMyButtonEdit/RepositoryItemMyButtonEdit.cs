using System;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Controls;





namespace DevExpress.MyControl
{
    [UserRepositoryItem("RegisterMyButtonEdit")]
    public class RepositoryItemMyButtonEdit : RepositoryItemButtonEdit
    {
        internal const string EDITORTypeName = "MyButtonEdit";
        public override string EditorTypeName
        {
            get
            {
                return EDITORTypeName;
            }
        }

        [Browsable(false)]
        public new MyButtonEdit OwnerEdit
        {
            get
            {
                return base.OwnerEdit as MyButtonEdit;
            }
        }


        static RepositoryItemMyButtonEdit()
        {
            RegisterMyButtonEdit();
        }



        public RepositoryItemMyButtonEdit()
            : base()
        {
        }



        public override void CreateDefaultButton()
        {
            base.CreateDefaultButton();
            EditorButton eb = new EditorButton(ButtonPredefines.Glyph);
            eb.IsDefaultButton = true;
            Buttons.Add(eb);
        }



        public static void RegisterMyButtonEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EDITORTypeName,
            typeof(MyButtonEdit), typeof(RepositoryItemMyButtonEdit),
            typeof(MyButtonEditViewInfo), new MyButtonEditPainter(), true, null));
        }
    }
}
