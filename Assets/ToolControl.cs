using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolControl : MonoBehaviour
{

    [SerializeField]
    [Range(0, 2)]
    public int type = 0;
    /*indica el tipo de herramienta:
     0 = llave
     1 = martillo
     2 = casco
     */
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField]
    private float blueMass = 1f;
    [SerializeField]
    private float yellowMass = 2f;
    [SerializeField]
    private float greenMass = 0.5f;




    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        setProperties();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setProperties()
    {
        switch (type)
        {
            case 0:
                rb.mass = blueMass;
                sr.color = new Color(0,0,255);  //blue
                break;
            case 1:
                rb.mass = yellowMass;
                sr.color = new Color(255, 255, 0);//yellow
                break;
            case 2:
                rb.mass = greenMass;
                sr.color = new Color(0, 255, 0); //green
                break;

        }
    }
}
