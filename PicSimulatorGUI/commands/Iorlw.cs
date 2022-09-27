namespace PicSimulatorGUI.commands
{

    class Iorlw : Command
    {

        Memory memory;

        public Iorlw( ref Memory mem)
        {
            memory = mem;
        }
        public override void execute(int opCode)
        {
            int literal = opCode & 0xFF;
            memory.W |= literal;

            zeroFlagCheck(memory.W);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0x3800)
            {
                return true;
            }

            return false;
        }

    }
}