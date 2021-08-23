using System;
using ColorSwitch.Core;
using Random = UnityEngine.Random;

namespace ColorSwitch.Helpers
{
    public static class GameColorHelper
    {
        public static GameColor GetRandom(GameColor colorToAvoid)
        {
            var values = Enum.GetValues(typeof(GameColor));
            GameColor newGameColor;
            do
            {
                newGameColor = (GameColor)values.GetValue(Random.Range(1, values.Length));
            } while (newGameColor == colorToAvoid);
            return newGameColor;
        }
    }
}