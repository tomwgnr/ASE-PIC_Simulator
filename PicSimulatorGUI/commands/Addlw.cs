
namespace PicSimulatorGUI.commands
{

    class Addlw : Command
    {

        Memory memory;

        public Addlw(ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int literal)
        {
            digitCarryCheck(literal);

            memory.W = memory.W + literal;
            
            carryCheck(memory.W);
            

            memory.W &= 0xFF;

            zeroFlagCheck(memory.W);
        }


    }
}



