using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private Character _target;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    public bool IsAlive { get; private set; } = true;
    public float HealthMaX { get; private set; }
    public float Health => _health;

    public event Action Died;
    public event Action Hited;
    public event Action Attacked;

    private void OnEnable()
    {
        HealthMaX = _health;
    }

    public void TakeDamage(float damage)
    {
        if (_health < damage)
            Die();

        _health -= damage;

        if (_health <= 0)
            Die();

        _hitEffect.Play();
        Hited?.Invoke();
    }

    private void Attack() //Invoke from animation
    {
        if (IsAlive && _target.IsAlive)
        {
            _target.TakeDamage(_damage);
            Attacked?.Invoke();
        }
    }

    private void Die()
    {
        IsAlive = false;
        Died?.Invoke();
    }
}

