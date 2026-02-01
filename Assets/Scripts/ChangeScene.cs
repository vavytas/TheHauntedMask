using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeTheScene() 
    {
        SceneManager.LoadScene("Blank");
    }
}
