namespace PicSimulatorGUI.commands
{

    public class Addwf : Command
    {



        public Addwf ()
        {
        }
        public override void execute(int opCode)
        {

            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            digitCarryCheck(registerAddress);

            int value = memory.readByte(registerAddress) + memory.W;

            carryCheck(memory.W);

            value &= 0xFF;

            zeroFlagCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0xF00) == 0x700)
            {
                return true;
            }

            return false;
        }

    }
} 