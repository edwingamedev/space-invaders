using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EdwinGameDev.Effects
{
    public class TextColorChange : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] [Range(0f, 100f)] private float frequency;
        [SerializeField] private Color[] colors;

        private int colorIndex = 0;
        private float currentTime = 0;
        private int colorSize;

        private void Awake()
        {
            colorSize = colors.Length;
        }

        // Update is called once per frame
        void Update()
        {
            SetColor();
        }

        private void SetColor()
        {
            if (colors == null)
                return;

            textMesh.color = Color.Lerp(textMesh.color, colors[colorIndex], frequency * Time.deltaTime);
            currentTime = Mathf.Lerp(currentTime, 1f, frequency * Time.deltaTime);

            if (currentTime > 0.9f)
            {
                currentTime = 0;                                
                colorIndex = (colorIndex + 1) % colorSize;
            }
        }
    }
}