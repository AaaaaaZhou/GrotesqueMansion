using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelection : MonoBehaviour {

    private UISprite selectHeroSprite;
    private UILabel selectHeroName;
    private UILabel selectHeroName1;
    private UILabel selectProperty1;
    private UILabel selectProperty2;
    private UILabel selectProperty3;


    private string[] heroNames = { "Detective", "Rescuer", "Explorer" };

    void Awake()
    {
        selectHeroName = this.transform.parent.Find("HeroName").GetComponent<UILabel>();
        selectHeroSprite = this.transform.parent.Find("HeroSelected").GetComponent<UISprite>();
        selectHeroName1 = this.transform.parent.Find("Name").GetComponent<UILabel>();
        selectProperty1 = this.transform.parent.Find("P1").GetComponent<UILabel>();
        selectProperty2 = this.transform.parent.Find("P2").GetComponent<UILabel>();
        selectProperty3 = this.transform.parent.Find("P3").GetComponent<UILabel>();
    }

    void OnClick()
    {
        string heroname = this.gameObject.name;
        selectHeroSprite.spriteName = heroname;
        PlayerInfo.no = heroname;
        //selectHeroSprite = this.transform.parent.Find("HeroSelected").GetComponent<UISprite>();

        char heroIndexChar = heroname[heroname.Length - 1];
        int heroIndex = heroIndexChar - '0';
        selectHeroName.text = heroNames[heroIndex - 1];
        selectHeroName1.text = heroNames[heroIndex - 1];
        PlayerInfo.name = heroNames[heroIndex - 1];
        if (selectHeroName.text == "Detective")
        {
            PlayerInfo.health = 20;
            PlayerInfo.sanity = 60;
            PlayerInfo.activity = 5;
            selectProperty1.text = "20";
            selectProperty2.text = "60";
            selectProperty3.text = "5";
        }
        else if (selectHeroName.text == "Rescuer")
        {
            PlayerInfo.health = 30;
            PlayerInfo.sanity = 40;
            PlayerInfo.activity = 5;
            selectProperty1.text = "30";
            selectProperty2.text = "40";
            selectProperty3.text = "5";
        }
        else if (selectHeroName.text == "Explorer")
        {
            PlayerInfo.health = 25;
            PlayerInfo.sanity = 50;
            PlayerInfo.activity = 5;
            selectProperty1.text = "25";
            selectProperty2.text = "50";
            selectProperty3.text = "5";
        }
    }
}
