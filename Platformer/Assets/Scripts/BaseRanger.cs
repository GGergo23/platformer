using UnityEngine;

public class BaseRanger : BaseClassScript
{
    public BaseRanger ()
    {
        ClassName="Ranger";
        Strength=3;
        Health=8;
        Intelligent=5;
        Damage=Strength*2;
        Shoot=false;
    }

    public void Attack(GameObject garanade) {

    }
}
