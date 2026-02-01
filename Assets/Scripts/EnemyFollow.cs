using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject basePlace;

    [SerializeField] private Transform[] dummyTargets;
    [SerializeField] private float darknessIntensity = 0.4f;


    [SerializeField] private float distancething = 1f;

    [SerializeField] private float thingdistance = 19f;



    public bool targetPlayer = true;
    [SerializeField] public float speed = 2f;

    [SerializeField] public bool isGhost = false;

    public bool stop = false;

    [SerializeField] public SpriteRenderer unitSpriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if (isGhost || MainManager.mainManager.isMaskOn)
            {
                if (!isGhost)
                {
                    Color tmp = unitSpriteRenderer.color;
                    tmp.a = 1f;
                    unitSpriteRenderer.color = tmp;
                }
                float distance = Vector3.Distance(transform.position, target.position);

                if (distance < thingdistance)
                {
                    if (distance > distancething)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                        if (isGhost)
                        {
                            Vector3 diff = (target.transform.position - transform.position);
                            float atan2 = Mathf.Atan2(diff.y, diff.x);
                            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg - 90f);
                        }
                    }
                    else
                    {
                        if (MainManager.mainManager.goDark)
                        {
                            if (MainManager.mainManager.isMaskOn)
                            {
                                StartCoroutine(GoDarkByFive());
                            }
                        }
                    }
                }else
                {
                    if (isGhost && !MainManager.mainManager.isMaskOn)
                    {
                        Vector3 diff = (target.transform.position - transform.position);
                        float atan2 = Mathf.Atan2(diff.y, diff.x);
                        transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg - 90f);
                        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    }
                    
                }
            }
            else
            {
                if (!isGhost)
                {
                    Color tmp = unitSpriteRenderer.color;
                    tmp.a = 0.2f;
                    unitSpriteRenderer.color = tmp;
                }
                else 
                {
                
                }
            }
        }
    }


    public IEnumerator GoDarkByFive()
    {
        MainManager.mainManager.goDark = false;
        MainManager.mainManager.globalLight.intensity -= darknessIntensity;
        int tar = Random.Range(0, dummyTargets.Length);
        speed = 2.5f;
        target = dummyTargets[tar];
        yield return new WaitForSeconds(0.5f);
        MainManager.mainManager.goDark = true;
        yield return new WaitForSeconds(2.5f);
        target = player.transform;
        speed = 2f;
    }

    public void ResetTargetToRand()
    {
        int tar = Random.Range(0, dummyTargets.Length);
        speed = 8f;
        target = dummyTargets[tar];
    }

    public void ResetTargetToPlayer()
    {
        target = player.transform;
    }
}