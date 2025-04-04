using System;
using UnityEngine;

public interface IInput
{
    public event Action OnButtonPressed;
    public event Action OnButtonReleased;

    public void Enable();
    public void Disable();
}
