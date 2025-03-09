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


    public const string ANIM_UI_FadeInOut = "Fade_InOut";
    public const string ANIM_UI_FadeIn = "FadeIn";
    public const string ANIM_UI_FadeOut = "FadeOut";
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
    HeroSword_2 = PoolType.HeroSword_2,
}

public enum BoolType
{
    Blood_1 = PoolType.Blood_1,
    Blood_3 = PoolType.Blood_3,
    Blood_4 = PoolType.Blood_4,
    Blood_5 = PoolType.Blood_5,
    Blood_6 = PoolType.Blood_6,
    Blood_7 = PoolType.Blood_7,
    Blood_8 = PoolType.Blood_8,
    Blood_9 = PoolType.Blood_9,
    Blood_10 = PoolType.Blood_10,
    Blood_11 = PoolType.Blood_11,
    Blood_12 = PoolType.Blood_12,
    Blood_13 = PoolType.Blood_13,
    Blood_14 = PoolType.Blood_14,
    Blood_15 = PoolType.Blood_15,
}