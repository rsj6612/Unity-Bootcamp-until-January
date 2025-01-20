using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    private int hp;   
    
    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
            mediator.NotifyHealthChanged(hp);
        }
    }
    public int Atk;
    public int Def;
    public float Speed;

    private IMediator mediator;

    public void SetMediator(IMediator mediator)
    {
        this.mediator = mediator;
    }
}
