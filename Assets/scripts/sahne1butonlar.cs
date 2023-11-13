using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sahne1butonlar : MonoBehaviour
{
    public GameObject panel;
    public Button durdur, oyundon, menu, cıkıs;
    void Start()
    {
        panel = GameObject.Find("durdurmapanel");
        durdur = GameObject.Find("durdurma").GetComponent<Button>();
        oyundon = GameObject.Find("oyunadon").GetComponent<Button>();
        menu = GameObject.Find("menubut").GetComponent<Button>();
        cıkıs = GameObject.Find("cıkıs").GetComponent<Button>();
        durdur.onClick.AddListener(durdurma);
        oyundon.onClick.AddListener(oyunadon);
        menu.onClick.AddListener(menudon);
        cıkıs.onClick.AddListener(cıkıs1);
        panel.SetActive(false);
    }

    public void durdurma()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void oyunadon()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void menudon()
    {
        SceneManager.LoadScene(0);
    }

    public void cıkıs1()
    {
     Application.Quit();   
    }
}
