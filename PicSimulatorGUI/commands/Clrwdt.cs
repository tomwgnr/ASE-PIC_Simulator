namespace PicSimulatorGUI.commands
{

    class Clrwdt : Command
    {



        public Clrwdt ()
        {
        }
        public override void execute(int opCode)
        {

            memory.wdTimer = 0;
            memory.writeByte(0x81, memory.readByte(0x81) & 0xF8);
        
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