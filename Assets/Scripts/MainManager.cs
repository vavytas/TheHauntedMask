using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class MainManager : MonoBehaviour
{
    public static MainManager mainManager;
    public int score;

    public bool goDark;
    [SerializeField] public Light2D globalLight;

    private void Awake()
    {
        if (mainManager == null)
        {
            mainManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("mainManager just died");
            Destroy(gameObject);
        }
    }



}
