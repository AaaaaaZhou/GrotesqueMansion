using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Explorer {

    public GameObject cardPrefab;
    public Transform fromCard;
    public Transform toCard;
    private UISprite enemyCard;

    private float transformTime = 1f;
    private float showTime = 0.5f;
    private float alphaTIme = 0.5f;
    private float timer = 0;
    private bool isShow = false;

    private void Awake()
    {
        maxHP = 60;
        minHP = 0;
        sprite = this.GetComponent<UISprite>();
    }

    // Use this for initialization
    private void Start ()
    {
        //string explorerName = PlayerPrefs.GetString("Enemy");
        hpCount = maxHP;
        string explorerName = "hero2";
        sprite.spriteName = explorerName;
        GameController._instance.onNewRound += this.OnNewRound;
    }

    private void Update()
    {
        if (isShow)
        {
            timer += Time.deltaTime;
            if (timer >= alphaTIme + showTime + transformTime)
            {
                timer = 0;
                isShow = false;
                enemyCard.alpha = 0;
                if(GameController._instance.gamestate != GameState.End)
                {
                    GameController._instance.TransformPlayer();
                }
            }
            else if(timer >= showTime + transformTime)
            {
                enemyCard.alpha = (alphaTIme + +showTime + transformTime - timer) / alphaTIme;
            }
        }
    }

    public void OnNewRound(string playerName)
    {
        if (playerName == "Enemy")
        {
            PlayCard("Attack");
            //GameController._instance.TransformPlayer();
        }
    }

    private void PlayCard(string cardName)
    {
        GameObject go = NGUITools.AddChild(this.gameObject, cardPrefab);
        go.transform.position = fromCard.position;
        enemyCard = go.GetComponent<UISprite>();
        enemyCard.spriteName = cardName;
        isShow = true;
        iTween.MoveTo(go, toCard.position, transformTime);
        switch (cardName)
        {
            case "Attack":
                enemyCard.transform.Find("cardName").GetComponent<UILabel>().text = "攻击";
                enemyCard.transform.Find("cardCaption").GetComponent<UILabel>().text = "造成1D12伤害, 丢失1D3点理智值";
                enemyCard.transform.Find("needCrystal").GetComponent<UILabel>().text = "2";
                this.transform.parent.Find("Player").GetComponent<Player>().TakeDamage(D(1, 12));
                this.transform.parent.Find("Player").GetComponent<Player>().DecreaseSAN(D(1, 3));
                break;
            default:
                break;
        }
    }

    public void TakeDamage(int damage)
    {
        hpCount -= damage;
        if (hpCount <= minHP)
        {
            // Game Over
            hpCount = 0;
        }
        this.transform.parent.Find("EnemyInformation").Find("hpInformation").GetComponent<UIControlEnemy>().UpdatShow(hpCount, maxHP);
    }

    private int D(int n, int m)
    {
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            result += Random.Range(1, m + 1);
            System.Threading.Thread.Sleep(1);

        }
        return result;
    }

}
