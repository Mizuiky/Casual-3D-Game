using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPowerUp : PowerUpBase
{
    [Header("Fly PowerUp Fields")]

    [SerializeField]
    private float _flyHeight;

    public override void StartPowerUp()
    {
        _player.MakeFly(_flyHeight, _duration);
        base.StartPowerUp();
    }

    public override void EndPowerUp()
    {
        base.EndPowerUp();
    }
}
