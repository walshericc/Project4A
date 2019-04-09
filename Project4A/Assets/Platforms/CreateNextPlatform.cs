using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNextPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rightEdge = new Vector3(transform.position.x + GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y, transform.position.z);
        GeneratePlatforms.Instance.SpawnPlatform(rightEdge);
    }

    private void Start()
    {
        var rightEdge = new Vector3(transform.position.x + GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y, transform.position.z);
        GeneratePlatforms.Instance.SpawnPlatform(rightEdge);
    }
}
