using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Datas/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public Vector3 itemSize = Vector3.one;
}