using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1000)]
    private float MoveSpeed = 10.0f;
    // Start is called before the first frame update

    [SerializeField]
    Rigidbody2D rigidbody;

    [SerializeField]
    Animator animator;
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 oldPosition = transform.position;


        Vector3 velocity = new Vector3(xInput, yInput, 0) * MoveSpeed;
        animator.SetFloat("Speed", velocity.sqrMagnitude);

        CardinalDirection facing = CardinalDirection.SOUTH;

        if(velocity.x > 0)
            facing = CardinalDirection.EAST;
        else if(velocity.x < 0)
            facing = CardinalDirection.WEST;
        else if(velocity.y < 0)
            facing = CardinalDirection.SOUTH;
        else if(velocity.y > 0)
            facing = CardinalDirection.NORTH;

        animator.speed = MoveSpeed;
        animator.SetInteger("FacingDirection", (int)facing);

        rigidbody.MovePosition(oldPosition + velocity * Time.deltaTime);
        //transform.position = oldPosition + new Vector3(xInput, yInput, 0) * MoveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player Collided with: " + collision.gameObject.name);
    }

    
}
