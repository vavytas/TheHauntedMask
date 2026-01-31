using System.Collections;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject basePlace;

    [SerializeField] private Transform[] dummyTargets;
    [SerializeField] private float darknessIntensity = 0.4f;
    public bool targetPlayer = true;
    [SerializeField] public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector3 diff = (target.transform.position - transform.position);
            float atan2 = Mathf.Atan2(diff.y, diff.x);
            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg - 90f);
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
        MainManager.mainManager.globalLight.intensity -= darknessIntensity;
        int tar = Random.Range(0, dummyTargets.Length);
        speed = 5f;
        target = dummyTargets[tar];
        yield return new WaitForSeconds(0.5f);
        MainManager.mainManager.goDark = true;
        yield return new WaitForSeconds(2.5f);
        target = player.transform;
        speed = 2f;
    }

}