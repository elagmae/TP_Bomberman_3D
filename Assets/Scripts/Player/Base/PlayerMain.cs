using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMain : MonoBehaviour
{
    [field: SerializeField]
    public int Health { get; set; }
    public Rigidbody Rb { get; set; }
    public PlayerInput PlayerInput { get; set; }
    public ParticleSystem DeathPart { get; set; }
    public PlayerInputHandler PlayerInputHandler { get; set; }
    public PlayerHealthBehaviour PlayerHealthBehaviour { get; set; }
    public PlayerInventoryBehaviour PlayerInventoryBehaviour { get; set; }
    public MeshRenderer Render { get; set; }
    public Material Material { get; set; }
    public Animator Animator { get; set; }
    public int Id { get; set; } = 0;
    private ParticleSystem.MainModule _main;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();
        PlayerInputHandler = GetComponent<PlayerInputHandler>();
        PlayerHealthBehaviour = GetComponent<PlayerHealthBehaviour>();
        PlayerInventoryBehaviour = GetComponent<PlayerInventoryBehaviour>();
        Render = GetComponent<MeshRenderer>();
        Material = Render.material;
        Animator = GetComponent<Animator>();
        DeathPart = GetComponentInChildren<ParticleSystem>();
        _main = DeathPart.main;
        _main.startColor = new ParticleSystem.MinMaxGradient(Material.color, Color.black);
    }
}
