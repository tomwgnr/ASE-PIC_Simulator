namespace PicSimulatorGUI.commands
{

    class Bcf : Command
    {



        public Bcf ()
        {
        }
        public override void execute(int opCode)
        {

            int registerAddress = opCode & 0x7F;
            int bitAddress = (opCode & 0x380) / 0x80;
            
            memory.writeBit(registerAddress, bitAddress, 0);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3C00) == 0x1000)
            {
                return true;
            }

            return false;
        }

    }
} 