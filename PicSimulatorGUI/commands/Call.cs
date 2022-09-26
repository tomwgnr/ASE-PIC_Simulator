namespace PicSimulatorGUI.commands
{

    class Call : Command
    {

        Memory memory;

        public Call( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int address)
        {
            if (memory.stackPointer == 7) 
            {
                memory.stackPointer = 0;
            }

            memory.stackPointer++;

            memory.returnAddr[memory.stackPointer] = memory.getProgramCounter();
            int pclathBits = (memory.readByte(0xA) & 0x18) << 8;

            memory.setProgramCounter((address + pclathBits) - 1);

            memory.incrementTimer();
        
        }

    }
} 