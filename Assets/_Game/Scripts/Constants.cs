using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants 
{
    
    public const string ANIM_IDLE = "Idle";
    public const string ANIM_WAITTARGET = "WaitTarget";
    public const string ANIM_MOVE = "Move";
    public const string ANIM_DEATH = "Death";
    public const string ANIM_SHOOT = "Shoot";
    public const string ANIM_RELOAD = "Reload";
    public const string ANIM_ATTACK = "Attack";
    public const string ANIM_ATTACKCOUNDOWN = "AttackCoundown";
    public const string ANIM_SKILL_1 = "Skill_1";
    public const string ANIM_SKILL_2 = "Skill_2";
}

public class TAG
{
    public const string ZOMBIE = "Zombie";
    public const string HERO = "Hero";

}

public enum GameState
{
    Menu,
    GamePlay,
    Pause,
    Win,
    Lose,
}
public enum EnemyType
{
    ZombieFast_1 = PoolType.ZombieFast_1,
    Zombie_Creep1 = PoolType.Zombie_Creep1,
    Zombie_Creep2 = PoolType.Zombie_Creep2,
    Zombie_Creep3 = PoolType.Zombie_Creep3,
    Monster_X = PoolType.Monster_X,
}

public enum HeroType
{
    HeroSword_1 = PoolType.HeroSword_1,
    Hero_AKM = PoolType.Hero_AKM,
}