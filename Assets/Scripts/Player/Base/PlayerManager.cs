using Cinemachine;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [field: SerializeField]
    public VolumeProfile Volume { get; set; }
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

    [SerializeField]
    private bool _isPvE;

    [SerializeField, ShowIf("_isPvE")] private PlayerMain _playerCharacter;
    [SerializeField, ShowIf("_isPvE")] private PlayerMain _aiCharacter;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if(!_isPvE){
            _inputManager = GetComponent<PlayerInputManager>();
            _inputManager.onPlayerJoined += Join;
        }
        else
        {
            PlayerMains.Add(_playerCharacter);
            PlayerMains.Add(_aiCharacter);
            
            _playerCharacter.gameObject.name = "Player_R";
            _playerCharacter.Id = 0;
            _aiCharacter.gameObject.name = "Player_B";
            _aiCharacter.Id = 1;
            
            _playerCharacter.transform.position = _playerPositions[0].transform.position;
            _aiCharacter.transform.position = _playerPositions[1].transform.position;
            
            _playerCharacter.GetComponent<MeshRenderer>().material.color = PlayerColors[0];
            _aiCharacter.GetComponent<MeshRenderer>().material.color = PlayerColors[1];
        }

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


