using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoToTetris()
    {
        SceneManager.LoadScene("Tetris");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToInfo()
    {
        SceneManager.LoadScene("Info");
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
