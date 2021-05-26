using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Possible Elements
public enum Element
{
    GreyMatter,
    Fire,
    Water,
    Air,
    Plant,
    Cinder,
    Lava,
    Rain,
    Swamp,
    Mystic,
    Spark,
    Obsidian,
    Urban,
    Entropy,
    Order
}

//Possible Orb Tiers
public enum Tier
{
    Tier0,
    Tier1,
    Tier2,
    Tier3,
    Tier4
}

//Possible Eggs
public enum PowerEgg
{
    OrbEgg,
    MultiEgg,
    RerollEgg
}

//Volume Types
public enum SoundType
{
    Music,
    MajorSFX,
    MinorSFX,
    Voice
}

//Scenes
public enum GameScene
{
    StartScreen,
    MenuScreen,
    OptionsScreen,
    CustomizationScreen,
    GameplayScene,
    TutorialScene
}

//UI Styles
public enum UIStyles
{
    Nature,
    Farm
}