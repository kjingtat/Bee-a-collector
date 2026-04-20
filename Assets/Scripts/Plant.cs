using UnityEngine;

public class Plant : MonoBehaviour, IInteractable
{

    [SerializeField] private PlantCD indicator;
    [SerializeField] private int PointsGiven;
    [SerializeField] private PointsManager PointsManager;

    public float cooldownDuration = 5.0f;
    private float timer = 0;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            indicator.SetIndicator(false);
        }
    }

    public void Interact()
    {
        if (indicator != null && timer <= 0 && PointsManager.CanCollectNectar())
        {
            indicator.SetIndicator(true);
            timer += cooldownDuration;
            PointsManager.AddNectar(PointsGiven);
        }
    }

}
