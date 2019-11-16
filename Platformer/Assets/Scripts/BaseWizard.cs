using UnityEngine;

public class BaseWizard : BaseClassScript
{

    public GameObject firepoint;

    public BaseWizard() {
        ClassName = "Wizard";
        Strength = 5;
        Health = 4;
        Intelligent = 7;
        Damage = Strength * 2;
        Shoot = true;
    }

    void Start() {
        firepoint = GameObject.Find("Firepoint");
    }

    public void Attack(ShootController fireBall) {
        Instantiate(fireBall.gameObject, firepoint.transform.position, firepoint.transform.rotation);
    }
}