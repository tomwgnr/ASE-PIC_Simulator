namespace PicSimulatorGUI.commands
{

    class Btfss : Command
    {



        public Btfss ()
        {
        }
        public override void execute(int opCode)
        {

            int registerAddress = opCode & 0x7F;
            int bitAddress = (opCode & 0x380) / 0x80;
            
            int value = memory.readByte(registerAddress);
            value >>= bitAddress;
            value &= 1;
            if (value == 1)
            {
                memory.Pc ++;  
                memory.incrementTimer();
            }
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3C00) == 0x1C00)
            {
                return true;
            }

            return false;
        }

    }
} 