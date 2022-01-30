using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string sceneName;

    public Animator anim;

    public bool deepForest;
    
    void Start()
    {
        if(deepForest)
        {
            StartCoroutine(RegionName());
        }
    }

    void Update()
    {
        
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
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionName", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("regionName", false);
    }
}
