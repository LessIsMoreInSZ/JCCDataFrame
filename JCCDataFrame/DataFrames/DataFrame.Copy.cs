using JCCDataFrame.Entities.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCCDataFrame.DataFrames
{
    public partial class DataFrame
    {
        public DataFrame Copy(DataFrame data)
        {
            return data.Clone() as DataFrame;
        }

        public DataFrame CopyPart(DataFrame data,string name,int startRow,int endRow,
            int startCell,int endCell)
        {
            DataFrame dataFrame = new DataFrame();
            dataFrame.PageFooter = data.PageFooter;
            dataFrame.PageHeader = data.PageHeader;
            dataFrame.Name = name;
            dataFrame.LastColumnIndex = endCell - startCell;
            dataFrame.LastRowIndex = endRow - startRow;
            for(int  i = startRow; i <= endRow; i++)
            {
                dataFrame.Rows.Add(data.Rows[i]);
                dataFrame.HeaderRows.Add(data.HeaderRows[i]);
            }

            return dataFrame;
        }
    }
}
