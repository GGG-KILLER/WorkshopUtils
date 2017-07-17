namespace WorkshopUtils.UI.GLuaHighlighter
{
    public enum HighlightTokenTypes
    {
        SyntaxIdentifier,   // IsSyntaxIdentifier
        GLuaFunc,           // IsGLuaFuncName ( 97 KiB return :V )
        JustPrintTM,        // JustPrint(tm)
        Whitespace,         // Duh x 2
        Number,             // 1, 1.2, 0xFF, 12.2[Ee][+-]2, 0.31416[Ee]1
        String,             // 'x', "x"
        Comment,            // --<x != \n>, --<LongString>
    }
}
