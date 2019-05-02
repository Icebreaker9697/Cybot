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
    public GameObject toChase = null;
    public int numSpawned = 0;
    private float angle = 45;
    GameObject laser;
    bool fired = false;
    public AudioClip shootSound;

    float laserWaitTime = 3;
    float elapsedTime;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        fpc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        laser = GameObject.FindObjectOfType<RandomMap>().laser;

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
        if (PlayerIsInSight() && !fired)
        {
            Vector3 spawnOffset = new Vector3(0, 3.7f, 1f);
            Vector3 targetPoint = fpc.transform.position + new Vector3(0, 1.0f, 0);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - (transform.position + spawnOffset), Vector3.up);
            Instantiate(laser, transform.position + spawnOffset, targetRotation);
            fpc.GetComponent<AudioSource>().PlayOneShot(shootSound);
            fired = true;
        }

        if (fired)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= laserWaitTime)
            {
                elapsedTime = 0;
                fired = false;
            }
        }
    }

    private void SetDestination()
    {
        if(destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            agent.SetDestination(targetVector);
        }
    }

    public bool PlayerIsInSight()
    {
        Vector3 playerpos = fpc.transform.position;
        Vector3 mypos = gameObject.transform.position;
        Vector3 dir = (playerpos - mypos);
        RaycastHit hit;
        if (Physics.Raycast(mypos + new Vector3(0, 0.1f, 0), dir, out hit))
        {
            bool isPlayer = false;
            if (hit.collider.gameObject.transform.parent != null)
            {
                isPlayer = hit.collider.gameObject.transform.parent.gameObject.tag == "Player";
            }

            bool isInFov = Vector3.Angle(dir, gameObject.transform.forward) < angle * 0.5f;
            return isPlayer && isInFov;
        }
        return false;
    }
}
