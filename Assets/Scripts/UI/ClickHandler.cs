using System;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Button _clikerButton;

    public event Action Clicked;

    private void OnEnable()
    {
        _clikerButton.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _clikerButton.onClick.RemoveListener(OnClicked);        
    }

    private void OnClicked()
    {
        Clicked?.Invoke();
    }
}
