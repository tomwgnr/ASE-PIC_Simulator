namespace PicSimulatorGUI.commands
{

    class Clrw : Command
    {

        Memory memory;

        public Clrw( ref Memory mem)
        {
            memory = mem;
        }
        public void execute()
        {
            memory.W = 0;
            memory.writeBit(3, 2, 1);
        
        }

    }
} 