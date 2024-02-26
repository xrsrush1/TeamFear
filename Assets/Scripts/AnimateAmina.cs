using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAmina : MonoBehaviour
{
    [Header("Animator Elements")]
    public Animator AminaAnimator;

    private bool hasTalked=false;

    // Start is called before the first frame update
    void Start()
    {
        //AminaAnimator = GameObject.FindGameObjectWithTag("Amina").GetComponent<Animator>();
        //get reference of amina's animator

        if (AminaAnimator == null )
        {
            Debug.LogError("Amina Animator not set up", this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has collided with the AI trigger");


        //if other is player
        if (other.gameObject.CompareTag("Player") && hasTalked == false)
        {
            Debug.Log("Amina will talk now");

            AminaAnimator.Play("Talking"); //starting the animator

            Debug.Log("Amina has started talking");
            hasTalked = true;
        }
    }
}
