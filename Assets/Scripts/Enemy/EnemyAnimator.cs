using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Enemy _enemy;
    private readonly float _delay = 4f;

    private const string DieAnimation = "Die";
    private const string AttackAnimation = "Attack";

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        StartCoroutine(Attacking());

        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private IEnumerator Attacking()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            Attack();
            yield return waitForSeconds;
        }
    }

    private void Attack()
    {
        _animator.SetTrigger(AttackAnimation);
    }

    private void OnDied()
    {
        StopCoroutine(Attacking());
        _animator.SetTrigger(DieAnimation);
    }
}
