using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableCard :UIDragDropItem {

    protected override void OnDragDropRelease(GameObject surface)
    { 

        base.OnDragDropRelease(surface);
        if(surface != null && surface.tag == "FightCard")
        {
            // 检测到已经拖拽到发牌区域
            // 首先得到需要的水晶数
            int needCrystal = this.GetComponent<Card>().needCrystal;
            PlayerCrystal playerCrystal = GameObject.Find("PlayerCrystal").GetComponent<PlayerCrystal>();
            bool isSuccess = playerCrystal.GetCrystal(needCrystal);


            // 如果水晶数足够就可以发牌
            if(isSuccess)
            {
                this.transform.parent.GetComponent<MyCard>().RemoveCard(this.gameObject);
                surface.GetComponent<FightCard>().AddCard(this.gameObject);
                switch (this.GetComponent<UISprite>().spriteName)
                {
                    case "Attack":
                        this.transform.parent.parent.Find("Enemy").GetComponent<Enemy>().TakeDamage(D(2, 6));
                        break;
                    case "Attack2":
                        this.transform.parent.parent.Find("Enemy").GetComponent<Enemy>().TakeDamage(D(2, 3));
                        this.transform.parent.parent.Find("Player").GetComponent<Player>().PlusHP(D(2, 2));
                        break;
                    case "Pistol":
                        if (D(1, 100) > this.transform.parent.parent.Find("Player").GetComponent<Player>().accuracy)
                            break;
                        this.transform.parent.parent.Find("Enemy").GetComponent<Enemy>().TakeDamage(D(2, 8) + 2);
                        break;
                    case "AddEnergy":
                        if(this.transform.parent.parent.Find("Player").GetComponent<Player>().sanCount != 0)
                        {
                            this.transform.parent.parent.Find("Player").GetComponent<Player>().DecreaseSAN(D(1, 4));
                            this.transform.parent.parent.Find("PlayerCrystal").GetComponent<PlayerCrystal>().addCrystal(2);
                        }
                        break;
                    default:
                        break;
                }
            }
            // 如果水晶数不够就不可以发牌
            else
            {
                transform.parent.GetComponent<MyCard>().UpdateShow();
            }
        }
        else
        {
            transform.parent.GetComponent<MyCard>().UpdateShow();
        }
    }

    private int D(int n, int m)
    {
        int result = 0;
        for(int i = 0; i < n; i++)
        {
            result += Random.Range(1, m + 1);
            System.Threading.Thread.Sleep(1);
            
        }
        return result;
    }

}
