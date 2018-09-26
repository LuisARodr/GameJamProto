using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

namespace CoreGame {
    public class MobileInputsWithoutJoystick : MonoBehaviour {
        
        bool touchButton = false;
        Vector2 pointA;
        Vector2 pointB;

        bool A_Button, B_Button, X_Button, Y_Button;
        
        [SerializeField]
        LayerMask layer;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            
            if ((Input.touchCount == 1)) {
                //Si va empezando el touch
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    //hacer un raycast
                    Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                    RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward, .1f, layer);
                    //Si hay un collider, comparar el nombre
                    if (hitInformation.collider != null) {
                        //Si es un boton
                        switch (hitInformation.collider.name) {
                            case "A_Button":
                                Debug.Log("A_Button");
                                A_Button = true;
                                touchButton = true;
                                pointA = pointB;
                                break;
                            case "B_Button":
                                Debug.Log("B_Button");
                                B_Button = true;
                                touchButton = true;
                                pointA = pointB;
                                break;
                            case "X_Button":
                                Debug.Log("X_Button");
                                X_Button = true;
                                touchButton = true;
                                pointA = pointB;
                                break;  
                            case "Y_Button":
                                Debug.Log("Y_Button");
                                Y_Button = true;
                                touchButton = true;
                                pointA = pointB; 
                                break;
                        }
                    }
                }
                else {
                    touchButton = false;
                    A_Button = false;
                    B_Button = false;
                    X_Button = false;
                    Y_Button = false;
                }
            }

        }
        
        public bool AButton {
            get {
                return A_Button;
            }
        }
        public bool BButton {
            get {
                return B_Button;
            }
        }
        public bool XButton {
            get {
                return X_Button;
            }
        }
        public bool YButton {
            get {
                return Y_Button;
            }
        }

    }
}