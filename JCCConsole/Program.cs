using JCCConsole.Test;

namespace JCCConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            ExcelParserTest excelParserTest = new ExcelParserTest();
            excelParserTest.BaseTestExtractSheetFooter("45538_classic_Footer.xls");
        }
    }
}
