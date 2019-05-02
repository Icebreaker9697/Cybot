using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LaserChild : MonoBehaviour {

    bool startedDestroying;
    private FirstPersonController fpc;
    public AudioClip hitSound;

    // Use this for initialization
    void Start () {
        fpc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fpc.GetComponent<AudioSource>().PlayOneShot(hitSound);
            fpc.frozenLeft += 2;
        }
        else if(!startedDestroying)
        {
            startedDestroying = true;
            StartCoroutine(DestroyAfterSeconds());
        }
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
