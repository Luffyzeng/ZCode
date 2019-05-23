using UnityEditor;
using UnityEngine;

namespace ZCode
{
    public class SimulationModeMenu 
    {
        private const string kSimulationModeKey = "simulation mode";
        private const string kSimulationModePath = "ZCode/Framework/ResKit/Simulation Mode";

        //private static bool SimulationMode
        //{
        //    get { return EditorPrefs.GetBool(kSimulationModeKey, true); }
        //    set { EditorPrefs.SetBool(kSimulationModeKey, value); }
        //}

        [MenuItem(kSimulationModePath)]
        private static void ToggleSimulationMode()
        {
            ResMgr.SimulationMode = !ResMgr.SimulationMode;
        }

        [MenuItem(kSimulationModePath,true)]
        private static bool ToggleSimulationModeValidate()
        {
            Menu.SetChecked(kSimulationModePath, ResMgr.SimulationMode);
            return true;
        }
    }
}