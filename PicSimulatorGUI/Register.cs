using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PicSimulatorGUI
{
    public abstract class Register : System.Data.DataTable
    {
        public Register() : base() {}
        public Register(string? tableName) :base(tableName)
        {}
        public void fillNew()
        {
            //spezialRegister = new DataTable(arg);
            Columns.Add("W", typeof(String));
            Columns.Add("FSR", typeof(String));
            Columns.Add("PCL", typeof(String));
            Columns.Add("PCLATH", typeof(String));
            Columns.Add("Status", typeof(String)); 

            Rows.Add(0, 0, 0, 0, 0);
       }
    }
}