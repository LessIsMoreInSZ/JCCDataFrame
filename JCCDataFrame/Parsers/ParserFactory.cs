using JCCDataFrame.Parsers.Interfaces;
using JCCDataFrame.Parsers.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
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

        static string GetFileExtention(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (!parserMapping.ContainsKey(fi.Extension.ToLower()))
                throw new NotSupportedException("Extension " + fi.Extension + " is not supported");
            return fi.Extension.ToLower();
        }

        /// <summary>
        /// Core fetching object methods
        /// </summary>
        /// <param name="context"></param>
        /// <param name="itype"></param>
        /// <param name="operationName"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        static object CreateObject(ParserContext context, Type itype, string operationName)
        {
            string ext = GetFileExtention(context.Path);
            var types = parserMapping[ext];
            object obj = null;
            bool isFound = false;
            foreach (Type type in types)
            {
                obj = Activator.CreateInstance(type, context);
                if (itype.IsAssignableFrom(obj.GetType()))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
                throw new InvalidDataException(ext + " is not supported for " + operationName);
            return obj;
        }


        public static ISpreadsheetParser CreateSpreadsheet(ParserContext context)
        {
            object obj = CreateObject(context, typeof(ISpreadsheetParser), "CreateSpreadsheet");
            ISpreadsheetParser parser = (ISpreadsheetParser)obj;
            return parser;
        }
    }
}
