using PicSimulatorGUI;
using System.Reflection.Emit;

namespace PicSimTest;

[TestClass]
public class SpezRegTest
{
    public PicSimulatorGUI.Memory memory;
    public PicSimulatorGUI.registers.SpezialRegister spezReg;
    public string name = "spezial";
    // public PicSimulatorGUI picsim;
    [TestMethod]
    public void naming_works()
    {
        //Arange
        spezReg = new PicSimulatorGUI.registers.SpezialRegister(name);
        Assert.AreEqual(name, spezReg.TableName);
        // Assert.IsFalse(false);
    }
    [TestMethod]
    public void register_is_Filled()
    {
            //Arange
            spezReg = new PicSimulatorGUI.registers.SpezialRegister("spezial");
            spezReg.fillNew();

            Assert.AreEqual(1,spezReg.Rows.Count);
           // Assert.IsFalse(false);
    }

}