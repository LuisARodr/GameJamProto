using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla las propiedades de las herramientas
/// </summary>
public class ToolControl : MonoBehaviour
{
    /// <summary>
    /// indica el tipo de herramienta:
    /// 0 = llave
    /// 1 = martillo
    /// 2 = casco
    /// </summary>
    [SerializeField]
    [Range(0, 2)]
    public int type = 0;
    
    /// <summary>
    /// rigidbody2D de la herramienta
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// spriteRender de la herramieta
    /// </summary>
    private SpriteRenderer sr;

    /// <summary>
    /// Masa de la herramienta azul
    /// </summary>
    [SerializeField]
    private float blueMass = 1f;
    /// <summary>
    /// Masa de la herramienta amarilla
    /// </summary>
    [SerializeField]
    private float yellowMass = 1.1f;
    /// <summary>
    /// Masa de la herramienta verde
    /// </summary>
    [SerializeField]
    private float greenMass = 0.8f;




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

    /// <summary>
    /// Cambia las propiedades de la herramienta dependiendo del type (Tipo de herramienta)
    /// </summary>
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
