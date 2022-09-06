using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicSimulatorGUI
{
    public partial class Form1 : Form
    {
        string[] input;
        Simulator sim;
        public bool threadRunning = false;
        Thread t;
        DataGridViewRow lastrow;
        string oldcellvalue;
        string oldquartzvalue;
        double quartz = 4;


        public Form1()
        {
            InitializeComponent();
            sim = new Simulator();

        }

        //fill all the grids by binding source and set layout
        void fillDataGrid()
        {
            Eprom.DataSource = sim.table.DefaultView;
            spezialRegister.DataSource = sim.spezialRegister.DefaultView;
            PA.DataSource = sim.t_PortA.DefaultView;
            PB.DataSource = sim.t_PortB.DefaultView;
            Status.DataSource = sim.t_status.DefaultView;
            optionReg.DataSource = sim.t_Option.DefaultView;
            intcon.DataSource = sim.t_intcon.DefaultView;

            //initialze PA
            PA.Width = 250;
            PA.Height = 62;
            PA.Font = new Font("Courier New", 7);
            PA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PA.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            PA.Columns[0].Width = 30;
            PA.AllowUserToAddRows = false;
            PA.RowHeadersVisible = false;
            PA.ReadOnly = true;

            //initialize PB
            PB.Width = 250;
            PB.Height = 62;
            PB.Font = new Font("Courier New", 7);
            PB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            PB.Columns[0].Width = 30;
            PB.AllowUserToAddRows = false;
            PB.RowHeadersVisible = false;
            PB.ReadOnly = true;

            //initialize special
            spezialRegister.Width = 220;
            spezialRegister.Height = 38;
            spezialRegister.Font = new Font("Courier New", 7);
            spezialRegister.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            spezialRegister.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
            //initialize Status
            Status.Width = 300;
            Status.Height = 38;
            Status.Font = new Font("Courier New", 7);
            Status.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Status.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Status.AllowUserToAddRows = false;
            Status.RowHeadersVisible = false;
            Status.ReadOnly = true;

            //initialize option reg
            optionReg.Width = 300;
            optionReg.Height = 38;
            optionReg.Font = new Font("Courier New", 7);
            optionReg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            optionReg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            optionReg.AllowUserToAddRows = false;
            optionReg.RowHeadersVisible = false;
            optionReg.ReadOnly = true;

            //initialize intcon
            intcon.Width = 300;
            intcon.Height = 38;
            intcon.Font = new Font("Courier New", 7);
            intcon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            intcon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            intcon.AllowUserToAddRows = false;
            intcon.RowHeadersVisible = false;
            intcon.ReadOnly = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.fillDataGrid();
            codeView.RowTemplate.Height = 20;
        }

        //load file and initiate eprom etc.
        private void loadFile_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.ShowDialog();
            if (oFD.FileName != "")
            {
                codeView.Rows.Clear();
                input = System.IO.File.ReadAllLines(oFD.FileName);
                for (int i = 0; i < input.Length; i++)
                {
                    codeView.Rows.Add(false, input[i]);
                }

                sim.input = input;
                sim.fillEprom();
                sim.qf = quartz;
                highlightlastrow();
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!(sim.eprom == null) && threadRunning == false)
            {
                checkBreakpoints();
                threadStart();
            }
        }

        //check if breakpoints were set
        private void checkBreakpoints()
        {
            for (int i = 0; i < codeView.RowCount; i++)
            {
                bool t321 = (bool)codeView.Rows[i].Cells[0].Value;
                if (t321 == true)
                {
                    for (int j = 0; j < sim.eprompositions.Count(); j++)
                    {
                        if (i == sim.eprompositions[j])
                        {
                            sim.breakpoints[j] = 1;
                        }
                    }
                }
            }
        }

        //stop all threads and running code
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            if (sim.eprom != null)
            {
                resetProgram();
            }

        }

        //reset program
        private void resetProgram()
        {
            threadRunning = false;
            System.Threading.Thread.Sleep(500);
            sim = new Simulator();
            fillDataGrid();
            sim.input = input;
            sim.fillEprom();
            lbl_wdtimer.Text = "0";
            label_tmr.Text = "0";
            lbl_timer.Text = "0";
            highlightlastrow();
        }

        //next step in program
        private void btn_StepForward_Click(object sender, EventArgs e)
        {
            if(sim.eprom != null)
            {
                
                checkBreakpoints();
                sim.executeline();
                highlightlastrow();
                UpdateWindows();
            }
        }

        //start a new thread to run a program
        public void threadStart()
        {
            threadRunning = true;
            t = new Thread(run);
            t.Name = "testthread";
            t.IsBackground = true;
            t.Start();
        }

        //update all the Elements of the GUI while program is running
        public void UpdateWindows()
        {
            sim.spezialRegister.Rows[0].SetField(0, sim.W.ToString("X") + "h");
            sim.spezialRegister.Rows[0].SetField(1, sim.table.Rows[0].Field<string>(5));    //FSR
            sim.spezialRegister.Rows[0].SetField(2, sim.table.Rows[0].Field<string>(3));    //PCL
            sim.spezialRegister.Rows[0].SetField(3, sim.table.Rows[1].Field<string>(3));    //PCLATH
            sim.spezialRegister.Rows[0].SetField(4, sim.table.Rows[0].Field<string>(4));

            //Port A
            var ha1 = sim.table.Rows[0].Field<string>(6);
            var ha2 = sim.table.Rows[15].Field<string>(6);
            var portA = HexStringToBinary(ha1);
            var portAio = HexStringToBinary(ha2);
            for (int i = 1; i <= 8; i++)    //starts at 1 because first field contains name
            {
                PA.Rows[1].Cells[i].Value = portA[i-1];
                if (portAio[i-1] == '0')
                {
                    PA.Rows[0].Cells[i].Value = "o";
                } else if (portAio[i - 1] == '1')
                {
                    PA.Rows[0].Cells[i].Value = "i";
                }
            }

            //Port B
            var hb1 = sim.table.Rows[0].Field<string>(7);
            var hb2 = sim.table.Rows[15].Field<string>(7);
            var portB = HexStringToBinary(hb1);
            var portBio = HexStringToBinary(hb2);
            for (int i = 1; i <= 8; i++)    //starts at 1 because first field contains name
            {
                PB.Rows[1].Cells[i].Value = portB[i-1];
                if (portBio[i - 1] == '0')
                {
                    PB.Rows[0].Cells[i].Value = "o";
                }
                else if (portBio[i - 1] == '1')
                {
                    PB.Rows[0].Cells[i].Value = "i";
                }
            }

            //Status 
            var hs = sim.table.Rows[0].Field<string>("3");
            var status = HexStringToBinary(hs);
            for (int i = 0; i < 8; i++)
            {
                Status.Rows[0].Cells[i].Value = status[i];
            }

            //Option
            var ho = sim.table.Rows[16].Field<string>("0");
            var option = HexStringToBinary(ho);
            for (int i = 0; i < 8; i++)
            {
                optionReg.Rows[0].Cells[i].Value = option[i];
            }

            //intcon
            var hi = sim.table.Rows[1].Field<string>("3");
            var intco = HexStringToBinary(hi);
            for (int i = 0; i < 8; i++)
            {
                intcon.Rows[0].Cells[i].Value = intco[i];
            }
            
            Action updateWD = () => lbl_wdtimer.Text = sim.wdTimer.ToString();
            Invoke(updateWD);

            double time = ((1 / quartz) * sim.runtime) * 4;

            Action updateTimer = () => lbl_timer.Text = time.ToString();
            Invoke(updateTimer);

            Action updateTMR = () => label_tmr.Text = sim.timer.ToString();
            Invoke(updateTMR);
        }


        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'a', "1010" },
            { 'b', "1011" },
            { 'c', "1100" },
            { 'd', "1101" },
            { 'e', "1110" },
            { 'f', "1111" }
        };      
        
        //convert a string of hex to a binary number without deleting leading zeros
        public string HexStringToBinary(string hex)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in hex)
            {
                result.Append(hexCharacterToBinary[char.ToLower(c)]);
            }
            return result.ToString();
        }

        //run a program
        public void run()
        {
            bool bp = false;
            while (sim.Pc < sim.eprom.Length && threadRunning == true && bp == false)
            {
                if (sim.reset == true)
                {
                    threadRunning = false;
                    Action resetall = resetProgram;
                    Invoke(resetall);
                    return;
                }
                if (sim.breakpoints[sim.Pc] == 1 && sim.l_breakpoint != sim.Pc)
                {
                    sim.l_breakpoint = sim.Pc;
                    bp = true;
                    threadRunning = false;
                }
                else
                {
                    if (cb_watchdog.Checked)
                    {
                        sim.watchdogOn = true;
                    }
                    else if (!cb_watchdog.Checked)
                    {
                        sim.watchdogOn = false;
                    }
                    
                    sim.executeline();
                    highlightlastrow();
                    UpdateWindows(); 
                    Action updateProgress = updateGUI;         

                    Invoke(updateProgress);
                }
            }
        }

        //update the GUI
        public void updateGUI()
        {
            Eprom.Update();
            PA.Update();
            PB.Update();
            Status.Update();
            optionReg.Update();
            spezialRegister.Update();
            intcon.Update();
        }

        //highlighting of code row
        public void highlightlastrow()
        {
            if (lastrow != null)
            {
                lastrow.DefaultCellStyle.BackColor = codeView.DefaultCellStyle.BackColor;
            }
            lastrow = codeView.Rows[sim.eprompositions[sim.Pc]];
            lastrow.DefaultCellStyle.BackColor = Color.LightBlue;
        }

        //change in PortA
        private void PA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex;
            if (x == 1)
            {
                int y = e.ColumnIndex;
                string s = PA.Rows[x].Cells[y].Value.ToString();
                if (s == "1")
                {
                    sim.t_PortA.Rows[x].SetField(y, "0");
                }
                else if (s == "0")
                {
                    sim.t_PortA.Rows[x].SetField(y, "1");
                }
                string binary = "";
                for (int i = 1; i <= 8; i++)
                {
                    binary = binary + PA.Rows[1].Cells[i].Value.ToString();

                }
                int intHex = Convert.ToInt32(binary, 2);
                sim.table.Rows[0].SetField(6, Cpu.checktwohex(intHex));
            }
        }

        //change in PortB
        private void PB_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int x = e.RowIndex;
            if (x == 1)
            {
                int y = e.ColumnIndex;
                string s = PB.Rows[x].Cells[y].Value.ToString();
                if (s == "1")
                {
                    sim.t_PortB.Rows[x].SetField(y, "0");
                }
                else if (s == "0")
                {
                    sim.t_PortB.Rows[x].SetField(y, "1");
                }
                string binary = "";
                for (int i = 1; i <= 8; i++)
                {
                    binary = binary + PB.Rows[1].Cells[i].Value.ToString();

                }
                int intHex = Convert.ToInt32(binary, 2);
                sim.table.Rows[0].SetField(7, Cpu.checktwohex(intHex));
            }
        }

        //validate new value
        private void Eprom_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var newvalue = Eprom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (newvalue.Length > 2 || newvalue.Length == 0)
            {
                Eprom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldcellvalue;
            }
            else
            {
                try
                {
                    var x = Int32.Parse(newvalue, System.Globalization.NumberStyles.HexNumber);
                    sim.table.Rows[e.RowIndex].SetField(e.ColumnIndex, Cpu.checktwohex(x));
                }
                catch (FormatException)
                {
                    Eprom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldcellvalue;
                }
            }
        }

        //save oldvalue on editbegin
        private void Eprom_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldcellvalue = Eprom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
        
        //pause program
        private void btn_pause_Click(object sender, EventArgs e)
        {
            threadRunning = false;
        }

        //validate new quartz value
        private void tb_quartz_Validating(object sender, CancelEventArgs e)
        {
            if (threadRunning == false)
            {
                var text = tb_quartz.Text;
                try
                {
                    quartz = double.Parse(text);
                    if(sim.eprom != null)
                    {
                        sim.qf = quartz;
                    }
                }
                catch (FormatException)
                {
                    tb_quartz.Text = oldquartzvalue;
                    e.Cancel = true;
                    MessageBox.Show("incorrect Quartz value");
                }

            } else
            {
                tb_quartz.Text = oldquartzvalue;
            }
        }

        //save old value when entering field
        private void tb_quartz_Enter(object sender, EventArgs e)
        {
            oldquartzvalue = tb_quartz.Text;
        }

    }
}
