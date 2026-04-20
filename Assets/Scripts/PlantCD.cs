using UnityEngine;

public class PlantCD : MonoBehaviour
{

    [SerializeField] private SpriteRenderer thisSprite;

    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
    }

    public void SetIndicator(bool changed)
    {
        if (changed == true) { 
            thisSprite.color = new Color(1, 0, 0);
        }
        else
        {
            thisSprite.color = new Color(0, 1, 0);
        }
    }
}
