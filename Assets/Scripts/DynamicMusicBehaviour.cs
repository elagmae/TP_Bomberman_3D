using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;


public class DynamicMusicBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float playerBlue = (3.0f - PlayerManager.Instance.PlayerMains[1].Health / 6.0f);
        float playerRed = (3.0f - PlayerManager.Instance.PlayerMains[0].Health / 6.0f);
        float ratio = 0.5f + (playerRed - playerBlue);

        print(ratio);
        
        RuntimeManager.StudioSystem.setParameterByName("PlayerAdvantage", ratio);
    }
}
