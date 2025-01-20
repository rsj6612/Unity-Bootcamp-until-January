using TMPro; // TextMesh Pro 네임스페이스 추가
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    private ItemInfo itemInfo;
    public ItemInfo ItemInfo
    {
        get => itemInfo;
        set
        {
            itemInfo = value;
            SetItemImage(itemInfo.itemData.icon);
            UpdateItemAmountText(itemInfo.amount); // 수량 텍스트 업데이트
        }  
    }

    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemAmountText; // 수량을 표시할 TMP 텍스트

    void SetItemImage(Sprite sprite)
    {
        itemImage.sprite = sprite;
        if (sprite == null)
        {
            var color = itemImage.color;
            color.a = 0;
            itemImage.color = color;
        }
        else
        {
            var color = itemImage.color;
            color.a = 1.0f;
            itemImage.color = color;
        }
    }

    // 수량 텍스트 업데이트 함수
    void UpdateItemAmountText(int amount)
    {
        itemAmountText.text = amount.ToString(); // 수량 텍스트 표시
        itemAmountText.gameObject.SetActive(amount > 0); // 수량이 0보다 크면 텍스트 표시
    }
}