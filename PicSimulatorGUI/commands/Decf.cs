namespace PicSimulatorGUI.commands
{

    class Decf : Command
    {

        Memory memory;

        public Decf( ref Memory mem)
        {
            memory = mem;
        }
        public void execute(int destinationBit, int registerAddress)
        {
            int value = memory.readByte(registerAddress);
            if (value == 0)
            {
                value = 0xFF;

            } 
            else{
                
                value --;
                zeroFlagCheck(value);
            }

            writeToDestination(destinationBit, registerAddress, value);
        
        }

    }
} 