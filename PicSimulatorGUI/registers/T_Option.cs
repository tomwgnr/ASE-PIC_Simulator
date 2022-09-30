using System;
using System.Data;

namespace PicSimulatorGUI.registers
{
    public class T_Option : DataTable
    {
        public T_Option(string tableName) :base(tableName)
        {}
        public void fillNew()
        {
            Columns.Add("RBP");
            Columns.Add("IE");
            Columns.Add("TOCS");
            Columns.Add("TOSE");
            Columns.Add("PSA");
            Columns.Add("PS2");
            Columns.Add("PS1");
            Columns.Add("PS0");
            Rows.Add(0, 0, 0, 0, 0, 0, 0, 0);

        }

    }
}