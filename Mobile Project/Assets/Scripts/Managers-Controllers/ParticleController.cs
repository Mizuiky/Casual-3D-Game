using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSetup> _setup;

    public void PlayParticleByType(ParticleType type, Vector3 position)
    {
        var newParticle = _setup.Find(x => x.type == type).particle;

        if (newParticle != null)
            Play(newParticle, position);
    }

    private void Play(ParticleSystem particle, Vector3 position)
    {
        var obj = Instantiate(particle, transform);
        obj.transform.position = position;

        particle.Play();
    }
}

public enum ParticleType
{
    COLLECTABLE1,
    DEATH,
    MONSTERDEATH,
    WINNER
}

[System.Serializable]
public class ParticleSetup
{
    public ParticleSystem particle;
    public ParticleType type;
}
