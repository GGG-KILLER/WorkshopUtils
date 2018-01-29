using System;
using System.Net;
using System.Text.RegularExpressions;
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
            if ( String.IsNullOrEmpty ( this.txturl.Text ) || String.IsNullOrWhiteSpace ( this.txturl.Text ) )
            {
                L ( "Empty ID/URL." );
                return;
            }

            Int32 id;
            if ( wsurl.IsMatch ( this.txturl.Text ) )
            {
                id = Int32.Parse ( wsurl.Match ( this.txturl.Text ).Groups[1].ToString ( ) );
            }
            else if ( !Int32.TryParse ( this.txturl.Text, out id ) )
            {
                L ( "Invalid ID/URL." );
                return;
            }

            WorkshopAddon addon = await WorkshopHTTPAPI.GetAddonByIDAsync ( id, Program.APIKey );
            using ( var wc = new WebClient ( ) )
            {
                wc.DownloadProgressChanged += ( a, b ) =>
                    this.progressBar1.Value = b.ProgressPercentage;
                Byte[] data = await wc.DownloadDataTaskAsync ( addon.URL );

                using ( var f = new GMAParserForm ( ) )
                {
                    f.ShowInTaskbar = false;
                    f.ParseData ( data );
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
