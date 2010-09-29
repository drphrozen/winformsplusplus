using System.Windows.Forms;
using WinFormPlusPlus;

namespace CheckBoxCollection
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
      var checkBoxes = new CheckBox[10];
      for (var i = 0; i < checkBoxes.Length; i++)
      {
        checkBoxes[i] = new CheckBox { Text = i.ToString() };
        flowLayoutPanel1.Controls.Add(checkBoxes[i]);
      }

      var parentAll = new CheckBoxParent { Text = "All" };
      foreach (var checkBox in checkBoxes)
        parentAll.AddChildCheckBox(checkBox);
      flowLayoutPanel1.Controls.Add(parentAll);
      
      var parentLast5 = new CheckBoxParent { Text = "Last 5" };
      for (var i = 5; i < checkBoxes.Length; i++)
        parentLast5.AddChildCheckBox(checkBoxes[i]);        
      flowLayoutPanel1.Controls.Add(parentLast5);

      var parentInParent = new CheckBoxParent { Text = "Parent in Parent" };
      parentInParent.AddChildCheckBox(checkBoxes[0]);
      parentInParent.AddChildCheckBox(parentLast5);
      flowLayoutPanel1.Controls.Add(parentInParent);
    }
  }
}
