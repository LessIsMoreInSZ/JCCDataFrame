using JCCDataFrame.DataCells;
using JCCDataFrame.Entities.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.DataFrameRows
{
    public struct DataFrameRow:ICloneable
    {
        public int RowIndex { get; set; }
        public int LastCellIndex { get; set; }
        public DataFrameRow(int rowIndex,int lastCellIndex)
        {
            RowIndex = rowIndex;
            LastCellIndex = lastCellIndex;
            Cells = new List<DataFrameCell>();
        }
        public List<DataFrameCell> Cells
        {
            get;
            set;
        }

        public object Clone()
        {
            //DataFrameRow clonedrow = new DataFrameRow(RowIndex, LastCellIndex);
            //foreach (DataFrameCell cell in Cells)
            //{
            //    clonedrow.Cells.Add(cell.Clone() as DataFrameCell);
            //}
            //return clonedrow;
            return new object();
        }
    }
}
