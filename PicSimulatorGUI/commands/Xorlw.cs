namespace PicSimulatorGUI.commands
{

    class Xorlw : Command
    {

        Memory memory;

        public Xorlw( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int literal)
        {
            memory.W ^= literal;

            zeroFlagCheck(memory.W);
        }

    }
}