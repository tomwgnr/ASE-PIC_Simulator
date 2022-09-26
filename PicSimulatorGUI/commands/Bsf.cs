namespace PicSimulatorGUI.commands
{

    class Bsf : Command
    {

        Memory memory;

        public Bsf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int bitAddress, int registerAddress)
        {
            memory.writeBit(registerAddress, bitAddress, 1);
        
        }

    }
} 