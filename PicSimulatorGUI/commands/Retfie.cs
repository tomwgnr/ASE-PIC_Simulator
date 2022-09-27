namespace PicSimulatorGUI.commands
{

    class Retfie : Command
    {

        Memory memory;

        public Retfie( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            memory.writeBit(0xB, 7, 1);
            memory.setProgramCounter(memory.returnAddr[memory.stackPointer]);

             if (memory.stackPointer == 0)
            {
                memory.stackPointer = 8;
            }
            memory.stackPointer--;

            memory.incrementTimer();
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3FFF) == 0x9)
            {
                return true;
            }

            return false;
        }

    }
} 