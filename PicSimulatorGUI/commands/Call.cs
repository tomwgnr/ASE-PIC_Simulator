namespace PicSimulatorGUI.commands
{

    class Call : Command
    {



        public Call ()
        {
        }
        public override void execute(int opCode)
        {

            int address = opCode & 0x7FF;
            
            if (memory.stackPointer == 7) 
            {
                memory.stackPointer = 0;
            }

            memory.stackPointer++;

            memory.returnAddr[memory.stackPointer] = memory.Pc;
            int pclathBits = (memory.readByte(0xA) & 0x18) << 8;

            memory.Pc = (address + pclathBits) - 1;
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