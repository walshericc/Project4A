using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscroll : MonoBehaviour
{
    public enum Direction { Left, Right, Up, Down }

    public Direction direction = Direction.Right;
    public float defaultSpeed = 1f;
    public bool adjustSpeed = false;
    public float maxDistance = 3f;
    public float speedUpRate = 1.2f;
    public float speedDelay = 2f;

    [SerializeField]
    private float speed;

    private void Awake()
    {
        speed = defaultSpeed;
    }

    private void Start()
    {
        if (adjustSpeed)
        {
            InvokeRepeating("AdjustSpeed", speedDelay, speedDelay);
        }
    }

    public void Update()
    {
        Scroll();
    }

    private void AdjustSpeed()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        
        // Only works scrolling to the right for now
        if (player.transform.position.x - transform.position.x > maxDistance)
        {
            StartCoroutine(SpeedUp());
        }
        else
        {
            StopCoroutine(SpeedUp());
            speed = defaultSpeed;
        }

    }

    private IEnumerator SpeedUp()
    {
        speed = speed * speedUpRate;

        yield return new WaitForSeconds(speedDelay);

        SpeedUp();
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
