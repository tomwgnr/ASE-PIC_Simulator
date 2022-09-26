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
    class Simulator
    {
        //Datatable for the registers as display
        public DataTable spezialRegister;
        public DataTable table;
        public DataTable t_PortA;
        public DataTable t_PortB;
        public DataTable t_status;
        public DataTable t_Option;
        public DataTable t_intcon;

        public string[] input;

        public bool reset = false;
        public Boolean watchdogOn;
        public int Pc;
        public int timer;
        public int partTimer;
        //public int wdTimer;
        //public int s_pointer = 0;
        public int oldRB4 = 0;
        public int oldRB0;
        public int RB0;
        //public int[] returnAddr = new int[6];
        public double qf;
        public double runtime = 0;

        

        public Decode decode;
        //public Cpu cpu;

        public Memory memory;

        //eprom arrays
        public int[] eprompositions;
        public int[] eprom;
        public int[] breakpoints;
        public int l_breakpoint;



        public Simulator()
        {
            memory = new Memory(this);
            //cpu = new Cpu(this);
            decode = new Decode(memory);
            fillNewTable();
            fillextratables();
        }

        public void fillNewTable()
        {
            table = new DataTable("EPROM");
            table.Columns.Add("Adr", typeof(String));
            table.Columns.Add("0", typeof(String));
            table.Columns.Add("1", typeof(String));
            table.Columns.Add("2", typeof(String));
            table.Columns.Add("3", typeof(String));
            table.Columns.Add("4", typeof(String));
            table.Columns.Add("5", typeof(String));
            table.Columns.Add("6", typeof(String));
            table.Columns.Add("7", typeof(String));

            table.PrimaryKey = new DataColumn[] { table.Columns["Adr"] };

            for (int i = 0; i < 0xFF; i += 8)
            {
                string j = i.ToString("X");
                table.Rows.Add(j, "00", "00", "00", "00", "00", "00", "00", "00");
            }
        }

        public void fillextratables()
        {
            spezialRegister = new DataTable("spezial");
            spezialRegister.Columns.Add("W", typeof(String));
            spezialRegister.Columns.Add("FSR", typeof(String));
            spezialRegister.Columns.Add("PCL", typeof(String));
            spezialRegister.Columns.Add("PCLATH", typeof(String));
            spezialRegister.Columns.Add("Status", typeof(String));

            spezialRegister.Rows.Add(0, 0, 0, 0, 0);

            t_PortA = new DataTable("porta");
            t_PortA.Columns.Add("RA");
            t_PortA.Columns.Add("7");
            t_PortA.Columns.Add("6");
            t_PortA.Columns.Add("5");
            t_PortA.Columns.Add("4");
            t_PortA.Columns.Add("3");
            t_PortA.Columns.Add("2");
            t_PortA.Columns.Add("1");
            t_PortA.Columns.Add("0");
            t_PortA.Rows.Add("Tris", "o", "o", "o", "o", "o", "o", "o", "o");
            t_PortA.Rows.Add("Pin", 0, 0, 0, 0, 0, 0, 0, 0);


            t_PortB = new DataTable("portb");
            t_PortB.Columns.Add("RB");
            t_PortB.Columns.Add("7");
            t_PortB.Columns.Add("6");
            t_PortB.Columns.Add("5");
            t_PortB.Columns.Add("4");
            t_PortB.Columns.Add("3");
            t_PortB.Columns.Add("2");
            t_PortB.Columns.Add("1");
            t_PortB.Columns.Add("0");
            t_PortB.Rows.Add("Tris", "o", "o", "o", "o", "o", "o", "o", "o");
            t_PortB.Rows.Add("Pin", 0, 0, 0, 0, 0, 0, 0, 0);

            t_status = new DataTable("status");
            t_status.Columns.Add("IRP");
            t_status.Columns.Add("RP1");
            t_status.Columns.Add("RP0");
            t_status.Columns.Add("TO");
            t_status.Columns.Add("PD");
            t_status.Columns.Add("Z");
            t_status.Columns.Add("DC");
            t_status.Columns.Add("C");
            t_status.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0);

            t_Option = new DataTable("option");
            t_Option.Columns.Add("RBP");
            t_Option.Columns.Add("IE");
            t_Option.Columns.Add("TOCS");
            t_Option.Columns.Add("TOSE");
            t_Option.Columns.Add("PSA");
            t_Option.Columns.Add("PS2");
            t_Option.Columns.Add("PS1");
            t_Option.Columns.Add("PS0");
            t_Option.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0);

            t_intcon = new DataTable("intcon");
            t_intcon.Columns.Add("GIE");
            t_intcon.Columns.Add("PIE");
            t_intcon.Columns.Add("T0IE");
            t_intcon.Columns.Add("INTE");
            t_intcon.Columns.Add("RBIE");
            t_intcon.Columns.Add("T0IF");
            t_intcon.Columns.Add("INTF");
            t_intcon.Columns.Add("TBIF");
            t_intcon.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0);
        }


        public void executeline()
        {
           
            //set timer
            table.Rows.Find("0")["1"] = Memory.checktwohex((timer & 0xFF));

            

            decode.analyse(eprom[Pc]);

            flankCheck();

            if (interruptCheck())
            {
                memory.writeBit(0xB, 7, 0);

                if (memory.stackPointer == 7) 
                {
                    memory.stackPointer = 0;
                }

                memory.stackPointer++;

                memory.returnAddr[memory.stackPointer] = memory.getProgramCounter();
                int pclathBits = (memory.readByte(0xA) & 0x18) << 8;

                memory.setProgramCounter((4 + pclathBits) - 1);

                memory.incrementTimer();
                //Pc++;
            }

            memory.W &= 0xFF;
            Pc++;
            Pc &= 0x1FFF;

            //set pcl
            table.Rows.Find("0")["2"] = Memory.checktwohex((Pc & 0xFF));

            timerInit();
            runtime++;
        }


        public void fillEprom()
        {
            eprom = new int[input.Length];
            eprompositions = new int[input.Length];
            string x;
            string y;
            Pc = 0;
            int count = 0;
            for (int i = 0; i < eprom.Length; i++)
            {
                x = input[i].Substring(0, 9);
                if (!string.IsNullOrWhiteSpace(x))
                {

                    string[] ph = x.Split(' ');
                    int z = int.Parse(ph[1], System.Globalization.NumberStyles.HexNumber);
                    y = Convert.ToString(z, 2);
                    z = Convert.ToInt32(y, 2);
                    Console.WriteLine(ph[1]);
                    eprom[count] = z;
                    eprompositions[count] = i;

                    count++;
                }

            }
            breakpoints = new int[count];
            for (int i = 0; i < count; i++)
            {
                breakpoints[i] = 0;
            }
            Array.Resize(ref eprom, count);
            Array.Resize(ref eprompositions, count);

            oldRB0 = memory.readByte(6) & 1;
            memory.writeByte(0x81, 0xFF);
        }

        public void timerInit()
        {
            int prescaler;
            int wdPrescaler;



            if (((memory.readByte(0x81) >> 3) & 1) == 0)
            {
                prescaler = (int)Math.Pow(2, 1 + (memory.readByte(0x81) & 7));
                wdPrescaler = 1;
            }
            else
            {
                wdPrescaler = 2 ^ (memory.readByte(0x81) & 7);
                prescaler = 2;
            }

            
            

            int RB4 = (memory.readByte(6) >> 4) & 1;


            if (((memory.readByte(0x81) >> 5) & 1) == 0)
            {
                //T0CS = 0
                partTimer++;
            }
            else
            {
                //T0CS = 1
                //check if interrupt at rising flank is true
                if (RB4 > oldRB4 && ((memory.readByte(0x81) >> 6) & 1) == 1)
                {
                    partTimer++;
                }
                if (RB4 < oldRB4 && ((memory.readByte(0x81) >> 6) & 1) == 0)
                {
                    partTimer++;

                }


            }

            if (partTimer >= prescaler)
            {
                timer++;
                partTimer = 0;
            }
            if (timer > 0xFF)
            {
                memory.writeBit(0xB, 2, 0);
                timer = 0;
                partTimer = 0;
            }
            oldRB4 = RB4;
        }

       

        public bool interruptCheck()
        {
            //GIE bit set
            if ( ((memory.readByte(0xB) >> 7) & 1) == 1)
            {
                //timer0 interrupt
                if ((((memory.readByte(0xB) >> 2) & 1) == 1) && (((memory.readByte(0xB) >> 5) & 1) == 1))
                {
                    return true;
                }
                //interrupt für INT(RB0)
                var intcon = memory.readByte(0xB);
                if ((((memory.readByte(0xB) >> 1) & 1) == 1) && (((memory.readByte(0xB) >> 4) & 1) == 1))
                {
                     return true;
                }

                //interrupt für RB4 - RB7
                return false;
            }
            else
            {
                return false;
            }
        }

        public void flankCheck()
        {
            RB0 = memory.readByte(6) & 1;

            if((memory.readByte(6) & 1 & 1) == 1)
            {
                memory.writeByte(0x30, 1);
            }
            
            if ((memory.readByte(6) & 1 & 1) == 0)
            {
                memory.writeByte(0x30, 2);
            }

            //check if interrupt at rising flank is true
            if (RB0 > oldRB0 && ((memory.readByte(0x81) >> 6) & 1) == 1)
            {
                memory.writeBit(0xB, 1, 1);

            }
            var z = memory.readByte(0x81);
            var y = z >> 6;
            if (RB0 < oldRB0 && ((memory.readByte(0x81) >> 6) & 1) == 0)
            {
                memory.writeBit(0xB, 1, 1);
            }

            
            oldRB0 = RB0;
        }

    }
}