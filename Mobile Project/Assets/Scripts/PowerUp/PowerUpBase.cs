using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("PowerUp Fields")]

    [SerializeField]
    protected float _duration;

    [SerializeField]
    protected Color _powerUpColor;

    public override void Collect()
    {
        base.Collect();
        StartPowerUp();     
    }

    public override void HideItem()
    {
        base.HideItem();
    }

    public override void OnCollect() { }

    public virtual void StartPowerUp()
    {
        _player.ChangeColor(_powerUpColor);
        Invoke("EndPowerUp", _duration);
    }

    public virtual void EndPowerUp() 
    {
        _player.ResetColor();
    }
}
