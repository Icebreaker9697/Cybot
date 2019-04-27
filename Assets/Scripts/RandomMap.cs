using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class RandomMap : MonoBehaviour {

    public GameObject star;
    private FirstPersonController fpc;
    private TextMeshProUGUI winGameTxt;
    private Button newGame;
    private GameObject g;

    private List<GameObject> objects = new List<GameObject>();

    // Use this for initialization
    void Start () {

        winGameTxt = GameObject.FindGameObjectWithTag("WinGameText").GetComponent<TextMeshProUGUI>();
        newGame = GameObject.FindGameObjectWithTag("BnRestart").GetComponent<Button>();
        fpc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        g = GameObject.FindGameObjectWithTag("Goal");

        NewGame();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        winGameTxt.enabled = false;
        newGame.gameObject.SetActive(false);
        Cursor.visible = false;
        Screen.lockCursor = true;

        if (objects.Count > 0)
        {
            for(int i = 0; i < objects.Count; i++)
            {
                Destroy(objects[i]);
            }
            objects = new List<GameObject>();
        }

        int numStars = (int)Random.Range(12, 30);
        for (int i = 0; i < numStars; i++)
        {
            GameObject go = Instantiate(star);
            objects.Add(go);
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(Random.Range(-57.4f, 57.4f), 1.5f, Random.Range(-57.4f, 57.4f));
        }

        Vector3 randStart = new Vector3(Random.Range(-57.4f, 57.4f), 2.63f, Random.Range(-57.4f, 57.4f));
        Vector3 randGoal = new Vector3(Random.Range(-57.4f, 57.4f), 2.63f, Random.Range(-57.4f, 57.4f));

        float dist = Vector3.Distance(randGoal, randStart);
        while (dist < 91)
        {
            randStart = new Vector3(Random.Range(-57.4f, 57.4f), 2.63f, Random.Range(-57.4f, 57.4f));
            randGoal = new Vector3(Random.Range(-57.4f, 57.4f), 2.63f, Random.Range(-57.4f, 57.4f));

            dist = Vector3.Distance(randGoal, randStart);
        }

        g.transform.SetParent(transform);
        g.transform.position = randGoal;
        
        fpc.transform.position = randStart;


        print("Created a new game!");
    }
    
}
