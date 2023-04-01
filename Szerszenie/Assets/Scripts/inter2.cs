using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inter2 : MonoBehaviour
{

    public GameObject canvas;

    public PlayerControler plctrl;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DisableScript");
    }

    IEnumerator DisableScript()
    {
        canvas.SetActive(true);
        plctrl.Stop();
        plctrl.enabled = false;

        yield return new WaitForSeconds(5f);
        canvas.SetActive(false);
        plctrl.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
