using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMain : MonoBehaviour
{
    [field: SerializeField]
    public int Health { get; set; }
    public Rigidbody Rb { get; set; }
    public PlayerInput PlayerInput { get; set; }
    [field:SerializeField]
    public ParticleSystem DeathPart { get; set; }
    [field: SerializeField]
    public ParticleSystem HitPart { get; set; }
    public PlayerInputHandler PlayerInputHandler { get; set; }
    public PlayerHealthBehaviour PlayerHealthBehaviour { get; set; }
    public PlayerInventoryBehaviour PlayerInventoryBehaviour { get; set; }
    public MeshRenderer Render { get; set; }
    public Material Material { get; set; }
    public Animator Animator { get; set; }
    public int Id { get; set; } = 0;

    private ParticleSystem.MainModule _mainDeath;
    private ParticleSystem.MainModule _mainHit;

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
    }

    private void Start()
    {
        _mainDeath = DeathPart.main;
        _mainDeath.startColor = new ParticleSystem.MinMaxGradient(Material.color, Color.black);

        _mainHit = HitPart.main;
        _mainHit.startColor = new ParticleSystem.MinMaxGradient(Material.color, Color.black);
    }
}
