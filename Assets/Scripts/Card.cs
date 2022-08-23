using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public string name;
    public string caption ;
    public int needCrystal ;

    private UISprite sprite;
    private UILabel cardname;
    private UILabel cardcaption;
    private UILabel needcrystal;

    private string cardName
    {
        get
        {
            if(sprite == null)
            {
                sprite = this.GetComponent<UISprite>();
            }
            return sprite.spriteName;
        }
    }

	// Use this for initialization
	void Start () {
        InitProperty();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateShow();
	}

    private void Awake()
    {
        sprite = this.GetComponent<UISprite>();
        cardname = transform.Find("cardName").GetComponent<UILabel>();
        cardcaption = transform.Find("cardCaption").GetComponent<UILabel>();
        needcrystal = transform.Find("needCrystal").GetComponent<UILabel>();
    }

    public void SetDepth(int depth)
    {
        sprite.depth = depth;
        cardname.depth = depth + 1;
        cardcaption.depth = depth + 1;
        needcrystal.depth = depth + 1;
    }

    void OnPress(bool isPressed)
    {
        if(isPressed)
        {
            DesCard._instance.Show(cardName);
        }
    }

    // 更新血量和伤害的显示
    void UpdateShow()
    {
        needcrystal.text = needCrystal + "";
        cardname.text = name;
        cardcaption.text = caption;
    }

    // 初始化血量和伤害
    public void InitProperty()
    {
        string spriteName = sprite.spriteName;
        switch(spriteName)
        {
            case "Attack":
                needCrystal = 2;
                name = "攻击";
                caption = "造成2D6点伤害";
                break;
            case "Attack2":
                needCrystal = 2;
                name = "偷取生命";
                caption = "造成2D3点伤害\n回复2D2点生命值";
                break;
            case "Pistol":
                needCrystal = 3;
                name = "手枪";
                caption = "以一定几率\n造成2D8+2点伤害";
                break;
            case "AddEnergy":
                needCrystal = 0;
                name = "能量饮料";
                caption = "获得两点行动值\n减少1D4点理智值";
                break;
            default:
                break;
        }
    }

}
