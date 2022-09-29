namespace PicSimulatorGUI.commands
{

    class Swapf : Command
    {




        public Swapf ()
        {
        }
        public override void execute(int opCode)
        {

            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = memory.readByte(registerAddress);
            zeroFlagCheck(value);

            int bottom4 = (value & 0xF) * 0x10;
            int top4 = (value & 0xF0) / 0x10;

            writeToDestination(destinationBit, registerAddress, bottom4 + top4);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0xE00)
            {
                return true;
            }

            return false;
        }

    }

    
}