using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ColorSwitch
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private PlayerColorToColorMap playerColorToColorMap;

        public GameColor CurrentColor { get; private set; }

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private readonly Dictionary<GameColor, Color> _colorMapDictionary = new Dictionary<GameColor, Color>();

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();

            SetupColorMapDictionary();
            SwitchNewPlayerColor();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }

        public void SwitchNewPlayerColor()
        {
            CurrentColor = GetRandomPlayerColor();
            _spriteRenderer.color = _colorMapDictionary[CurrentColor];
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