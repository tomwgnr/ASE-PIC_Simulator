namespace PicSimulatorGUI.commands
{

    class Swapf : Command
    {


        Memory memory;

        public Swapf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress);
            zeroFlagCheck(value);

            int bottom4 = (value & 0xF) * 0x10;
            int top4 = (value & 0xF0) / 0x10;

            writeToDestination(destinationBit, registerAddress, bottom4 + top4);
        }

    }
}