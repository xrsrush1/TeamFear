using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class AnimateAsad : MonoBehaviour
{
    [Header("Animator Elements")]
    public Animator AsadAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        if (AsadAnimator == null)
        {
            Debug.LogError("Asad Animator not set up", this);
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
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Asad will talk now");

            AsadAnimator.Play("Talking"); //starting the animator

            Debug.Log("Asad has started talking");
        }
    }
}
