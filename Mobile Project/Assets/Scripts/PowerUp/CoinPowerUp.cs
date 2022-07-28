using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerUp : PowerUpBase
{
    [Header("Coin PowerUp Fields")]

    [SerializeField]
    private int _amount;

    public override void StartPowerUp()
    {
        _player.ChangeCoinColliderSize(_amount);
        base.StartPowerUp();     
    }

    public override void EndPowerUp()
    {
        base.EndPowerUp();
        _player.ChangeCoinColliderSize(1);   
    }
}
