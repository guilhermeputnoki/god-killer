using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stoneLight4 : MonoBehaviour
{
    public pedestal Pedestal;
    public lightPilar pilar;
    public AudioSource dragging;
    public AudioSource shining;

    public bool on;
    public bool on4;
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
        PlayerPrefs.SetFloat(curentSceneS + "5X", transform.position.x);
        PlayerPrefs.SetFloat(curentSceneS + "5Y", transform.position.y);
    }

    public void LoadPosition()
    {
        if(PlayerPrefs.HasKey(curentSceneS + "5X") && PlayerPrefs.HasKey(curentSceneS + "5Y"))
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat(curentSceneS + "5X"), PlayerPrefs.GetFloat(curentSceneS + "5Y"));
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pedestal4")
        {
            on4 = true;
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
        if(collision.gameObject.tag == "pedestal4")
        {
            on4 = false;
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
