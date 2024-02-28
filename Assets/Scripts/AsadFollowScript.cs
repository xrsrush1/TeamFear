using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

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

    [Header("Animator Elements")]
    public Animator AsadAnimator;

    [Header("NavMesh Elements")]
    public NavMeshAgent myNavMeshAgent;
    //it will store the nav mesh agent component of the current game obj on which this script is

    public InMemoryVariableStorage yarnInMemoryStorage;

    // Start is called before the first frame update
    void Start()
    {
        //myNavMeshAgent = GetComponent<NavMeshAgent>();
        //take ref of nav mesh agent component of the current game obj
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("walkToPump")]
    public void StartWalking()
    {
        Debug.Log("We have entered the start talking func ");
        bool hasAsadTalked;

        yarnInMemoryStorage.TryGetValue("$AsadTalked1", out hasAsadTalked);
        Debug.Log("Has asad talked? ");
        Debug.Log(hasAsadTalked);

        if(hasAsadTalked)
        {
            Debug.Log("We have entered the if func to start anim");

            AsadAnimator.Play("Turn180fromRight");
            Debug.Log("Asad has turned");
            //this will make the npc go to target point
            myNavMeshAgent.SetDestination(target1.transform.position);
        }
        
    }
}
