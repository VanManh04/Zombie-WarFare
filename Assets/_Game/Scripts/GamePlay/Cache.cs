using System.Collections.Generic;
using UnityEngine;

public class Cache
{
    private static Dictionary<Collider, Hero> dictBirge_Hero = new Dictionary<Collider, Hero>();
    private static Dictionary<Collider, Zombie> dictBirge_ZomBie = new Dictionary<Collider, Zombie>();

    public static Hero GenCollectHero(Collider collider)
    {
        if (!dictBirge_Hero.ContainsKey(collider))
        {
            Hero brige = collider.GetComponent<Hero>();

            dictBirge_Hero.Add(collider, brige);
        }

        return dictBirge_Hero[collider];
    }
    public static Zombie GenCollectZombie(Collider collider)
    {
        if (!dictBirge_ZomBie.ContainsKey(collider))
        {
            Zombie brige = collider.GetComponent<Zombie>();

            dictBirge_ZomBie.Add(collider, brige);
        }

        return dictBirge_ZomBie[collider];
    }
}