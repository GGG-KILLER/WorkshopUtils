# WorkshopUtils
A workshop utility tool to download GMAD files and extract or look at files in-memory

This is **broken** now that GMod uses the new workshop system which requires us to use the Steamworks API instead of calling the HTTP IPublishedFileService API.

# Dependencies
- [GMADFileFormat](https://github.com/GGG-KILLER/GMADFileFormat)
- [Newtonsoft.Json](http://www.newtonsoft.com/json)

# Requirements
- VS 2017 Community (not tested with previous versions)
- .NET Core SDK
- .NET Framework 4.6.1

# Re-generating highlight functions list
1. Copy contents of `highlighter-scrapper.js` to Chrome (should work in other browsers but untested) console
2. Paste output into `WorkshopUtils/UI/GLuaHighlighter/GLuaHighlightTokenizer.Fns.cs` (don't worry about what was there previously)
3. Re-compile

# License
MIT, do whatever the license lets you but at least give me credits
