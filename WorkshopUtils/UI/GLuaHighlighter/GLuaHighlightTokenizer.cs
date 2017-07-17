using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopUtils.UI.GLuaHighlighter
{
    public partial class GLuaHighlightTokenizer
    {
        private readonly String Code;
        private Int32 Position;

        public GLuaHighlightTokenizer ( String Code )
        {
            this.Code = Code;
        }

        public static IEnumerable<HighlightToken> Tokenize ( String code )
        {
            return new GLuaHighlightTokenizer ( code )
                .Tokenize ( );
        }

        public IEnumerable<HighlightToken> Tokenize ( )
        {
            Position = -1;
            var buff = new StringBuilder ( );
            var ret = new List<HighlightToken> ( );
            Char next;

            void SubmitBuffer ( )
            {
                if ( buff.Length == 0 )
                    return;

                ret.Add ( new HighlightToken
                {
                    Type = HighlightTokenTypes.JustPrintTM,
                    Raw = buff.ToString ( )
                } );
                buff.Clear ( );
            }

            while ( ( next = Next ( ) ) != '\0' )
            {
                if ( Char.IsWhiteSpace ( next ) )
                {
                    SubmitBuffer ( );
                    ret.Add ( new HighlightToken
                    {
                        Type = HighlightTokenTypes.Whitespace,
                        Raw = ReadUntilNot ( Char.IsWhiteSpace )
                    } );
                }
                else if ( IsValidFirstIdentifierChar ( next ) )
                {
                    SubmitBuffer ( );
                    ret.Add ( ReadIdentifier ( ) );
                }
                else if ( Char.IsDigit ( next ) )
                {
                    SubmitBuffer ( );
                    ret.Add ( new HighlightToken
                    {
                        Type = HighlightTokenTypes.Number,
                        Raw = ReadUntilNot ( PossibleNumberPart )
                    } );
                }
                // Strings
                else if ( next == '"' || next == '\'' )
                {
                    SubmitBuffer ( );
                    ret.Add ( ReadString ( Read ( ) ) );
                }
                else if ( next == '[' && ( Next ( 2 ) == '[' || Next ( 2 ) == '=' ) )
                {
                    SubmitBuffer ( );
                    ret.Add ( ReadLongString ( $"{Read ( )}{ReadUntil ( '[' )}{Read ( )}" ) );
                }
                // Comments
                else if ( next == '-' && Next ( 2 ) == '-' )
                {
                    SubmitBuffer ( );
                    ret.Add ( ReadComment ( ) );
                }
                else if ( next == '/' && Next ( 2 ) == '*' )
                {
                    SubmitBuffer ( );
                    ret.Add ( new HighlightToken
                    {
                        Type = HighlightTokenTypes.Comment,
                        Raw = $"{Read ( )}{Read ( )}{ReadUntil ( "*/" )}{Read ( )}{Read ( )}"
                    } );
                }
                else if ( next == '/' && Next ( 2 ) == '/' )
                {
                    SubmitBuffer ( );
                    ret.Add ( new HighlightToken
                    {
                        Type = HighlightTokenTypes.Comment,
                        Raw = $"{Read ( )}{Read ( )}{ReadUntil ( x => x == '\n' || x == '\r' )}"
                    } );
                }
                else
                    buff.Append ( Read ( ) );
            }
            SubmitBuffer ( );

            return ret;
        }

        #region Moving Around

        private Boolean CanMove ( Int32 Delta )
        {
            var newPos = Position + Delta;
            return -1 < newPos && newPos < Code.Length;
        }

        private Char Read ( Int32 len = 1 )
        {
            if ( !CanMove ( len ) )
                return '\0';
            return Code[Position += len];
        }

        private Char Next ( Int32 len = 1 )
        {
            if ( !CanMove ( len ) )
                return '\0';
            return Code[Position + len];
        }

        private Int32 IndexOf ( Char ch )
        {
            for ( int i = Position ; i < Code.Length ; i++ )
                if ( Code[i] == ch )
                    return i - Position;
            return -1;
        }

        private Int32 IndexOf ( Func<Char, Boolean> Filter )
        {
            for ( int i = Position ; i < Code.Length ; i++ )
                if ( Filter?.Invoke ( Code[i] ) ?? default ( Boolean ) )
                    return i - Position;
            return -1;
        }

        #endregion Moving Around

        #region Advanced Moving Around

        private String ReadUntil ( Char ch )
        {
            var buff = new StringBuilder ( );
            while ( Next ( ) != ch )
                buff.Append ( Read ( ) );
            return buff.ToString ( );
        }

        private String ReadUntil ( String str )
        {
            var buff = new StringBuilder ( );
            while ( true )
            {
                var alleq = true;
                for ( int i = 0 ; i < str.Length ; i++ )
                {
                    if ( Next ( 1 + i ) != str[i] )
                    {
                        alleq = false;
                        break;
                    }
                }
                if ( alleq )
                    break;

                buff.Append ( Read ( ) );
            }
            return buff.ToString ( );
        }

        private String ReadUntil ( Func<Char, Boolean> Filter )
        {
            var buff = new StringBuilder ( );
            while ( !Filter?.Invoke ( Next ( ) ) ?? default ( Boolean ) )
                buff.Append ( Read ( ) );
            return buff.ToString ( );
        }

        private String ReadUntilNot ( Func<Char, Boolean> Filter )
        {
            var buff = new StringBuilder ( );
            while ( Filter?.Invoke ( Next ( ) ) ?? default ( Boolean ) )
                buff.Append ( Read ( ) );
            return buff.ToString ( );
        }

        private String ReadUntilNot ( Char ch )
        {
            var buff = new StringBuilder ( );
            while ( Next ( ) == ch )
                buff.Append ( Read ( ) );
            return buff.ToString ( );
        }

        #endregion Advanced Moving Around

        #region Actually Reading Stuff

        public HighlightToken ReadIdentifier ( )
        {
            var raw = ReadUntilNot ( IsValidIdentifierChar );
            return new HighlightToken
            {
                Type = IsSyntaxIdentifier ( raw ) ?
                    HighlightTokenTypes.SyntaxIdentifier :
                    ( IsGLuaFuncName ( raw ) ?
                        HighlightTokenTypes.GLuaFunc :
                        HighlightTokenTypes.JustPrintTM ),
                Raw = raw
            };
        }

        public HighlightToken ReadString ( Char quoteStart )
        {
            var buff = new StringBuilder ( );
            buff.Append ( quoteStart );
            while ( Next ( ) != quoteStart && Next ( ) != '\0' )
            {
                if ( Next ( ) == '\\' ) // Ignore char if it's a \<smth>
                    buff.Append ( Read ( ) );
                buff.Append ( Read ( ) );
            }
            buff.Append ( Read ( ) );
            return new HighlightToken
            {
                Type = HighlightTokenTypes.String,
                Raw = buff.ToString ( )
            };
        }

        public HighlightToken ReadLongString ( String start )
        {
            var buff = new StringBuilder ( );
            buff.Append ( start );
            start = start.Replace ( '[', ']' );
            buff.Append ( ReadUntil ( start ) );
            buff.Append ( start );
            Read ( start.Length + 1 );
            return new HighlightToken
            {
                Type = HighlightTokenTypes.String,
                Raw = buff.ToString ( )
            };
        }

        public HighlightToken ReadComment ( )
        {
            var buff = new StringBuilder ( "--" );
            if ( Next ( ) == '[' && (
                Next ( 2 ) == '[' ||
                // Make sure the long string/comment actually
                // starts before the line ends
                ( Next ( 2 ) == '=' && IndexOf ( '\n' ) > IndexOf ( '[' ) )
            ) )
            {
                // Get [ and then all the way until the other [
                var init = Read ( ) + ReadUntil ( '[' );
                var ret = ReadLongString ( init );
                ret.Type = HighlightTokenTypes.Comment;
                ret.Raw = "--" + ret.Raw;
                return ret;
            }

            return new HighlightToken
            {
                Type = HighlightTokenTypes.Comment,
                Raw = "--" + ReadUntil ( x => x == '\r' || x == '\n' )
            };
        }

        #endregion Actually Reading Stuff

        private static Boolean IsSyntaxIdentifier ( String str )
        {
            return str == "in" || str == "do" || str == "or" ||
                str == "if" || str == "not" || str == "end" ||
                str == "nil" || str == "for" || str == "and" ||
                str == "else" || str == "then" || str == "true" ||
                str == "while" || str == "local" || str == "false" ||
                str == "break" || str == "until" || str == "repeat" ||
                str == "elseif" || str == "return" || str == "function";
        }

        // Fns is in another file where I actually generate the code
        private static Boolean IsGLuaFuncName ( String str )
        {
            return Array.IndexOf ( Fns, str ) != -1;
        }

        private static Boolean IsValidFirstIdentifierChar ( Char ch )
        {
            return !Char.IsDigit ( ch ) && IsValidIdentifierChar ( ch );
        }

        private static Boolean IsValidIdentifierChar ( Char ch )
        {
            return !Char.IsWhiteSpace ( ch ) && ( Char.IsLetterOrDigit ( ch ) || ch == '.' );
        }

        private static Boolean PossibleNumberPart ( Char ch )
        {
            return Char.IsDigit ( ch ) || ( 'a' <= ch && ch < 'h' ) || ch == '.' ||
                ch == 'x' || ch == 'e' || ch == 'E' || ch == '-' || ch == '+';
        }
    }
}
