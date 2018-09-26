using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame;

public class Newspaper : MonoBehaviour {

	[SerializeField]
	GameObject newspaper;
    
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    GameObject mobileInputsObject;
    MobileInputsWithoutJoystick mobileInputs;

    private void Awake() {
        mobileInputs = mobileInputsObject.GetComponent<MobileInputsWithoutJoystick>();
    }

    // Update is called once per frame
    void Update () {
		if (mobileInputs.XButton) {
			GameObject news = Instantiate (newspaper, transform.position, transform.rotation);
			news.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 50f);
			news.name = "newspaper";
            audioSource.Play();
		}
	}
}
