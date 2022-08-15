using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private PlayerController _player;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            if(!_player.Invencible)
                GameManager.Instance.StopGame();
        }  
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("EndLine"))
        {
            GameManager.Instance.CallVictory();
        }
    }
}
