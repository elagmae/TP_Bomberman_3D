using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryBehaviour : MonoBehaviour
{
    public List<GameObject> BombInventory { get; set; } = new();
    private PlayerBombDetection _bombDetect;
    private PlayerBombActivation _bombActivation;

    private void Start()
    {
        _bombDetect = GetComponent<PlayerBombDetection>();
        _bombDetect.OnBombDetection += Add;

        _bombActivation = GetComponent<PlayerBombActivation>();
        _bombActivation.OnBombActivation += Remove;
    }
    public void Add(int id, GameObject bomb)
    {
        var inventory = PlayerManager.Instance.InventoriesUI[id];

        foreach (var item in inventory)
        {
            if (!item.activeInHierarchy)
            {
                BombInventory.Add(bomb);
                item.SetActive(true);
                bomb.SetActive(false);
                // Explosion de la bombe.
                // Lyta sort la bombe de la pool stp.
                return;
            }
        }
    }

    public void Remove(int id)
    {
        for (int i = PlayerManager.Instance.InventoriesUI[id].Count-1; i >= 0; i--)
        {
            var item = PlayerManager.Instance.InventoriesUI[id][i];
            if (item.activeInHierarchy)
            {
                var bomb = BombInventory[^1];
                bomb.tag = "ActivatedBomb";
                bomb.SetActive(true);
                bomb.transform.position = this.transform.position;
                BombInventory.Remove(bomb);
                item.SetActive(false);

                //Lyta remet dans la pool stp.
                return;
            }
        }
    }
}
