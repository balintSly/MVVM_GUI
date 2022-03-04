using MVVM_GUI.Models;
using System.Collections.Generic;

namespace MVVM_GUI.Logic
{
    public interface IArmyLogic
    {
        int AllCost { get; }
        double AvgPower { get; }
        double AvgSpeed { get; }
        public void EditTrooper(Trooper trooper);
        void AddToArmy(Trooper trooper);
        void RemoveFromArmy(Trooper trooper);
        void SetupCollections(IList<Trooper> barracks, IList<Trooper> army);
    }
}