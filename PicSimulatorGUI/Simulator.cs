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
       
        public string[] input;

        public bool reset = false;
        public Boolean watchdogOn;


        public int oldRB4 = 0;
        public int oldRB0;
        public int RB0;

        public double qf;


        

        public Decoder decoder;

        public Memory memory;

        //eprom arrays
        public int[] eprompositions;
        public int[] eprom;
        public int[] breakpoints;
        public int l_breakpoint;



        public Simulator()
        {
            memory = new Memory();
            decoder = new Decoder(memory);
            


        }

        
        
        public void executeline()
        {
           
            //set timer
            memory.writeByte(0x1, memory.timer & 0xFF);

            

            decoder.analyse(eprom[memory.Pc]);

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

                memory.returnAddr[memory.stackPointer] = memory.Pc;
                int pclathBits = (memory.readByte(0xA) & 0x18) << 8;

                memory.Pc = (4 + pclathBits) - 1;

                memory.incrementTimer();
                //Pc++;
            }

            memory.W &= 0xFF;
            memory.Pc++;
            memory.Pc &= 0x1FFF;

            //set pcl
            memory.writeByte(0x2, (memory.Pc & 0xFF));

            timerInit();
            memory.runtime++;
        }


        public void fillEprom()
        {
            eprom = new int[input.Length];
            eprompositions = new int[input.Length];
            string x;
            string y;
            memory.Pc = 0;
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
                memory.partTimer++;
            }
            else
            {
                //T0CS = 1
                //check if interrupt at rising flank is true
                if (RB4 > oldRB4 && ((memory.readByte(0x81) >> 6) & 1) == 1)
                {
                    memory.partTimer++;
                }
                if (RB4 < oldRB4 && ((memory.readByte(0x81) >> 6) & 1) == 0)
                {
                    memory.partTimer++;

                }


            }

            if (memory.partTimer >= prescaler)
            {
                memory.timer++;
                memory.partTimer = 0;
            }
            if (memory.timer > 0xFF)
            {
                memory.writeBit(0xB, 2, 0);
                memory.timer = 0;
                memory.partTimer = 0;
            }
            oldRB4 = RB4;
        }
    }
}