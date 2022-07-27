using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUpBase
{
    [Header("Speed PowerUp")]

    [SerializeField]
    private float _speedModifier;

    public override void StartPowerUp()
    {
        base.StartPowerUp();
        _player.ChangeSpeed(_speedModifier);
    }

    public override void EndPowerUp()
    {
        base.EndPowerUp();
    }
}
