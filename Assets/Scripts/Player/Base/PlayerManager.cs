using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [field: SerializeField]
    public CinemachineImpulseSource ImpulseSource { get; set; }
    [field: SerializeField]
    public List<Slider> PlayerHealthSliders { get; set; } = new();
    [field: SerializeField]
    public Image EndGamePanel { get; set; }
    [field: SerializeField]
    public List<Color> PlayerColors { get; set; } = new();
    public List<PlayerMain> PlayerMains { get; set; } = new();
    public List<List<GameObject>> InventoriesUI { get; set; } = new();

    [SerializeField]
    private List<GameObject> _playerPositions = new();

    [SerializeField]
    private List<GameObject> _inventory_R;
    [SerializeField]
    private List<GameObject> _inventory_B;

    private PlayerMain _main;
    private PlayerInputManager _inputManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _inputManager = GetComponent<PlayerInputManager>();
        _inputManager.onPlayerJoined += Join;

        InventoriesUI.Clear();
        InventoriesUI.Add(_inventory_R);
        InventoriesUI.Add(_inventory_B);
    }

    private void Join(PlayerInput input)
    {
        _main = input.gameObject.GetComponent<PlayerMain>();
        PlayerMains.Add(_main);

        if(_main == PlayerMains[0])
        {
            input.gameObject.name = "Player_R";
            _main.Id = 0;
        }

        else
        {
            input.gameObject.name = "Player_B";
            _main.Id = 1;
        }

        input.gameObject.transform.position = _playerPositions[_main.Id].transform.position;
        input.GetComponent<MeshRenderer>().material.color = PlayerColors[_main.Id];
    }
}


