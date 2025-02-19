using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Team Hero", menuName = "Data/Data Team Hero")]
public class TeamHero : ScriptableObject
{
    [SerializeField] int countHero;
    public int GetCountHero => countHero;


    [SerializeField] List<HeroType> listHeroTeam = new List<HeroType>();

    public void AddHeroToList(HeroType heroType)
    {
        if (listHeroTeam.Count < countHero)
            listHeroTeam.Add(heroType);
        //Debug.Log(listHeroTeam.Count);
    }

    public void RemoveHeroToList(HeroType heroType)
    {
        listHeroTeam.Remove(heroType);
    }

    public void ChangeheroList(int _index, HeroType _newHeroType)
    {
        // Debug.Log(_index);
        listHeroTeam[_index] = _newHeroType;
    }

    public HeroType GetIndex(int _index)
    {
        return listHeroTeam[_index];
    }
}
