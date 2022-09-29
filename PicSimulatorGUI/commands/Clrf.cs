namespace PicSimulatorGUI.commands
{

    class Clrf : Command
    {



        public Clrf ()
        {
        }
        public override void execute(int opCode)
        {

            int registerAddress = opCode & 0x7F;
            
            memory.writeByte(registerAddress, 0);
            memory.writeBit(3, 2, 1);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F80) == 0x180)
            {
                return true;
            }

            return false;
        }

    }
} 