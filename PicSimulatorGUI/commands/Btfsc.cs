namespace PicSimulatorGUI.commands
{

    class Btfsc : Command
    {

        Memory memory;

        public Btfsc( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int byteAddress, int registerAddress)
        {
            int value = memory.readByte(registerAddress);
            value >>= byteAddress;
            value &= 1;
            if (value == 0)
            {
                memory.setProgramCounter(memory.getProgramCounter() + 1);   
                memory.incrementTimer();
            }
        
        }

    }
} 