using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PicSimulatorGUI
{
    class Decode
    {
        public Memory memory;

        public Decode( Memory mem)
        {
            memory = mem;
        }

        public void analyse(int operation)
        {

            //extract the first 2 bits, set rest to 0
            int msb2 = (operation & 0x3000) / 0x1000;


            //set first 2 its to 0
            int rest12 = operation & 0xFFF;
            switch (msb2)
            {
                case 0b11:
                    //literal

                    Literal_op(rest12);
                    break;

                case 0b10:
                    //controll
                    Controll_op(rest12);
                    break;

                case 0b01:
                    //bit oriented
                    Bit_op(rest12);
                    break;

                case 0b0:
                    //byte oriented

                    Byte_op(rest12);
                    break;
                default:
                    Console.WriteLine("invalid operation");
                    break;
            }

        }

        void Literal_op(int rest12)
        {
            ////extraxt first 3 bits, set rest to 0
            int operation = rest12 & 0xE00;
            int bit8check = rest12 & 0x100;
            int literal = rest12 & 0xFF;


            switch (operation)
            {
                case 0xE00:
                    Console.WriteLine("ADDLW");
                    commands.Addlw addlw = new commands.Addlw(ref memory);
                    addlw.execute(literal);
                    break;
                case 0x800:
                    if (bit8check == 0)
                    {
                        Console.WriteLine("IORLW");
                        commands.Iorlw iorlw = new commands.Iorlw(ref memory);
                        iorlw.execute(literal);
                    }
                    else
                    {
                        Console.WriteLine("ANDLW");
                        commands.Andlw andlw = new commands.Andlw(ref memory);
                        andlw.execute(literal);
                    }
                    break;
                case 0xC00:
                    Console.WriteLine("SUBLW");
                    commands.Sublw sublw = new commands.Sublw(ref memory);
                    sublw.execute(literal);
                    break;
                case 0xA00:
                    Console.WriteLine("XORLW");
                    commands.Xorlw xorlw = new commands.Xorlw(ref memory);
                    xorlw.execute(literal);
                    break;
                case 0x000:
                case 0x200:
                    Console.WriteLine("MOVLW");
                    commands.Movlw movlw = new commands.Movlw(ref memory);
                    movlw.execute(literal);
                    break;
                case 0x400:
                case 600:
                    Console.WriteLine("RETLW");
                    commands.Retlw retlw = new commands.Retlw(ref memory);
                    retlw.execute(literal);
                    break;
                default:
                    Console.WriteLine("invalid Opcode");
                    break;


            }

        }

        void Controll_op(int rest12)
        {
            //extraxt first bit, set rest to 0
            int operation = rest12 & 0x800;
            int p_address = rest12 & 0x7FF;
            switch (operation)
            {
                case 0x800:
                    Console.WriteLine("GOTO");
                    commands.Goto _goto = new commands.Goto(ref memory);
                    _goto.execute(p_address);
                    break;
                case 0x000:
                    Console.WriteLine("CALL");
                    commands.Call call = new commands.Call(ref memory);
                    call.execute(p_address);
                    break;
                default:
                    Console.WriteLine("invalid Opcode");
                    break;
            }
        }

        void Bit_op(int rest12)
        {
            ////extraxt first 2 bits, set rest to 0
            int operation = rest12 & 0xC00;
            int f_address = rest12 & 0x7F;
            int b_address = (rest12 & 0x380) / 0x80;

            switch (operation)
            {
                case 0x0:
                    Console.WriteLine("BCF");
                    commands.Bcf bcf = new commands.Bcf(ref memory);
                    bcf.execute(b_address, f_address);
                    break;
                case 0x400:
                    Console.WriteLine("BSF");
                    commands.Bsf bsf = new commands.Bsf(ref memory);
                    bsf.execute(b_address, f_address);
                    break;
                case 0x800:
                    Console.WriteLine("BTFSC");
                    commands.Btfsc btfsc = new commands.Btfsc(ref memory);
                    btfsc.execute(b_address, f_address);
                    break;
                case 0xC00:
                    Console.WriteLine("BTFSS");
                    commands.Btfss btfss = new commands.Btfss(ref memory);
                    btfss.execute(b_address, f_address);
                    break;
                default:
                    Console.WriteLine("invalid Opcode");
                    break;

            }
        }

        void Byte_op(int rest12)
        {
            //extraxt first 4 bits, set rest to 0
            int operation = rest12 & 0xF00;
            int bit7check = rest12 & 0x80;
            int destination = bit7check / 0x80;
            int f_address = rest12 & 0x7F;

            switch (operation)
            {
                case 0x700:
                    Console.WriteLine("ADDWF");
                    commands.Addwf addwf = new commands.Addwf(ref memory);
                    addwf.execute(destination, f_address);
                    break;
                case 0x500:
                    Console.WriteLine("ANDWF");
                    commands.Addwf andwf = new commands.Addwf(ref memory);
                    andwf.execute(destination, f_address);
                    break;
                case 0x100:
                    if (bit7check == 0)
                    {
                        Console.WriteLine("CLRW");
                        commands.Clrw clrw = new commands.Clrw(ref memory);
                        clrw.execute();
                    }
                    else
                    {
                        Console.WriteLine("CLRF");
                        commands.Clrf clrf = new commands.Clrf(ref memory);
                        clrf.execute(f_address);
                    }
                    break;
                case 0x900:
                    Console.WriteLine("COMF");
                    commands.Comf comf = new commands.Comf(ref memory);
                    comf.execute(destination, f_address);
                    break;
                case 0x300:
                    Console.WriteLine("DECF");
                    commands.Decf decf = new commands.Decf(ref memory);
                    decf.execute(destination, f_address);
                    break;
                case 0xB00:
                    Console.WriteLine("DECFSZ");
                    commands.Decfsz decfsz = new commands.Decfsz(ref memory);
                    decfsz.execute(destination, f_address);
                    break;
                case 0xA00:
                    Console.WriteLine("INCF");
                    commands.Incf incf = new commands.Incf(ref memory);
                    incf.execute(destination, f_address);
                    break;
                case 0xF00:
                    Console.WriteLine("INCFSZ");
                    commands.Incfsz incfsz = new commands.Incfsz(ref memory);
                    incfsz.execute(destination, f_address);
                    break;
                case 0x400:
                    Console.WriteLine("IORWF");
                    commands.Iorwf iorwf = new commands.Iorwf(ref memory);
                    iorwf.execute(destination, f_address);
                    break;
                case 0x800:
                    Console.WriteLine("MOVF");
                    commands.Movf movf = new commands.Movf(ref memory);
                    movf.execute(destination, f_address);
                    break;
                case 0x000:
                    int rest8 = rest12 & 0xFF;
                    switch (rest8)
                    {
                        case 0x64:
                            Console.WriteLine("CLRWDT");
                            commands.Clrwdt clrwdt = new commands.Clrwdt(ref memory);
                            clrwdt.execute();
                            break;
                        case 0x9:
                            Console.WriteLine("RETFIE");
                            commands.Retfie retfie = new commands.Retfie(ref memory);
                            retfie.execute();
                            break;
                        case 0x8:
                            Console.WriteLine("RETURN");
                            commands.Return _return = new commands.Return(ref memory);
                            _return.execute();
                            break;
                        case 0x63:
                            Console.WriteLine("SLEEP");
                            commands.Sleep sleep = new commands.Sleep();
                            sleep.execute();
                            break;
                        case 0x0:
                        case 0x20:
                        case 0x40:
                        case 0x60:
                            Console.WriteLine("NOP");
                            commands.Nop nop = new commands.Nop();
                            nop.execute();
                            break;
                        default:
                            if (bit7check == 0x80)
                            {
                                Console.WriteLine("MOVWF");
                                commands.Movwf movwf = new commands.Movwf(ref memory);
                                movwf.execute(f_address);
                            }
                            else
                            {
                                Console.WriteLine("invalid opcode MOVWF");
                            }
                            break;
                    }


                    break;
                case 0xD00:
                    Console.WriteLine("RLF");
                    commands.Rlf rlf = new commands.Rlf(ref memory);
                    rlf.execute(destination, f_address);
                    break;
                case 0xC00:
                    Console.WriteLine("RRF");
                    commands.Rrf rrf = new commands.Rrf(ref memory);
                    rrf.execute(destination, f_address);
                    break;
                case 0x200:
                    Console.WriteLine("SUBWF");
                    commands.Subwf subwf = new commands.Subwf(ref memory);
                    subwf.execute(destination, f_address);
                    break;
                case 0xE00:
                    Console.WriteLine("SWAPF");
                    commands.Swapf swapf = new commands.Swapf(ref memory);
                    swapf.execute(destination, f_address);
                    break;
                case 0x600:
                    Console.WriteLine("XORWF");
                    commands.Xorwf xorwf = new commands.Xorwf(ref memory);
                    xorwf.execute(destination, f_address);
                    break;

                default:
                    Console.WriteLine("invalid Opcode!");
                    break;
            }
        }
    }
}
