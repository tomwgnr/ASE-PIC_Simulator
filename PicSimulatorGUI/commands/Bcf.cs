namespace PicSimulatorGUI.commands
{

    class Bcf : Command
    {

        Memory memory;

        public Bcf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int bitAddress, int registerAddress)
        {
            memory.writeBit(registerAddress, bitAddress, 0);
        
        }

    }
} 