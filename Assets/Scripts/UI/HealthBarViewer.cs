using UnityEngine;
using UnityEngine.UI;

public class HealthBarViewer : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Image _bar;

    private void OnEnable()
    {
        _character.Hited += OnHealthChanged;
    }

    private void OnDisable()
    {
        _character.Hited -= OnHealthChanged;        
    }

    private void OnHealthChanged()
    {
        _bar.fillAmount = Mathf.InverseLerp(0, _character.HealthMaX, _character.Health);
    }
}
