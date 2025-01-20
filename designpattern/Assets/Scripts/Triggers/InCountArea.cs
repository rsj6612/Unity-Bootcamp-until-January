using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MessageTypeNotifyInCountArea
{
    public InCountArea InCountArea;
    public Collider other;
}

public class InCountArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var notifyInCountArea = new MessageTypeNotifyInCountArea
        {
            InCountArea = this,
            other = other
        };
        EventManagerJ.Instance.PushMessage(notifyInCountArea);
    }
}
