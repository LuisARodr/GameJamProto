using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame;

public class ShouderRotation : MonoCollection<ShouderRotation> {

    private Quaternion rotation;
    public float angle;

    //private Transform shouder;

    float step = 99;

    // Use this for initialization
    void Start () {
        //shouder = gameObject.GetComponent<Transform>();
        angle = 90;
	}
	
	// Update is called once per frame
	void Update () {
        setShouderRotation();
	}

    
    
    /// <summary>
    /// Hace que la rotacion del hombro sea la misma que la rotacion del Stick izquierdo.
    /// </summary>
    private void setShouderRotation()
    {
        if(Controls.LeftJoystick().y != 0 && Controls.LeftJoystick().x != 0)
        {
            angle = Mathf.Atan2(Controls.LeftJoystick().y, Controls.LeftJoystick().x) * Mathf.Rad2Deg;
            //Debug.Log("zValue: " + angle);
            //Debug.Log("X y Y: " + Controls.LeftJoystick().x + " " + Controls.LeftJoystick().y);
            rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);
        }
        
    }
}
