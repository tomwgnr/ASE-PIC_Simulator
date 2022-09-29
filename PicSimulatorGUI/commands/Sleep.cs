namespace PicSimulatorGUI.commands
{

    class Sleep : Command
    {


        public Sleep()
        {
        }
        public override void execute(int opCode)
        {
           
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3FFF) == 0x64)
            {
                return true;
            }

            return false;
        }

    }
}