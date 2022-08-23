using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertySelection : MonoBehaviour
{
    private UILabel strengthValue;
    private UILabel vitalityValue;
    private UILabel dexterityValue;
    private UILabel willValue;
    private UILabel luckValue;
    private UILabel evadingValue;
    private UILabel currentRemain;
    private UILabel heroName;
    private UISprite Button;
    private UISprite selectHeroSprite;

    void Awake()
    {
        strengthValue = this.transform.parent.Find("Str").GetComponent<UILabel>();
        vitalityValue = this.transform.parent.Find("Vit").GetComponent<UILabel>();
        dexterityValue = this.transform.parent.Find("Dex").GetComponent<UILabel>();
        willValue = this.transform.parent.Find("Wil").GetComponent<UILabel>();
        luckValue = this.transform.parent.Find("Luc").GetComponent<UILabel>();
        evadingValue = this.transform.parent.Find("Eva").GetComponent<UILabel>();
        currentRemain = this.transform.parent.Find("currentremain").GetComponent<UILabel>();
        heroName = this.transform.parent.Find("HeroName").GetComponent<UILabel>();
        selectHeroSprite = this.transform.parent.Find("HeroSelected").GetComponent<UISprite>();
    }

    void Update()
    {
        heroName.text = PlayerInfo.name;
        selectHeroSprite.spriteName = PlayerInfo.no;
    }

    void OnClick()
    {
        string buttonname = this.transform.GetComponent<UISprite>().spriteName;
        string tmp1, tmp2;
        switch (buttonname)
        {
            case "Strplus":
                if (PlayerInfo.str == 18 || PlayerInfo.remain == 0) break;
                PlayerInfo.str = PlayerInfo.str + 1;
                PlayerInfo.remain = PlayerInfo.remain - 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.str.ToString();
                strengthValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Strminus":
                if (PlayerInfo.str == 3) break;
                PlayerInfo.str = PlayerInfo.str - 1;
                PlayerInfo.remain = PlayerInfo.remain + 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.str.ToString();
                strengthValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Vitplus":
                if (PlayerInfo.vit == 18 || PlayerInfo.remain == 0) break;
                PlayerInfo.vit = PlayerInfo.vit + 1;
                PlayerInfo.remain = PlayerInfo.remain - 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.vit.ToString();
                vitalityValue.text = tmp1;
                currentRemain.text = tmp2;
                PlayerInfo.currenthealth = PlayerInfo.health + PlayerInfo.vit;
                break;
            case "Vitminus":
                if (PlayerInfo.vit == 3) break;
                PlayerInfo.vit = PlayerInfo.vit - 1;
                PlayerInfo.remain = PlayerInfo.remain + 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.vit.ToString();
                vitalityValue.text = tmp1;
                currentRemain.text = tmp2;
                PlayerInfo.currenthealth = PlayerInfo.health + PlayerInfo.vit;
                break;
            case "Dexplus":
                if (PlayerInfo.dex == 18 || PlayerInfo.remain == 0) break;
                PlayerInfo.dex = PlayerInfo.dex + 1;
                PlayerInfo.remain = PlayerInfo.remain - 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.dex.ToString();
                dexterityValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Dexminus":
                if (PlayerInfo.dex == 3) break;
                PlayerInfo.dex = PlayerInfo.dex - 1;
                PlayerInfo.remain = PlayerInfo.remain + 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.dex.ToString();
                dexterityValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Wilplus":
                if (PlayerInfo.wil == 18 || PlayerInfo.remain == 0) break;
                PlayerInfo.wil = PlayerInfo.wil + 1;
                PlayerInfo.remain = PlayerInfo.remain - 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.wil.ToString();
                willValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Wilminus":
                if (PlayerInfo.wil == 3) break;
                PlayerInfo.wil = PlayerInfo.wil - 1;
                PlayerInfo.remain = PlayerInfo.remain + 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.wil.ToString();
                willValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Lucplus":
                if (PlayerInfo.luc == 18 || PlayerInfo.remain == 0) break;
                PlayerInfo.luc = PlayerInfo.luc + 1;
                PlayerInfo.remain = PlayerInfo.remain - 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.luc.ToString();
                luckValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Lucminus":
                if (PlayerInfo.luc == 3) break;
                PlayerInfo.luc = PlayerInfo.luc - 1;
                PlayerInfo.remain = PlayerInfo.remain + 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.luc.ToString();
                luckValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Evaplus":
                if (PlayerInfo.eva == 18 || PlayerInfo.remain == 0) break;
                PlayerInfo.eva = PlayerInfo.eva + 1;
                PlayerInfo.remain = PlayerInfo.remain - 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.eva.ToString();
                evadingValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
            case "Evaminus":
                if (PlayerInfo.eva == 3) break;
                PlayerInfo.eva = PlayerInfo.eva - 1;
                PlayerInfo.remain = PlayerInfo.remain + 1;
                tmp2 = PlayerInfo.remain.ToString();
                tmp1 = PlayerInfo.eva.ToString();
                evadingValue.text = tmp1;
                currentRemain.text = tmp2;
                break;
        }

    }

}
