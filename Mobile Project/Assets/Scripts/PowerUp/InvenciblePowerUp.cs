using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenciblePowerUp : PowerUpBase
{
    [SerializeField]
    private bool _invencible;

    public override void StartPowerUp()
    {
        _player.MakeInvencible(true);
        base.StartPowerUp();
        _invencible = _player.Invencible;
    }

    public override void EndPowerUp()
    {
        _player.MakeInvencible(false);
        _invencible = _player.Invencible;
    }
}
