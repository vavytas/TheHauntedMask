using System.Collections;
using UnityEngine;

public class WinPlane : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            StartCoroutine(Ghostpup());
        }
    }

    public IEnumerator Ghostpup()
    {
        var ghostrenderer = MainManager.mainManager.theGhost2.GetComponent<SpriteRenderer>();
        var doggorenderer = MainManager.mainManager.TheDoggo.GetComponent<SpriteRenderer>();

        //var anim = MainManager.mainManager.theGhost2.GetComponent<Animator>();
        //anim.SetBool("OnStop", true);

        MainManager.mainManager.theGhost2.gameObject.SetActive(false);
        MainManager.mainManager.theGhost.gameObject.SetActive(false);

        MainManager.mainManager.Win.SetActive(true);
        MainManager.mainManager.theGhost2.stop = true;
        yield return new WaitForSeconds(0.2f);
        var spcolor = ghostrenderer.color;
        spcolor.a = 0.3f;
        ghostrenderer.color = spcolor;
        yield return new WaitForSeconds(0.2f);
        spcolor = ghostrenderer.color;
        spcolor.a = 0f;
        ghostrenderer.color = spcolor;
        MainManager.mainManager.TheDoggo.SetActive(true);
        spcolor = doggorenderer.color;
        spcolor.a = 0.2f;
        doggorenderer.color = spcolor;
        yield return new WaitForSeconds(0.9f);
        spcolor = doggorenderer.color;
        spcolor.a = 0.5f;
        doggorenderer.color = spcolor;
        yield return new WaitForSeconds(0.9f);
        spcolor = doggorenderer.color;
        spcolor.a = 0.8f;
        doggorenderer.color = spcolor;
        yield return new WaitForSeconds(0.9f);
        spcolor = doggorenderer.color;
        spcolor.a = 1f;
        doggorenderer.color = spcolor;
        yield return new WaitForSeconds(3f);
        spcolor = doggorenderer.color;
        spcolor.a = 0.5f;
        doggorenderer.color = spcolor;
        yield return new WaitForSeconds(0.9f);
        spcolor = doggorenderer.color;
        spcolor.a = 0.5f;
        doggorenderer.color = spcolor;
        yield return new WaitForSeconds(0.5f);
        spcolor = doggorenderer.color;
        spcolor.a = 0f;
        doggorenderer.color = spcolor;
        //MainManager.mainManager.goDark = true;
        //yield return new WaitForSeconds(2.5f);
        //target = player.transform;
        //speed = 2f;
    }


}
