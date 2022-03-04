using MVVM_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_GUI.Services
{
    public class TrooperEditorViaWindow : ITrooperEditorService
    {
        public void Edit(Trooper trooper)
        {
            var tre = new TrooperEditorWindow(trooper).ShowDialog();
        }
    }
}
