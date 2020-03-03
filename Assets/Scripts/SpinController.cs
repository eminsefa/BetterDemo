using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinController : MonoBehaviour
{
    public GameObject wheel;
    public float power = 400f;
    public bool buttonPressed = false;
    bool playerCanMove = false;
    public Player player;
    public GameObject text;
    public Text coinText;
    public needle needle;
    int coin = 0;
    public void SpinButtonTapped()
    {
        if(!buttonPressed)
        {            
            float i = Random.Range(1, 7);
            wheel.GetComponent<Rigidbody>().AddTorque(new Vector3(0,-1f,0) * i * power);
        }
    }

    public void QuitButtonTapped()
    {
        Application.Quit();
    }

    void Update()
    {
        coinText.text = "Coin=" + coin.ToString();
        if (wheel.GetComponent<Rigidbody>().angularVelocity.y >= 0f)
        {
            wheel.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            buttonPressed = false;
            text.SetActive(true);
            MovePlayer();
        }
        else
        {
            buttonPressed = true;
            wheel.GetComponent<Rigidbody>().angularVelocity += new Vector3(0, 0.04f, 0);
            text.SetActive(false);
            playerCanMove = true;
        }
    }
    void MovePlayer()
    {
        if(playerCanMove)
        {
            needle.DrawRay();
            for (int i = 0; i < needle.number; i++)
            {
                player.Move();
                coin += 10;
            }
            playerCanMove = false;
        }
    }
}
