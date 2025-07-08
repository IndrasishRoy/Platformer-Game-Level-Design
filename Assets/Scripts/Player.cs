using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        Initialize();  
    }

    private void Initialize()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        GameManager.Instance.GetPlayer(this);
    }

    #region Player-Logic
    public void UpdatePlayerMovements()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(horizontalMove, 0);

        transform.Translate(movement * _speed * Time.deltaTime);
    }
    #endregion

    #region OnTrigger-Logic
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            StartCoroutine(StarCollected(other));
        }

        if (other.CompareTag("DeathCollider"))
        {
            GameManager.Instance.isDead = true;
        }
    }

    IEnumerator StarCollected(Collider2D other)
    {
        other.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        GameManager.Instance.isWin = true;
    }
    #endregion
}
