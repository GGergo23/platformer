using UnityEngine;

public class BaseClassScript : MonoBehaviour
{
    private string className;
    private int strenght;
    private int health;
    private int intelligent;
    private int damage;
    private bool canShoot;

    public string ClassName {
        get { return className; }
        set { className = value; }
    }
    public int Strength {
        get { return strenght; }   
        set { strenght = value; }
    }
    public int Health {
        get { return health; }
        set { health = value; }
    }
    public int Intelligent {
        get { return intelligent; }
        set { intelligent = value; }
    }
    public int Damage {
        get { return damage; }
        set { damage = value; }
    }
    public bool CanShoot {
        get { return canShoot; }
        set { canShoot = value; }
    }

}
