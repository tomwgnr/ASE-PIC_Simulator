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
        Cpu cpu;
        public Decode(Cpu x)
        {
            cpu = x;
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
                    cpu.Addlw(literal);
                    break;
                case 0x800:
                    if (bit8check == 0)
                    {
                        Console.WriteLine("IORLW");
                        cpu.Iorlw(literal);
                    }
                    else
                    {
                        Console.WriteLine("ANDLW");
                        cpu.Andlw(literal);
                    }
                    break;
                case 0xC00:
                    Console.WriteLine("SUBLW");
                    cpu.Sublw(literal);
                    break;
                case 0xA00:
                    Console.WriteLine("XORLW");
                    cpu.Xorlw(literal);
                    break;
                case 0x000:
                case 0x200:
                    Console.WriteLine("MOVLW");
                    cpu.Movlw(literal);
                    break;
                case 0x400:
                case 600:
                    Console.WriteLine("RETLW");
                    cpu.Retlw(literal);
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
                    cpu.Goto(p_address);
                    break;
                case 0x000:
                    Console.WriteLine("CALL");
                    cpu.Call(p_address);
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
                    cpu.Bcf(b_address, f_address);
                    break;
                case 0x400:
                    Console.WriteLine("BSF");
                    cpu.Bsf(b_address, f_address);
                    break;
                case 0x800:
                    Console.WriteLine("BTFSC");
                    cpu.Btfsc(b_address, f_address);
                    break;
                case 0xC00:
                    Console.WriteLine("BTFSS");
                    cpu.Btfss(b_address, f_address);
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
                    cpu.Addwf(destination, f_address);
                    break;
                case 0x500:
                    Console.WriteLine("ANDWF");
                    cpu.Andwf(destination, f_address);
                    break;
                case 0x100:
                    if (bit7check == 0)
                    {
                        Console.WriteLine("CLRW");
                        cpu.Clrw();
                    }
                    else
                    {
                        Console.WriteLine("CLRF");
                        cpu.Clrf(f_address);
                    }
                    break;
                case 0x900:
                    Console.WriteLine("COMF");
                    cpu.Comf(destination, f_address);
                    break;
                case 0x300:
                    Console.WriteLine("DECF");
                    cpu.Decf(destination, f_address);
                    break;
                case 0xB00:
                    Console.WriteLine("DECFSZ");
                    cpu.Decfsz(destination, f_address);
                    break;
                case 0xA00:
                    Console.WriteLine("INCF");
                    cpu.Incf(destination, f_address);
                    break;
                case 0xF00:
                    Console.WriteLine("INCFSZ");
                    cpu.Incfsz(destination, f_address);
                    break;
                case 0x400:
                    Console.WriteLine("IORWF");
                    cpu.Iorwf(destination, f_address);
                    break;
                case 0x800:
                    Console.WriteLine("MOVF");
                    cpu.Movf(destination, f_address);
                    break;
                case 0x000:
                    int rest8 = rest12 & 0xFF;
                    switch (rest8)
                    {
                        case 0x64:
                            Console.WriteLine("CLRWDT");
                            cpu.Clrwdt();
                            break;
                        case 0x9:
                            Console.WriteLine("RETFIE");
                            cpu.Retfie();
                            break;
                        case 0x8:
                            Console.WriteLine("RETURN");
                            cpu.Return();
                            break;
                        case 0x63:
                            Console.WriteLine("SLEEP");
                            cpu.Sleep();
                            break;
                        case 0x0:
                        case 0x20:
                        case 0x40:
                        case 0x60:
                            Console.WriteLine("NOP");
                            cpu.Nop();
                            break;
                        default:
                            if (bit7check == 0x80)
                            {
                                Console.WriteLine("MOVWF");
                                cpu.Movwf(f_address);
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
                    cpu.Rlf(destination, f_address);
                    break;
                case 0xC00:
                    Console.WriteLine("RRF");
                    cpu.Rrf(destination, f_address);
                    break;
                case 0x200:
                    Console.WriteLine("SUBWF");
                    cpu.Subwf(destination, f_address);
                    break;
                case 0xE00:
                    Console.WriteLine("SWAPF");
                    cpu.Swapf(destination, f_address);
                    break;
                case 0x600:
                    Console.WriteLine("XORWF");
                    cpu.Xorwf(destination, f_address);
                    break;

                default:
                    Console.WriteLine("invalid Opcode!");
                    break;
            }
        }
    }
}
