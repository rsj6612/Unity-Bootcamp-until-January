using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedItem : MonoBehaviour
{
    public Action OnDestroiedAction;
    public ItemData itemData;

    public void SetItemData(ItemData itemData)
    {
        GetComponent<SpriteRenderer>().sprite = itemData.icon;
        this.itemData = itemData;
        // 아이템 크기 설정
        transform.localScale = itemData.itemSize; // 아이템 크기 적용
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        OnDestroiedAction?.Invoke();
    }
}