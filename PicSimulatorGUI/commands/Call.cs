namespace PicSimulatorGUI.commands
{

    class Call : Command
    {

        Memory memory;

        public Call( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int address = opCode & 0x7FF;
            
            if (memory.stackPointer == 7) 
            {
                memory.stackPointer = 0;
            }

            memory.stackPointer++;

            memory.returnAddr[memory.stackPointer] = memory.getProgramCounter();
            int pclathBits = (memory.readByte(0xA) & 0x18) << 8;

            memory.setProgramCounter((address + pclathBits) - 1);

            memory.incrementTimer();
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3E00) == 0x2000)
            {
                return true;
            }

            return false;
        }

    }
} 