using PicSimulatorGUI;
using System.Reflection.Emit;

namespace PicSimTest;

[TestClass]
public class BcfTest
{
   // public Memory memory;
    public PicSimulatorGUI.commands.Bcf bcf;
    // public PicSimulatorGUI picsim;
    [TestMethod]
    public void isOpCode_wrongCode()
    {
        //Arange
        bcf = new PicSimulatorGUI.commands.Bcf();

        //addlw.memory.W = 0x0000;
        //Act
        bool res = bcf.isOpCode(0x4E00);
            //Assert
            //Console.WriteLine(res);
            Assert.IsFalse(res);
    }
    [TestMethod]
    public void isOpCode_rightCode()
    {
        //Arange
        bcf = new PicSimulatorGUI.commands.Bcf();
        //andlw = new PicSimulatorGUI.commands.Andlw();
        //addlw.memory.W = 0x0000;
        //Act
        bool res = bcf.isOpCode(0x1000);
        //Assert
        //Console.WriteLine(res);
        Assert.IsTrue(res);
    }
}