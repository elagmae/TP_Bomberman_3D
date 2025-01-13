using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action<InputAction.CallbackContext> OnActivate;
    public event Action<InputAction.CallbackContext, Vector2> OnMove;

    private PlayerInput _player;

    [SerializeField]
    private bool _isAI;

    private void Awake()
    {
        if (_isAI) return;
        _player = GetComponent<PlayerInput>();
        _player.onActionTriggered += OnInput;
    }

    public void OnInput(InputAction.CallbackContext ctx)
    {
        switch (ctx.action.name)
        {
            case "Move":
                OnMove?.Invoke(ctx, ctx.ReadValue<Vector2>());
                break;

            case "Activate":
                OnActivate?.Invoke(ctx);
                break;
        }
    }
}
