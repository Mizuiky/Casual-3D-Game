using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSetup> _setup;

    [SerializeField]
    private float _timeToDestroy;

    public void PlayParticleByType(ParticleType type, Vector3 position)
    {
        var newParticle = _setup.Find(x => x.type == type).particle;

        if (newParticle != null)
            Play(newParticle, position);       
    }

    private void Play(ParticleSystem newParticle, Vector3 position)
    {
        var particle = Instantiate(newParticle, transform);
        particle.transform.position = position;
       
        SetParticleCollision(particle);

        particle.Play();

        Destroy(particle.gameObject, _timeToDestroy);
    }

    public void SetParticleCollision(ParticleSystem particle)
    {
        if (particle.ToString().Contains("Collectable", System.StringComparison.OrdinalIgnoreCase))
        {
            //Add the Particle Collision with code

            var collision = particle.collision;
            collision.enabled = true;
            collision.type = ParticleSystemCollisionType.Planes;
            collision.mode = ParticleSystemCollisionMode.Collision3D;

            //LevelGround is the ground collider of the level that will collide with the collectables
            collision.SetPlane(0, GameManager.Instance.LevelGround);
        }       
    }
}

public enum ParticleType
{
    MAIN,
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
