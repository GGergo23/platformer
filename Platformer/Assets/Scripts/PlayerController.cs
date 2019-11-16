using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 20.0f;
    public float jumpForce = 400.0f;
    public float horizontalMove;
    public string playerClass = "player";
    private bool canJump = false;
    private Rigidbody2D rb;

    public ShootController fireBall;
    public ShootController granade;

    public int health, damage, intelligance, strength; 

    public Transform firepoint;
    
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

        //attacking
        if(Input.GetMouseButton(0)) {
            if (GetComponent<BaseWarrior>())
                GetComponent<BaseWarrior>().Attack();
            else if (GetComponent<BaseWizard>())
                GetComponent<BaseWizard>().Attack(fireBall);
            else if (GetComponent<BaseRanger>())
                GetComponent<BaseRanger>().Attack(granade);
        }

    }

    public void WarriorClass() {
        if(!GetComponent<BaseWarrior>()) {
            if(GetComponent<BaseWizard>() || GetComponent<BaseRanger>()) {
                Destroy(GetComponent<BaseRanger>());
                Destroy(GetComponent<BaseWizard>());
            }
            var _class = gameObject.AddComponent<BaseWarrior>();
            health = _class.Health;
            damage = _class.Damage;
            intelligance = _class.Intelligent;
            strength = _class.Strength;
            playerClass = _class.ClassName;
            firepoint.localEulerAngles = Vector3.zero;
        }
    }
    public void WizardClass() {
        if(!GetComponent<BaseWizard>()) {
            if(GetComponent<BaseWarrior>() || GetComponent<BaseRanger>()) {
                Destroy(GetComponent<BaseRanger>());
                Destroy(GetComponent<BaseWarrior>());
            }
            var _class = gameObject.AddComponent<BaseWizard>();
            health = _class.Health;
            damage = _class.Damage;
            intelligance = _class.Intelligent;
            strength = _class.Strength;
            playerClass = _class.ClassName;
            firepoint.localEulerAngles = Vector3.zero;
        }
    }
    public void RangerClass() {
        if(!GetComponent<BaseRanger>()) {
            if(GetComponent<BaseWizard>() || GetComponent<BaseWarrior>()) {
                Destroy(GetComponent<BaseWarrior>());
                Destroy(GetComponent<BaseWizard>());
            }
            var _class = gameObject.AddComponent<BaseRanger>();
            health = _class.Health;
            damage = _class.Damage;
            intelligance = _class.Intelligent;
            strength = _class.Strength;
            playerClass = _class.ClassName;
            firepoint.localEulerAngles = new Vector3(0, 0, 45);
        }
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
