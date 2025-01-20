using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpanwer : MonoBehaviour
{
    public GameObject itemPrefab; // 여러 프리팹 배열
    public ItemData[] itemDataArray; // 각각의 ItemData 배열

    public float minSpawnTime;
    public float maxSpawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnItemCallback();
    }

    IEnumerator SpawnItem()
    {
        float nextRandomTime = Random.Range(minSpawnTime, maxSpawnTime);
        
        yield return new WaitForSeconds(nextRandomTime);
        
        SpawnItemCallback();
    }

    private void SpawnItemCallback()
    {
        int randomIndex = Random.Range(0, itemDataArray.Length); // 랜덤 인덱스 선택
        GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        SpawnedItem spawnedItem = item.GetComponent<SpawnedItem>();
        spawnedItem.SetItemData(itemDataArray[randomIndex]);
        
        // 익명함수 , 델리게이트 하나
        item.GetComponent<SpawnedItem>().OnDestroiedAction += () =>
        {
            Debug.Log("Item call");
            StartCoroutine(SpawnItem());
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}