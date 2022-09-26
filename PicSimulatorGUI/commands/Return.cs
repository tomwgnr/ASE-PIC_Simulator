namespace PicSimulatorGUI.commands
{

    class Return : Command
    {

        Memory memory;

        public Return( ref Memory mem)
        {
            memory = mem;
        }
        public void execute()
        {
            memory.setProgramCounter(memory.returnAddr[memory.stackPointer]);

             if (memory.stackPointer == 0)
            {
                memory.stackPointer = 8;
            }
            memory.stackPointer--;

            memory.incrementTimer();
        
        }

    }
} 