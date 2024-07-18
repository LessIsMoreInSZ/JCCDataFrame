using JCCDataFrame.Entities.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Parsers.Interfaces
{
    public interface ISpreadsheetParser
    {
        JccSpreadsheet Parse();
        JccTable Parse(int sheetIndex);
        ParserContext Context { get; set; }
    }
}
