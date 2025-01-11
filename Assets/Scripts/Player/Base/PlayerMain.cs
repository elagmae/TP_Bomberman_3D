using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMain : MonoBehaviour
{
    public PlayerBombDetection BombDetect { get; set; }
    public PlayerInventoryBehaviour InventoryBehaviour { get; set; }
    public Rigidbody Rb { get; set; }
    public PlayerInput PlayerInput { get; set; }
    public MeshRenderer Render { get; set; }
    public Material Material { get; set; }
    public int Id { get; set; } = 0;

    private void Awake()
    {
        BombDetect = GetComponent<PlayerBombDetection>();
        Rb = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        Render = GetComponent<MeshRenderer>();
        Material = Render.material;
    }
}
