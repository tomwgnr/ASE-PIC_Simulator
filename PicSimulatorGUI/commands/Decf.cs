namespace PicSimulatorGUI.commands
{

    class Decf : Command
    {

        Memory memory;

        public Decf( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = memory.readByte(registerAddress);
            if (value == 0)
            {
                value = 0xFF;

            } 
            else{
                
                value --;
                zeroFlagCheck(value);
            }

            writeToDestination(destinationBit, registerAddress, value);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0x300)
            {
                return true;
            }

            return false;
        }

    }
} 