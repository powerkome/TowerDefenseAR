using UnityEngine;
using System.Collections;

public class Bin_Drone : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject target;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Tower");
	}
	
	void Update ()
    {
        agent.destination = target.transform.position;
	}
}
