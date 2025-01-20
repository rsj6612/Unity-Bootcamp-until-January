using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManagerJ : Singleton<MonsterManagerJ>
{
    Dictionary<int, MonsterJ> monsters = new Dictionary<int, MonsterJ>();
    private Dictionary<InCountArea, List<MonsterJ>> monsterInCountArea = new();

    void Start()
    {
        // 1번방식
        EventManagerJ.Instance.Subscribe((MessageTypeNotifyInCountArea areaMsg) =>
        {
            EntityJ entityj = areaMsg.other.GetComponent<EntityJ>();
            if (entityj is MonsterJ j1)
            {
                if (!monsterInCountArea.ContainsKey(areaMsg.InCountArea))
                {
                    monsterInCountArea[areaMsg.InCountArea] = new List<MonsterJ>();
                }
                
                monsterInCountArea[areaMsg.InCountArea].Add(j1);
            }
            else if (entityj is PlayerJ j)
            {
                if (monsterInCountArea.TryGetValue(areaMsg.InCountArea, value: out var value))
                {
                    foreach (var monsterJ in value)
                    {
                        monsterJ.OnDetectPlayer(j);
                    }
                }
            }
        });
    }

    public void AddMonster(MonsterJ monster)
    {
        monsters.Add(monster.GetInstanceID(), monster);
    }

    public void RemoveMonster(MonsterJ monster)
    {
        monsters.Remove(monster.GetInstanceID());
    }
}
