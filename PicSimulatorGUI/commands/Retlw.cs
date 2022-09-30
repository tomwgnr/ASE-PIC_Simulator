namespace PicSimulatorGUI.commands
{

    class Retlw : Command
    {


        public Retlw ()
        {
        }
        public override void execute(int opCode)
        {

            int literal = opCode & 0xFF;
            
            memory.W = literal;
            memory.Pc = memory.returnAddr[memory.stackPointer];
            memory.stackPointer --;
            memory.incrementTimer();

        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3E00) == 0x3600)
            {
                return true;
            }

            return false;
        }

    }
} 