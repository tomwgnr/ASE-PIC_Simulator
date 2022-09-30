using PicSimulatorGUI;
using System.Reflection.Emit;

namespace PicSimTest;

[TestClass]
public class AndlwTest
{
   // public Memory memory;
    public PicSimulatorGUI.commands.Andlw andlw;
    // public PicSimulatorGUI picsim;
    [TestMethod]
    public void isOpCode_wrongCode()
    {
        //Arange
        andlw = new PicSimulatorGUI.commands.Andlw();

        //addlw.memory.W = 0x0000;
        //Act
        bool res = andlw.isOpCode(0x4E00);
            //Assert
            //Console.WriteLine(res);
            Assert.IsFalse(res);
    }
    [TestMethod]
    public void isOpCode_rightCode()
    {
        //Arange
        andlw = new PicSimulatorGUI.commands.Andlw();
        //andlw = new PicSimulatorGUI.commands.Andlw();
        //addlw.memory.W = 0x0000;
        //Act
        bool res = andlw.isOpCode(0x3900);
        //Assert
        //Console.WriteLine(res);
        Assert.IsTrue(res);
    }
}