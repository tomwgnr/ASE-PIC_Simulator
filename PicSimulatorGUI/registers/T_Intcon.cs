using System;
using System.Data;

namespace PicSimulatorGUI.registers
{
    public class T_Intcon : DataTable
    {
        public T_Intcon(string tableName) :base(tableName)
        {}
        public void fillNew()
        {
            Columns.Add("GIE");
            Columns.Add("PIE");
            Columns.Add("T0IE");
            Columns.Add("INTE");
            Columns.Add("RBIE");
            Columns.Add("T0IF");
            Columns.Add("INTF");
            Columns.Add("TBIF");
            
            Rows.Add(0, 0, 0, 0, 0, 0, 0, 0);
        }

    }
}