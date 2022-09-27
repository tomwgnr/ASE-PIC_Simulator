namespace PicSimulatorGUI.commands
{

    class Incfsz : Command
    {

        Memory memory;

        public Incfsz( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress) + 1;
            value &= 0xFF;
            
            if (value == 0)
            {
                memory.setProgramCounter(memory.getProgramCounter() + 1);
                memory.incrementTimer();
            }

            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
} 