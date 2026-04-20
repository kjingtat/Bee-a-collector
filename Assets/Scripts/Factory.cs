using UnityEngine;

public class Factory : MonoBehaviour , IInteractable
{

    [SerializeField] private PointsManager PointsManager;

    private float pumpAnimSpeed = 2.0f;
    private float scaleStrength = 0.1f;
    private Vector3 initialScale;
    private float timeAddMulti = 1.0f;
    public float pumpSpeed; 
    private float timer = 0f;
    private int CollectedNectar = 0;
    private bool IsRunning = false;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            float scale = 1 + Mathf.Sin(Time.time * pumpAnimSpeed) * scaleStrength;
            transform.localScale = initialScale * scale;
            IsRunning = true;
        }
        else
        {
            if (IsRunning)
            {
                PointsManager.AddHoney(CollectedNectar);
                CollectedNectar = 0;
                IsRunning = false;
            }
            transform.localScale = initialScale;
        }
        
    }

    public void Interact()
    {
        timer += (timeAddMulti * PointsManager.Nectar)/pumpSpeed;
        CollectedNectar = PointsManager.RemoveNectar();
    }
}
