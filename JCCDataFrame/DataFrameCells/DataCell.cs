using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.DataCells
{
    public struct DataFrameCell
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public Type DType { get; set; }

        public override string ToString()
            => $"{Name} {DType}";
    }
}
