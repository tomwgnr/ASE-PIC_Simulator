namespace PicSimulatorGUI.commands
{

    class Bsf : Command
    {

        Memory memory;

        public Bsf( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int registerAddress = opCode & 0x7F;
            int bitAddress = (opCode & 0x380) / 0x80;
            
            memory.writeBit(registerAddress, bitAddress, 1);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3C00) == 0x1400)
            {
                return true;
            }

            return false;
        }

    }
} 