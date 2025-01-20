using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageFieldPool : Singleton<DamageFieldPool>
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int initialSize = 10;
        public Queue<DamageField> pool = new Queue<DamageField>();
    }

    [SerializeField] private List<Pool> pools = new List<Pool>();
    private Dictionary<string, Queue<DamageField>> poolDictionary = new Dictionary<string, Queue<DamageField>>();

    public override void OnAwake()
    {
        InitializePools();
    }

    private void InitializePools()
    {
        foreach (var pool in pools)
        {
            Queue<DamageField> objectPool = new Queue<DamageField>();

            for (int i = 0; i < pool.initialSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                DamageField field = obj.GetComponent<DamageField>();
                obj.SetActive(false);
                objectPool.Enqueue(field);
            }

            poolDictionary.Add(pool.prefab.name, objectPool);
        }
    }

    public DamageField GetDamageField(string fieldType, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(fieldType))
        {
            Debug.LogWarning($"Pool with name {fieldType} doesn't exist.");
            return null;
        }

        Queue<DamageField> pool = poolDictionary[fieldType];
        
        if (pool.Count == 0)
        {
            var poolData = pools.Find(x => x.prefab.name == fieldType);
            GameObject obj = Instantiate(poolData.prefab);
            DamageField field = obj.GetComponent<DamageField>();
            return field;
        }

        DamageField instance = pool.Dequeue();
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        
        return instance;
    }

    public void ReturnToPool(DamageField field)
    {
        string poolName = field.gameObject.name.Replace("(Clone)", "");
        poolDictionary[poolName].Enqueue(field);
    }
}