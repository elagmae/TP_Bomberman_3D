using System.Collections.Generic;
using UnityEngine;

//TODO: A custom property drawer for those dictionnary
public class ObjectPoolManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of this manager
    /// </summary>
    public static ObjectPoolManager Instance { get; private set; }
    
    /// <summary>
    /// A dictionnary containing the type of the IPoolable object and a max number of instance.
    /// It can accept non IPoolable class, but it will never get used,
    /// because the type check is used at instanciation and pooling
    /// </summary>
    [Tooltip("The name of the type and the number max of instance of that type")]
    [SerializeField] private IntDictionnary _maxValue;
    
    /// <summary>
    /// A dictionnary containing the type of the IPoolable object and a prefab/gameobject to instanciate
    /// whenever there is not enough object in the pool and in existance.
    /// It can accept non IPoolable class, but it will never get used,
    /// because the type check is used at instanciation and pooling
    /// </summary>
    [Tooltip("The name of the type and the prefab of that type")]
    [SerializeField] private ObjectDictionnary _prefabPool;
    
    /// <summary>
    /// The current number of each type in the pool actually (both instanciated and dormant)
    /// </summary>
    private Dictionary<string, int> _currentPoolCount = new ();
    
    /// <summary>
    /// A list of every dormant object in the pool
    /// </summary>
    private Dictionary<string, List<IPoolable>> _pool;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _pool = new Dictionary<string, List<IPoolable>>();
    }

    /// <summary>
    /// Check if the type T already has a prefab attached to it, for easy instanciation
    /// </summary>
    /// <param name="T">
    /// Type of the IPoolable object
    /// It can accept non IPoolable class, but it will never get used,
    /// because the type check is used at instanciation and pooling
    /// </param>
    /// <returns> Whether the type T has a prefab attached or not </returns>
    public bool IsRegistered(string T)
    {
        return _prefabPool.ContainsKey(T);
    }

    /// <summary>
    /// Add the type T to the prefab pool
    /// </summary>
    /// <param name="T">
    /// Type of the IPoolable object
    /// It can accept non IPoolable class, but it will never get used,
    /// because the type check is used at instanciation and pooling
    /// </param>
    /// <param name="prefab"> The gameobject that will be used as instanciation prefab. </param>
    public void AddToPrefabPool(string T, GameObject prefab)
    {
        prefab.transform.SetParent(transform);
        _prefabPool.Add(T, prefab);
    }

    /// <summary>
    /// Get an object of type T, which is an IPoolable.
    /// </summary>
    /// <typeparam name="T">The type of the object being return,
    /// which should be a IPoolable MonoBehaviour subclass</typeparam>
    /// <returns> The object being pooled </returns>
    public IPoolable Pool(string item)
    {
        IPoolable pooledObject;
        if (!_pool.ContainsKey(item) || _pool[item].Count == 0)
        {
            if (!_currentPoolCount.ContainsKey(item)) _currentPoolCount.Add(item, 0);
            if (_currentPoolCount[item] >= _maxValue[item]) return null;

            _currentPoolCount[item]++;
            
            if(!_pool.ContainsKey(item)) _pool.Add(item, new List<IPoolable>());

            var prefab = _prefabPool[item];
            var instance = Instantiate(prefab);
            pooledObject = instance.GetComponent<IPoolable>();
        }
        else pooledObject = _pool[item][0];

        _pool[item].Remove(pooledObject);
        
        pooledObject.gameObject.SetActive(true);
        pooledObject.gameObject.transform.SetParent(null);
        pooledObject.OnPooled(item);

        return pooledObject;
    }

    /// <summary>
    /// Store an object into the pool
    /// </summary>
    /// <param name="pooledObject"> The object to store </param>
    public void Unpool(string T, IPoolable pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        if (!_pool.ContainsKey(T))
        {
            _pool.Add(T, new List<IPoolable>());
        }
        _pool[T].Add(pooledObject);
        pooledObject.OnUnPooled();
    }
}