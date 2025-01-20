using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMediator
{
    void NotifyHealthChanged(int health);
}

public class UIMediatorJ : MonoBehaviour, IMediator
{
    private MonsterStatus monsterStatus;
    
    // Start is called before the first frame update
    void Start()
    {
        monsterStatus = GetComponent<MonsterStatus>();
        monsterStatus.SetMediator(this);
    }

    public void NotifyHealthChanged(int health)
    {
        Debug.Log($"current health: {health}");       
    }
}
