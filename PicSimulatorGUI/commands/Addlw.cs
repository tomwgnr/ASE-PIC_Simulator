
namespace PicSimulatorGUI.commands
{

    class Addlw : Command
    {



        public Addlw ()
        {
            
        }
        public override void execute(int opCode)
        {

            int literal = opCode & 0xFF;


            digitCarryCheck(literal);

            memory.W = memory.W + literal;
            
            carryCheck(memory.W);
            

            memory.W &= 0xFF;

            zeroFlagCheck(memory.W);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3E00) == 0x3E00)
            {
                return true;
            }

            return false;
        }

    }
}



