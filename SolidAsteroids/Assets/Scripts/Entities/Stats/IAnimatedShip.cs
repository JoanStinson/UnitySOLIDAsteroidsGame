using UnityEngine;

public interface IAnimatedShip
{
    Sprite IdleSprite { get; }
    Sprite MovingUpSprite { get; }
    Sprite MovingDownSprite { get; }
}
