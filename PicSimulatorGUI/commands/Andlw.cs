namespace PicSimulatorGUI.commands
{

    class Andlw : Command
    {


        public Andlw ()
        {
        }
        public override void execute(int opCode)
        {

            int literal = opCode & 0xFF;
            memory.W &= literal;

            zeroFlagCheck(memory.W);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F00) == 0x3900)
            {
                return true;
            }

            return false;
        }

    }
}