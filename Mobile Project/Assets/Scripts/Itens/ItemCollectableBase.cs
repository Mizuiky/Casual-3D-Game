using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [Header("Item Fields")]

    [SerializeField]
    private Collider _itemCollider;

    [SerializeField]
    private GameObject _graphic;

    [SerializeField]
    protected string _tagToCompare;


    private void Start()
    {
        Init();    
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag(_tagToCompare))
        {
            Collect();
        }
    }

    public virtual void Collect()
    {
        _itemCollider.enabled = false;
        _graphic.SetActive(false);

        OnCollect();
    }

    public virtual void OnCollect() { }

    private void Init()
    {
        _itemCollider.enabled = true;
        _graphic.SetActive(true);
    }
}
