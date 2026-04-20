using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public int Nectar = 0;
    public int Honey = 0;
    public TextMeshProUGUI NectarText;
    public TextMeshProUGUI HoneyText;

    public int maxNectar;

    void Start()
    {
        UpdateUI();
    }

    public void AddNectar(int amount)
    {
        Nectar += amount;
        UpdateUI();
    }

    public int RemoveNectar()
    {
        int TempNectar = Nectar;
        Nectar = 0;
        UpdateUI();
        return TempNectar;
    }

    public void AddHoney(int amount)
    {
        Honey += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        NectarText.text = "Nectar: " + Nectar + "/" + maxNectar;
        HoneyText.text = "Honey Collected: " + Honey;
    }

    public void ResetHoney()
    {
        Honey = 0;
        UpdateUI();
    }

    public void ResetNectar()
    {
        Nectar = 0;
        UpdateUI();
    }

    public bool CanCollectNectar()
    {
        return Nectar < maxNectar;
    }
}