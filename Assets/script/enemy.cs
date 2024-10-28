using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class enemy : MonoBehaviour
{
    NavMeshAgent pathFinder;
    Transform target;

    void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.Find("player").transform;

        StartCoroutine(UpdatePath());
    }
    void Update()
    {        
    }
    IEnumerator UpdatePath(){
        float refreshRate= 0.25f;

        while(target != null){
            Vector3 targetPosition = new Vector3 ( target.position.x, target.position.y, target.position.z);
            pathFinder.SetDestination(target.position);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
