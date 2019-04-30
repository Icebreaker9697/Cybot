using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class NPCScript : MonoBehaviour {

    private Transform destination;
    private FirstPersonController fpc;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        fpc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();

        if (agent == null)
        {
            Debug.LogError("No navMeshAgent attached to " + gameObject.name);
        }
        else
        {
            //SetDestination();
        }
     
        agent.speed = Random.Range(0, 7);
        agent.acceleration = agent.speed * 5;

	}
	
	// Update is called once per frame
	void Update () {
        destination = fpc.transform;
        //SetDestination();
    }

    private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            agent.SetDestination(targetVector);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collided!");
            GameObject.FindObjectOfType<RandomMap>().Capture();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Left collision!");
            GameObject.FindObjectOfType<RandomMap>().Free();
        }
    }*/
}
