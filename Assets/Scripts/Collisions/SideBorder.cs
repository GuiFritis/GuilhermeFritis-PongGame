using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBorder : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private string ballTag = "Ball";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ballTag)
        {
            ScorePoint();
            GameManager.Instance.ResetBallPosition();
        }
    }

    private void ScorePoint()
    {
        player.AddPoints();
        player.UpdateUI();
    }
}
