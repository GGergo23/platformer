using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 20.0f;
    public float jumpForce = 400.0f;
    public float horizontalMove;
    public string playerClass;
    private bool canJump = false;
    private Rigidbody2D rb;

    public GameObject fireBall;
    public GameObject granade;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;
        if (0 < horizontalMove)
            transform.localEulerAngles = new Vector3(0, 0, 0);
        if (horizontalMove < 0)          
            transform.localEulerAngles = new Vector3(0, 180, 0);
        if (Input.GetButtonDown("Jump") && GetComponent<CircleCollider2D>().IsTouchingLayers())
            canJump = true;


        if (GetComponent<BaseWarrior>())
            GetComponent<BaseWarrior>().Attack();
        else if (GetComponent<BaseWizard>())
            GetComponent<BaseWizard>().Attack(fireBall);
        else if (GetComponent<BaseRanger>())
            GetComponent<BaseRanger>().Attack(granade);

    }
    
    private void FixedUpdate() {
        Move(horizontalMove, canJump);
    }

    private void Move(float movement, bool canJump) {
        rb.velocity = new Vector2(movement * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        if (canJump && GetComponent<CircleCollider2D>().IsTouchingLayers()) {
            this.canJump = false;
            rb.AddForce(Vector2.up * jumpForce);
        }

    }
}
