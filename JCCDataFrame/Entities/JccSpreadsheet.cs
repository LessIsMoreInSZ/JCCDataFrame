using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace JCCDataFrame.Entities
{
    public class JccSpreadsheet:ICloneable
    {
        public JccSpreadsheet()
        {
            this.Tables = new List<JccTable>();
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
                for (int i = 0; i < this.Tables.Count; i++)
                {
                    if (this.Tables[i].Name == name)
                        return this.Tables[i];
                }
                return null;
            }
        }




        public DataSet ToDataSet()
        {
            DataSet ds = new DataSet();
            ds.DataSetName = this.Name;
            foreach (var table in this.Tables)
            {
                ds.Tables.Add(table.ToDataTable());
            }
            return ds;
        }

        public object Clone()
        {
            JccSpreadsheet newss = new JccSpreadsheet();
            newss.Name = this.Name;
            for (int i = 0; i < this.Tables.Count; i++)
            {
                newss.Tables.Add(this.Tables[i].Clone() as JccTable);
            }
            return newss;
        }
    }
}
