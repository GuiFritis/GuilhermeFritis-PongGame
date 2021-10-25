using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;

    [Header("Keys")]
    [SerializeField]
    private KeyCode resetKey = KeyCode.R;

    [Header("Collisors")]
    [SerializeField]
    private BaseBall ball;
    [SerializeField]
    private Player[] players;

    private Player winner = null;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI message;
    [SerializeField]
    private GameObject menuUI;
    [SerializeField]
    private TextMeshProUGUI endMessage;

    [Space]
    public int maxScore = 100;

    private float timeToResetBall = 1f;

    [SerializeField]
    private StateMachine stateMachine;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(resetKey))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        ResetPlayers();
        ResetBallPosition();
    }

    private void ResetPlayers()
    {
        foreach (Player player in players)
        {
            player.score = 0;
            player.UpdateUI();
        }
    }

    public void StartGame()
    {
        menuUI.SetActive(false);
        message.text = "Press \"R\" to restart";
        ball.CanMove(true);
        winner = null;
        endMessage.gameObject.SetActive(false);
        endMessage.text = "";
    }

    public void SwitchStateResetingPosition()
    {
        StateMachine.Instance.ResetPosition();
    }

    public void ResetBallPosition()
    {
        ball.CanMove(false);
        ball.ResetBall();
        Invoke(nameof(AllowBallMove), timeToResetBall);
    }

    public void AllowBallMove()
    {
        ball.CanMove(true);
    }

    //usar o parâmetro player no futuro para exibir o nome do ganhador
    public void EndGame(Player winner)
    {
        this.winner = winner;
        stateMachine.SwitchState(State.END_GAME);
        HighScoreManager.Instance.SaveWinner(winner);
        ResetPlayers();
    }

    public void ShowMenu()
    {
        ball.CanMove(false);
        menuUI.SetActive(true);
        endMessage.text = winner.playerName+" is the winner!";
        endMessage.gameObject.SetActive(true);
    }

}
