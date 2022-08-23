using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesCard : MonoBehaviour {

    public static DesCard _instance;
    private UISprite sprite;

    public float showTime = 2f;
    private float timer = 0;
    private bool isShow = false;

    private UILabel cardName;
    private UILabel cardCaption;
    private UILabel needCrystal;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isShow)
        {
            timer += Time.deltaTime;
            if(timer > showTime)
            {
                sprite.alpha = 0;
                isShow = false;
                timer = 0;
            }
            else
            {
                sprite.alpha = (showTime - timer) / showTime;
            }
        }
	}

    private void Awake()
    {
        _instance = this;
        sprite = this.GetComponent<UISprite>();
        sprite.alpha = 0; // 开始时隐藏

        cardName = this.transform.Find("cardName").GetComponent<UILabel>();
        cardCaption = this.transform.Find("cardCaption").GetComponent<UILabel>();
        needCrystal = this.transform.Find("needCrystal").GetComponent<UILabel>();
    }

    public void Show(string cardName)
    {
        this.gameObject.SetActive(true);
        sprite.spriteName = cardName;

        sprite.alpha = 1;
        isShow = true;
        timer = 0;
        InitProperty();
    }

    public void InitProperty()
    {
        string spriteName = sprite.spriteName;
        switch (spriteName)
        {
            case "Attack":
                needCrystal.text = "2";
                cardName.text = "攻击";
                cardCaption.text = "造成2D6伤害";
                break;
            case "Attack2":
                needCrystal.text = "2";
                cardName.text = "偷取生命";
                cardCaption.text = "造成2D3伤害\n回复2D2生命";
                break;
            case "Pistol":
                needCrystal.text = "3";
                cardName.text = "手枪";
                cardCaption.text = "以一定几率\n造成2D8+2点伤害";
                break;
            case "AddEnergy":
                needCrystal.text = "0";
                cardName.text = "能量饮料";
                cardCaption.text = "获得两点行动值\n减少1D4点理智值";
                break;
            default:
                break;
        }
    }

}
