using UnityEngine;

public class ShowMessage : MonoBehaviour
{

    [SerializeField] private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 2f) 
        {
        MainManager.mainManager.Ins.SetActive(true);
        }
        else
        {
            MainManager.mainManager.Ins.SetActive(false);
        }
    }
}
