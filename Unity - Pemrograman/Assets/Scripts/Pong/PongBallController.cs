﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongBallController : MonoBehaviour
{
    Text scoreUIP1;
    Text scoreUIP2;
    int scoreP1;
    int scoreP2;
    GameObject panelSelesai;
    Text txPemenang;
    AudioSource audio;

    public int force;
    Rigidbody2D rigid;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);

        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();

        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlayOneShot(hitSound);
        if(collision.gameObject.name == "TepiKanan")
        {
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
            scoreP1 += 1;
            TampilkanScore();
            if(scoreP1 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent <Text>();
                txPemenang.text = "Player Biru Pemenang!";
                Destroy(gameObject);
                return;
            }
        }
        if (collision.gameObject.name == "TepiKiri")
        {
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
            scoreP2 += 1;
            TampilkanScore();
            if (scoreP2 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Merah Pemenang!";
                Destroy(gameObject);
                return;
            }
        }

        if (collision.gameObject.name == "Pemukul1" || collision.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force);
        }
    }

    void TampilkanScore()
    {
        Debug.Log("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }
}
