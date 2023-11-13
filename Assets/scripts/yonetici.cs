using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class yonetici : MonoBehaviour
{
    public Slider slider1, slider2;
    public movement player1;
    public movement2 player2;
    private Button but1, but2;
    private int characterindex;
    public GameObject[] prefabs;
    public GameObject p1, p2;
    public AudioSource sesler;
    public AudioClip fatality;

    private void Awake()
    {
        sesler = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        switch (PlayerPrefs.GetInt("karakter1"))
        {
            case  0:
                Instantiate(prefabs[0], p1.transform);
                break;
            case 1:
                Instantiate(prefabs[1], p1.transform);
                break;
            case  2:
                Instantiate(prefabs[2], p1.transform);
                break;
        }
        switch (PlayerPrefs.GetInt("karakter"))
        {
            case  0:
                Instantiate(prefabs[3], p2.transform);
                break;
            case 1:
                Instantiate(prefabs[4], p2.transform);
                break;
            case  2:
                Instantiate(prefabs[5], p2.transform);
                break;
        }
    }

    void Start()
    {
        but1 = GameObject.FindWithTag("GameController").GetComponent<Button>();
       but2 = GameObject.FindWithTag("gamecontroller2").GetComponent<Button>();
       player1 = GameObject.FindWithTag("player1").GetComponent<movement>();
        player2 = GameObject.FindWithTag("player2").GetComponent<movement2>();
        slider1 = GameObject.FindWithTag("slider1").GetComponent<Slider>();
        slider2 = GameObject.FindWithTag("slider2").GetComponent<Slider>();
        slider1.maxValue = player1.can;
        slider2.maxValue = player2.can;
        but1.onClick.AddListener(player1.buttonisdown);
        but2.onClick.AddListener(player2.buttonisdown);
        
    }

   
    
    void Update()
    {
        slider1.value = player1.can;
        slider2.value = player2.can;
    }
}
