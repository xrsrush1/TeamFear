using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSiteMan : MonoBehaviour
{
    [Header("Animator Elements")]
    public Animator SiteManAnimator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has collided with the AI trigger");


        //if other is player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("site man will talk now");

            SiteManAnimator.Play("Talking"); //starting the animator

            Debug.Log("site man has started talking");
            //hasTalked = true;
        }
    }
}
