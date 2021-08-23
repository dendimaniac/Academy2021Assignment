using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "GameColorToColorMap", menuName = "GameColorToColorMap")]
    public class GameColorToColorMapSO : ScriptableObject
    {
        public List<ColorMap> ColorMaps;
        
        public readonly Dictionary<GameColor, Color> ColorMapDictionary = new Dictionary<GameColor, Color>();

        private void OnValidate()
        {
            foreach (var colorMap in ColorMaps)
            {
                ColorMapDictionary[colorMap.gameColor] = colorMap.color;
            }
        }
    }
}