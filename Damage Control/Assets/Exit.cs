using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button mybutton;

    void Start()
    {
        mybutton.onClick.AddListener(exitGame);
    }

    void exitGame()
    {
        Application.Quit();
    }
}
