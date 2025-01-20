using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIPanel
{
    void Show();
    void Hide();
    void Update(float deltaTime);
}

public class InventoryFacadePattern
{
    public void SortInventory()
    {

    }

    public void Show()
    {

    }

    public void Add()
    {

    }
}

public class StatusFacadePattern
{
    public int GetShareHp()
    {
        return 1;
    }
}

public class ShopFacadePattern
{
    public void Buy()
    {
        
    }
}

public class UIFacade : MonoBehaviour
{
    IUIPanel uiCurrentPanel;
    
    InventoryFacadePattern inventory;
    ShopFacadePattern shop;
    StatusFacadePattern status;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = new InventoryFacadePattern();
        shop = new ShopFacadePattern();
        status = new StatusFacadePattern();
    }

    public void Show()
    {
        shop.Buy();
        inventory.Add();
        status.GetShareHp();
        inventory.Show();  
    }
}
