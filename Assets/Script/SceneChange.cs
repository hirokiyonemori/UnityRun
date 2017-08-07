using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour {
    Button myButton ;
    
    // Use this for initialization
    void Start () {
        //myButton = GameObject.Find("Button");
        //myButton.GetComponent<Button>().colors.disabledColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //myButton.interactable = false;
        //myButton.GetComponent<Button>().colors.disabledColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void SceneLoad()
    {
        Application.LoadLevel("1PStage");
    }
}
