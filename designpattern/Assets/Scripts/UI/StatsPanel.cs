using UnityEngine;

public class StatsPanel : MonoBehaviour, IUIComponent
{
    public int Hp;
    public int Atk;
    
    public void Initialize()
    {
        // ui getcomponent
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void UpdateUI()
    {
    }

    public void ResetState()
    {
    }

    public void Cleanup()
    {
        // ui release
    }
}