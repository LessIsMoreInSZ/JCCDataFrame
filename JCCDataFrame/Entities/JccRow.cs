using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Entities
{
    public class JccRow : ICloneable
    {
        public int RowIndex { get; set; }
        public int LastCellIndex { get; set; }
        public JccRow(int rowIndex)
        {
            this.RowIndex = rowIndex;
            this.Cells = new List<JccCell>();
        }
        public List<JccCell> Cells
        {
            get;
            set;
        }

        public object Clone()
        {
            JccRow clonedrow = new JccRow(this.RowIndex);
            foreach (JccCell cell in this.Cells)
            {
                clonedrow.Cells.Add(cell.Clone() as JccCell);
            }
            return clonedrow;
        }
    }
}
