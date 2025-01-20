// using UnityEngine;
// using UnityEngine.UI;
//
// public class ItemButton : MonoBehaviour
// {
//     public Text amountText; // 수량을 표시할 텍스트
//     private ItemInfo itemInfo;
//
//     public ItemInfo ItemInfo
//     {
//         get => itemInfo;
//         set
//         {
//             itemInfo = value;
//             UpdateUI();
//         }
//     }
//
//     private void UpdateUI()
//     {
//         if (itemInfo != null)
//         {
//             GetComponent<Image>().sprite = itemInfo.itemData.icon; // 아이콘 설정
//             amountText.text = itemInfo.amount.ToString(); // 수량 업데이트
//             amountText.gameObject.SetActive(true);
//         }
//         else
//         {
//             GetComponent<Image>().sprite = null; // 아이콘 초기화
//             amountText.text = "";
//             amountText.gameObject.SetActive(false);
//         }
//     }
// }