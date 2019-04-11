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
    public GameObject platformsContainer;

    [Header("Procedural Generation")]
    public Vector3 startPos = Vector3.zero;
    public int platformsAhead = 5;
    public float minJumpHeight = -3f;
    public float maxJumpHeight = 1f;
    public float minJumpWidth = 0f;
    public float maxJumpWidth = 1f;

    private List<GameObject> platforms = new List<GameObject>();
    private Vector3 nextPlatformPos;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            if (Instance != this)
                Destroy(this.gameObject);

        nextPlatformPos = startPos;
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < platformsAhead; i++)
        {
            CreatePlatform();
        }

        InvokeRepeating("CreatePlatform", 3f, 1f);
    }

    public void ReplacePlatform()
    {
        CreatePlatform();
    }

    private void CreatePlatform()
    {
        // Get a random size
        int size = Random.Range(minPlatformSize, maxPlatformSize + 1);

        var platform = new GameObject();
        platform.name = "Platform";
        platforms.Add(platform);
        platform.transform.position = nextPlatformPos;
        platform.transform.SetParent(platformsContainer.transform);

        var lastPos = platform.transform.position;
        var lastSize = 0f;

        for (int i = 0; i < size; i++)
        {
            var platformPiece = new GameObject();
            platformPiece.name = "Piece (" + i + ")";
            platformPiece.gameObject.tag = "Platform";
            platformPiece.transform.SetParent(platform.transform);

            // Select a random sprite for this part of the platform
            var spriteRenderer = platformPiece.AddComponent<SpriteRenderer>();
            Sprite platformSprite = platformSprites[Random.Range(0, platformSprites.Count - 1)];
            spriteRenderer.sprite = platformSprite;

            // Add colliders
            platformPiece.AddComponent<BoxCollider2D>();

            if (i == 0)
            {
                platformPiece.transform.position = lastPos;
            }
            else
            {
                platformPiece.transform.position = new Vector3(lastPos.x + lastSize, lastPos.y, lastPos.z);
            }
            

            lastPos = platformPiece.transform.position;
            lastSize = spriteRenderer.bounds.size.x;

            // Set nextPlatformPos
            float xPos = lastPos.x + lastSize + Random.Range(minJumpWidth, maxJumpWidth);
            float yPos = lastPos.y + spriteRenderer.bounds.size.y + Random.Range(minJumpHeight, maxJumpHeight);
            nextPlatformPos = new Vector3(xPos, yPos, lastPos.z);
        }

        Debug.Log("Platform created!");
        
    }

    /*public void SpawnPlatform(Vector3 rightEdge)
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
    }*/
}
