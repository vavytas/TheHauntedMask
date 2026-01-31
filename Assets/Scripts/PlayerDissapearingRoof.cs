using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerDissapearingRoof : MonoBehaviour
{
    public float fadedAlpha = 0.1f;
    public float fadeSpeed = 5f;

    private Tilemap tilemap;
    private Color targetColor;

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        targetColor = tilemap.color;
    }

    void Update()
    {
        tilemap.color = Color.Lerp(tilemap.color, targetColor, Time.deltaTime * fadeSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetColor = new Color(1, 1, 1, fadedAlpha);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetColor = Color.white;
        }
    }
}
