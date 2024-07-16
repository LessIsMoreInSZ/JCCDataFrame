using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Entities
{
    public class JccCell:ICloneable
    {
        public JccCell(int cellIndex, string value)
        {
            if (value == null)
            {
                this.Value = string.Empty;
            }
            else
            {
                this.Value = value;
            }
            this.CellIndex = cellIndex;
        }

        public string Value { get; set; }
        public int CellIndex { get; set; }
        public string Comment { get; set; }
        public string Formula { get; set; }

        public override string ToString()
        {
            return this.Value;
        }
        public object Clone()
        {
            JccCell clonedCell = new JccCell(this.CellIndex, this.Value);
            clonedCell.Comment = this.Comment;
            clonedCell.Formula = this.Formula;
            return clonedCell;
        }
    }
}
