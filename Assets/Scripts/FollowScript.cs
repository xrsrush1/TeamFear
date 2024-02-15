using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //to use the AI methods

public class FollowScript : MonoBehaviour
{

    public bool isAnusha;
    public bool goToplayer;

    public GameObject target; //it will store the target which the character should aim for
    NavMeshAgent myNavMeshAgent; //it will store the nav mesh agent component of the current game obj on which this script is
    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>(); //take ref of nav mesh agent component of the current game obj
    }

    // Update is called once per frame
    void Update()
    {
        //so that female npc, will come to the player only after the other 2 are done talking.
        if(isAnusha == true)
        {
            if (goToplayer == true)
                myNavMeshAgent.SetDestination(target.transform.position);
            else
                Debug.Log("Dont go to the player");
        }
        else
        {
            //this is for other characters
            myNavMeshAgent.SetDestination(target.transform.position);

        }
        //SetDestination is a method in AI module, which sets the final point where character has to go
        //it will take the shortest path possible.
    }
}
