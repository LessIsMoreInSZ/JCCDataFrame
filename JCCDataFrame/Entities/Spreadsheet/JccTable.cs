using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace JCCDataFrame.Entities.Spreadsheet
{
    public class JccTable : ICloneable
    {
        public JccTable()
        {
            Name = string.Empty;
            HeaderRows = new List<JccRow>();
            Rows = new List<JccRow>();
            LastColumnIndex = -1;
            MergeCells = new List<MergeCellRange>();
        }
        /// <summary>
        /// The sheet has column header (row)
        /// </summary>
        public bool HasHeader
        {
            get { return HeaderRows.Count > 0; }
        }

        public List<MergeCellRange> MergeCells { get; set; }
        public string Name { get; set; }
        public string PageHeader { get; set; }
        public string PageFooter { get; set; }
        public int LastRowIndex { get; set; }
        public int LastColumnIndex { get; set; }

        public List<JccRow> HeaderRows { get; set; }

        public List<JccRow> Rows { get; set; }

        private string ExcelColumnFromNumber(int column)
        {
            column++;
            string columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                decimal currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }

        public DataTable ToDataTable()
        {

            int lastCol = 0;
            DataTable dt = new DataTable(Name);

            int rowIndex = 0;
            if (HasHeader)
            {
                foreach (var header in HeaderRows[0].Cells)
                {
                    var col = new DataColumn(header.Value);
                    dt.Columns.Add(col);
                    lastCol++;
                }
                for (int j = dt.Columns.Count; LastColumnIndex > 0 && j <= LastColumnIndex; j++)
                {
                    dt.Columns.Add(string.Empty);
                    lastCol++;
                }
                rowIndex++;
            }
            foreach (var row in Rows)
            {
                DataRow drow = null;
                if (rowIndex < row.RowIndex)
                {
                    drow = dt.NewRow();
                    while (rowIndex < row.RowIndex)
                    {
                        dt.Rows.Add(drow);
                        drow = dt.NewRow();
                        rowIndex++;
                    }
                }
                else
                {
                    drow = dt.NewRow();
                }

                while (lastCol <= row.LastCellIndex)
                {
                    dt.Columns.Add(ExcelColumnFromNumber(lastCol));
                    lastCol++;
                }

                foreach (var cell in row.Cells)
                {
                    drow[cell.CellIndex] = cell.Value;   //no comment included
                }
                if (drow == null)
                {
                    drow = dt.NewRow();
                }
                dt.Rows.Add(drow);
                rowIndex++;
            }
            return dt;
        }

        public override string ToString()
        {
            return string.Format("[{0}]", Name);
        }

        public object Clone()
        {
            JccTable newtt = new JccTable();
            newtt.PageFooter = PageFooter;
            newtt.PageHeader = PageHeader;
            newtt.Name = Name;
            newtt.LastColumnIndex = LastColumnIndex;
            newtt.LastRowIndex = LastRowIndex;
            foreach (JccRow row in Rows)
            {
                newtt.Rows.Add(row.Clone() as JccRow);
            }
            foreach (JccRow header in HeaderRows)
            {
                newtt.HeaderRows.Add(header.Clone() as JccRow);
            }
            return newtt;
        }
    }
}
