using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    public static GeneratePlatforms Instance;

    public List<Sprite> platformSprites = new List<Sprite>();
    public int minPlatformSize = 3;
    public int maxPlatformSize = 10;
    public float platformOffset = 5f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            if (Instance != this)
                Destroy(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlatform(Vector3 rightEdge)
    {
        // Select a platform sprite
        Sprite platformSprite = platformSprites[Random.Range(0, platformSprites.Count - 1)];

        // Get a random size
        int size = Random.Range(minPlatformSize, maxPlatformSize + 1);

        // Create our new platform
        var container = new GameObject();
        container.transform.position = new Vector3(rightEdge.x + platformOffset, rightEdge.y, rightEdge.z);
        var platform = new GameObject();
        platform.transform.SetParent(container.transform);
        var spriteRenderer = platform.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = platformSprite;
    }
}
