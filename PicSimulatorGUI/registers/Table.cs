using System;
using System.Data;

namespace PicSimulatorGUI.registers
{
    public class Table : DataTable
    {
        public Table(string tableName) :base(tableName)
        {}
        public void fillNew()
        {
            Columns.Add("Adr", typeof(String));
            Columns.Add("0", typeof(String));
            Columns.Add("1", typeof(String));
            Columns.Add("2", typeof(String));
            Columns.Add("3", typeof(String));
            Columns.Add("4", typeof(String));
            Columns.Add("5", typeof(String));
            Columns.Add("6", typeof(String));
            Columns.Add("7", typeof(String));

            PrimaryKey = new DataColumn[] { Columns["Adr"] };

            for (int i = 0; i < 0xFF; i += 8)
            {
                string j = i.ToString("X");
                Rows.Add(j, "00", "00", "00", "00", "00", "00", "00", "00");
            }
        }

    }
}