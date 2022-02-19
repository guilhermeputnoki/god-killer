using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveGame : MonoBehaviour
{
    public string savedScene;

    void Start()
    {
        if(PlayerPrefs.HasKey(savedScene + "X") && PlayerPrefs.HasKey(savedScene + "Y"))
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat(savedScene + "X"), PlayerPrefs.GetFloat(savedScene + "Y"));
        }
    }

    public void SaveGame()
    {
        savedScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("saved", savedScene);
        PlayerPrefs.SetFloat(savedScene + "X", transform.position.x);
        PlayerPrefs.SetFloat(savedScene + "Y", transform.position.y);
    }
}
