using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace JCCDataFrame.Entities.Spreadsheet
{
    public class JccSpreadsheet : ICloneable
    {
        public JccSpreadsheet()
        {
            Tables = new List<JccTable>();
        }
        public string Name { get; set; }
        public List<JccTable> Tables { get; set; }

        public JccTable this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException("sheet name cannot be empty or null");
                }
                for (int i = 0; i < Tables.Count; i++)
                {
                    if (Tables[i].Name == name)
                        return Tables[i];
                }
                return null;
            }
        }




        public DataSet ToDataSet()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = Name;
            foreach (var table in Tables)
            {
                ds.Tables.Add(table.ToDataTable());
            }
            return ds;
        }

        public object Clone()
        {
            JccSpreadsheet newss = new JccSpreadsheet();
            newss.Name = Name;
            for (int i = 0; i < Tables.Count; i++)
            {
                newss.Tables.Add(Tables[i].Clone() as JccTable);
            }
            return newss;
        }
    }
}
