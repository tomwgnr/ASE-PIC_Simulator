namespace PicSimulatorGUI.commands
{

    class Movwf : Command
    {


        Memory memory;

        public Movwf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int registerAddress)
        {
            memory.writeByte(registerAddress, memory.W);
        }

    }
}