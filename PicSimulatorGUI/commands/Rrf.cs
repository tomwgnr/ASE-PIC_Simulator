namespace PicSimulatorGUI.commands
{

    class Rrf : Command
    {


        Memory memory;

        public Rrf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress) >> 1;
            int bit0 = memory.readByte(registerAddress) & 1;
            if ((memory.readByte(3) & 1) == 1)
            {
                value += 1;
            }
            
            //check if bit0 is 1
            if(bit0 == 1)
            {
                memory.writeBit(3, 0, 1);
            }
            else
            {
                memory.writeBit(3, 0, 0);
            }

            writeToDestination(destinationBit, registerAddress, value);
        }

    }
}