using System;

namespace WorkshopUtils.UI.GLuaHighlighter
{
    public struct HighlightToken
    {
        internal HighlightTokenTypes Type;
        internal String Raw;

        public override String ToString ( ) => $"HighlightToken<{Type}, {Raw}>";
    }
}
