namespace PicSimulatorGUI.commands
{

    class Iorlw : Command
    {
        Simulator simulator;
        Memory memory;

        public Iorlw(ref Simulator sim, ref Memory mem)
        {
            simulator = sim;
            memory = mem;
        }
        public void execute(int literal)
        {
            simulator.W |= literal;
            
            zeroFlagCheck(simulator.W);
        }

    }
}