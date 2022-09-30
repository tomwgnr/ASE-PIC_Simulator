using PicSimulatorGUI;
namespace PicSimTest;

[TestClass]
public class flankenCheckTest
{
    public PicSimulatorGUI.Memory memory;
    public PicSimulatorGUI.sim.FlakenCheck flkChk;
    public string name = "spezial";
    // public PicSimulatorGUI picsim;
    [TestMethod]
    public void flankenCheck_risingflank_true()
    {
        //Arange
        flkChk = new PicSimulatorGUI.sim.FlakenCheck();

        Assert.IsFalse(true);
    }
    [TestMethod]
    public void register_is_Filled()
    {
        //Arange
        flkChk = new PicSimulatorGUI.sim.FlakenCheck();

        Assert.IsFalse(false);
    }

}