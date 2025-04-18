using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody2d;
    public float moveSpeed;
    private Vector2 moveDirection;
    public InputActionReference move;
    bool facingRight = true;
    public float playerSize;
    void Start()
    {
        
    }
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        myRigidBody2d.velocity = new Vector2 (moveDirection.x*moveSpeed, moveDirection.y*moveSpeed);
        if(moveDirection.x > 0 && !facingRight)
        {
            Flip();
        }
        if (moveDirection.x < 0 && facingRight)
        {
            Flip();
        }
        if (gameObject.transform.position.x > 180 + (5 * playerSize))
        {
            transform.position = new Vector2(-180 + (-5 * playerSize), gameObject.transform.position.y);
        }
        if (gameObject.transform.position.x < -180 + (-5 * playerSize))
        {
            transform.position = new Vector2(180 + (5 * playerSize), gameObject.transform.position.y);
        }
        if (gameObject.transform.position.y > 100 + (5 * playerSize))
        {
            transform.position = new Vector2(gameObject.transform.position.x, y: -100 + (-2.5F * playerSize));
        }
        if (gameObject.transform.position.y < -100 + (-5 * playerSize))
        {
            transform.position = new Vector2(gameObject.transform.position.x, y: 100 + (2.5F * playerSize));
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
