using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour
{
    public string savedGame;

    public GameObject load;
    public GameObject loadOff;

    public void Update()
    {
        savedGame = PlayerPrefs.GetString("saved");

        if(PlayerPrefs.HasKey(savedGame + "X") && PlayerPrefs.HasKey(savedGame + "Y"))
        {
            load.SetActive(true);
            loadOff.SetActive(false);
        }
        else
        {
            load.SetActive(false);
            loadOff.SetActive(true);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(savedGame);
    }
}
