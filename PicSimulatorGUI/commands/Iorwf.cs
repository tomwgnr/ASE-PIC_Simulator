namespace PicSimulatorGUI.commands
{

    class Iorwf : Command
    {

        Memory memory;

        public Iorwf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress) | memory.W;
            
            zeroFlagCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
} 