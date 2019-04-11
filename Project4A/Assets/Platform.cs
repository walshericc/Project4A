using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool hasTriggered = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !hasTriggered)
        {
            hasTriggered = true;
            GeneratePlatforms.Instance.ReplacePlatform();
        }
    }
}
