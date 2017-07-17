using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorkshopUtils.UI
{
    internal static class Dbg
    {
        internal static Form GetTbForm ( String str )
        {
            var frm = new Form ( );
            var tb = new TextBox
            {
                Multiline = true,
                Text = str,
                Location = Point.Empty,
                Dock = DockStyle.Fill
            };
            frm.Controls.Add ( tb );
            frm.FormClosing += ( o, e ) => tb.Dispose ( );
            return frm;
        }

        internal static Form GetGLuaForm ( String str )
        {
            var frm = new Form ( );
            var cb = new GLuaCode
            {
                Location = Point.Empty,
                Dock = DockStyle.Fill
            };
            cb.SetCode ( str );
            frm.Controls.Add ( cb );
            frm.FormClosing += ( o, e ) => cb.Dispose ( );
            return frm;
        }
    }
}