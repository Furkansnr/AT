using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class menuyonet : MonoBehaviour
{
    public Button oynabut, magazabut, cıkısbut, magazagerıbut;
    private GameObject magazapanel;
    void Start()
    {
        oynabut = GameObject.FindWithTag("oynabut").GetComponent<Button>();
        magazagerıbut = GameObject.Find("magazadangeri").GetComponent<Button>();
        magazabut = GameObject.FindWithTag("magazabut").GetComponent<Button>();
        cıkısbut = GameObject.FindWithTag("cıkısbut").GetComponent<Button>();
        magazapanel = GameObject.Find("magazapanel");
        magazabut.onClick.AddListener(magazabutton);
        magazagerıbut.onClick.AddListener(magazadangerıdon);
        cıkısbut.onClick.AddListener(oyundancık);
        oynabut.onClick.AddListener(oynabutton);
        magazapanel.SetActive(false);
    }

    public void oynabutton()
    {
        SceneManager.LoadScene(1);
    }

    public void magazabutton()
    {
     magazapanel.SetActive(true);   
    }

    public void magazadangerıdon()
    {
        magazapanel.SetActive(false);
    }

    public void oyundancık()
    {
        Application.Quit();
    }
}
