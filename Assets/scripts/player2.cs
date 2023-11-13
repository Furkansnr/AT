using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    private Rigidbody2D oyuncu2;
    private Animator animator2;
    public bool fatal;
    void Start()
    {
        oyuncu2 = GetComponent<Rigidbody2D>();
        animator2 = GetComponent<Animator>();
    }

    
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D  col)
    {
        if (col.gameObject.CompareTag("mermi"))
        {
            animator2.SetBool("fatal",true);  
         Destroy(col.gameObject);
        }
    }
}
