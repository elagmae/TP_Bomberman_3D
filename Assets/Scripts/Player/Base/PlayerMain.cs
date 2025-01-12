using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMain : MonoBehaviour
{
    [field: SerializeField]
    public int Health { get; set; }
    public Rigidbody Rb { get; set; }
    public PlayerInput PlayerInput { get; set; }
    public PlayerInputHandler PlayerInputHandler { get; set; }
    public MeshRenderer Render { get; set; }
    public Material Material { get; set; }
    public int Id { get; set; } = 0;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        PlayerInputHandler = GetComponent<PlayerInputHandler>();
        Render = GetComponent<MeshRenderer>();
        Material = Render.material;
    }
}
