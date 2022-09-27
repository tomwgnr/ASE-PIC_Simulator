namespace PicSimulatorGUI.commands
{

    class Goto : Command
    {

        Memory memory;

        public Goto( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int address = opCode & 0x7FF;
            
            int pclathBits = (memory.readByte(0xA) & 0x18) << 8;

            memory.setProgramCounter((address + pclathBits) - 1);

            memory.incrementTimer();

        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3E00) == 0x2800)
            {
                return true;
            }

            return false;
        }

    }
} 