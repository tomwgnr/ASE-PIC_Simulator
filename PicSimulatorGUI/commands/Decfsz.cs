namespace PicSimulatorGUI.commands
{

    class Decfsz : Command
    {

        Memory memory;

        public Decfsz( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int registerAddress = opCode & 0x7F;
            int destinationBit = (opCode & 0x80) / 0x80;

            int value = memory.readByte(registerAddress) - 1;
            if (value == 0)
            {
                memory.setProgramCounter(memory.getProgramCounter() + 1);
                memory.incrementTimer();
            }

            writeToDestination(destinationBit, registerAddress, value);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0xB00)
            {
                return true;
            }

            return false;
        }

    }
} 