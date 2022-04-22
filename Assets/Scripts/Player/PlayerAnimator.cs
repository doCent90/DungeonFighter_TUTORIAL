using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ClickHandler _clickHandler;

    private Player _player;

    private const string DieAnimation = "Die";
    private const string AttackAnimation = "Attack";

    private void OnEnable()
    {
        _player = GetComponent<Player>();

        _clickHandler.Clicked += OnClicked;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _clickHandler.Clicked -= OnClicked;                
    }

    private void OnClicked()
    {
        _animator.SetTrigger(AttackAnimation);
    }

    private void OnDied()
    {
        _animator.SetTrigger(DieAnimation);
    }
}
