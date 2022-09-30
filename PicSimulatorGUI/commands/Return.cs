namespace PicSimulatorGUI.commands
{

    class Return : Command
    {



        public Return ()
        {
        }
        public override void execute(int opCode)
        {

            memory.Pc = memory.returnAddr[memory.stackPointer];

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