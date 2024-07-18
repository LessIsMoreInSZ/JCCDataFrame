using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Parsers.Interfaces
{
    public interface ITextParser
    {
        string Parse();
        ParserContext Context { get; set; }
    }
}
