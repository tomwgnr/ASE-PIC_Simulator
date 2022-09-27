namespace PicSimulatorGUI.commands
{

    class Clrf : Command
    {

        Memory memory;

        public Clrf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int registerAddress)
        {
            memory.writeByte(registerAddress, 0);
            memory.writeBit(3, 2, 1);
        
        }

    }
} 