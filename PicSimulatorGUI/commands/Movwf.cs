namespace PicSimulatorGUI.commands
{

    class Movwf : Command
    {


        Memory memory;

        public Movwf( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int registerAddress = opCode & 0x7F;

            memory.writeByte(registerAddress, memory.W);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F80) == 0x80)
            {
                return true;
            }

            return false;
        }

    }
}