using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Ground;
    public GameObject BackGround;
    public GameObject Ground2;
    public GameObject BackGround2;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject EnemySpecial;
    public Text Texto;
    public Text Texto2;
    public int DirectionX = -1;
    private int speed = 5;
    float Times = 340;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateEnemy",2);
        Invoke("CreateSpecialEnemy", 7);
    }

    // Update is called once per frame
    void Update()
    {
        Times = Times - Time.deltaTime;
        Texto2.text = "TIEMPO: "+Times.ToString("F0");
        if (Player != null)
        {
            if (Player.GetComponent<PlayerController>().Horizontal == 1)
            {
                Ground.transform.position = new Vector2(Ground.transform.position.x + (speed + 5) * DirectionX * Time.deltaTime, -1.7295f);
                BackGround.transform.position = new Vector2(BackGround.transform.position.x + (speed + 5) * DirectionX * Time.deltaTime, 6.73f);
                Ground2.transform.position = new Vector2(Ground2.transform.position.x + (speed + 5) * DirectionX * Time.deltaTime, -1.7295f);
                BackGround2.transform.position = new Vector2(BackGround2.transform.position.x + (speed + 5) * DirectionX * Time.deltaTime, 6.73f);
            }
            else
            {
                Ground.transform.position = new Vector2(Ground.transform.position.x + speed * DirectionX * Time.deltaTime, -1.7295f);
                BackGround.transform.position = new Vector2(BackGround.transform.position.x + speed * DirectionX * Time.deltaTime, 6.73f);
                Ground2.transform.position = new Vector2(Ground2.transform.position.x + speed * DirectionX * Time.deltaTime, -1.7295f);
                BackGround2.transform.position = new Vector2(BackGround2.transform.position.x + speed * DirectionX * Time.deltaTime, 6.73f);
            }
            Infinito();
        }
    }
    void Infinito()
    {
        if(Ground.transform.position.x <= -17.83 || BackGround.transform.position.x <= -17.83)
        {
            Ground.transform.position = new Vector2(17.75f,-1.7295f);
            BackGround.transform.position = new Vector2(17.75f, 6.73f);
        }
        if (Ground2.transform.position.x <= -17.83 || BackGround2.transform.position.x <= -17.83)
        {
            Ground2.transform.position = new Vector2(17.75f, -1.7295f);
            BackGround2.transform.position = new Vector2(17.75f, 6.73f);
        }
    }
    void CreateEnemy()
    {
        GameObject enemy = Instantiate(Enemy, new Vector3(10f, Random.Range(3.50f, -4.5f), 0), transform.rotation);
        Invoke("CreateEnemy", 2);
    }
    void CreateSpecialEnemy()
    {
        GameObject enemy2 = Instantiate(EnemySpecial, new Vector3(10f, Random.Range(3.50f, -4.5f), 0), transform.rotation);
        Invoke("CreateSpecialEnemy", 9);
    }
}
