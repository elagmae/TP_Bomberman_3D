using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBombActivation : MonoBehaviour
{
    public event Action<int> OnBombActivation;
    private PlayerInputHandler _input;
    private PlayerBombDetection _detection;
    private PlayerMain _main;

    private void Start()
    {
        _main = GetComponent<PlayerMain>();

        _input = GetComponent<PlayerInputHandler>();
        _input.OnActivate += ActivateBomb;
    }

    public void ActivateBomb(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            OnBombActivation?.Invoke(_main.Id);
        }
    }
}
