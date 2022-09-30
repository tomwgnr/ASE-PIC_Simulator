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
    public class Simulator
    {
        //Datatable for the registers as display
        public registers.SpezialRegister spezReg;
        
        public registers.Table table;
        public registers.T_PortA t_portA;
        public registers.T_PortB t_portB;
        public registers.T_Status t_status;
        public registers.T_Option t_option;
        public registers.T_Intcon t_intcon; 
        
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

        

        public Decoder decoder;

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
            decoder = new Decoder(memory);
            fillTables();


        }

        public void fillTables()
        {
            spezReg = new registers.SpezialRegister("test");
            spezReg.fillNew();

            t_intcon = new registers.T_Intcon("");
            t_intcon.fillNew();

            t_portB = new registers.T_PortB("");
            t_portB.fillNew();

            t_portA = new registers.T_PortA("");
            t_portA.fillNew();

            t_option = new registers.T_Option("");
            t_option.fillNew();

            t_status = new registers.T_Status("");
            t_status.fillNew();

            table = new registers.Table("");
            table.fillNew();

        }
        
        public void executeline()
        {
           
            //set timer
            table.Rows.Find("0")["1"] = Memory.checktwohex((timer & 0xFF));

            

            decoder.analyse(eprom[Pc]);

            sim.FlakenCheck flankCheck = new sim.FlakenCheck();
            RB0 = flankCheck.flankCheck(RB0,oldRB0,ref memory);
            oldRB0 = RB0;

            sim.InterruptCheck interruptCheck = new sim.InterruptCheck();

            if (interruptCheck.interruptCheck(ref memory))
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
    }
}