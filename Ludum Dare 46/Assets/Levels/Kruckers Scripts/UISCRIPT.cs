using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISCRIPT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
