using JCCDataFrame;
using JCCDataFrame.Entities.Spreadsheet;
using JCCDataFrame.Parsers;
using JCCDataFrame.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCCConsole.Test
{
    public class ExcelParserTest
    {
        public void BaseTestExtractSheetFooter(string filename)
        {
            ParserContext context = new ParserContext(TestDataSample.GetExcelPath(filename));
            ISpreadsheetParser parser = ParserFactory.CreateSpreadsheet(context);
            JccSpreadsheet ss = parser.Parse();
            //Assert.IsNull(ss.Tables[0].PageFooter);

            parser.Context.Properties.Add("ExtractSheetFooter", "1");
            JccSpreadsheet ss2 = parser.Parse();
            //Assert.IsNotNull(ss2.Tables[0].PageFooter);
            //Assert.AreEqual("testdoc|test phrase|", ss2.Tables[0].PageFooter);
        }

       
    }
}
