using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Barriers
{
    public class BarrierUIController : MonoBehaviour, IObserver
    {
        [SerializeField] private Barrier barrier;

        [SerializeField] private SpriteRenderer render;

        [SerializeField] private List<Sprite> sprites;

        private void Awake()
        {
            if (barrier != null)
                (barrier as ISubject).Attach(this);
        }

        public void ReceiveNotification(ISubject subject)
        {
            SetGraphics((subject as Barrier).GetLife);
        }

        private void SetGraphics(int value)
        {
            int index = sprites.Count - value;

            if (index < sprites.Count)
                render.sprite = sprites[index];
        }
    }
}