using System;
using System.Data;

namespace PicSimulatorGUI.sim
{
    public class FlakenCheck
    {

        public Memory memory;
        public int flankenCheck(int RB0,int oldRB0,ref Memory mem)
        {
            memory = mem;
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
            return RB0;
        }
    }
}