using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [SerializeField]
    private Collider _itemCollider;

    private void Start()
    {
        Init();    
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            Collect();
        }
    }

    public virtual void Collect()
    {
        _itemCollider.enabled = false;
        gameObject.SetActive(false);

        OnCollect();
    }

    public virtual void OnCollect() { }

    private void Init()
    {
        _itemCollider.enabled = true;
    }
}
