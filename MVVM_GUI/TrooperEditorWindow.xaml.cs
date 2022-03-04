using MVVM_GUI.Models;
using MVVM_GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_GUI
{
    /// <summary>
    /// Interaction logic for TrooperEditorWindow.xaml
    /// </summary>
    public partial class TrooperEditorWindow : Window
    {
        public TrooperEditorWindow(Trooper trooper)
        {
            InitializeComponent();
            this.DataContext = new TrooperEditorWindowViewModel();
            (this.DataContext as TrooperEditorWindowViewModel).Setup(trooper);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
