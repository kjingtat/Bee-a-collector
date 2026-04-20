using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    void LateUpdate()
    {
        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, 0, transform.position.z);
    }
}