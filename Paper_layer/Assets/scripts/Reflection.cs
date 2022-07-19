using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reflection : MonoBehaviour
{
    public GameObject whiteBackground;
    public GameObject blackBackground;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject title;

    public Sprite blackQ;
    public Sprite whiteQ;

    public GameObject QuitButton;

    public GameObject reflectionButton;

    int count = 0;

    void Start()
    {
        QuitButton.GetComponent<Image>().sprite = blackQ;
        whiteBackground.SetActive(true);
        player1.SetActive(true);
        blackBackground.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        title.SetActive(false);
    }

    // 반전 버튼
    public void ReflectionButton()
    {
        count++;
        switch (count) {
            case 0:
                QuitButton.GetComponent<Image>().sprite = blackQ;
                whiteBackground.SetActive(true);
                player1.SetActive(true);
                blackBackground.SetActive(false);
                player2.SetActive(false);
                player3.SetActive(false);
                title.SetActive(false);
                break;
            case 1:
                QuitButton.GetComponent<Image>().sprite = whiteQ;
                whiteBackground.SetActive(false);
                player1.SetActive(false);
                blackBackground.SetActive(true);
                player2.SetActive(true);
                player3.SetActive(false);
                title.SetActive(false);
                break;
            case 2:
                QuitButton.GetComponent<Image>().sprite = blackQ;
                whiteBackground.SetActive(true);
                player1.SetActive(false);
                blackBackground.SetActive(false);
                player2.SetActive(false);
                player3.SetActive(true);
                title.SetActive(false);
                break;
            case 3:
                QuitButton.GetComponent<Image>().sprite = whiteQ;
                whiteBackground.SetActive(false);
                player1.SetActive(false);
                blackBackground.SetActive(true);
                player2.SetActive(false);
                player3.SetActive(false);
                title.SetActive(true);
                Invoke("Quit", 5);
                break;
            default:
                break;
        }
    }
    // 종료 함수
    public void Quit()
    {
        Application.Quit();
    }
}
