using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainManager : MonoBehaviour
{
    public static MainManager mainManager;

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
