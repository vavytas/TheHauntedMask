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
    [SerializeField] public GameObject GroundMask;

    [SerializeField] public GameObject MaskforInstant;
    public bool overMask = false;

    public bool isMaskOn = false;



    [SerializeField] public EnemyFollow theGhost;


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
    public void Resetintensity()
    {
        MainManager.mainManager.globalLight.intensity = 100f;
    }

    public void MaskOn() 
    {
        theGhost.ResetTargetToRand();
        isMaskOn = true;
    }

    public void MaskOff()
    {
        theGhost.ResetTargetToPlayer();
        isMaskOn = false;
    }
}
