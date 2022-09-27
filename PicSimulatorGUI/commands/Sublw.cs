
namespace PicSimulatorGUI.commands
{

    class Sublw : Command
    {

        Memory memory;

        public Sublw(ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int literal)
        {
            digitCarryCheck(literal);

            memory.W = literal - memory.W;
            
            carryCheck(memory.W);
            

            memory.W &= 0xFF;

            zeroFlagCheck(memory.W);
        }


    }
}
