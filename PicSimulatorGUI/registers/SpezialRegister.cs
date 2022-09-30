using System;
using System.Data;

namespace PicSimulatorGUI.registers
{
    public class SpezialRegister : DataTable
    {
        public SpezialRegister(string tableName) :base(tableName)
        {}
        public void fillNew()
        {
            //new DataTable("spezial");
            Columns.Add("W", typeof(String));
            Columns.Add("FSR", typeof(String));
            Columns.Add("PCL", typeof(String));
            Columns.Add("PCLATH", typeof(String));
            Columns.Add("Status", typeof(String)); 

            Rows.Add(0, 0, 0, 0, 0);
        }

    }
}