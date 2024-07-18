using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.Entities.Spreadsheet
{
    /// <summary>
    /// 合并单元格
    /// </summary>
    public struct MergeCellRange
    {
        public int FirstRow { get; set; }
        public int LastRow { get; set; }
        public int FirstColumn { get; set; }
        public int LastColumn { get; set; }
    }
}
