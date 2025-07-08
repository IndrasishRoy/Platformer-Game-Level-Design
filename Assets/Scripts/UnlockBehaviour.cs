using System.Collections;
using UnityEngine;

public class UnlockBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            StartCoroutine(UnlockPath());
        }
    }

    IEnumerator UnlockPath()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.isUnlocked = true;
    }
}
