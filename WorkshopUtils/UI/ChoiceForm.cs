using System;
using System.Windows.Forms;

namespace WorkshopUtils.UI
{
    public partial class ChoiceForm : Form
    {
        public ChoiceForm ( )
        {
            InitializeComponent ( );
        }

        private void Button4_Click ( Object sender, EventArgs e )
        {
            using ( var f = new GMAParserForm ( ) )
            {
                f.ShowInTaskbar = false;
                f.ShowDialog ( this );
            }
        }

        private void Button5_Click ( Object sender, EventArgs e )
        {
            using ( var f = new WorkshopDLForm ( ) )
            {
                f.ShowInTaskbar = false;
                f.ShowDialog ( this );
            }
        }
    }
}