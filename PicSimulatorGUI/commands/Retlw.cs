namespace PicSimulatorGUI.commands
{

    class Retlw : Command
    {

        Memory memory;

        public Retlw( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int literal)
        {
            memory.W = literal;
            memory.setProgramCounter(memory.returnAddr[memory.stackPointer]);
            memory.stackPointer --;
            memory.incrementTimer();

        }

    }
} 