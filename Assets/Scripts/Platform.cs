using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool _isVertical = false;
    [SerializeField] private float _platformSpeed = 1.2f;
    [SerializeField] private float _timer = 0.6f;
    [SerializeField] private Transform pointA, pointB;
    [SerializeField] private Vector3 _currentTarget;

    private void Update()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        if (_isVertical)
        {
            StartCoroutine(VerticalPlatform());
        }
        else
        {
            StartCoroutine(HorizontalPlatform());
        }
    }

    #region OnTrigger-Logic
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
    #endregion

    #region Coroutine-Logic
    IEnumerator VerticalPlatform()
    {
        Vector3 pos = transform.position;

        if (pos == pointA.position)
        {
            yield return new WaitForSeconds(_timer);
            _currentTarget = pointB.position;
        }
        else if (pos == pointB.position)
        {

            yield return new WaitForSeconds(_timer);
            _currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(pos ,_currentTarget, _platformSpeed * Time.deltaTime);
    }

    IEnumerator HorizontalPlatform()
    {
        Vector3 pos = transform.position;

        if (pos == pointA.position)
        {
            yield return new WaitForSeconds(_timer);
            _currentTarget = pointB.position;
        }
        else if (pos == pointB.position)
        {

            yield return new WaitForSeconds(_timer);
            _currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(pos, _currentTarget, _platformSpeed * Time.deltaTime);
    }
    #endregion
}
