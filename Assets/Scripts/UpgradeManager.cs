using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeData[] allUpgrades;

    [SerializeField] private PointsManager pointsManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Factory factory;

    [SerializeField] private Canvas upgradeCanvas;
    [SerializeField] private Canvas notificationCanvas;

    [SerializeField] private TextMeshProUGUI revealedUpgradeName;
    [SerializeField] private TextMeshProUGUI revealedUpgradeDescription;
    [SerializeField] private TextMeshProUGUI notificationText;

    [SerializeField] private Button revealedUpgradeButton;
    [SerializeField] private Button mysteryUpgradeButton;
    [SerializeField] private Button okButton;

    private UpgradeData currentRevealedUpgrade;

    private int originalMaxNectar;
    private float originalMaxSpeed;
    private float originalAcceleration;
    private float originalPumpSpeed;
    private float originalPlantCooldown;

    void Start()
    {
        originalMaxNectar = pointsManager.maxNectar;
        originalMaxSpeed = playerMovement.MaxSpeed;
        originalAcceleration = playerMovement.Acceleration;
        originalPumpSpeed = factory.pumpSpeed;
        originalPlantCooldown = gameManager.GetOriginalPlantCooldown();

        revealedUpgradeButton.onClick.AddListener(PickRevealedUpgrade);
        mysteryUpgradeButton.onClick.AddListener(PickMysteryUpgrade);
        okButton.onClick.AddListener(CloseNotification);
    }

    public void ResetUpgrades()
    {
        pointsManager.maxNectar = originalMaxNectar;
        playerMovement.MaxSpeed = originalMaxSpeed;
        playerMovement.Acceleration = originalAcceleration;
        factory.pumpSpeed = originalPumpSpeed;
        foreach (Plant plant in gameManager.allPlants)
        {
            plant.cooldownDuration = originalPlantCooldown;
        }
    }

    public void ShowUpgradeScreen()
    {
        upgradeCanvas.gameObject.SetActive(true);
        currentRevealedUpgrade = allUpgrades[Random.Range(0, allUpgrades.Length)];
        revealedUpgradeName.text = currentRevealedUpgrade.upgradeName;
        revealedUpgradeDescription.text = currentRevealedUpgrade.upgradeDescription;
    }

    void PickRevealedUpgrade()
    {
        ApplyUpgrade(currentRevealedUpgrade);
    }

    void PickMysteryUpgrade()
    {
        UpgradeData mystery = allUpgrades[Random.Range(0, allUpgrades.Length)];
        ApplyUpgrade(mystery);
    }

    void ApplyUpgrade(UpgradeData upgrade)
    {
        switch (upgrade.upgradeType)
        {
            case UpgradeType.MaxNectar:
                pointsManager.maxNectar += 1;
                break;
            case UpgradeType.MaxSpeed:
                playerMovement.MaxSpeed += 1;
                break;
            case UpgradeType.Acceleration:
                playerMovement.Acceleration += 0.5f;
                break;
            case UpgradeType.FactorySpeed:
                factory.pumpSpeed += 0.5f;
                break;
            case UpgradeType.MoreTime:
                gameManager.AddTime(10f);
                break;
            case UpgradeType.PlantCooldown:
                gameManager.ReducePlantCooldown(0.5f);
                break;
        }

        upgradeCanvas.gameObject.SetActive(false);
        notificationText.text = "You got: " + upgrade.upgradeName + "!\n" + upgrade.upgradeDescription;
        notificationCanvas.gameObject.SetActive(true);
    }

    void CloseNotification()
    {
        notificationCanvas.gameObject.SetActive(false);
        gameManager.StartRound();
    }
}