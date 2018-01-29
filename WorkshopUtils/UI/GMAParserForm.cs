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
            this.bw = new BackgroundWorker ( );
            this.bw.DoWork += this.Bw_DoWork;
        }

        public void ParseData ( Byte[] data )
        {
            GMADAddon addon = GMADParser.Parse ( data);
            this.addon = addon;

            this.InvokeEx ( a =>
            {
                this.txtAddonName.Text = addon.Name;
                this.txtAddonVersion.Text = addon.Version.ToString ( );
                this.txtAuthorName.Text = addon.Author.Name;
                this.txtAuthorSteamID.Text = addon.Author.SteamID64.ToString ( );
                this.txtDescription.Text = addon.Description;
                this.txtFormatVersion.Text = addon.FormatVersion.ToString ( );
                this.txtTimestamp.Text = addon.Timestamp.ToString ( );

                this.lbFiles.Items.Clear ( );
                foreach ( GMADAddon.File file in addon.Files )
                    this.lbFiles.Items.Add ( file.Path );
            } );
        }

        private static String GetString ( Byte[] data )
        {
            return String.Join ( "", data.Select ( d => ( Char ) d ).ToArray ( ) );
        }

        private void Button1_Click ( Object sender, EventArgs e )
        {
            if ( this.ParsingUnderway )
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
                DialogResult r = ofd.ShowDialog ( );
                if ( r != DialogResult.OK )
                    return;

                this.txtFn.Text = ofd.FileName;
                TriggerGMAParse ( );
            }
        }

        private void Button2_Click ( Object sender, EventArgs e )
        {
            var fsd = new FolderSelectDialog { Title = "GMAD Extractor | Select Directory" };
            if ( !fsd.ShowDialog ( this.Handle ) )
                return;

            foreach ( GMADAddon.File file in this.addon.Files )
            {
                var path = Path.Combine ( fsd.FileName, file.Path );
                var di = new DirectoryInfo ( Path.GetDirectoryName ( path ) );
                var fi = new FileInfo ( path );
                di.Create ( );
                using ( FileStream writer = fi.OpenWrite ( ) )
                    writer.Write ( file.Data, 0, file.Data.Length );
            }
        }

        private void Bw_DoWork ( Object _, DoWorkEventArgs __ )
        {
            this.ParsingUnderway = true;
            var fn = this.txtFn.Text;
            Byte[] data;
            try
            {
                using ( FileStream reader = File.OpenRead ( fn ) )
                using ( var ms = new MemoryStream ( ) )
                {
                    reader.CopyTo ( ms );
                    data = ms.ToArray ( );
                }
                ParseData ( data );
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
                using ( Form w = Dbg.GetTbForm ( a ) )
                    w.ShowDialog ( d );
            } );
        }

        private void LbFiles_DoubleClick ( Object sender, EventArgs e )
        {
            if ( this.lbFiles.SelectedItem != null )
            {
                var name = this.lbFiles.SelectedItem.ToString ( );
                foreach ( GMADAddon.File file in this.addon.Files )
                {
                    if ( file.Path == name )
                    {
                        using ( Form w = Dbg.GetGLuaForm (
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
            if ( this.ParsingUnderway )
                return;
            this.bw.RunWorkerAsync ( );
        }
    }
}
