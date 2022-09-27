namespace PicSimulatorGUI.commands
{

    class Rlf : Command
    {


        Memory memory;

        public Rlf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress) << 1;
            if ((memory.readByte(3) & 1) == 1)
            {
                value += 1;
            }
            carryCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        }

    }
}