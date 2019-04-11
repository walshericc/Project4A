using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool followX = false;
    public bool followY = false;
    public bool stopWhileInAir = false;

    GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (stopWhileInAir && !player.GetComponent<PlayerMovement>().grounded) return;

        var posX = 0f;
        if (followX)
            posX = player.transform.position.x;
        else
            posX = transform.position.x;

        var posY = 0f;
        if (followY)
            posY = player.transform.position.y;
        else
            posY = transform.position.y;

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
