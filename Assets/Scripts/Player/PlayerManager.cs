using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public List<PlayerMain> PlayerMains { get; set; } = new();

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

        _inputManager = GetComponent<PlayerInputManager>();
        _inputManager.onPlayerJoined += Join;
    }

    private void Join(PlayerInput input)
    {
        var playerMain = input.gameObject.GetComponent<PlayerMain>();
        PlayerMains.Add(playerMain);

        if(playerMain == PlayerMains[0])
        {
            playerMain.Render.material.color = Color.red;
        }

        else
        {
            playerMain.Render.material.color = Color.blue;
        }

    }
}


