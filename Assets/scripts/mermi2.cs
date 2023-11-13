using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi2 : MonoBehaviour
{
    public Rigidbody2D rgb;
    private float speed = 7f;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();  
    }

   
    void Update()
    {
        rgb.velocity = new Vector2(-speed,0f);  
    }
}
