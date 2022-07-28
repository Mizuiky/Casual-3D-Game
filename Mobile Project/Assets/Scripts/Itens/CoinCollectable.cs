using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : ItemCollectableBase
{
    [Header("Coin Fields")]

    [SerializeField]
    private float _lerpDuration;

    [SerializeField]
    private float _speedModifier;

    [SerializeField]
    private float _minDistance;

    private bool _colleted;

    public override void Collect()
    {
        _colleted = true;
        OnCollect();
    }

    public override void OnCollect()
    {
        base.OnCollect();
    }

    public override void HideItem()
    {
        _colleted = false;
        base.HideItem();
    }

    private void Update()
    {
        if (_colleted)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, _lerpDuration * Time.deltaTime * _speedModifier);

            if (Vector3.Distance(transform.position, _player.transform.position) < _minDistance)
                base.HideItem();
        }
    }
}
