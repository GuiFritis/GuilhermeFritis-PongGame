using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    public string playerName;

    [Header("Movement")]
    [SerializeField]
    private KeyCode moveUp = KeyCode.UpArrow;
    [SerializeField]
    private KeyCode moveDown = KeyCode.DownArrow;

    [Space]
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private Rigidbody2D rigdbody;
    [SerializeField]
    private Image uiPlayer;

    [Header("Points")]
    public int score;

    [Space]
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        score = 0;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(moveUp))
        {
            rigdbody.MovePosition(transform.position + transform.up * speed);
        } else if (Input.GetKey(moveDown))
        {
            rigdbody.MovePosition(transform.position + transform.up * -speed);
        }
    }

    public void setName(string name)
    {
        this.playerName = name;
    }

    public void AddPoints()
    {
        score += 10;
        CheckMaxPoints();
    }

    public void UpdateUI()
    {
        scoreText.text = score.ToString();
    }

    private void CheckMaxPoints()
    {
        if(score >= GameManager.Instance.maxScore)
        {
            GameManager.Instance.EndGame(this);
        }
    }

    public void ChangeColor(Color color)
    {
        uiPlayer.color = color;
    }

}
