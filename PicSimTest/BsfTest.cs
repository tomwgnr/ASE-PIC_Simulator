using PicSimulatorGUI;
using System.Reflection.Emit;

namespace PicSimTest;

[TestClass]
public class BsfTest
{
   // public Memory memory;
    public PicSimulatorGUI.commands.Bsf bsf;
    // public PicSimulatorGUI picsim;
    [TestMethod]
    public void isOpCode_wrongCode()
    {
        //Arange
        bsf = new PicSimulatorGUI.commands.Bsf();

        //addlw.memory.W = 0x0000;
        //Act
        bool res = bsf.isOpCode(0x4E00);
            //Assert
            //Console.WriteLine(res);
            Assert.IsFalse(res);
    }
    [TestMethod]
    public void isOpCode_rightCode()
    {
        //Arange
        bsf = new PicSimulatorGUI.commands.Bsf();
        //andlw = new PicSimulatorGUI.commands.Andlw();
        //addlw.memory.W = 0x0000;
        //Act
        bool res = bsf.isOpCode(0x1400);
        //Assert
        //Console.WriteLine(res);
        Assert.IsTrue(res);
    }
}