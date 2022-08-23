using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public static int str = 10;
    public static int vit = 10;
    public static int dex = 10;
    public static int wil = 10;
    public static int luc = 10;
    public static int eva = 10;
    public static int remain = 10;

    public static int health = 20;
    public static int sanity = 60;
    public static int activity = 5;

    public static int currenthealth;

    public static int floor = 3;

    public static float map1x = -322;
    public static float map1y = -148;
    public static bool if_card1 = true;
    public static bool if_level1 = true;

    public static float map2x = -75;
    public static float map2y = -222;
    public static bool if_card2 = true;
    public static bool if_level2 = true;

    public static float map3x = 167;
    public static float map3y = -279;
    public static bool if_card3 = true;
    public static bool if_level3 = true;

    public static bool if_metlevel1 = false;
    public static bool if_metlevel2 = false;
    public static bool if_metlevel3 = false;

    public static bool if_bulb1 = false;
    public static bool if_bulb2 = false;
    public static bool if_bulb3 = false;

    public static string name = "Detective";
    public static string no = "hero1";

    public static void RefreshMap()
    {
        map1x = -322;
        map1y = -148;
        if_card1 = true;
        if_level1 = true;

        map2x = -75;
        map2y = -222;
        if_card2 = true;
        if_level2 = true;

        map3x = 167;
        map3y = -279;
        if_card3 = true;
        if_level3 = true;

        str = 10;
    vit = 10;
    dex = 10;
    wil = 10;
    luc = 10;
    eva = 10;
    remain = 10;

    health = 20;
    sanity = 60;
    activity = 5;

    

    floor = 3;

    

    if_metlevel1 = false;
    if_metlevel2 = false;
    if_metlevel3 = false;

    if_bulb1 = false;
    if_bulb2 = false;
    if_bulb3 = false;
    }
}
