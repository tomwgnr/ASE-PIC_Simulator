using System;
using System.Data;
namespace PicSimulatorGUI.registers
{
    public class T_PortB : DataTable
    {
        public T_PortB(string tableName) :base(tableName)
        {}
        public void fillNew()
        {
            //t_PortB = new DataTable("portb");
            Columns.Add("RB");
            Columns.Add("7");
            Columns.Add("6");
            Columns.Add("5");
            Columns.Add("4");
            Columns.Add("3");
            Columns.Add("2");
            Columns.Add("1");
            Columns.Add("0");
            Rows.Add("Tris", "o", "o", "o", "o", "o", "o", "o", "o");
            Rows.Add("Pin", 0, 0, 0, 0, 0, 0, 0, 0);

        }

    }
}