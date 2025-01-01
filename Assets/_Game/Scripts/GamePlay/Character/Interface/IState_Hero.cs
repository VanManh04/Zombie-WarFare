using System.Collections;
using UnityEngine;

public interface IState_Hero
{
    void OnEnter(Hero hero);
    void OnExecute(Hero hero);
    void OnExit(Hero hero);
}