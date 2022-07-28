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

    private AnimationSetup _currenAnimation;

    public void Play(AnimationType type)
    {
        _currenAnimation = _animationSetup.Where(x => x.type == type).FirstOrDefault();

        if (_currenAnimation != null)
            _animator.SetTrigger(_currenAnimation.trigger);          
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
}
