using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[
    RequireComponent(typeof(Blackboard_Monster)),
    RequireComponent(typeof(BuffHandler)),
    RequireComponent(typeof(MonsterStatus))
]
public class MonsterJ : EntityJ
{
    Blackboard_Monster monster;
    protected override StaterType EnityStaterType => StaterType.Monster;

    protected override void Start()
    {
        base.Start();
        monster = GetComponent<Blackboard_Monster>();
    }
    
    private void OnEnable()
    {
        MonsterManagerJ.Instance.AddMonster(this);
    }

    private void OnDisable()
    {
        if(!MonsterManagerJ.Instance.IsUnityNull())
            MonsterManagerJ.Instance.RemoveMonster(this);
    }

    void Update()
    {
    }

    public void OnDetectPlayer(PlayerJ player)
    {
        Debug.Log(player);
        monster.target = player;
    }
}
