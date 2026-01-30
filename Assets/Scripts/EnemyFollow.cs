using System.Collections;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject basePlace;


    public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            if (MainManager.mainManager.goDark)
            {
                StartCoroutine(GoDarkByFive());
            }
        }
    }


    public IEnumerator GoDarkByFive()
    {
        MainManager.mainManager.goDark = false;
        MainManager.mainManager.globalLight.intensity -= 0.2f;
       yield return new WaitForSeconds(0.5f);
        MainManager.mainManager.goDark = true;
    }

}