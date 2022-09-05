using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParticleTrigger : MonoBehaviour
{
    [SerializeField]
    private List<TriggerSetup> _triggerSetup;

    [SerializeField]
    private string _tagToCompare;

    private void OnTriggerEnter(Collider collider)
    {
        OnCollision(collider);
    }

    protected virtual void OnCollision(Collider collider)
    {
        if (collider.CompareTag(_tagToCompare))
        {
            foreach (TriggerSetup setup in _triggerSetup)
            {
                GameManager.Instance.PlayParticle(setup.type, setup.particle);
            }           
        }
    }
}

[System.Serializable]
public class TriggerSetup
{
    public Transform particle;
    public ParticleType type;
}
