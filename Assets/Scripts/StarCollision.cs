using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class StarCollision : MonoBehaviour {

    public AudioClip coinSound;
    private FirstPersonController fpc;
    private int powerupLength;

	// Use this for initialization
	void Start () {
        fpc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        powerupLength = (int)Random.Range(5, 25);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {   
            fpc.sprintLeft += powerupLength;
            fpc.GetComponent<AudioSource>().PlayOneShot(coinSound);
            Destroy(GetComponentInChildren<MeshFilter>());
            Destroy(GetComponentInChildren<MeshRenderer>());
            Destroy(GetComponentInChildren<AnimationScript>());
            Destroy(GetComponent<Collider>());
        } 
    }
}
