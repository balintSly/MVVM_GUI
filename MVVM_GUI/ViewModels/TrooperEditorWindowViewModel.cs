﻿using MVVM_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_GUI.ViewModels
{
    public class TrooperEditorWindowViewModel
    {
        public Trooper Actual { get; set; }
        public void Setup (Trooper trooper)
        {
            this.Actual = trooper;
        }
        public TrooperEditorWindowViewModel()
        {

        }
    }
}
