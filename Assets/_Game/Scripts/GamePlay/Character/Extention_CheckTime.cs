using UnityEngine;

public class Extention_CheckTime : MonoBehaviour
{
    public bool CanPrind;
    public float timmer;
    public float Endtimmer;

    void Update()
    {
        timmer += Time.deltaTime;
        Endtimmer += Time.deltaTime;
    }

    public void StartTimmer()
    {
        if (!CanPrind)
        return;

        timmer = 0;
        Endtimmer = 0;
    }

    public void PrindTimmer()
    {
        if (!CanPrind)
            return;

        print(timmer);
        timmer = 0;
    }

    public void EndAnimation()
    {
        if (!CanPrind)
            return;

        print(Endtimmer);
    }
}
