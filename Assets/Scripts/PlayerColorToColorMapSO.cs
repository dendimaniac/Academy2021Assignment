using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "PlayerColorToColorMap", menuName = "PlayerColorToColorMap")]
    public class PlayerColorToColorMapSO : ScriptableObject
    {
        public List<ColorMap> colorMaps;
    }
}