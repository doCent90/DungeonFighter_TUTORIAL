using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private PlayerWallet _playerWallet;

    private void OnEnable()
    {
        _playerWallet.CoinAdded += UpdateScore;
    }

    private void OnDisable()
    {
        _playerWallet.CoinAdded -= UpdateScore;        
    }

    private void UpdateScore()
    {
        _text.text = _playerWallet.Coins.ToString();
    }
}
