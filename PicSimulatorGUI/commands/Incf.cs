namespace PicSimulatorGUI.commands
{

    class Incf : Command
    {

        Memory memory;

        public Incf( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = memory.readByte(registerAddress) + 1;
            value &= 0xFF;

            zeroFlagCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0xA00)
            {
                return true;
            }

            return false;
        }

    }
} 