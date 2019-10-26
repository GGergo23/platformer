using UnityEngine;

public class BaseWizard : BaseClassScript
{
    public BaseWizard (){
        ClassName="Wizard";
        Strength=2;
        Health=20;
        Intelligent=10;
        Damage=3*Intelligent;
        Shoot=true;
    }
}
