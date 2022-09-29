namespace PicSimulatorGUI.commands
{

    class Clrw : Command
    {



        public Clrw ()
        {
        }
        public override void execute(int opCode)
        {

            memory.W = 0;
            memory.writeBit(3, 2, 1);
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3F80) == 0x100)
            {
                return true;
            }

            return false;
        }

    }
} 