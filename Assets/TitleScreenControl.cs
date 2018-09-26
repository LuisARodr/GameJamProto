using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenControl : MonoBehaviour {

    [SerializeField]
    GameObject titleScreen;
    bool firstStart;

	// Use this for initialization
	void Start () {
        firstStart = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Start_Button") || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (!firstStart) {
                firstStart = true;
                titleScreen.SetActive(false);
            }
            else {
                GameManager.nextScene();
            }
        }
    }

}
