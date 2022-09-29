namespace PicSimulatorGUI.commands
{

    class Nop : Command
    {


        public Nop()
        {
        }
        public override void execute(int opCode)
        {
            
        
        }

        public override bool isOpCode(int opCode){

            if ((opCode & 0x3FFF) == 0x0 || (opCode & 0x3FFF) == 0x20 || (opCode & 0x3FFF) == 0x40 || (opCode & 0x3FFF) == 0x60)
            {
                return true;
            }

            return false;
        }

    }
}