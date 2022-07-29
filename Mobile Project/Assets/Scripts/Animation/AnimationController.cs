using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Animations")]

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private List<AnimationSetup> _animationSetup;

    public void Play(AnimationType type)
    {
        var anim = FindAnimationByType(type);

        if (anim != null)
        {
            _animator.SetTrigger(anim.trigger);
            SetAnimationSpeed(anim.speed);
        }
    }

    private AnimationSetup FindAnimationByType(AnimationType type)
    {
        return _animationSetup.Where(x => x.type == type).FirstOrDefault();     
    }

    public void SetAnimationSpeed(float speed)
    {
        _animator.speed = speed;
    }
}


public enum AnimationType
{
    IDLE,
    RUN,
    DEAD
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationType type;
    public string trigger;
    public float speed;
}
