using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private Transform _targetPosition;

    private readonly float _duration = 1f;

    public void Init(Transform targetPosition)
    {
        _targetPosition = targetPosition;
        Move();
    }

    private void Move()
    {
        var tween = transform.DOMove(_targetPosition.position, _duration);
        tween.OnComplete(Destroy);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
