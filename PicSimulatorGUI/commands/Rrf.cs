namespace PicSimulatorGUI.commands
{

    class Rrf : Command
    {


        Memory memory;

        public Rrf( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = memory.readByte(registerAddress) >> 1;
            int bit0 = memory.readByte(registerAddress) & 1;
            if ((memory.readByte(3) & 1) == 1)
            {
                value += 1;
            }
            
            //check if bit0 is 1
            if(bit0 == 1)
            {
                memory.writeBit(3, 0, 1);
            }
            else
            {
                memory.writeBit(3, 0, 0);
            }

            writeToDestination(destinationBit, registerAddress, value);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0xC00)
            {
                return true;
            }

            return false;
        }

    }
}