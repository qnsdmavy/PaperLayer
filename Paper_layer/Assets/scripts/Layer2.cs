using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Layer2 : MonoBehaviour
{
    public Transform lockLayer;
    public Transform woodLayer;
    public Transform doorLayer;

    public GameObject scenestart2;

    public GameObject lock0;
    public GameObject lock90;
    public GameObject lock180;
    public GameObject lock270;

    public Sprite icon0;
    public Sprite icon90;
    public Sprite icon180;
    public Sprite icon270;

    public GameObject icon;

    public Image wood;

    private int change = 0;

    public AudioSource LockOn;

    void Start()
    {
        icon.GetComponent<Image>().sprite = icon0;
        LockOn = GetComponent<AudioSource>();
        lock0.SetActive(true);
        lock90.SetActive(false);
        lock180.SetActive(false);
        lock270.SetActive(false);
        Invoke("StartBackground", 2);
    }

    // 레이어 순서 변경 함수
    public void ChangeLayer2()
    {
        lockLayer.SetSiblingIndex(Central.firstIndex);
        woodLayer.SetSiblingIndex(Central.secondIndex);
        doorLayer.SetSiblingIndex(Central.thirdindex);
        change++;
        change = change % 4;
        rotate(change);
        if (doorLayer.GetSiblingIndex() < woodLayer.GetSiblingIndex())
        {
            if(woodLayer.GetSiblingIndex() < lockLayer.GetSiblingIndex())
            {
                if(lock0.activeSelf == true)
                {

                    Invoke("ClearMotion", 0.5f);

                }
            }
        }
       
    }

    // 초반 배경 제거 함수
    public void StartBackground()
    {
        scenestart2.SetActive(false);
    }

    // 나무 오브젝트 페이드 아웃 함수
    public void ClearMotion()
    {
        LockOn.Play();
        Color color = wood.color;
        for(float i = 1.0f; i>=0.0f; i -= 0.1f)
        {
            color.a = i;
            wood.color = color;
        }
        BroadcastMessage("fall");
        Invoke("ChangeScene3", 2);
    }

    // 오브젝트 회전 함수
    public void rotate(int change)
    {
        switch (change) {
            case 0:
                icon.GetComponent<Image>().sprite = icon0;
                lock0.SetActive(true);
                lock90.SetActive(false);
                lock180.SetActive(false);
                lock270.SetActive(false);
                break;
            case 1:
                icon.GetComponent<Image>().sprite = icon90;
                lock0.SetActive(false);
                lock90.SetActive(true);
                lock180.SetActive(false);
                lock270.SetActive(false);
                break;
            case 2:
                icon.GetComponent<Image>().sprite = icon180;
                lock0.SetActive(false);
                lock90.SetActive(false);
                lock180.SetActive(true);
                lock270.SetActive(false);
                break;
            case 3:
                icon.GetComponent<Image>().sprite = icon270;
                lock0.SetActive(false);
                lock90.SetActive(false);
                lock180.SetActive(false);
                lock270.SetActive(true);
                break;
        }

    }

    // 다음 씬
    public void ChangeScene3()
    {
        SceneManager.LoadScene("Scene3");
    }
}
