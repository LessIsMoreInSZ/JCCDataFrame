using JCCDataFrame.DataCells;
using JCCDataFrame.Entities.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace JCCDataFrame.DataFrames
{
    public partial class DataFrame
    {
        public DataFrame()
        {
            Name = string.Empty;
            HeaderRows = new List<string>();
            Cells = new List<DataFrameCell>();
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
        public int LastRowIndex { get; set; }
        public int LastColumnIndex { get; set; }

        public List<string> HeaderRows { get; set; }

        public List<DataFrameCell> Cells { get; set; }

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
            return ($"[{Name}]");
        }

        public object Clone()
        {
            DataFrameCell newtt = new DataFrameCell();
            newtt.Name = Name;
            //newtt.LastColumnIndex = LastColumnIndex;
            //newtt.LastRowIndex = LastRowIndex;
            foreach (DataFrameCell cell in Cells)
            {
                //newtt.Cells.Add(row.Clone() as JccRow);

            }
            foreach (string header in HeaderRows)
            {
                newtt.Name = header;
            }
            return newtt;
        }
    }
}
