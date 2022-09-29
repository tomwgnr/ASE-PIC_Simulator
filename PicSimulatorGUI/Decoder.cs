using PicSimulatorGUI.commands;
using System.Collections.Generic;



namespace PicSimulatorGUI
{
    public class Decoder
    {
        public Memory memory;



        public List<Command> CommandList;
        public Decoder( Memory mem)
        {
            memory = mem;

            CommandList = new List<Command>();
            CommandList.Add(new Addlw());
            CommandList.Add(new Andlw());
            CommandList.Add(new Andwf());
            CommandList.Add(new Addwf());
            CommandList.Add(new Bcf());
            CommandList.Add(new Bsf());
            CommandList.Add(new Btfsc());
            CommandList.Add(new Btfss());
            CommandList.Add(new Call());
            CommandList.Add(new Clrf());
            CommandList.Add(new Clrw());
            CommandList.Add(new Comf());
            CommandList.Add(new Decf());
            CommandList.Add(new Decfsz());
            CommandList.Add(new Goto());
            CommandList.Add(new Incf());
            CommandList.Add(new Incfsz());
            CommandList.Add(new Iorlw());
            CommandList.Add(new Iorwf());
            CommandList.Add(new Movf());
            CommandList.Add(new Movlw());
            CommandList.Add(new Movwf());
            CommandList.Add(new Retlw());
            CommandList.Add(new Return());
            CommandList.Add(new Retfie());
            CommandList.Add(new Rlf());
            CommandList.Add(new Rrf());
            CommandList.Add(new Sublw());
            CommandList.Add(new Subwf());
            CommandList.Add(new Swapf());
            CommandList.Add(new Xorlw());
            CommandList.Add(new Xorwf());

        }


        public void analyse(int opCode)
        {
            foreach(Command command in CommandList)
            {
                if (command.isOpCode(opCode))
                {
                    command.setMemory(ref memory);
                    command.execute(opCode);
                }
            } 
            
        }
        
    }
}