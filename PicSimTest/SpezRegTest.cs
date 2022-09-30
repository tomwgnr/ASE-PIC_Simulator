using PicSimulatorGUI;
using System.Reflection.Emit;

namespace PicSimTest;

[TestClass]
public class SpezRegTest
{
    public PicSimulatorGUI.Memory memory;
    public PicSimulatorGUI.commands.Addlw addlw;
   // public PicSimulatorGUI picsim;
    [TestMethod]
    public void register_is_Filled()
    {
            //Arange
            addlw = new PicSimulatorGUI.commands.Addlw();
            //addlw.memory.W = 0x0000;
            //Act
            bool res = addlw.isOpCode(0x4E00);
            //Assert
            //Console.WriteLine(res);
            Assert.IsFalse(res);
    }
    /*
    [TestMethod]
    public void isOpCode_rightCode()
    {
        //Arange
        addlw = new PicSimulatorGUI.commands.Addlw();
        //addlw.memory.W = 0x0000;
        //Act
        bool res = addlw.isOpCode(0x3E00);
        //Assert
        //Console.WriteLine(res);
        Assert.IsTrue(res);
    }
    */
}