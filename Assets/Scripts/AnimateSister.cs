using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSister : MonoBehaviour
{
    [Header("Animator Elements")]
    public Animator SisterAnimator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has collided with the AI trigger");


        //if other is player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("sis will talk now");

            SisterAnimator.Play("Talking"); //starting the animator

            Debug.Log("sis has started talking");
            //hasTalked = true;
        }
    }
}
