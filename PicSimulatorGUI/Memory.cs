

namespace PicSimulatorGUI
{
    class Memory
    {

        Simulator sim;

        public Memory(Simulator x)
        {
            sim = x;
        }

        public int FindKey(int registerAddress)
        {
            while (registerAddress % 8 != 0)
            {
                registerAddress--;
            }

            return registerAddress;
        }

        public int readByte(int registerAddress)
        {

            //check RP0 Bit
            if (((int.Parse((string)sim.table.Rows.Find("0")["3"], System.Globalization.NumberStyles.HexNumber) & 0x20) == 0x20) && registerAddress <= 0x7F)
            {
                registerAddress += 0x80;
            }


            //indirect addressing
            if (registerAddress == 0 )
            {
                registerAddress = readByte(4);
            }


            int key = FindKey(registerAddress);
            int column = (registerAddress % 8) + 1;
            System.Data.DataRow foundRow = sim.table.Rows.Find(key.ToString("X"));
            if (foundRow != null)
            {
                int value = int.Parse((string)foundRow[column], System.Globalization.NumberStyles.HexNumber);

                return value & 0xFF;
            }
            return 0;
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


        public void writeByte(int registerAddress, int value)
        {
            System.Data.DataRow foundRow;
            System.Data.DataRow foundRow2;

            //TMR0 register
            if (registerAddress == 1)  
            {
                sim.partTimer = 0;
                sim.timer = value;
                    
            }

            value &= 0xFF;


            //Manipulation of PCL register
            if (registerAddress == 2 || registerAddress == 0x82)
            {
                sim.Pc = (((readByte(0xA) & 0x1F) << 8) + value);
            }



            //indirect addressing
            if (registerAddress == 0 || registerAddress == 0x80)
            {
                registerAddress = readByte(4);
            }

            


            int key = FindKey(registerAddress);
            int column = (registerAddress % 8) +1;
                

            //mirroring banks GPR
            if ((registerAddress >= 0xc && registerAddress <= 0x7F) || registerAddress == 0x2 || registerAddress == 0x3 || registerAddress == 0x4 || registerAddress == 0xA || registerAddress == 0xB)
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
            else if((registerAddress >= 0x8C && registerAddress <= 0xFF) || registerAddress == 0x82 || registerAddress == 0x83 || registerAddress == 0x84 || registerAddress == 0x8A || registerAddress == 0x8B)
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
                //non mirroring registers SFR

                //check RP0 Bit
                if ((readByte(3) & 0x20) == 0x20)
                {

                    foundRow = sim.table.Rows.Find((key + 0x80).ToString("X"));
                }
                else
                {
                    foundRow = sim.table.Rows.Find(key.ToString("X"));
                }

                if (foundRow != null)
                {
                    //writing on ports
                    if (registerAddress == 5)
                    {
                        value &= (0xFF ^ readByte(0x85));
                    }
                    if (registerAddress == 6)
                    {
                        value &= (0xFF ^ readByte(0x86));
                    }
                    foundRow[column] = checktwohex(value);
                }
                
            }
        }

        public void writeBit(int registerAddress, int bitAddress, int bitValue)
        {
            int registerValue = readByte(registerAddress);

            if (bitValue == 0)
            {
                registerValue &= (0xFF - (1 << bitAddress));
            }
            else if (bitValue == 1)
            {
                registerValue |= (1 << bitAddress);
            }

            writeByte(registerAddress, registerValue);

        }


    }
} 