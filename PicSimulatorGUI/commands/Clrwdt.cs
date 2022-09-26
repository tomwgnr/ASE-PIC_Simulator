namespace PicSimulatorGUI.commands
{

    class Clrwdt : Command
    {

        Memory memory;

        public Clrwdt( ref Memory mem)
        {
            memory = mem;
        }
        public void execute()
        {
            memory.wdTimer = 0;
            memory.writeByte(0x81, memory.readByte(0x81) & 0xF8);
        
        }

    }
}