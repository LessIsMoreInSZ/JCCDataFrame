using JCCDataFrame.Parsers.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Parsers
{
    public class ParserFactory
    {
        private ParserFactory() { }
        static Dictionary<string, List<Type>> parserMapping = new Dictionary<string, List<Type>>();
    
        static ParserFactory()
        {
            var typeXls = new List<Type>();
            typeXls.Add(typeof(ExcelSpreadsheetParser));
            typeXls.Add(typeof(ExcelTextParser));
            typeXls.Add(typeof(OLE2MetadataParser));
            parserMapping.Add(".xls", typeXls);
        }
    }
}
