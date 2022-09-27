namespace PicSimulatorGUI.commands
{

    class Iorlw : Command
    {

        Memory memory;

        public Iorlw( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int literal)
        {
            memory.W |= literal;

            zeroFlagCheck(memory.W);
        }

    }
}