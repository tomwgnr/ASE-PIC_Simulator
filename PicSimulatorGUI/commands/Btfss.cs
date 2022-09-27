namespace PicSimulatorGUI.commands
{

    class Btfss : Command
    {

        Memory memory;

        public Btfss( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int byteAddress, int registerAddress)
        {
            int value = memory.readByte(registerAddress);
            value >>= byteAddress;
            value &= 1;
            if (value == 1)
            {
                memory.setProgramCounter(memory.getProgramCounter() + 1);   
                memory.incrementTimer();
            }
        
        }

    }
} 