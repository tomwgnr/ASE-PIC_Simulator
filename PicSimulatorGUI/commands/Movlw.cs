namespace PicSimulatorGUI.commands
{

    class Movlw : Command
    {

        Memory memory;

        public Movlw( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int literal)
        {
            memory.W = literal;

        }

    }
}  