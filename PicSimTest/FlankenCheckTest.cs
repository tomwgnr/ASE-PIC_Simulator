using Moq;
using PicSimulatorGUI;
using PicSimulatorGUI.sim;
using System.Diagnostics;

namespace PicSimTest;

[TestClass]
public class flankenCheckTest
{
    private PicSimulatorGUI.sim.FlakenCheck flkChk;
    public int oldRB0;
    public int RB0;
    //public PicSimulatorGUI picsim; 
    //private Memory memMock;
    private Simulator simMock;
    private Mock<Simulator> simulatorMock = new Mock<Simulator>();
    //private Mock<Memory> memoryMock = new Mock<Memory>();
    private Memory memory;
    [TestMethod]
    public void flankenCheck_risingflank_true()
    {   
        simMock = new Simulator();
        memory = simMock.memory;
        //Arange
        PicSimulatorGUI.sim.FlakenCheck flkChk = new PicSimulatorGUI.sim.FlakenCheck();
        memory.writeByte(6,1);
        RB0 = flkChk.flankenCheck(1, 0,ref memory);

        //Debug.WriteLine("Debug Debug World", res);
        Assert.AreEqual(1, RB0);
    }
}