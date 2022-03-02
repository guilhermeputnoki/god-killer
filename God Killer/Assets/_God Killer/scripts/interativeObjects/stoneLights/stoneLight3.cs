using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stoneLight3 : MonoBehaviour
{
    public pedestal Pedestal;
    public lightPilar pilar;
    public AudioSource dragging;
    public AudioSource shining;

    public bool on;
    public bool on3;
    string curentSceneS;

    void Awake()
    {
        curentSceneS = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        LoadPosition();
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat(curentSceneS + "4X", transform.position.x);
        PlayerPrefs.SetFloat(curentSceneS + "4Y", transform.position.y);
    }

    public void LoadPosition()
    {
        if(PlayerPrefs.HasKey(curentSceneS + "4X") && PlayerPrefs.HasKey(curentSceneS + "4Y"))
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat(curentSceneS + "4X"), PlayerPrefs.GetFloat(curentSceneS + "4Y"));
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pedestal3")
        {
            on3 = true;
            on = true;
            StartCoroutine(shine());
            StartCoroutine(PilarShine());
        }

        if(collision.gameObject.tag == "Player")
        {
            dragging.Play();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pedestal3")
        {
            on3 = false;
            on = false;
            StartCoroutine(off());
            StartCoroutine(PilarOff());
        }

        if(collision.gameObject.tag == "Player")
        {
            dragging.Pause();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dragging.Play();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dragging.Pause();
            SavePosition();
        }
    }

    public IEnumerator shine()
    {
        Pedestal.light1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Pedestal.light2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Pedestal.light3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Pedestal.light4.SetActive(true);
    }

    public IEnumerator off()
    {
        Pedestal.light4.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Pedestal.light3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Pedestal.light2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Pedestal.light1.SetActive(false);
    }

    private IEnumerator PilarShine()
    {
        shining.Play();
        pilar.light1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        pilar.light2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        pilar.light3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        pilar.light4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        pilar.light5.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        pilar.light6.SetActive(true);
    }

    private IEnumerator PilarOff()
    {
        shining.Play();
        pilar.light6.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pilar.light5.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pilar.light4.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pilar.light3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pilar.light2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pilar.light1.SetActive(false);
    }
}
