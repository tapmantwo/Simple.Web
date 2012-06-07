﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Web.Razor.Engine
{
    using System.Web.Razor;
    using System.Web.Razor.Parser;
    using System.Web.Razor.Parser.SyntaxTree;
    using System.Web.Razor.Tokenizer.Symbols;

    internal class SimpleRazorEngineHost : RazorEngineHost
    {
        public SimpleRazorEngineHost(RazorCodeLanguage codeLanguage) : base(codeLanguage)
        {
            
        }

        public override ParserBase DecorateCodeParser(ParserBase incomingCodeParser)
        {
            if (incomingCodeParser is CSharpCodeParser) return new SimpleCSharpCodeParser();
            return base.DecorateCodeParser(incomingCodeParser);
        }
    }
}
