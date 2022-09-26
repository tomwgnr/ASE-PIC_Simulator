namespace PicSimulatorGUI.commands
{

    class Decfsz : Command
    {

        Memory memory;

        public Decfsz( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress) - 1;
            if (value == 0)
            {
                memory.setProgramCounter(memory.getProgramCounter() + 1);
                memory.incrementTimer();
            }

            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
} 