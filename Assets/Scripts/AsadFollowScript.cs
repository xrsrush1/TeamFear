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

    private GameObject _currentTarget;
    public bool isWalking;

    [Header("Animator Elements")]
    public Animator AsadAnimator;

    [Header("NavMesh Elements")]
    public NavMeshAgent myNavMeshAgent;
    //it will store the nav mesh agent component of the current game obj on which this script is

    public InMemoryVariableStorage yarnInMemoryStorage;

    //public NPC3D npc3dScript;

    public GameObject QuestionBtn;

    // Start is called before the first frame update
    void Start()
    {
        //myNavMeshAgent = GetComponent<NavMeshAgent>();
        //take ref of nav mesh agent component of the current game obj

        QuestionBtn = GameObject.FindGameObjectWithTag("QuestBtn");

        if (QuestionBtn == null)
            Debug.LogError("Question button not found");

        QuestionBtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (myNavMeshAgent.remainingDistance == 0 && isWalking)
       {
            AsadAnimator.Play("Idle");
            Debug.Log("asad reached the destination");
            isWalking = false;
       }
    }

    [YarnCommand("walkToPump")]
    public void StartWalking()
    {
        Debug.Log("We have entered the start walking func ");
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

            _currentTarget = target1; //target set as water pump
        }
        
    }

    [YarnCommand("walkToHouse1")]
    public void StartWalkingToHouse()
    {
        Debug.Log("We have entered the go to house func ");
        bool waterPumpFinished;

        yarnInMemoryStorage.TryGetValue("$WaterPumpDone", out waterPumpFinished);
        Debug.Log("Has water pump finished? ");
        Debug.Log(waterPumpFinished);

        if (waterPumpFinished)
        {
            Debug.Log("We have entered the if func to start anim");

            AsadAnimator.Play("Turn180fromRight");
            Debug.Log("Asad has turned");

            _currentTarget = target4; //target set as house

        }
    }

    [YarnCommand("walkToSite")]
    public void StartWalkingToSite()
    {
        Debug.Log("We have entered the go to site func ");
        bool metFatherFinished;

        yarnInMemoryStorage.TryGetValue("$metFather", out metFatherFinished);
        Debug.Log("meeting father finished? ");
        Debug.Log(metFatherFinished);

        if (metFatherFinished)
        {
            Debug.Log("We have entered the if func to start anim");

            AsadAnimator.Play("Turn180fromRight");
            Debug.Log("Asad has turned & started walking");
  
            _currentTarget = target2; //target set as site
            //npc3dScript.talkToNode = "AsadatSite";

        }
    }

    [YarnCommand("walkToStore")]
    public void StartWalkingToStore()
    {
        Debug.Log("We have entered the go to store func ");
        bool siteWorkFinished;

        yarnInMemoryStorage.TryGetValue("$finishedSiteWork", out siteWorkFinished);
        Debug.Log("site work finished? ");
        Debug.Log(siteWorkFinished);

        if (siteWorkFinished)
        {
            Debug.Log("We have entered the if func to start anim");

            AsadAnimator.Play("Turn180fromRight");
            Debug.Log("Asad has turned & started walking");

            _currentTarget = target3; //target set as store
        }
    }

    //[YarnCommand("walkBackHome")]
    //public void StartWalkingBackHome()
    //{
    //    Debug.Log("We have entered the go back to home func ");
    //    bool storeWorkFinished;

    //    yarnInMemoryStorage.TryGetValue("$finishedStoreWork", out storeWorkFinished);
    //    Debug.Log("store work finished? ");
    //    Debug.Log(storeWorkFinished);

    //    if (storeWorkFinished)
    //    {
    //        Debug.Log("We have entered the if func to start anim");

    //        AsadAnimator.Play("Turn180fromRight");
    //        Debug.Log("Asad has turned & started walking");

    //        _currentTarget = target4; //target set as home
    //        QuestionBtn.gameObject.SetActive(true); //activating the button
    //    }
    //}
    
    public void StartNavAgent()
    {
         myNavMeshAgent.SetDestination(_currentTarget.transform.position);
         isWalking = true;
    }
}
