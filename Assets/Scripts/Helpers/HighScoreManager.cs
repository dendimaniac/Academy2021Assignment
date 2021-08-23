using UnityEngine;

namespace ColorSwitch.Helpers
{
    public static class HighScoreManager
    {
        private const string HighScoreKey = "HighscoreKey";
        
        public static void SaveScore(int newScore)
        {
            var currentHighScore = PlayerPrefs.GetInt(HighScoreKey);
            if (newScore <= currentHighScore) return;
            
            PlayerPrefs.SetInt(HighScoreKey, newScore);
            PlayerPrefs.Save();
        }

        public static int GetHighScore()
        {
            return PlayerPrefs.GetInt(HighScoreKey);
        }
    }
}