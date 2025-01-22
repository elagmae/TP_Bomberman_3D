using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryBehaviour : MonoBehaviour
{
    public event Action<GameObject> OnItemAdded;
    public event Action<GameObject> OnItemRemoved;
    public List<BombPickupObject> BombInventory { get; set; } = new();
    private PlayerBombDetection _bombDetect;
    private PlayerBombActivation _bombActivation;

    private void Start()
    {
        _bombDetect = GetComponent<PlayerBombDetection>();
        _bombDetect.OnBombDetection += Add;

        _bombActivation = GetComponent<PlayerBombActivation>();
        _bombActivation.OnBombActivation += Remove;
    }
    public void Add(int id, BombPickupObject bomb)
    {
        var inventory = PlayerManager.Instance.InventoriesUI[id];

        foreach (var item in inventory)
        {
            if (!item.activeInHierarchy)
            {
                BombInventory.Add(bomb);
                OnItemAdded?.Invoke(item);
                
                ObjectPoolManager.Instance.Unpool("bomb_pickup", bomb);
                return;
            }
        }
    }

    public void Remove(int id)
    {
        for (int i = PlayerManager.Instance.InventoriesUI[id].Count-1; i >= 0; i--)
        {
            var item = PlayerManager.Instance.InventoriesUI[id][i];
            if (item.activeInHierarchy && item.transform.localScale == Vector3.one)
            {
                var bomb = BombInventory[^1];
                OnItemRemoved?.Invoke(item);
                BombInventory.Remove(bomb);

                var actBomb = ObjectPoolManager.Instance.Pool("bomb_explosion");
                actBomb.gameObject.transform.position = transform.position;
                
                return;
            }
        }
    }
}
