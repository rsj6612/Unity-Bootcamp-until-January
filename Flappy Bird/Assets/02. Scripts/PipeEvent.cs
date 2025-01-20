using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeEvent : MonoBehaviour
{
    public GameObject endUI;
    public SoundManager soundManager;
  public void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
        endUI.SetActive(true);
        soundManager.OnEventSound(3);
        soundManager.OnStop();
        //부딪히면 엔딩 사운드 추가, 메인 사운드 종료, 메인으로 돌아가거나 다시 게임하게 만들어야할듯
    }
  }
  
}
