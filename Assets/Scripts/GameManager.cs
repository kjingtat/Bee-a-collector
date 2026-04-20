using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PointsManager pointsManager;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float roundDuration = 60f;
    [SerializeField] private int startingHoneyGoal = 5;
    [SerializeField] private int honeyGoalIncrement = 5;

    [SerializeField] private Canvas endCanvas;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private Button nextRoundButton;
    [SerializeField] private Button restartButton;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI honeyGoalText;

    public Plant[] allPlants;
    [SerializeField] private UpgradeManager upgradeManager;

    private float timer;
    private int currentHoneyGoal;
    private int currentRound = 1;
    private bool roundActive = false;

    void Start()
    {
        nextRoundButton.onClick.AddListener(NextRound);
        restartButton.onClick.AddListener(RestartGame);
        currentHoneyGoal = startingHoneyGoal;
        StartRound();
    }

    void Update()
    {
        if (!roundActive) return;

        timer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timer);

        if (pointsManager.Honey >= currentHoneyGoal)
        {
            EndRound(true);
        }
        else if (timer <= 0)
        {
            EndRound(false);
        }
    }

    public void StartRound()
    {
        timer = roundDuration;
        roundActive = true;
        endCanvas.gameObject.SetActive(false);
        honeyGoalText.text = "Honey Goal: " + currentHoneyGoal;
        pointsManager.ResetHoney();
        pointsManager.ResetNectar();
        playerMovement.transform.position = Vector2.zero;
    }

    void EndRound(bool won)
    {
        roundActive = false;
        endCanvas.gameObject.SetActive(true);

        if (won)
        {
            endText.text = "You made enough honey!";
            nextRoundButton.gameObject.SetActive(true);
        }
        else
        {
            endText.text = "You failed to make enough honey!";
            nextRoundButton.gameObject.SetActive(false);
        }
    }

    public void NextRound()
    {
        currentRound++;
        currentHoneyGoal += honeyGoalIncrement;
        if (currentRound > 1)
        {
            upgradeManager.ShowUpgradeScreen();
        }
        else
        {
            StartRound();
        }
    }

    public void RestartGame()
    {
        currentRound = 1;
        currentHoneyGoal = startingHoneyGoal;
        roundDuration = 60f;
        upgradeManager.ResetUpgrades();
        StartRound();
    }

    public void AddTime(float amount)
    {
        roundDuration += amount;
    }

    public void ReducePlantCooldown(float amount)
    {
        foreach (Plant plant in allPlants)
        {
            plant.cooldownDuration -= amount;
        }
    }

    public float GetOriginalPlantCooldown()
    {
        return allPlants[0].cooldownDuration;
    }
}