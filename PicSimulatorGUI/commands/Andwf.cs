namespace PicSimulatorGUI.commands
{

    public class Andwf : Command
    {



        public Andwf ()
        {
        }
        public override void execute(int opCode)
        {

            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = (memory.readByte(registerAddress) & memory.W);
            zeroFlagCheck(value);


            writeToDestination(destinationBit, registerAddress, value);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0xF00) == 0x500)
            {
                return true;
            }

            return false;
        }

    }
} 