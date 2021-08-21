using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "PlayerColorToColorMap", menuName = "PlayerColorToColorMap")]
    public class PlayerColorToColorMap : ScriptableObject
    {
        public List<ColorMap> colorMaps;
    }
}