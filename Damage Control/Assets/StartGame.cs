using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button mybutton;
    // Start is called before the first frame update
    void Start()
    {
        mybutton.onClick.AddListener(loadGame);
    }

    void loadGame()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
}
