using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveGame : MonoBehaviour
{
    string curentScene;

    void Awake()
    {
        curentScene = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        //if(PlayerPrefs.HasKey(curentScene + "X") && PlayerPrefs.HasKey(curentScene + "Y"))
        //{
            //transform.position = new Vector2(PlayerPrefs.GetFloat(curentScene + "X"), PlayerPrefs.GetFloat(curentScene + "Y"));
        //}
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat(curentScene + "X", transform.position.x);
        PlayerPrefs.SetFloat(curentScene + "Y", transform.position.y);
    }
}
