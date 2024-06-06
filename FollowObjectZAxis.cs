using UnityEngine;

public class FollowObjectZAxis : MonoBehaviour
{
    public Transform target; // Objekt, který bude sledován kamerou
    public float smoothSpeed = 0.125f; // Hladkost sledování kamery

    private Vector3 offset; // Vzdálenost mezi kamerou a sledovaným objektem

    void Start()
    {
        // Vypočítejte výchozí offset kamery
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Vypočítejte cílovou pozici kamery
        Vector3 desiredPosition = target.position + offset;

        // Upravte pozici kamery pouze podél osy Z
        desiredPosition.x = transform.position.x;
        desiredPosition.y = transform.position.y;

        // Interpolujte mezi aktuální pozicí kamery a cílovou pozicí, aby byl pohyb hladký
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Nastavte novou pozici kamery
        transform.position = smoothedPosition;
    }
}
