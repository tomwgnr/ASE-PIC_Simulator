namespace PicSimulatorGUI
{

    public abstract class Command
    {

        Memory memory;

        public Command()
        {
            
        }

        public void carryCheck(int value)
        {
            if (value > 0xFF || memory.W > 0xFF)
            {
                memory.writeBit(3, 0, 1);
            }
            else
            {
                memory.writeBit(3, 0, 1);
            }
        }


        public void digitCarryCheck(int value)
        {
            if ((memory.readByte(value) & 0xF) + (memory.W & 0xF) > 0xF)
            {
                memory.writeBit(3, 1, 1);
            }
            else
            {
                memory.writeBit(3, 1, 0);
            }

        }

        public void zeroFlagCheck(int value)
        {
            if (value == 0)
            {
                memory.writeBit(3, 2, 1);
            }
            else 
            {
                memory.writeBit(3, 2, 0);
            }
        }

        public void resetCarryBits(int value)
        {
            if (value < 0)
            {

                memory.writeBit(3,0,0);
                memory.writeBit(3,1,0);
                value &= 0xFF;
            }
            else
            {
                memory.writeBit(3,0,1);
                memory.writeBit(3,1,1);
            }
        }

        public void writeToDestination(int destinationBit, int registerAddress, int value)
        {
            if (destinationBit == 0)
            {
                memory.W = value;
            }
            else
            {
                memory.writeByte(registerAddress, value);
            }
        }



    }
}