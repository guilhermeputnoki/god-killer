using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string sceneName;

    public Animator anim;

    public bool deepForest;
    public bool ruins;
    public bool forest;

    public GameObject transition;

    void Start()
    {
        if(deepForest)
        {
            StartCoroutine(RegionNameDeepForest());
        }

        if(ruins)
        {
            StartCoroutine(RegionNameRuins());
        }

        if(forest)
        {
            StartCoroutine(RegionNameForest());
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

    IEnumerator RegionNameDeepForest()
    {
        anim.SetBool("on", false);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionNameDeepForest", true);   
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionNameDeepForest", false);
    }

    IEnumerator RegionNameRuins()
    {
        anim.SetBool("on", false);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionNameRuins", true);   
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionNameRuins", false);
    }

    IEnumerator RegionNameForest()
    {
        anim.SetBool("on", false);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionNameForest", true);   
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionNameForest", false);
    }
}
