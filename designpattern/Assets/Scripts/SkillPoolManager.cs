using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillPoolManager : Singleton<SkillPoolManager>
{
    [System.Serializable]
    public class SkillPool
    {
        public GameObject skillPrefab;
        public int initialSize = 10;
        public Queue<SkillInstance> pool = new Queue<SkillInstance>();
    }

    public List<SkillPool> skillPools = new List<SkillPool>();
    private Dictionary<string, Queue<SkillInstance>> poolDictionary = new Dictionary<string, Queue<SkillInstance>>();

    public override void OnAwake()
    {
        InitializePools();
    }

    private void InitializePools()
    {
        foreach (var skillPool in skillPools)
        {
            Queue<SkillInstance> objectPool = new Queue<SkillInstance>();

            for (int i = 0; i < skillPool.initialSize; i++)
            {
                GameObject obj = Instantiate(skillPool.skillPrefab);
                SkillInstance skillInstance = obj.GetComponent<SkillInstance>();
                obj.SetActive(false);
                objectPool.Enqueue(skillInstance);
            }

            poolDictionary.Add(skillPool.skillPrefab.name, objectPool);
        }
    }

    public SkillInstance GetSkillInstance(string skillName, Vector3 position = default, Quaternion rotation = default)
    {
        if (!poolDictionary.ContainsKey(skillName))
        {
            Debug.LogWarning($"Pool with name {skillName} doesn't exist.");
            return null;
        }

        Queue<SkillInstance> pool = poolDictionary[skillName];
        
        if (pool.Count == 0)
        {
            // 풀이 비었으면 새로 생성
            var skillPool = skillPools.Find(x => x.skillPrefab.name == skillName);
            GameObject obj = Instantiate(skillPool.skillPrefab);
            SkillInstance skillInstance = obj.GetComponent<SkillInstance>();
            return skillInstance;
        }

        SkillInstance instance = pool.Dequeue();
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        
        return instance;
    }

    public void ReturnToPool(SkillInstance skillInstance)
    {
        string poolName = skillInstance.gameObject.name.Replace("(Clone)", "");
        poolDictionary[poolName].Enqueue(skillInstance);
    }
}
