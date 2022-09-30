

namespace PicSimulatorGUI
{
    public class Memory
    {
         //Datatable for the registers as display
        public registers.SpezialRegister spezReg;
        
        public registers.Table table;
        public registers.T_PortA t_portA;
        public registers.T_PortB t_portB;
        public registers.T_Status t_status;
        public registers.T_Option t_option;
        public registers.T_Intcon t_intcon; 
        



        public int W { get; set;}

        public int[] returnAddr = new int[6];
        public int Pc{ get; set;}
        public int stackPointer = 0;
        public int wdTimer;
        public int partTimer;
        public int timer;
        public double runtime = 0;


        public Memory()
        {
            fillTables();
        }

        public void fillTables()
        {
            spezReg = new registers.SpezialRegister("test");
            spezReg.fillNew();

            t_intcon = new registers.T_Intcon("");
            t_intcon.fillNew();

            t_portB = new registers.T_PortB("");
            t_portB.fillNew();

            t_portA = new registers.T_PortA("");
            t_portA.fillNew();

            t_option = new registers.T_Option("");
            t_option.fillNew();

            t_status = new registers.T_Status("");
            t_status.fillNew();

            table = new registers.Table("");
            table.fillNew();

        }


        public void incrementTimer()
        {
            if (readByte(1) != 0 && ((readByte(0x81) >> 5) & 1) == 0)
            {
                partTimer++;
            }
            runtime++;
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
            if (((int.Parse((string)table.Rows.Find("0")["3"], System.Globalization.NumberStyles.HexNumber) & 0x20) == 0x20) && registerAddress <= 0x7F)
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
            System.Data.DataRow foundRow = table.Rows.Find(key.ToString("X"));
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
                partTimer = 0;
                timer = value;
                    
            }

            value &= 0xFF;


            //Manipulation of PCL register
            if (registerAddress == 2 || registerAddress == 0x82)
            {
                Pc = (((readByte(0xA) & 0x1F) << 8) + value);
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
                foundRow = table.Rows.Find(key.ToString("X"));
                if (foundRow != null)
                {
                    foundRow[column] = checktwohex(value);
                }

                foundRow2 = table.Rows.Find((key + 0x80).ToString("X"));
                if (foundRow2 != null)
                {
                    
                    foundRow2[column] = checktwohex(value);
                }

            }
            else if((registerAddress >= 0x8C && registerAddress <= 0xFF) || registerAddress == 0x82 || registerAddress == 0x83 || registerAddress == 0x84 || registerAddress == 0x8A || registerAddress == 0x8B)
            {
                foundRow = table.Rows.Find(key.ToString("X"));
                if (foundRow != null)
                {
                    foundRow[column] = checktwohex(value);
                }

                foundRow2 = table.Rows.Find((key - 0x80).ToString("X"));
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

                    foundRow = table.Rows.Find((key + 0x80).ToString("X"));
                }
                else
                {
                    foundRow = table.Rows.Find(key.ToString("X"));
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