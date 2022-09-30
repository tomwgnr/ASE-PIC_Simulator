using System;
using System.Data;

namespace PicSimulatorGUI.registers
{
    public class T_Status : DataTable
    {
        public T_Status(string tableName) :base(tableName)
        {}
        public void fillNew()
        {
            Columns.Add("IRP");
            Columns.Add("RP1");
            Columns.Add("RP0");
            Columns.Add("TO");
            Columns.Add("PD");
            Columns.Add("Z");
            Columns.Add("DC");
            Columns.Add("C");
            Rows.Add(0, 0, 0, 0, 0, 0, 0, 0);

        }

    }
}