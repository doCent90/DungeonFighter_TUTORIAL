using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerWallet : MonoBehaviour
{
    private Player _player;

    public int Coins { get; private set; }

    public event Action CoinAdded;

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _player.Attacked += AddCoin;
    }

    private void OnDisable()
    {
        _player.Attacked -= AddCoin;        
    }

    private void AddCoin()
    {
        Coins++;
        CoinAdded?.Invoke();
    }
}
