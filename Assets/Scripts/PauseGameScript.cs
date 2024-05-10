using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;

    void Start()
    {

    }

    // Update is called once per frame
    public void Pause()
    {
        PausePanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);

        Time.timeScale = 1;
    }
}
