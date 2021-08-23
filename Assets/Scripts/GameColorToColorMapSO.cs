using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "GameColorToColorMap", menuName = "GameColorToColorMap")]
    public class GameColorToColorMapSO : ScriptableObject
    {
        public List<ColorMap> ColorMaps;
    }
}