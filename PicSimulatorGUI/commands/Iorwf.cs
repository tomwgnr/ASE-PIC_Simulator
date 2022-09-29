namespace PicSimulatorGUI.commands
{

    class Iorwf : Command
    {


        public Iorwf ()
        {
        }
        public override void execute(int opCode)
        {

            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = memory.readByte(registerAddress) | memory.W;
            
            zeroFlagCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0x400)
            {
                return true;
            }

            return false;
        }

    }
} 