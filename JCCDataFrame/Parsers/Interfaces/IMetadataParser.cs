using JCCDataFrame.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Parsers.Interfaces
{
    public interface IMetadataParser
    {
        JccMetadata Parse();
        ParserContext Context { get; set; }
    }
}
