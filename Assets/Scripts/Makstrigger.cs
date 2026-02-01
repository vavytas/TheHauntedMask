using System;
using UnityEngine;

public class Makstrigger : MonoBehaviour
{
    [SerializeField] GameObject Buttontopress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ShowF();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowF();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Buttontopress.SetActive(false);
        MainManager.mainManager.overMask = false;

    }

    private void ShowF()
    {
        MainManager.mainManager.overMask = true;
        Buttontopress.SetActive(true);
        Buttontopress.LeanScale(new Vector3(2f,2f,2f), 2f).setEaseOutBack();
    }
}
