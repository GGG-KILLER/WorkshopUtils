﻿using System;
using System.Drawing;
using System.Windows.Forms;
using WorkshopUtils.UI.GLuaHighlighter;

namespace WorkshopUtils.UI
{
    public partial class GLuaCode : RichTextBox
    {
        public readonly Color
            Background  = ColorTranslator.FromHtml ( "#2f3136" ),
            Literals    = ColorTranslator.FromHtml ( "#2aa198" ),
            Keyword     = ColorTranslator.FromHtml ( "#859900" ),
            Comment     = ColorTranslator.FromHtml ( "#586e75" ),
            Builtin     = ColorTranslator.FromHtml ( "#dc322f" ),
            // hsla(0,0%,100%,.7)
            NormalText  = Color.FromArgb ( ( Int32 ) Math.Round ( 0.7 * 255 ), 255, 255, 255 );

        public new Color BackColor => base.BackColor;

        public new BorderStyle BorderStyle => base.BorderStyle;

        public new Boolean ReadOnly => base.ReadOnly;

        public GLuaCode ( )
        {
            InitializeComponent ( );
            base.BackColor = this.Background;
            base.BorderStyle = BorderStyle.None;
            base.ReadOnly = true;
        }

        public void SetCode ( String Code )
        {
            System.Collections.Generic.IEnumerable<HighlightToken> tokens = GLuaHighlightTokenizer.Tokenize ( Code );
            foreach ( HighlightToken token in tokens )
            {
                switch ( token.Type )
                {
                    case HighlightTokenTypes.Comment:
                        this.AppendText ( token.Raw, this.Comment );
                        break;

                    case HighlightTokenTypes.GLuaFunc:
                        this.AppendText ( token.Raw, this.Builtin );
                        break;

                    case HighlightTokenTypes.Whitespace:
                    case HighlightTokenTypes.JustPrintTM:
                        this.AppendText ( token.Raw, this.NormalText );
                        break;

                    case HighlightTokenTypes.Number:
                    case HighlightTokenTypes.String:
                        this.AppendText ( token.Raw, this.Literals );
                        break;

                    case HighlightTokenTypes.SyntaxIdentifier:
                        this.AppendText ( token.Raw, this.Keyword );
                        break;
                }
            }
            this.SelectionStart = 0;
            this.SelectionLength = 0;
        }

        public void AppendText ( String text, Color color )
        {
            this.SelectionStart = this.TextLength;
            this.SelectionLength = 0;

            this.SelectionColor = color;
            this.AppendText ( text );
            this.SelectionColor = this.ForeColor;
        }
    }
}
