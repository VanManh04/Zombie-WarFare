using System.Collections;
using UnityEngine;

public class AKM_47 : WeaponBase
{
    public override void Reload()
    {
        ChangeAnim(Constants.ANIM_IDLE);
        base.Reload();
    }

    public override void Shoot(float _timeDelay)
    {
        ChangeAnim(Constants.ANIM_SHOOT); 
        base.Shoot(_timeDelay);//.1s .2s
    }
}