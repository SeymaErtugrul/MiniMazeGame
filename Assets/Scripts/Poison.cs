using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Poison : MonoBehaviour
{
    public AudioClip collisionSound;

    private AudioSource audioSource;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("PoisonCherry");
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
  
    IEnumerator PoisonCherry()  //zamanı yavaşlatır
    {
        gameObject.transform.DOScale(new Vector3(5, 5, 0), 2f);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(3f);
        gameObject.transform.DOScale(new Vector3(1, 1, 1), 2f);
        Time.timeScale = 1f;
    }
}
