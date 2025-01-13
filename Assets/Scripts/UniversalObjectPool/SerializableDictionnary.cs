using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public sealed class ObjectDictionnary : SerializedDictionary<string, GameObject>
{ }

[Serializable]
public sealed class IntDictionnary : SerializedDictionary<string, int>
{ }

[Serializable]
public class SerializedDictionary<K, V>
{
    [SerializeField] private List<K> keys = new();
    
    [SerializeField]
    private List<V> values = new();
    
    public void Add(K key, V value)
    {
        if (keys.Contains(key)) return;
        
        keys.Add(key);
        values.Add(value);
    }

    public V this[K key]
    {
        get => values[keys.IndexOf(key)];
        set => values[keys.IndexOf(key)] = value;
    }
    
    public bool ContainsKey(K key)
    {
        return keys.Contains(key);
    }
}