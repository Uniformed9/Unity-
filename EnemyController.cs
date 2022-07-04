using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState
{
    Idle,Run
}
public class EnemyController : MonoBehaviour
{   
    public EnemyState currentstate=EnemyState.Idle;
    //private Animation ani;
    private Transform player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //ani = GetComponent<Animation>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        switch (currentstate)
        {
            case EnemyState.Idle:
                
                if (distance < 8&&distance>2)
                {
                    currentstate = EnemyState.Run;
                }
                break;
            case EnemyState.Run:
               
                if (distance > 8||distance<2)   
                {
                    currentstate = EnemyState.Idle;
                }
                agent.isStopped = false;
                agent.SetDestination(player.position);  
                break;
            
        }
    }
    void OnCollisionEnter(Collision other)
    {
        int a = -5;
        Controller player = other.gameObject.GetComponent<Controller>();
        if(player != null)
        {
            player.changehealth(a);
        }
    }
        
}
