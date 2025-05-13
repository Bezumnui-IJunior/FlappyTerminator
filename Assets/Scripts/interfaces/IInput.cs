using System;

public interface IInput
{
    event Action Jumping;
    event Action Shoot;
}