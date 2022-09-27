namespace PicSimulatorGUI.commands
{

    class Andlw : Command
    {

        Memory memory;

        public Andlw( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int literal)
        {
            memory.W &= literal;

            zeroFlagCheck(memory.W);
        }

    }
}