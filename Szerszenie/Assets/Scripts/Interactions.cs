using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{

    bool startGame = true;
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject electricyty;
    public GameObject canvas3;
    public bool isTaken = false;
    [SerializeField] private AudioSource changingLevel;

    public PlayerControllerLobby plctrl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enter" && startGame)
        {
            Debug.Log("Enter");
            StartCoroutine("DisableScript");
            startGame = false;
        }
        else if (other.gameObject.tag == "questMan")
        {
            isTaken = true;
            Debug.Log("Quest od typa");
        }

    }

    IEnumerator DisableScript()
    {
        canvas.SetActive(true);
        plctrl.Stop();
        plctrl.enabled = false;

        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
        plctrl.enabled = true;
    }

    IEnumerator GoodOldDays()
    {
        canvas2.SetActive(true);
        plctrl.Stop();
        plctrl.enabled = false;

        yield return new WaitForSeconds(4f);
        electricyty.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(true);

        yield return new WaitForSeconds(3f);
        changingLevel.Play();
        SceneManager.LoadScene("Tetris");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GameOne" && isTaken)
        {
            StartCoroutine("GoodOldDays");
        }
        //else if (other.gameObject.tag == "GameTwo")
        //{
        //    SceneManager.LoadScene("SecondGame");
        //}
        //else if (other.gameObject.tag == "GameThree")
        //{
        //    SceneManager.LoadScene("ThirdGame");
        //}
        //else if (other.gameObject.tag == "GameFour")
        //{
        //    SceneManager.LoadScene("FourthGame");
        //}
    }
}
