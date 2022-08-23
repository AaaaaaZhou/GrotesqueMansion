using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Explorer {

    public int maxSAN = 20;
    public int minSAN = 0;
    public int sanCount;

    public int initHP = 25;
    private int extraHP = 0;
    public int initSAN = 15;
    private int extraSAN = 0;

    // player's properties
    public int STR = 0; // strength
    public int VIT = 0; // vitality
    public int DEX = 0; // dexterity
    public int WIL = 0; // willpower
    public int LUC = 0; // luck
    public int EVA = 0; // evade
    public int accuracy = 60; // 枪械的射击精度
    
    private void Awake()
    {
        initHP = PlayerInfo.health;
        initSAN = PlayerInfo.sanity;


        STR = PlayerInfo.str;
        VIT = PlayerInfo.vit;
        DEX = PlayerInfo.dex;
        WIL = PlayerInfo.wil;
        LUC = PlayerInfo.luc;
        EVA = PlayerInfo.eva;

        hpCount = maxHP = initHP + VIT;
        sanCount = maxSAN = initSAN + WIL;
        sprite = this.GetComponent<UISprite>();
    }

    // Use this for initialization
    void Start ()
    {
        //string explorerName = PlayerPrefs.GetString("Player");
        //string explorerName = "hero1";
        string explorerName = PlayerInfo.no;
        sprite.spriteName = explorerName;
        STR = PlayerInfo.str;
        VIT = PlayerInfo.vit;
        DEX = PlayerInfo.dex;
        WIL = PlayerInfo.wil;
        LUC = PlayerInfo.luc;
        EVA = PlayerInfo.eva;
	}

    public void TakeDamage(int damage)
    {
        hpCount -= damage;
        if (hpCount <= minHP)
        {
            // Game Over
            hpCount = 0;
        }
        this.transform.parent.Find("PlayerInformation").Find("hpInformation").GetComponent<UIControlHP>().UpdatShow(hpCount, maxHP);
    }

    public void DecreaseSAN(int damage)
    {
        sanCount -= damage;
        if(sanCount <= 0)
        {
            sanCount = 0;
        }
        this.transform.parent.Find("PlayerInformation").Find("sanInformation").GetComponent<UIControlSAN>().UpdatShow(sanCount, maxSAN);
    }

}
