using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ColorSwitch
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float jumpForce;
        [SerializeField] private PlayerColorToColorMap playerColorToColorMap;
        [SerializeField] private PlayerSpriteChoice playerSpriteChoice;

        public GameColor CurrentColor { get; private set; }
        
        private Rigidbody2D _rigidbody2D;
        private readonly Dictionary<GameColor, Color> _colorMapDictionary = new Dictionary<GameColor, Color>();

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            SetInitialPlayerSprite();
            SetupColorMapDictionary();
            SwitchNewPlayerColor();
        }
        
        public void SwitchNewPlayerColor()
        {
            CurrentColor = GetRandomPlayerColor();
            spriteRenderer.color = _colorMapDictionary[CurrentColor];
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }

        private void SetInitialPlayerSprite()
        {
            spriteRenderer.sprite = playerSpriteChoice.CurrentSpriteChoice;
        }
        
        private void SetupColorMapDictionary()
        {
            foreach (var colorMap in playerColorToColorMap.colorMaps)
            {
                _colorMapDictionary.Add(colorMap.gameColor, colorMap.color);
            }
        }
        
        private GameColor GetRandomPlayerColor()
        {
            var values = Enum.GetValues(typeof(GameColor));
            GameColor newGameColor;
            do
            {
                newGameColor = (GameColor)values.GetValue(Random.Range(0, values.Length));
            } while (newGameColor == CurrentColor);
            return newGameColor;
        }
    }
}