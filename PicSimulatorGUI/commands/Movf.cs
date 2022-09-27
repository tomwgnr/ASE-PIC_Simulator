namespace PicSimulatorGUI.commands
{

    class Movf : Command
    {

        Memory memory;

        public Movf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress);
            
            zeroFlagCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
}