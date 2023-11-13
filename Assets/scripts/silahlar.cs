using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silahlar : MonoBehaviour

{
    public Rigidbody2D rgb, rgb2shooter;
    public string myname;
    public float speed;
    public int damage;
    public bool sorgula;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        switch (myname)
        {
         case "mermi":
             damage = 8;   
         break;    
         case "shuriken":
             damage = 16;   
             break;   
         case "mızrak":
             damage = 8;   
             break;   
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("player1"))
        {
            col.gameObject.GetComponent<movement>().candusurme(damage);
        }   
        if (col.gameObject.CompareTag("player2"))
        {
            col.gameObject.GetComponent<movement2>().candusurme(damage);
        }

        if (col.gameObject.CompareTag("engel"))
        {
          Destroy(col.gameObject);
            Destroy(gameObject);  
        }

        if (col.gameObject.CompareTag("engel2"))
        {
          Destroy(col.gameObject);
          speed += 7;
        }
    }

    void Update()
    {
        sılahhareket(); 
    }

    public void sılahhareket()
    {
        if (sorgula)
        {
         transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);   
        }
    }
}
