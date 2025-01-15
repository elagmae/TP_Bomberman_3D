using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private PlayerInputHandler _input;
    private Rigidbody _rb;
    private Vector2 _direction;

    private void Awake()
    {
        _input = GetComponent<PlayerInputHandler>();
        _input.OnMove += Move;

        _rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        _rb.velocity = new Vector3(_direction.x, 0, _direction.y) * _speed;
    }

    public void Move(InputAction.CallbackContext ctx, Vector2 dir)
    {
        _direction = dir;
    }
}
