namespace PicSimulatorGUI.commands
{

    class Xorlw : Command
    {

    

        public Xorlw ()
        {
           
        }
        public override void execute(int opCode)
        {

            int literal = opCode & 0xFF;

            memory.W ^= literal;

            zeroFlagCheck(memory.W);
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3E00) == 0x3A00)
            {
                return true;
            }

            return false;
        }

    }
}