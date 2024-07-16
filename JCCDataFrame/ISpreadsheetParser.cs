using JCCDataFrame.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame
{
    public interface ISpreadsheetParser
    {
        JccSpreadsheet Parse();
        JccTable Parse(int sheetIndex);
        ParserContext Context { get; set; }
    }
}
