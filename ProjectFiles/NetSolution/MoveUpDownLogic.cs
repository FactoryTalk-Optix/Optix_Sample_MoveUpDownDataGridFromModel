#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using System.Linq;
#endregion

public class MoveUpDownLogic : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        dataGrid = (DataGrid) Owner;
        dataGridchildren = InformationModel.Get(dataGrid.Model).Children;
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void MoveUp()
    {
        // Insert code to be executed when the user-defined method is called
        if (selectedIndex > 0)
        {
            selectedIndex--;
            dataGrid.SelectedItem = dataGridchildren.ElementAt(selectedIndex).NodeId;
        }
    }

    [ExportMethod]
    public void MoveDown()
    {
        // Insert code to be executed when the user-defined method is called
        if (selectedIndex < dataGridchildren.Count)
        {
            selectedIndex++;
            dataGrid.SelectedItem = dataGridchildren.ElementAt(selectedIndex).NodeId;
        }
    }

    [ExportMethod]
    public void SelectionChanged()
    {
        // Insert code to be executed when the user-defined method is called
        var selectedItemBrowseName = dataGridchildren.Where(item => item.NodeId == dataGrid.SelectedItem).First().BrowseName;
        selectedIndex = dataGridchildren.ToList().FindIndex(item => item.BrowseName == selectedItemBrowseName);
    }

    private ChildNodeCollection dataGridchildren;
    private DataGrid dataGrid;
    private int selectedIndex = 0;
}
