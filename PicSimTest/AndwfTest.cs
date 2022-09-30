using PicSimulatorGUI;
using System.Reflection.Emit;

namespace PicSimTest;

[TestClass]
public class AndwfTest
{
   // public Memory memory;
    public PicSimulatorGUI.commands.Andwf andwf;
    // public PicSimulatorGUI picsim;
    [TestMethod]
    public void isOpCode_wrongCode()
    {
        //Arange
        andwf = new PicSimulatorGUI.commands.Andwf();

        //addlw.memory.W = 0x0000;
        //Act
        bool res = andwf.isOpCode(0x4E00);
            //Assert
            //Console.WriteLine(res);
            Assert.IsFalse(res);
    }
    [TestMethod]
    public void isOpCode_rightCode()
    {
        //Arange
        andwf = new PicSimulatorGUI.commands.Andwf();
        //andlw = new PicSimulatorGUI.commands.Andlw();
        //addlw.memory.W = 0x0000;
        //Act
        bool res = andwf.isOpCode(0x500);
        //Assert
        //Console.WriteLine(res);
        Assert.IsTrue(res);
    }
}