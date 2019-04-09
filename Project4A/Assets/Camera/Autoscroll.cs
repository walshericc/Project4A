using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscroll : MonoBehaviour
{
    public enum Direction { Left, Right, Up, Down }

    public Direction direction = Direction.Right;
    public float speed = 1f;

    public void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector3 directionToMove;
        switch (direction)
        {
            case Direction.Left:
                directionToMove = Vector3.left;
                break;
            case Direction.Right:
                directionToMove = Vector3.right;
                break;
            case Direction.Up:
                directionToMove = Vector3.up;
                break;
            case Direction.Down:
                directionToMove = Vector3.down;
                break;
            default:
                directionToMove = Vector3.zero;
                break;
        }

        transform.position += directionToMove * speed * Time.deltaTime;
    }
}
