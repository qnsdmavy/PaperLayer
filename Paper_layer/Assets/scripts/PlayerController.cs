using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float walkForce = 6000.0f;
    float maxWalkSpeed = 2.0f;
    bool clear = false;
    int key = 0;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
  
    }

    void Update()
    {
        // 플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 플레이어의 속도에 맞춰 애니메이션 속도를 변경
        this.animator.speed = speedx / 100.0f;
    }
    
    public void GameClear()
    {
        key = 1;
        Invoke("NextScene", 3);
       
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Scene2");
    }
}
