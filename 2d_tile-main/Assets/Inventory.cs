using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemInfo
{
    public ItemData itemData;
    public int amount = 0;
}
public class Inventory : MonoBehaviour
{
    [SerializeField] GridLayoutGroup gridLayoutGroup;
    private ItemButton[] buttons;

    private int selectedItemIndex1 = -1;
    private int selectedItemIndex2 = -1;

    // Start is called before the first frame update
    void Awake()
    {
        buttons = gridLayoutGroup.GetComponentsInChildren<ItemButton>();

        for (var i = 0; i < buttons.Length; i++)
        {
            var i1 = i;
            buttons[i].GetComponent<Button>().onClick.AddListener(() => 
                OnClickItemButton(i1)
            );
        }
    }

    public void AddItem(GettedObject item)
    {
        bool itemAdded = false;

        // 기존 슬롯에서 중복된 아이템이 있는지 확인
        for (var i = 0; i < buttons.Length; i++)
        {
            // 비어있는 슬롯이 아닌 경우, 중복 아이템 확인
            if (buttons[i].ItemInfo != null && buttons[i].ItemInfo.itemData == item.ItemData)
            {
                // 이미 해당 아이템이 존재하면 수량만 증가
                buttons[i].ItemInfo.amount++;
                buttons[i].ItemInfo = buttons[i].ItemInfo;  // 텍스트 업데이트
                itemAdded = true;
                break;  // 아이템을 찾았으므로 루프 종료
            }
        }

        // 빈 슬롯이거나 중복된 아이템이 없으면 새 아이템 추가
        if (!itemAdded)
        {
            for (var i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].ItemInfo == null)
                {
                    buttons[i].ItemInfo = new ItemInfo() { itemData = item.ItemData, amount = 1 };
                    break;
                }
            }
        }
    }

    void OnClickItemButton(int index)
    {
        if (0 > selectedItemIndex1)
        {
            selectedItemIndex1 = index;
        }
        else if (0 > selectedItemIndex2)
        {
            selectedItemIndex2 = index;

            var itemInfo1 = buttons[selectedItemIndex1].ItemInfo;
            var itemInfo2 = buttons[selectedItemIndex2].ItemInfo;
            buttons[selectedItemIndex1].ItemInfo = itemInfo2;
            buttons[selectedItemIndex2].ItemInfo = itemInfo1;
            selectedItemIndex1 = -1;
            selectedItemIndex2 = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
