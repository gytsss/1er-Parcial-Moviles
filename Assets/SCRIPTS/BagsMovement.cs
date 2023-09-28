using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagsMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float timeToChange = 1;
    private float timeT;


    private Direction moving;

    private enum Direction
    {
        left,
        right
    }

    private void Update()
    {
        timeT -= Time.deltaTime;
        if (timeT < 0)
        {
            switch (moving)
            {
                case Direction.left:
                    moving = Direction.right;
                    timeT = timeToChange;
                    break;
                case Direction.right:
                    moving = Direction.left;
                    timeT = timeToChange;
                    break;
                default:
                    break;
            }
        }

        switch (moving)
        {
            case Direction.left:
                transform.position += new Vector3(speed * Time.deltaTime, 0);
                break;
            case Direction.right:
                transform.position += new Vector3(-speed * Time.deltaTime, 0);
                break;
            default:
                break;
        }
    }
}