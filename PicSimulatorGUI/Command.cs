namespace PicSimulatorGUI
{

    public abstract class Command
    {
        Simulator simulator;
        Memory memory;

        public Command()
        {
            
        }

        public void carryCheck(int value)
        {
            if (value > 0xFF || simulator.W > 0xFF)
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
            if ((memory.readByte(value) & 0xF) + (simulator.W & 0xF) > 0xF)
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



    }
}