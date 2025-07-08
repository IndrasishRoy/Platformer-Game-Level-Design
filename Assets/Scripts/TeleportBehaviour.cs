using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _spawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = _spawn.position;
        }
    }
}
