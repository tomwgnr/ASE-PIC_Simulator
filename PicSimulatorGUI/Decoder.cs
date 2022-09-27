using PicSimulatorGUI.commands;
using System.Collections.Generic;



namespace PicSimulatorGUI
{
    class Decoder
    {
        public Memory memory;



        public List<Command> CommandList;
        public Decoder( Memory mem)
        {
            memory = mem;

            CommandList = new List<Command>();
            CommandList.Add(new Addlw(ref memory));
            CommandList.Add(new Andlw(ref memory));
            CommandList.Add(new Andwf(ref memory));
            CommandList.Add(new Addwf(ref memory));
            CommandList.Add(new Bcf(ref memory));
            CommandList.Add(new Bsf(ref memory));
            CommandList.Add(new Btfsc(ref memory));
            CommandList.Add(new Btfss(ref memory));
            CommandList.Add(new Call(ref memory));
            CommandList.Add(new Clrf(ref memory));
            CommandList.Add(new Clrw(ref memory));
            CommandList.Add(new Comf(ref memory));
            CommandList.Add(new Decf(ref memory));
            CommandList.Add(new Decfsz(ref memory));
            CommandList.Add(new Goto(ref memory));
            CommandList.Add(new Incf(ref memory));
            CommandList.Add(new Incfsz(ref memory));
            CommandList.Add(new Iorlw(ref memory));
            CommandList.Add(new Iorwf(ref memory));
            CommandList.Add(new Movf(ref memory));
            CommandList.Add(new Movlw(ref memory));
            CommandList.Add(new Movwf(ref memory));
            CommandList.Add(new Retlw(ref memory));
            CommandList.Add(new Return(ref memory));
            CommandList.Add(new Retfie(ref memory));
            CommandList.Add(new Rlf(ref memory));
            CommandList.Add(new Rrf(ref memory));
            CommandList.Add(new Sublw(ref memory));
            CommandList.Add(new Subwf(ref memory));
            CommandList.Add(new Swapf(ref memory));
            CommandList.Add(new Xorlw(ref memory));
            CommandList.Add(new Xorwf(ref memory));

        }


        public void analyse(int opCode)
        {
            foreach(Command command in CommandList)
            {
                if (command.isOpCode(opCode))
                {
                    command.execute(opCode);
                }
            } 
            
        }
    }
}