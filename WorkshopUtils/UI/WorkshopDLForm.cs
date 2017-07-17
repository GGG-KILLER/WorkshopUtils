using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkshopUtils.UI
{
    public partial class WorkshopDLForm : Form
    {
        private static readonly Regex wsurl = new Regex ( @"https?:\/\/steamcommunity\.com\/sharedfiles\/filedetails\/\?id=(\d+)" );

        public WorkshopDLForm ( )
        {
            InitializeComponent ( );
        }

        private async void Button1_ClickAsync ( Object sender, EventArgs e )
        {
            if ( String.IsNullOrEmpty ( txturl.Text ) || String.IsNullOrWhiteSpace ( txturl.Text ) )
            {
                L ( "Empty ID/URL." );
                return;
            }

            Int32 id;
            if ( wsurl.IsMatch ( txturl.Text ) )
            {
                id = Int32.Parse ( wsurl.Match ( txturl.Text ).Groups[1].ToString ( ) );
            }
            else if ( !Int32.TryParse ( txturl.Text, out id ) )
            {
                L ( "Invalid ID/URL." );
                return;
            }

            var addon = await WorkshopHTTPAPI.GetAddonByIDAsync ( id );
            using ( var wc = new WebClient ( ) )
            {
                wc.DownloadProgressChanged += ( a, b ) =>
                    this.progressBar1.Value = b.ProgressPercentage;
                var data = await wc.DownloadDataTaskAsync ( addon.URL );

                using ( var f = new GMAParserForm ( ) )
                {
                    f.ShowInTaskbar = false;
                    f.ParseData ( data, addon.ID, addon.URL );
                    f.ShowDialog ( this );

                    // Clean shit up
                    addon = null;
                    data = new Byte[0];
                    GC.Collect ( );
                }
            }
        }

        private void L ( String s )
        {
            this.InvokeEx ( d => MessageBox.Show ( d, s ) );
        }
    }
}
