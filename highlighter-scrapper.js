var funcs = Array.from ( document.querySelectorAll ( 'pagelist > ul > li' ) );
var areas = { Hooks: 0, Libs: 1, Global: 2, Classes: 3, Panels: 4 };
var lines = [
	'using System;',
	'using System.Linq;',
	'namespace WorkshopUtils.UI.GLuaHighlighter',
	'{',
	'	public partial class GLuaHighlightTokenizer',
	'	{',
	'		private static readonly String[] Fns = ( new String[] {',
	'			#region GLua Functions',
	''
];
let fns = [];
fns = fns.concat ( Array.from ( funcs[areas.Hooks].querySelectorAll ( 'ul > li > a' ) ).map ( x => `"${x.innerText}"` ) )
	.concat ( Array.from ( funcs[areas.Global].querySelectorAll ( 'ul > li > a' ) ).map ( x => `"${x.innerText}"` ) )
	.concat ( Array.from ( funcs[areas.Classes].querySelectorAll ( 'ul > li > a' ) ).map ( x => `"${x.innerText}"` ) )
	.concat ( Array.from ( funcs[areas.Panels].querySelectorAll ( 'ul > li > a' ) ).map ( x => `"${x.innerText}"` ) );
Array.from ( funcs[areas.Libs].querySelectorAll ( 'ul > li' ) )
	.map ( x => Array.from ( ( x.children[1] || { children: [] } ).children ).map ( y => `"${x.children[0].innerText.split(' ')[0]}.${y.innerText}"` ) )
	.forEach ( x => fns = fns.concat ( x ) );
lines = lines.concat ( [
	'			' + fns.join ( ', ' ),
	'',
	'			#endregion GLua Functions',
	'		} )',
	'			.OrderBy ( x => x )',
	'			.ToArray ( );',
	'	}',
	'}'
] );

document.write ( lines.join ( '<br>' ).replace ( /\t/ig, "&nbsp;&nbsp;&nbsp;&nbsp;" ) );