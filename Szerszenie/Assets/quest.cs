using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest : MonoBehaviour
{
    public GameObject canvas;
    public GameObject wykrzyknik;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("DisableScript");
        }
        

    }


    IEnumerator DisableScript()
    {
        canvas.SetActive(true);
        wykrzyknik.SetActive(false);

        yield return new WaitForSeconds(5f);
        canvas.SetActive(false);
        wykrzyknik.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
