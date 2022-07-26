using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            GameManager.Instance.EndGame();
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
