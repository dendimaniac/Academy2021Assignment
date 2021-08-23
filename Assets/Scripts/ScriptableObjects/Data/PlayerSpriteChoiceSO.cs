using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "PlayerSpriteChoice", menuName = "PlayerSpriteChoice")]
    public class PlayerSpriteChoiceSO : ScriptableObject
    {
        public List<Sprite> AllPossibleSprites;

        [HideInInspector] public Sprite CurrentSpriteChoice;

        private void OnValidate()
        {
            if (AllPossibleSprites == null || AllPossibleSprites.Count == 0) return;
            if (AllPossibleSprites.Contains(CurrentSpriteChoice)) return;
            
            CurrentSpriteChoice = AllPossibleSprites[0];
        }
    }
}