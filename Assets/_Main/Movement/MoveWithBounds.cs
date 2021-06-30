using EdwinGameDev.Settings;
using System;
using UnityEngine;

namespace EdwinGameDev.Movement
{
    public class MoveWithoutBounds : IMovement
    {
        private GameBounds gameBounds;

        public MoveWithoutBounds(GameBounds gameBounds)
        {
            this.gameBounds = gameBounds;
        }

        public bool IsValidHorizontalMovement(Transform movable, Vector2 movementVector)
        {
            var moveVector = new Vector2(movable.transform.position.x + movementVector.x, movable.transform.position.y + movementVector.y);

            return gameBounds.IsInHorizontalBounds(moveVector);
        }

        public bool IsValidVerticalMovement(Transform movable, Vector2 movementVector)
        {
            var moveVector = new Vector2(movable.transform.position.x + movementVector.x, movable.transform.position.y + movementVector.y);

            return gameBounds.IsInVerticalBounds(moveVector);
        }

        public void Move(Transform movable, Vector2 movementVector)
        {
            movable.Translate(movementVector);
        }
    }

    public class MoveWithBounds : IMovement
    {
        private GameBounds gameBounds;

        public MoveWithBounds(GameBounds gameBounds)
        {
            this.gameBounds = gameBounds;
        }

        public bool IsValidHorizontalMovement(Transform movable, Vector2 movementVector)
        {
            var moveVector = new Vector2(movable.transform.position.x + movementVector.x, movable.transform.position.y + movementVector.y);

            return gameBounds.IsInHorizontalBounds(moveVector);
        }

        public bool IsValidVerticalMovement(Transform movable, Vector2 movementVector)
        {
            var moveVector = new Vector2(movable.transform.position.x + movementVector.x, movable.transform.position.y + movementVector.y);

            return gameBounds.IsInVerticalBounds(moveVector);
        }

        public void Move(Transform movable, Vector2 movementVector)
        {
            var moveVector = new Vector2(movable.transform.position.x + movementVector.x, movable.transform.position.y + movementVector.y);

            if (gameBounds.IsInHorizontalBounds(moveVector) && gameBounds.IsInVerticalBounds(moveVector))
            {
                movable.Translate(movementVector);
            }
            else
            {
                movable.position = gameBounds.ConvertToInBoundsPositon(moveVector);
            }
        }
    }
}