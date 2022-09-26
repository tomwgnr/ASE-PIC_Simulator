namespace PicSimulatorGUI.commands
{

    class Addwf : Command
    {

        Memory memory;

        public Addwf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            digitCarryCheck(registerAddress);

            int value = memory.readByte(registerAddress) + memory.W;

            carryCheck(memory.W);

            value &= 0xFF;

            zeroFlagCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
} 