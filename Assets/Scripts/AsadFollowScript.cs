using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AsadFollowScript : MonoBehaviour
{
    public bool isAsad;
    public bool goToTarget1;
    public bool goToTarget2;
    public bool goToTarget3;
    public bool goToTarget4;

    [Header("Follow Targets")]
    public GameObject target1; //it will store the target which the character should aim for
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;

    NavMeshAgent myNavMeshAgent;
    //it will store the nav mesh agent component of the current game obj on which this script is

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        //take ref of nav mesh agent component of the current game obj
    }

    // Update is called once per frame
    void Update()
    {
        //this will make the npc go to target point
        myNavMeshAgent.SetDestination(target1.transform.position);
    }

    //public void StartWalking()
    //{
    //    animator.Play("Turn180FromRight");
    //}
}
