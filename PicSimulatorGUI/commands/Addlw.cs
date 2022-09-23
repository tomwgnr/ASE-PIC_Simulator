
namespace PicSimulatorGUI.commands
{

    class Addlw : Command
    {
        Simulator simulator;
        Memory memory;

        public Addlw(ref Simulator sim, ref Memory mem)
        {
            simulator = sim;
            memory = mem;
        }
        public void execute(int literal)
        {
            digitCarryCheck(literal);

            simulator.W = simulator.W + literal;
            
            carryCheck(simulator.W);
            

            simulator.W &= 0xFF;

            zeroFlagCheck(simulator.W);
        }


    }
}



