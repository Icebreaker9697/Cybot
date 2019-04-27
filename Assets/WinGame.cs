using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class WinGame : MonoBehaviour {

    private TextMeshProUGUI winGameTxt;
    private Button newGame;
    private FirstPersonController fpc;

    // Use this for initialization
    void Start () {
        winGameTxt = GameObject.FindGameObjectWithTag("WinGameText").GetComponent<TextMeshProUGUI>();
        newGame = GameObject.FindGameObjectWithTag("BnRestart").GetComponent<Button>();
        fpc = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winGameTxt.enabled = true;
            newGame.gameObject.SetActive(true);
            Cursor.visible = true;
            Screen.lockCursor = false;
        }
    }
}
