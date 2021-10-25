using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBall : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed = new Vector3(2.5f, 2.5f);
    private Vector3 startSpeed;
    private bool canMove = false;

    [SerializeField]
    private Image image;

    [Header("Tags")]
    [SerializeField]
    private string playerTag = "Player";
    [SerializeField]
    private string borderHeightTag = "SideBorder";

    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
        startSpeed = speed;
    }

    private void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(speed * Time.deltaTime * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        image.color = RandomizeColor();
        if(collision.gameObject.tag == playerTag)
        {
            speed.x *= -1.02f;
        }
        if (collision.gameObject.tag == borderHeightTag)
        {
            speed.y *= -1.02f;
        }
    }

    public void ResetBall()
    {
        transform.position = new Vector3(startPosition.x, (startPosition.y + Random.Range(-5f, 5f)), 0);
        speed = startSpeed;
        speed.x *= Random.Range(0, 2) == 1 ? 1 : -1;
        speed.y *= Random.Range(0, 2) == 1 ? 1 : -1; ;
    }

    public void CanMove(bool state)
    {
        canMove = state;
    }

    public Color RandomizeColor()
    {
        return new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f));
    }
}
