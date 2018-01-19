using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceFinal : MonoBehaviour {

    public Text textThrown;
    public Text textDestroyed;

	// Use this for initialization
	void Start () {
        textThrown.text = string.Format("Number of Stones: {0}", GameManager.stonesThrown);
        textDestroyed.text = string.Format("Destroyed: {0}", GameManager.stonesDestroyed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void click()
    {
        SceneManager.LoadScene("Awake");
    }
}
