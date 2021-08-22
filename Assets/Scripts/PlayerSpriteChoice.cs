using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    [CreateAssetMenu(fileName = "PlayerSpriteChoice", menuName = "PlayerSpriteChoice")]
    public class PlayerSpriteChoice : ScriptableObject
    {
        public List<Sprite> allPossibleSprites;

        [HideInInspector] public Sprite CurrentSpriteChoice;

        private void Awake()
        {
            if (allPossibleSprites == null || allPossibleSprites.Count == 0) return;
            
            CurrentSpriteChoice = allPossibleSprites[0];
        }
    }
}