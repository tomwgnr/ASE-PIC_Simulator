namespace PicSimulatorGUI.commands
{

    class Return : Command
    {

        Memory memory;

        public Return( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            memory.setProgramCounter(memory.returnAddr[memory.stackPointer]);

             if (memory.stackPointer == 0)
            {
                memory.stackPointer = 8;
            }
            memory.stackPointer--;

            memory.incrementTimer();
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3FFF) == 0x8)
            {
                return true;
            }

            return false;
        }

    }
} 