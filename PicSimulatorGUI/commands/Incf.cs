namespace PicSimulatorGUI.commands
{

    class Incf : Command
    {

        Memory memory;

        public Incf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress) + 1;
            value &= 0xFF;

            zeroFlagCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
} 