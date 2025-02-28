using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public PoolType poolType;
    private Transform tf;
    public Transform TF
    {
        get
        {
            if (tf == null)
            {
                tf = transform;
            }

            return tf;
        }
    }
}
