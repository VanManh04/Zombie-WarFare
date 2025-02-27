using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFX_BloodSettings : GameUnit
{
    public float AnimationSpeed = 1;
    public float GroundHeight = 0;
    [Range(0, 1)]
    public float LightIntensityMultiplier = 1;
    public bool FreezeDecalDisappearance = false;
    public _DecalRenderinMode DecalRenderinMode = _DecalRenderinMode.Floor_XZ;
    public bool ClampDecalSideSurface = false;

    public enum _DecalRenderinMode
    {
        Floor_XZ,
        AverageRayBetwenForwardAndFloor
    }

    public void OnDesPawn()
    {
        SimplePool.Despawn(this);
    }
    public void OnDesPawn(float sec)
    {
        StartCoroutine(IEDespawn(sec));
    }

    IEnumerator IEDespawn(float sec)
    {
        yield return new WaitForSeconds(sec);
        OnDesPawn();
    }
}
