using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] mainMenuobj;
    public GameObject StartM;
    private TextMeshProUGUI tmpstart;
    private Color pingpongA;
    // Start is called before the first frame update
    void Start()
    {
        StartM.SetActive(true);
        tmpstart = StartM.GetComponent<TextMeshProUGUI>();
        pingpongA = tmpstart.color;
        foreach (GameObject m in mainMenuobj)
        {
            m.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(StartM.activeSelf)
        {
          
            if (Input.anyKeyDown)
            {
                
                ShowMainMenu();
            }
            else
            {
                pingpongA.a = Mathf.PingPong(Time.time, 1.8f);
                tmpstart.color = pingpongA;

            }
        }
        else
        {
            pingpongA.a = 1;
            tmpstart.color = pingpongA;
        }
    }

    void ShowMainMenu()
    {
        foreach (GameObject m in mainMenuobj)
        {
            m.SetActive(true);
        }

        StartM.SetActive(false);
    }
}
