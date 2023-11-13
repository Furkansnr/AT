using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement2 : MonoBehaviour
{
    public Button but1;
    public int can = 24;
    public Rigidbody2D rgb2;
    public float speed = 5f;
    public bool moveup = true;
    public bool buttondown = false, sırabende = true , sıra1de = false ,tıkladı;
    public Animator anim;
    public GameObject silahlar, text;
    private movement movement;
    private bool sırabekleme, fatality = false;
    void Awake()
    {
        text = GameObject.Find("text");
        rgb2 = GameObject.FindWithTag("player2").GetComponent<Rigidbody2D>();
        but1 = GameObject.FindWithTag("gamecontroller2").GetComponent<Button>();
        anim = GameObject.FindWithTag("player2").GetComponent<Animator>();
        movement = GameObject.FindWithTag("player1").GetComponent<movement>();
    }


    void Update()
    {
        if (buttondown && moveup)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else if (buttondown)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        
    }
    public void candusurme(int damage)
    {
        can -= damage;
    }
    public void buttonisdown()
    {
        if (!movement.sıra && sırabekleme == false)
        {
           
            GameObject mermi = Instantiate(silahlar,transform.position + new Vector3(-1.5f,0,0),transform.rotation);
            mermi.GetComponent<silahlar>().sorgula = false;
            anim.SetBool("sırabende",false);
            sırabekleme = true;
            StartCoroutine(bekleme());
        }
        else
        {
            moveup = !moveup;
        }
    }

    IEnumerator bekleme()
    {
        yield return new WaitForSeconds(2f);
        movement.animator.SetBool("sırabende",true);
        sırabekleme = false;
        if (movement.can <= 0)
        {
            movement.sıra = false;
        }
        else
        {
            movement.sıra = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ustduvar"))
        {
            moveup = false;
        }

        if (col.gameObject.CompareTag("altduvar"))
        {
            moveup = true;
        }   
        if (col.gameObject.CompareTag("mermi"))
        {
            
            Destroy(col.gameObject);
            if (fatality)
            {
                movement.kapatma();
              if (PlayerPrefs.GetInt("karakter1") == 0)
              {
                  anim.SetBool("fatality",true);    
              }
              else if (PlayerPrefs.GetInt("karakter1") == 1)
              {
                  anim.SetTrigger("ninjatarafından");   
              }
              else if (PlayerPrefs.GetInt("karakter1")== 2)
              {
                anim.SetTrigger("spearmantarafından");  
              }
              text.SetActive(true);
              movement.yonetici.sesler.PlayOneShot(movement.yonetici.fatality);
            }
            
            else if (can <= 0)
            {
                fatality = true;
                anim.Play("etkisiz2");
                speed = 0f;
                movement.animator.SetBool("sırabende",true);
                movement.sırabekleme = false;
                StartCoroutine(bayıldım());
            }
        }
        
    }

    IEnumerator bayıldım()
    {
        yield return new WaitForSeconds(5f);
        anim.SetBool("fatal",true);
        movement.kapatma();
    }
}

