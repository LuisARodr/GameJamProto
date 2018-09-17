using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Start_Button"))
        {
            GameManager.nextScene();
        }
    }

}
