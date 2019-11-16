using UnityEngine;

public class BaseRanger : BaseClassScript
{

    GameObject firepoint;

    public BaseRanger ()
    {
        ClassName="Ranger";
        Strength=3;
        Health=8;
        Intelligent=5;
        Damage=Strength*2;
        Shoot=false;
    }

    void Start() {
        firepoint = GameObject.Find("Firepoint");
    }

    public void Attack(ShootController granade) {
        Instantiate(granade.gameObject, firepoint.transform.position, firepoint.transform.rotation);
    }
}
