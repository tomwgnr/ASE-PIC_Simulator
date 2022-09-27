namespace PicSimulatorGUI.commands
{

    class Subwf : Command
    {

        Memory memory;

        public Subwf( ref Memory mem)
        {
            memory = mem;
        }

        
        public void execute(int destinationBit, int registerAddress)
        {
            digitCarryCheck(registerAddress);

            int value = memory.readByte(registerAddress) - memory.W;

            carryCheck(memory.W);

            value &= 0xFF;

            zeroFlagCheck(value);

            resetCarryBits(value);

            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
} 