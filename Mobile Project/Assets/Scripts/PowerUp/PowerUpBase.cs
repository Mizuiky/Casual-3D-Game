using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("PowerUp Fields")]

    [SerializeField]
    private float _duration;

    protected PlayerController _player;

    protected override void OnTriggerEnter(Collider collider)
    {    
        if (collider.CompareTag(_tagToCompare))
        {
            _player = collider.GetComponent<PlayerController>();

            if (_player != null)
                Collect();
        }
    }

    public override void Collect()
    {
        base.Collect();
        StartPowerUp();     
    }

    public override void OnCollect()
    {
        
    }

    public virtual void StartPowerUp()
    {
        Invoke("EndPowerUp", _duration);
    }

    public virtual void EndPowerUp() { }
}
