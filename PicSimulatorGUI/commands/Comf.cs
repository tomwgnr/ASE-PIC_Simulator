namespace PicSimulatorGUI.commands
{

    class Comf : Command
    {

        Memory memory;

        public Comf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress) ^ 0xFF;

            zeroFlagCheck(value);
            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
} 