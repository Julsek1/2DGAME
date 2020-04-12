using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public enum EnumDirection { Left, Right, Up, Down };

    [SerializeField] float speed = 0.01f;
    [SerializeField] int power = 55;
    [SerializeField] EnumDirection dir;

    Vector2 windPushDirection;
    Vector2 windMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        switch (dir)
        {
            case EnumDirection.Left:
                windPushDirection = Vector2.left;
                break;
            case EnumDirection.Right:
                windPushDirection = Vector2.right;
                break;
            case EnumDirection.Up:
                windPushDirection = Vector2.up;
                break;
            case EnumDirection.Down:
                windPushDirection = Vector2.down;
                break;
            default:
                windPushDirection = Vector2.left;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {


        switch (dir)
        {
            case EnumDirection.Left:
                windMoveDirection = new Vector2(transform.position.x - speed, 0f);
                break;
            case EnumDirection.Right:
                windMoveDirection = new Vector2(transform.position.x + speed, 0f);
                break;
            case EnumDirection.Up:
                windMoveDirection = new Vector2(0f, transform.position.y + speed);
                break;
            case EnumDirection.Down:
                windMoveDirection = new Vector2(0f, transform.position.y - speed);
                break;
            default:
                windMoveDirection = new Vector2(transform.position.x - speed, 0f);
                break;
        }
        transform.position = windMoveDirection;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && collision.GetType() == typeof(BoxCollider2D))
        {
            if (!collision.GetComponent<Movement>().GetIsCube())
            {
                collision.GetComponent<Rigidbody2D>().AddForce(windPushDirection * power);
            }
        }
    }
}
