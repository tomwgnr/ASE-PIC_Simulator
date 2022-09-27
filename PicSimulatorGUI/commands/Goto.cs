namespace PicSimulatorGUI.commands
{

    class Goto : Command
    {

        Memory memory;

        public Goto( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int address)
        {
            int pclathBits = (memory.readByte(0xA) & 0x18) << 8;

            memory.setProgramCounter((address + pclathBits) - 1);

            memory.incrementTimer();

        }

    }
} 