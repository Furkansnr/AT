using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

public class spawner : MonoBehaviour
{
    public GameObject[] objeler;
    public GameObject[] konum;
    public float xsınır, ysınır;
    public Transform engeller;
    void Start()
    {
        xsınır = Random.Range(konum[0].transform.position.x, konum[1].transform.position.x);
        ysınır = Random.Range(konum[2].transform.position.y, konum[3].transform.position.y);
        engeller.position = new Vector3(xsınır, ysınır);
        StartCoroutine(clone());
    }

    IEnumerator clone()
    {
        yield return new WaitForSeconds(5f);
        GameObject a = Instantiate(objeler[Random.Range(0,objeler.Length)], engeller);
        a.transform.position = new Vector3(xsınır, ysınır);
        bekleme();
        StartCoroutine(clone());
    }

    void bekleme()
    {
        xsınır = Random.Range(konum[0].transform.position.x, konum[1].transform.position.x);
        ysınır = Random.Range(konum[2].transform.position.y, konum[3].transform.position.y);
        //engeller.position = Vector3.zero;
        //engeller.position = new Vector3(xsınır, ysınır);
    }
}
