using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string sceneName;

    public Animator anim;

    public bool deepForest;

    public GameObject transition;
    
    void Start()
    {
        if(deepForest)
        {
            StartCoroutine(RegionName());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator Transition()
    {
        anim.SetBool("on", true);
        yield return new WaitForSeconds(1.5f);
        LoadNextScene();
        anim.SetBool("on", false);
    }

    IEnumerator RegionName()
    {
        anim.SetBool("on", false);
        yield return new WaitForSeconds(1.5f);
        transition.SetActive(false);
        anim.SetBool("regionName", true);   
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionName", false);
    }
}
