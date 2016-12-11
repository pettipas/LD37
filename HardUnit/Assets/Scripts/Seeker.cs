using UnityEngine;
using System.Collections;

public class Seeker : MonoBehaviour {

    public NavMeshAgent agent;

    public void Update() {
        if(agent != null && Hero.Instance)
            agent.SetDestination(Hero.Instance.transform.position);
    }
}
