namespace PicSimulatorGUI.commands
{

    class Rlf : Command
    {



        public Rlf ()
        {
        }
        public override void execute(int opCode)
        {
            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = memory.readByte(registerAddress) << 1;
            if ((memory.readByte(3) & 1) == 1)
            {
                value += 1;
            }
            carryCheck(value);

            writeToDestination(destinationBit, registerAddress, value);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0xD00)
            {
                return true;
            }

            return false;
        }

    }
}