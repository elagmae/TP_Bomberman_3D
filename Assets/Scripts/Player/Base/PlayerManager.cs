using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [field: SerializeField]
    public List<GameObject> PlayerUI = new();
    public List<PlayerMain> PlayerMains { get; set; } = new();
    public List<List<GameObject>> InventoriesUI { get; set; } = new();

    [SerializeField]
    private List<GameObject> _playerPositions = new();
    [SerializeField]
    private List<Color> _playerColors = new();

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
            _main.Id = 0;
        }

        else
        {
            _main.Id = 1;
        }

        input.gameObject.transform.position = _playerPositions[_main.Id].transform.position;
        input.GetComponent<MeshRenderer>().material.color = _playerColors[_main.Id];
    }
}


