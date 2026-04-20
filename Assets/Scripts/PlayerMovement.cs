using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    public float MaxSpeed;
    public float Acceleration;
    Vector2 CurrentSpeed = Vector2.zero;
    public Rigidbody2D rb;
    Vector2 movement;
    private IInteractable currentInteractable = null;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject beeArt;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.I) && currentInteractable != null) {
            currentInteractable.Interact();
        }
        if (movement.x > 0)
        {
            beeArt.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movement.x < 0)
        {
            beeArt.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            CurrentSpeed = Vector2.MoveTowards(CurrentSpeed, movement * MaxSpeed, Acceleration);
        }
        else {
            CurrentSpeed = Vector2.MoveTowards(CurrentSpeed, movement * MaxSpeed, Acceleration / 2);
        }

        rb.linearVelocity = CurrentSpeed;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentInteractable = other.GetComponent<IInteractable>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentInteractable = null;
    }
}
