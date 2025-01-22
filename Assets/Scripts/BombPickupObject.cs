using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickupObject : MonoBehaviour, IPoolable
{
    public void RegisterType()
    {
    }

    public void OnPooled(string tag)
    {
        transform.position = new Vector3(Random.Range(-12f, 12f), transform.position.y, Random.Range(-30f, -15f));
    }

    public void OnUnPooled()
    {
    }
}
