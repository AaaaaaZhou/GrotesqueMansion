using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    CardGenerating,
    PlayCard,
    EnemyRound,
    End
}


public class GameController : MonoBehaviour {

    public static GameController _instance;

    public GameState gamestate = GameState.CardGenerating;
    public float cycleTime = 60f;
    private float timer = 0;
    private int cardNumbers = 4;

    private string CurrentPlayerName = "Player";
    private CardGenerator cardGenerator;
    public MyCard mycard;
    public Player player;
    public Enemy enemy;

    public int roundIndex; // 表示流转次数，当前回合数
    private bool isPlayerWin;
    public delegate void OnNewRoundEvent(string playerName); // 当出牌方改变的时候
    public event OnNewRoundEvent onNewRound;

    // 用于控制菜单
    private bool onMenu;
    private UILabel restart;
    private UILabel quit;

    private bool readyToLeave;

	// Use this for initialization
	void Start ()
    {
        onMenu = false;
        readyToLeave = false;
        restart.alpha = 0;
        quit.alpha = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (readyToLeave)
        {
            System.Threading.Thread.Sleep(3000);
            if (isPlayerWin)
            {
                Application.LoadLevel(PlayerInfo.floor);
            }
            else
            {
                PlayerInfo.RefreshMap();
                Application.LoadLevel(0);
            }
        }

        // 菜单控制
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onMenu = !onMenu;
        }
        if (onMenu)
        {
            restart.alpha = 1;
            quit.alpha = 1;
        }
        else
        {
            restart.alpha = 0;
            quit.alpha = 0;
        }

        // 回合控制
		if(gamestate == GameState.PlayCard)
        {
            timer += Time.deltaTime;
            if(timer > cycleTime)
            {
                // 强制回合转换
                TransformPlayer();
            }
        }
        if (enemy.isDead())
        {
            isPlayerWin = true;
            gamestate = GameState.End;
        }
        else if (player.isDead())
        {
            isPlayerWin = false;
            gamestate = GameState.End;
        }
        if(gamestate == GameState.End)
        {
            this.transform.parent.Find("GameOver").GetComponent<GameOver>().ShowResult(isPlayerWin);
            readyToLeave = true;
        }
	}

    private void Awake()
    {
        _instance = this;
        this.cardGenerator = this.GetComponent<CardGenerator>();
        this.mycard = this.transform.parent.Find("MyCard").GetComponent<MyCard>();
        this.player = this.transform.parent.Find("Player").GetComponent<Player>();
        this.enemy = this.transform.parent.Find("Enemy").GetComponent<Enemy>();
        this.restart = this.transform.Find("Restart").GetComponent<UILabel>();
        this.quit = this.transform.Find("Quit").GetComponent<UILabel>();
        //gamestate = GameState.CardGenerating;
        StartCoroutine(GenerateCardForPlayer());
    }

    public void TransformPlayer()
    {
        timer = 0;
        if(CurrentPlayerName == "Player")
        {
            this.transform.parent.Find("MyCard").GetComponent<MyCard>().RemoveAll();
            CurrentPlayerName = "Enemy";
        }
        else
        {
            CurrentPlayerName = "Player";
            StartCoroutine(GenerateCardForPlayer());
        }
        roundIndex++;
        onNewRound(CurrentPlayerName);
    }
    
    private IEnumerator GenerateCardForPlayer()
    {
        
        GameObject cardGo;
        for(int i = 0; i < cardNumbers; i++)
        {
            // 默认发4张
            cardGo = cardGenerator.RandomGenericCard();
            yield return new WaitForSeconds(0.5f);
            // 把这个卡牌放到卡牌管理里面
            mycard.GetCard(cardGo);
        }
        gamestate = GameState.PlayCard;
        timer = 0;
    }

    public void OnQuitButtonDown()
    {
        if (onMenu)
        {
            Application.Quit();
        }
    }

    public void OnRestartButtonDown()
    {
        if (onMenu)
        {
            PlayerInfo.RefreshMap();
            Application.LoadLevel(0);
        }
    }

}
