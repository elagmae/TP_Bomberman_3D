using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMain : MonoBehaviour
{
    public Rigidbody Rb { get; set; }
    public PlayerInput PlayerInput { get; set; }
    public MeshRenderer Render { get; set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        Render = GetComponent<MeshRenderer>();
    }
}
