namespace PicSimulatorGUI.commands
{

    class Xorwf : Command
    {


        Memory memory;

        public Xorwf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = (memory.readByte(registerAddress) ^ memory.W);
            zeroFlagCheck(value);


            writeToDestination(destinationBit, registerAddress, value);
        }

    }
}