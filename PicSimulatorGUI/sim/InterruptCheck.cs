using System;
using System.Data;

namespace PicSimulatorGUI.sim
{
    public class InterruptCheck
    {

        public Memory memory;
        public bool interruptCheck(ref Memory mem)
        {
            //GIE bit set
            memory = mem;
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
    }
}