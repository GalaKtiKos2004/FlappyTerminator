using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string JumpButton = "Jump";

    private const KeyCode ShootKey = KeyCode.Z;

    public event Action Jumping;
    public event Action Shooting;

    private void Update()
    {
        if (Input.GetButtonDown(JumpButton))
        {
            Jumping?.Invoke();
        }
        if (Input.GetKeyDown(ShootKey))
        {
            Shooting?.Invoke();
        }
    }
}
