namespace PicSimulatorGUI.commands
{

    class Btfsc : Command
    {

        Memory memory;

        public Btfsc( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int registerAddress = opCode & 0x7F;
            int bitAddress = (opCode & 0x380) / 0x80;
            
            int value = memory.readByte(registerAddress);
            value >>= bitAddress;
            value &= 1;
            if (value == 0)
            {
                memory.setProgramCounter(memory.getProgramCounter() + 1);   
                memory.incrementTimer();
            }
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3C00) == 0x1800)
            {
                return true;
            }

            return false;
        }

    }
} 