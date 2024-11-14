using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string JumpButton = "Jump";

    public event Action Jumping;

    private void Update()
    {
        if (Input.GetButtonDown(JumpButton))
        {
            Jumping?.Invoke();
        }
    }
}
