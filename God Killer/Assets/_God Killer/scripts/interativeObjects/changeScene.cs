using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public playerLife HP;

    public string sceneName;

    public Animator anim;

    public bool deepForest;
    public bool ruins;
    public bool forest;
    public bool teste;

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

    void Update()
    {
        if(HP.transition)
        {
            StartCoroutine(DeadTransition());
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

    public void StartTransition()
    {
        StartCoroutine(Transition());
        SceneManager.LoadScene("main menu");
    }

    public void NewGame()
    {
        StartCoroutine(Transition());
        SceneManager.LoadScene("forest");
        PlayerPrefs.DeleteAll();
    }

    public IEnumerator Transition()
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

    public IEnumerator DeadTransition()
    {
        anim.SetBool("on", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("on", false);
    }
}
