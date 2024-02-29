using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireManAnimate : MonoBehaviour
{
    [Header("Animator Elements")]
    public Animator FireManAnimator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has collided with the AI trigger");


        //if other is player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Fire man will talk now");

            FireManAnimator.Play("Talking"); //starting the animator

            Debug.Log("fire man has started talking");
            //hasTalked = true;
        }
    }
}
