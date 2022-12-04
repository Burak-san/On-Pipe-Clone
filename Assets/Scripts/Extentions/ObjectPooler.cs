using System.Collections.Generic;
using Extentions;
using Signals;
using UnityEngine;

public class ObjectPooler : MonoSingleton<ObjectPooler>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    #region Event Subscription

    private void OnEnable()
    {
        EnableActions();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        PoolSignals.Instance.onSpawnFromPool += OnSpawnFromPool;
        PoolSignals.Instance.onReturnToPool += OnReturnToPool;
    }
        
    private void UnSubscribeEvents()
    {
        PoolSignals.Instance.onSpawnFromPool -= OnSpawnFromPool;
        PoolSignals.Instance.onReturnToPool -= OnReturnToPool;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    #endregion

    private void OnSpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent)
    {
        SpawnFromPool(tag, position, rotation, parent);
    }
    
    
    private void OnReturnToPool(string tag, GameObject objectToPool)
    {
        ReturnToPool(tag, objectToPool);
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent) 
    {
        if (!poolDictionary.ContainsKey(tag)) 
        {
            Debug.LogWarning("Key doesn't exist in objectPooler:" + tag);
        }
        
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.parent = parent;
        objectToSpawn.transform.localPosition = position;
        objectToSpawn.transform.rotation = rotation;
        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject objectToPool) 
    {
        if (!poolDictionary.ContainsKey(tag)) 
        {
            Debug.LogWarning("Key doesn't exist in poolDictionary:" + tag);
        }
        objectToPool.SetActive(false);
        objectToPool.transform.parent = transform;
        objectToPool.transform.position = transform.position;
        poolDictionary[tag].Enqueue(objectToPool);
        Destroy(objectToPool.gameObject);
    }

    private void EnableActions() 
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.parent = transform;
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
}