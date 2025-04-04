using System;
using UnityEngine;

public class DesktopInput : IInput
{
    private readonly Controls controls;
    public event Action OnButtonPressed;
    public event Action OnButtonReleased;

    public DesktopInput()
    {
        controls = new Controls();

        Bind();
    }

    private void Bind()
    {
        controls.Gameplay.Shoot.performed += _ => OnButtonPressed?.Invoke();
        controls.Gameplay.Shoot.canceled += _ => OnButtonReleased?.Invoke();
    }

    public void Enable() => controls.Enable();
    public void Disable() => controls.Disable();
}
