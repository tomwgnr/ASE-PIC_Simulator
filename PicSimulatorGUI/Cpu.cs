/*
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSimulatorGUI
{
    class Cpu
    {  
        Simulator sim;
        public Cpu(Simulator x)
        {
            sim = x;
        }

        public void Addlw(int literal)
        {
            digitcarry check
            if ((literal & 0xF) +(sim.W & 0xF) > 0xF)
            {
                Bsf(1, 3);
            }
                else
            {
                Bcf(1, 3);
            }

            sim.W = sim.W + literal;
            
            CarryCheck(sim.W);
            

            sim.W &= 0xFF;

            if (sim.W == 0) Bsf(2, 3);
            else Bcf(2, 3);
        }

        public void Iorlw(int literal)
        {
            sim.W |= literal;
            if (sim.W == 0) Bcf(2, 3);
            else Bcf(2, 3);
        }

        public void Andlw(int literal)
        {
            sim.W &= literal;
            if (sim.W == 0) Bsf(2, 3);
            else Bcf(2, 3);
        }

        public void Sublw(int literal)
        {
            digit carry check
            if ((literal & 0xF) - (sim.W & 0xF) < 0)
            {
                Bcf(1, 3);
            }
            else
            {
                Bsf(1, 3);
            }

            sim.W = literal - sim.W;
            if (sim.W < 0)
            {
                Bcf(0, 3);
                sim.W &= 0xFF;
            }
            else
            {
                Bsf(0, 3);
            }


            if (sim.W == 0) Bsf(2, 3);
            else Bcf(2, 3);
        }

        public void Xorlw(int literal)
        {
            sim.W ^= literal;
            if (sim.W == 0) Bsf(2, 3);
            else Bcf(2, 3);
        }

        public void Movlw(int literal)
        {
            sim.W = literal;
        }

        public void Retlw(int literal)
        {
            sim.W = literal;
            sim.Pc = sim.returnAddr[sim.s_pointer];
            sim.s_pointer--;
            check if timer needs to be incremented
            if (Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
            {
                sim.partTimer++;
            }
            sim.runtime++;
        }

        public void Goto(int address)
        {
            int pclathBits = (Read(0xA) & 0x18) << 8;

            sim.Pc = (address + pclathBits) - 1;
            check if timer needs to be incremented 
            if (Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
            {
                sim.partTimer++;
            }
            sim.runtime++;
        }

        public void Call(int address)
        {
            if (sim.s_pointer == 7) 
            {
                sim.s_pointer = 0;
            }

            sim.s_pointer++;

            sim.returnAddr[sim.s_pointer] = sim.Pc;
            int pclathBits = (Read(0xA) & 0x18) << 8;

            sim.Pc = (address + pclathBits) - 1;

            check if timer needs to be incremented
            if (Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
            {
                sim.partTimer++;
            }
            sim.runtime++;
        }

        public void Btfss(int b_address, int f_address)
        {
            int value = Read(f_address);
            value >>= b_address;
            value &= 1;
            if (value == 1)
            {
                sim.Pc++;
                check if timer needs to be incremented
                if (Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
                {
                    sim.partTimer++;
                }
                sim.runtime++;
            }
        }

        public void Bcf(int b_address, int f_address)
        {
            int value = Read(f_address);
            value &= (0xFF - (1 << b_address));
            Write(value, f_address);
        }

        public void Bsf(int b_address, int f_address)
        {
            int value = Read(f_address);
            value |= (1 << b_address);
            Write(value, f_address);
        }

        public void Btfsc(int b_address, int f_address)
        {
            int value = Read(f_address);
            value >>= b_address;
            value &= 1;
            if (value == 0)
            {
                sim.Pc++;
                check if timer needs to be incremented
                if (Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
                {
                    sim.partTimer++;
                }
                sim.runtime++;
            }
        }

        public void Addwf(int destination, int f_address)
        {
            digitcarry check
            if ((Read(f_address) & 0xF) + (sim.W & 0xF) > 0xF)
            {
                Bsf(1, 3);
            }
            else
            {
                Bcf(1, 3);
            }

            int value = Read(f_address) + sim.W;

            CarryCheck(sim.W);

            value &= 0xFF;

            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Subwf(int destination, int f_address)
        {
            digit carry check
            if ((Read(f_address) & 0xF) - (sim.W & 0xF) < 0)
            {
                Bcf(1, 3);
            }
            else
            {
                Bsf(1, 3);
            }

            int value = Read(f_address) - sim.W;
            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            if (value < 0)
            {

                Bcf(0, 3);
                Bcf(1, 3);
                value &= 0xFF;
            }
            else
            {
                Bsf(0, 3);
                Bsf(1, 3);
            }
 

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Andwf(int destination, int f_address)
        {
            int value = Read(f_address) & sim.W;
            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Clrw()
        {
            sim.W = 0;
            Bsf(2, 3);
        }

        public void Clrf(int f_address)
        {
            Write(0, f_address);
            Bsf(2, 3);
        }

        public void Comf(int destination, int f_address)
        {
            int value = Read(f_address) ^ 0xFF;
            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }

        }


        public void Decf(int destination, int f_address)
        {
            int value = Read(f_address);
            if (value == 0)
            {
                value = 0x100;
            }
            else if (value == 1) Bsf(2, 3);
            else Bcf(2, 3);

            value--;
            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }



        public void Decfsz(int destination, int f_address)
        {
            int value = Read(f_address) - 1;
            if (value == 0)
            {
                sim.Pc++;
                check if timer needs to be incremented
                if(Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
                {
                    sim.partTimer++;
                }
            }

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Incf(int destination, int f_address)
        {
            int value = Read(f_address) + 1;
            value &= 0xFF;
            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Incfsz(int destination, int f_address)
        {
            int value = Read(f_address) + 1;
            value &= 0xFF;
            if (value == 0)
            {
                sim.Pc++;
                check if timer needs to be incremented
                if (Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
                {
                    sim.partTimer++;
                }
                sim.runtime++;
            }

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Iorwf(int destination, int f_address)
        {
            int value = Read(f_address) | sim.W;
            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Movf(int destination, int f_address)
        {
            int value = Read(f_address);
            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Clrwdt()
        {
            sim.wdTimer = 0;
            clear prescaler
            Write(Read(0x81) & 0xF8, 0x81);
        }

        public void Retfie()
        {
            Bsf(7, 0xB);
            sim.Pc = sim.returnAddr[sim.s_pointer];
            if (sim.s_pointer == 0)
            {
                sim.s_pointer = 8;
            }
            sim.s_pointer--;

            check if timer needs to be incremented
            if (Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
            {
                sim.partTimer++;
            }
            sim.runtime++;
        }

        public void Return()
        {
            sim.Pc = sim.returnAddr[sim.s_pointer];
            if (sim.s_pointer == 0)
            {
                sim.s_pointer = 8;
            }
            sim.s_pointer--;

            check if timer needs to be incremented
            if (Read(1) != 0 && ((Read(0x81) >> 5) & 1) == 0)
            {
                sim.partTimer++;
            }
            sim.runtime++;
        }


        public void Nop()
        {

        }

        public void Sleep()
        {

        }

        public void Movwf(int f_address)
        {
            Write(sim.W, f_address);
        }

        public void Rlf(int destination, int f_address)
        {
            int value = Read(f_address) << 1;
            if ((Read(3) & 1) == 1)
            {
                value += 1;
            }
            CarryCheck(value);

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Rrf(int destination, int f_address)
        {
            int value = Read(f_address) >> 1;
            int bit0 = Read(f_address) & 1;
            if ((Read(3) & 1) == 1)
            {
                value += 0x80;
            }
            
            check if bit0 is 1
            if(bit0 == 1)
            {
                Bsf(0, 3);
            }
            else
            {
                Bcf(0, 3);
            }

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public void Swapf(int destination, int f_address)
        {
            int value = Read(f_address);
            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            int bottom4 = (value & 0xF) * 0x10;
            int top4 = (value & 0xF0) / 0x10;
            if (destination == 0)
            {
                sim.W = (bottom4 + top4);
            }
            else
            {
                Write((bottom4 + top4), f_address);
            }

        }

        public void Xorwf(int destination, int f_address)
        {
            int value = (Read(f_address) ^ sim.W);
            if (value == 0) Bsf(2, 3);
            else Bcf(2, 3);

            if (destination == 0)
            {
                sim.W = value;
            }
            else
            {
                Write(value, f_address);
            }
        }

        public int FindKey(int f_address)
        {
            while (f_address % 8 != 0)
            {
                f_address--;
            }

            return f_address;
        }


        public void Write(int value, int f_address)
        {

            DataRow foundRow;
            DataRow foundRow2;

            TMR0 register
            if (f_address == 1)  
            {
                sim.partTimer = 0;
                sim.timer = value;
                    
            }

            value &= 0xFF;


            Manipulation of PCL register
            if (f_address == 2 || f_address == 0x82)
            {
                sim.Pc = (((Read(0xA) & 0x1F) << 8) + value);
            }



            indirect addressing
            if (f_address == 0 || f_address == 0x80)
            {
                f_address = Read(4);
            }

            


            int key = FindKey(f_address);
            int column = (f_address % 8) +1;
                

            mirroring banks GPR
            if ((f_address >= 0xc && f_address <= 0x7F) || f_address == 0x2 || f_address == 0x3 || f_address == 0x4 || f_address == 0xA || f_address == 0xB)
            {
                foundRow = sim.table.Rows.Find(key.ToString("X"));
                if (foundRow != null)
                {
                    foundRow[column] = checktwohex(value);
                }

                foundRow2 = sim.table.Rows.Find((key + 0x80).ToString("X"));
                if (foundRow2 != null)
                {
                    
                    foundRow2[column] = checktwohex(value);
                }

            }
            else if((f_address >= 0x8C && f_address <= 0xFF) || f_address == 0x82 || f_address == 0x83 || f_address == 0x84 || f_address == 0x8A || f_address == 0x8B)
            {
                foundRow = sim.table.Rows.Find(key.ToString("X"));
                if (foundRow != null)
                {
                    foundRow[column] = checktwohex(value);
                }

                foundRow2 = sim.table.Rows.Find((key - 0x80).ToString("X"));
                if (foundRow2 != null)
                {
                    foundRow2[column] = checktwohex(value);
                }
            }
            else
            {
                non mirroring registers SFR

                check RP0 Bit
                if ((Read(3) & 0x20) == 0x20)
                {

                    foundRow = sim.table.Rows.Find((key + 0x80).ToString("X"));
                }
                else
                {
                    foundRow = sim.table.Rows.Find(key.ToString("X"));
                }

                if (foundRow != null)
                {
                    writing on ports
                    if (f_address == 5)
                    {
                        value &= (0xFF ^ Read(0x85));
                    }
                    if (f_address == 6)
                    {
                        value &= (0xFF ^ Read(0x86));
                    }
                    foundRow[column] = checktwohex(value);
                }
                
            }
        }

        public static string checktwohex(int hexnr)
        {
            string result = hexnr.ToString("X");
            if (result.Length == 1)
            {
                result = "0" + result;
            }
            return result;
        }

        public int Read(int f_address)
        {


           
            check RP0 Bit
            if (((int.Parse((string)sim.table.Rows.Find("0")["3"], System.Globalization.NumberStyles.HexNumber) & 0x20) == 0x20) && f_address <= 0x7F)
            {
                f_address += 0x80;
            }


            indirect addressing
            if (f_address == 0 )
            {
                f_address = Read(4);
            }


            int key = FindKey(f_address);
            int column = (f_address % 8) + 1;
            DataRow foundRow = sim.table.Rows.Find(key.ToString("X"));
            if (foundRow != null)
            {
                int value = int.Parse((string)foundRow[column], System.Globalization.NumberStyles.HexNumber);

                return value & 0xFF;
            }
            return 0;
    
        }

        public void CarryCheck(int value)
        {
            if (value > 0xFF || sim.W > 0xFF)
            {
                Bsf(0, 3);
            }
            else
            {
                Bcf(0, 3);
            }
        }



    }
}
*/