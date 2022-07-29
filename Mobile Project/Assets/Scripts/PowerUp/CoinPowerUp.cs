using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerUp : PowerUpBase
{
    [Header("Coin PowerUp Fields")]

    [Header("Coin Collider")]
    [SerializeField]
    private int _amountToIncrease;

    public override void StartPowerUp()
    {
        Debug.Log("coin power up");
        _player.ChangeCoinColliderSize(_amountToIncrease);
        base.StartPowerUp();     
    }

    public override void EndPowerUp()
    {
        base.EndPowerUp();
        _player.ChangeCoinColliderSize(1);   
    }
}
