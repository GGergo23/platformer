using UnityEngine;

public class BaseWizard : BaseClassScript
{
    public BaseWizard() {
        ClassName = "Wizard";
        Strength = 5;
        Health = 4;
        Intelligent = 7;
        Damage = Strength * 2;
        Shoot = true;
    }
}
