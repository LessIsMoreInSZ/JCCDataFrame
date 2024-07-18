using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Entities.Spreadsheet
{
    public class JccRow : ICloneable
    {
        public int RowIndex { get; set; }
        public int LastCellIndex { get; set; }
        public JccRow(int rowIndex)
        {
            RowIndex = rowIndex;
            Cells = new List<JccCell>();
        }
        public List<JccCell> Cells
        {
            get;
            set;
        }

        public object Clone()
        {
            JccRow clonedrow = new JccRow(RowIndex);
            foreach (JccCell cell in Cells)
            {
                clonedrow.Cells.Add(cell.Clone() as JccCell);
            }
            return clonedrow;
        }
    }
}
