
namespace PicSimulatorGUI.commands
{

    class Sublw : Command
    {

        Memory memory;

        public Sublw(ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int literal = opCode & 0xFF;

            digitCarryCheck(literal);

            memory.W = literal - memory.W;
            
            carryCheck(memory.W);
            

            memory.W &= 0xFF;

            zeroFlagCheck(memory.W);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3E00) == 0x3C00)
            {
                return true;
            }

            return false;
        }


    }
}
