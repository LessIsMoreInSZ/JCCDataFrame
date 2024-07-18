using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Entities.Spreadsheet
{
    public class JccCell : ICloneable
    {
        public JccCell(int cellIndex, string value)
        {
            if (value == null)
            {
                Value = string.Empty;
            }
            else
            {
                Value = value;
            }
            CellIndex = cellIndex;
        }

        public string Value { get; set; }
        public int CellIndex { get; set; }
        public string Comment { get; set; }
        public string Formula { get; set; }

        public override string ToString()
        {
            return Value;
        }
        public object Clone()
        {
            JccCell clonedCell = new JccCell(CellIndex, Value);
            clonedCell.Comment = Comment;
            clonedCell.Formula = Formula;
            return clonedCell;
        }
    }
}
