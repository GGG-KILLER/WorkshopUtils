using GMADFileFormat;
using GUtils.Forms;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkshopUtils.UI
{
    public partial class GMAParserForm : Form
    {
        private readonly BackgroundWorker bw;
        private GMADAddon addon;
        private Boolean ParsingUnderway;

        public GMAParserForm ( )
        {
            InitializeComponent ( );
            bw = new BackgroundWorker ( );
            bw.DoWork += this.Bw_DoWork;
        }

        public void ParseData ( Byte[] data, Int64 ID, String WorkshopURL )
        {
            var addon = GMADParser.Parse ( data);
            this.addon = addon;

            this.InvokeEx ( a =>
            {
                txtAddonName.Text = addon.Name;
                txtAddonVersion.Text = addon.Version.ToString ( );
                txtAuthorName.Text = addon.Author.Name;
                txtAuthorSteamID.Text = addon.Author.SteamID64.ToString ( );
                txtDescription.Text = addon.Description;
                txtFormatVersion.Text = addon.FormatVersion.ToString ( );
                txtTimestamp.Text = addon.Timestamp.ToString ( );

                lbFiles.Items.Clear ( );
                foreach ( var file in addon.Files )
                    lbFiles.Items.Add ( file.Path );
            } );
        }

        private static String GetString ( Byte[] data )
        {
            return String.Join ( "", data.Select ( d => ( Char ) d ).ToArray ( ) );
        }

        private void Button1_Click ( Object sender, EventArgs e )
        {
            if ( ParsingUnderway )
                return;

            using ( var ofd = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "GMA Files | *.gma",
                RestoreDirectory = true,
                Title = "GMA Parser"
            } )
            {
                var r = ofd.ShowDialog ( );
                if ( r != DialogResult.OK )
                    return;

                txtFn.Text = ofd.FileName;
                TriggerGMAParse ( );
            }
        }

        private void Button2_Click ( Object sender, EventArgs e )
        {
            var fsd = new FolderSelectDialog { Title = "GMAD Extractor | Select Directory" };
            if ( !fsd.ShowDialog ( this.Handle ) )
                return;

            foreach ( var file in addon.Files )
            {
                var path = Path.Combine ( fsd.FileName, file.Path );
                var di = new DirectoryInfo ( Path.GetDirectoryName ( path ) );
                var fi = new FileInfo ( path );
                di.Create ( );
                using ( var writer = fi.OpenWrite ( ) )
                    writer.Write ( file.Data, 0, file.Data.Length );
            }
        }

        private void Bw_DoWork ( Object _, DoWorkEventArgs __ )
        {
            ParsingUnderway = true;
            var fn = txtFn.Text;
            Byte[] data;
            try
            {
                using ( var reader = File.OpenRead ( fn ) )
                using ( var ms = new MemoryStream ( ) )
                {
                    reader.CopyTo ( ms );
                    data = ms.ToArray ( );
                }
                ParseData ( data, -1, null );
            }
            catch ( Exception e )
            {
                L ( "Error:\n" + e );
            }
        }

        private void L ( String a )
        {
            this.InvokeEx ( d =>
            {
                using ( var w = Dbg.GetTbForm ( a ) )
                    w.ShowDialog ( d );
            } );
        }

        private void LbFiles_DoubleClick ( Object sender, EventArgs e )
        {
            if ( lbFiles.SelectedItem != null )
            {
                var name = lbFiles.SelectedItem.ToString ( );
                foreach ( var file in addon.Files )
                {
                    if ( file.Path == name )
                    {
                        using ( var w = Dbg.GetGLuaForm (
                               Encoding.UTF8.GetString ( file.Data )
                              .Replace ( "\n", Environment.NewLine )
                              .Replace ( "\r\r", "\r" ) ) )
                        {
                            w.ShowInTaskbar = false;
                            w.ShowDialog ( this );
                        }
                    }
                }
            }
        }

        private void TriggerGMAParse ( )
        {
            if ( ParsingUnderway )
                return;
            bw.RunWorkerAsync ( );
        }
    }
}