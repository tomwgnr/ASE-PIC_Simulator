namespace PicSimulatorGUI.commands
{

    class Movlw : Command
    {



        public Movlw ()
        {
        }
        public override void execute(int opCode)
        {

            int literal = opCode & 0xFF;
            
            memory.W = literal;

        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3E00) == 0x3200 || (opCode & 0x3E00)== 0x3000)
            {
                return true;
            }

            return false;
        }

    }
}  