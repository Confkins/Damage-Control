using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Button mybutton;

    void Start()
    {
        mybutton.onClick.AddListener(loadGame);
    }

    void loadGame()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
