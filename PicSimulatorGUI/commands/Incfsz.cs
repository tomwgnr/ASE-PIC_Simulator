namespace PicSimulatorGUI.commands
{

    class Incfsz : Command
    {



        public Incfsz ()
        {
        }
        public override void execute(int opCode)
        {

            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = memory.readByte(registerAddress) + 1;
            value &= 0xFF;
            
            if (value == 0)
            {
                memory.Pc ++;
                memory.incrementTimer();
            }

            writeToDestination(destinationBit, registerAddress, value);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0xF00)
            {
                return true;
            }

            return false;
        }

    }
} 