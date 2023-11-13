using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class movement : MonoBehaviour
{
    public bool sıra;
    private Button but1;
    public int can = 24;
    public Rigidbody2D rb1;
    public float speed = 5f;
    public bool moveup = true;
    public bool buttondown = false, sırabende , sıra2de ,tıkladı;
    public Animator animator;
    public GameObject silahlar;
    public Slider slider;
    private movement2 movement2;
    public bool sırabekleme, fatality;
    public GameObject a, b, text;
    public yonetici yonetici;
    void Start()
    {
        text = GameObject.Find("text");
        yonetici = GameObject.Find("yonetici").GetComponent<yonetici>();
        a = GameObject.FindWithTag("GameController");
        b = GameObject.FindWithTag("gamecontroller2");
        rb1 = GameObject.FindWithTag("player1").GetComponent<Rigidbody2D>();
        but1 = GameObject.FindWithTag("GameController").GetComponent<Button>();
        animator = GameObject.FindWithTag("player1").GetComponent<Animator>();
        movement2 = GameObject.FindWithTag("player2").GetComponent<movement2>();
        baslama();
        text.SetActive(false);
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

    public void buttonisdown()
    {
        if ( sıra && sırabekleme == false)
        {
            GameObject mermi = Instantiate(silahlar,transform.position + new Vector3(1.5f,0,0),transform.rotation);
            mermi.GetComponent<silahlar>().sorgula = true;
            animator.SetBool("sırabende",false);
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
        if (movement2.can <= 0)
        {
            sıra = true;
        }
        else
        {
            sıra = false;
        }
        movement2.anim.SetBool("sırabende",true);
        sırabekleme = false;
    }
    public void buttonisup()
    {
        buttondown = false;
    }

    public void SwitchDirection()
    {
        moveup = !moveup;
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
        if (col.gameObject.CompareTag("mermi2"))
        {
            
            Destroy(col.gameObject);
            if (fatality)
            {
                kapatma();
                if (PlayerPrefs.GetInt("karakter")== 0)
                {
                    animator.SetTrigger("fatality");   
                }   
                else if (PlayerPrefs.GetInt("karakter")== 1)
                {
                    animator.SetTrigger("ninjatarafından");
                }
                else if (PlayerPrefs.GetInt("karakter")== 2)
                {
                    animator.SetTrigger("spearmantarafından");
                }
                text.SetActive(true);
                yonetici.sesler.PlayOneShot(yonetici.fatality);
            }
            else if (can <= 0)
            {
                fatality = true;
                speed = 0f;
                animator.Play("etkisiz");
                movement2.anim.SetBool("sırabende",true);
                StartCoroutine(bayılma());
            }
        }
    }

    public IEnumerator ekrandegıs()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
    public void candusurme(int damage)
    {
        can -= damage;
    }
    IEnumerator bayılma()
    {
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("bayılma");
        kapatma();
    }
    private void baslama()
    {
        int a = Random.Range(1,3);
        switch (a)
        {
         case 1:
             sıra = true;
             animator.SetBool("sırabende",true);
             break;
         
         case 2:
             sıra = false;
             movement2.anim.SetBool("sırabende",true);
             break;
         
        }
    }

    public void kapatma()
    {
        a.SetActive(false);
        b.SetActive(false);
        speed = 0f;
        movement2.speed = 0f;
        StartCoroutine(ekrandegıs());
    }
    
    
    
    
    
    
}
    
    
         
    


