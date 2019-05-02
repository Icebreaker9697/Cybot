using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toggle_Cy1(bool newValue)
    {
        GameOptions.cybots[0] = newValue;
    }

    public void Toggle_Cy2(bool newValue)
    {
        GameOptions.cybots[1] = newValue;
    }

    public void Toggle_Cy3(bool newValue)
    {
        GameOptions.cybots[2] = newValue;
    }

    public void Toggle_Cy4(bool newValue)
    {
        GameOptions.cybots[3] = newValue;
    }

    public void Toggle_Cy5(bool newValue)
    {
        GameOptions.cybots[4] = newValue;
    }

    public void Toggle_Cy6(bool newValue)
    {
        GameOptions.cybots[5] = newValue;
    }

    public void Toggle_Cy7(bool newValue)
    {
        GameOptions.cybots[6] = newValue;
    }

    public void Toggle_Cy8(bool newValue)
    {
        GameOptions.cybots[7] = newValue;
    }

    public void Toggle_Cy9(bool newValue)
    {
        GameOptions.cybots[8] = newValue;
    }

    public void Toggle_Cy10(bool newValue)
    {
        GameOptions.cybots[9] = newValue;
    }

    public void ChangeMin(string val)
    {
        Debug.Log(val);
    }
}
