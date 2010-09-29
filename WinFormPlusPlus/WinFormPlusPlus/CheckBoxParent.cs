using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormPlusPlus
{
  public class CheckBoxParent : CheckBox
  {
    readonly List<CheckBox> _checkBoxes = new List<CheckBox>();
    private bool _disableEvents;

    public CheckBoxParent() {
      CheckStateChanged += CheckBoxParent_CheckStateChanged;
    }

    void CheckBoxParent_CheckStateChanged(object sender, EventArgs e)
    {
      if (_disableEvents) return;
      _disableEvents = true;
      var checkAll = CheckState != CheckState.Unchecked;
      foreach (var checkBox in _checkBoxes) {
        checkBox.Checked = checkAll;
      }
      _disableEvents = false;
    }

    public void AddChildCheckBox(CheckBox checkBox) {
      _checkBoxes.Add(checkBox);
      checkBox.CheckStateChanged += CheckBox_CheckStateChanged;
    }

    void CheckBox_CheckStateChanged(object sender, EventArgs e)
    {
      if (_disableEvents) return;
      _disableEvents = true;
      CheckState = GetState();
      _disableEvents = false;
    }

    private CheckState GetState() {
      var isChecked = _checkBoxes[0].CheckState;
      return _checkBoxes.Any(checkBox => checkBox.CheckState != isChecked) ? CheckState.Indeterminate : isChecked;
    }
  }
}
