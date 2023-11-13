using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class karaktersecım : MonoBehaviour
{
    public Sprite[] skin;
    public Image resım, resım2;
    public string isim;
    public byte sıra;
    private Button but1;
    private void Awake()
    {
        but1 = GameObject.Find("oyunabasla").GetComponent<Button>();
        but1.onClick.AddListener(oyunabasla);
          PlayerPrefs.SetInt("karakter1",0);
          PlayerPrefs.SetInt("karakter",0);
          
        if (isim == "1")
        {
            resım = GameObject.FindWithTag("p1karakter").GetComponent<Image>(); 
            resım.sprite = skin[0];
        }
        else
        {
            resım2 = GameObject.FindWithTag("p2karakter").GetComponent<Image>();
            resım2.sprite =  skin[0];
        }

    }

    public void oyunabasla()
    {
        SceneManager.LoadScene(2);
    }
    public void ileri(int deger)
    {
        if (deger == 0)
        {
            if (sıra == 2)
            {
                sıra = 0;
            }
            else
            {
                sıra++;
            }
            switch (sıra)
            {
                case   0:
                    resım.sprite = skin[sıra];
                    PlayerPrefs.SetInt("karakter1",0);
                    break;
                case 1:
                    resım.sprite = skin[sıra];
                    PlayerPrefs.SetInt("karakter1",1);
                    break;
                case 2:
                    resım.sprite = skin[sıra];
                    PlayerPrefs.SetInt("karakter1",2);
                    break;
            }   
        }
        else
        {
            Debug.Log("girildi");
            if (sıra == 2)
            {
                sıra = 0;
            }
            else
            {
                sıra++;
            }
            switch (sıra)
            {
                case   0:
                    resım2.sprite = skin[sıra];
                    PlayerPrefs.SetInt("karakter",0);
                    break;
                case 1:
                    resım2.sprite = skin[sıra];
                    PlayerPrefs.SetInt("karakter",1);
                    break;
                case 2:
                    resım2.sprite = skin[sıra];
                    PlayerPrefs.SetInt("karakter",2);
                    break;
            }   
        }
    }
    
}
