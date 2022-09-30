using PicSimulatorGUI;
using System.Reflection.Emit;

namespace PicSimTest;

[TestClass]
public class AddwfTest
{
    public PicSimulatorGUI.Memory memory;
    public PicSimulatorGUI.commands.Addwf addwf;
   // public PicSimulatorGUI picsim;
    [TestMethod]
    public void isOpCode_wrongCode()
    {
        //Arange
        addwf = new PicSimulatorGUI.commands.Addwf();
            //addlw.memory.W = 0x0000;
            //Act
            bool res = addwf.isOpCode(0x4E00);
            //Assert
            //Console.WriteLine(res);
            Assert.IsFalse(res);
    }
    [TestMethod]
    public void isOpCode_rightCode()
    {
        //Arange
        addwf = new PicSimulatorGUI.commands.Addwf();
        //addlw.memory.W = 0x0000;
        //Act
        bool res = addwf.isOpCode(0x700);
        //Assert
        //Console.WriteLine(res);
        Assert.IsTrue(res);
    }
}