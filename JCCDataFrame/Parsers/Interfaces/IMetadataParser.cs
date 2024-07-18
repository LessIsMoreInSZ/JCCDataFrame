using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Parsers.Interfaces
{
    public interface IMetadataParser
    {
        ToxyMetadata Parse();
        ParserContext Context { get; set; }
    }
}
