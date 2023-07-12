using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    SpawnObjects spawnobj;
    int coin;
    public GameObject door;
    public GameObject DoorPanel;

  

    private AudioSource audioSource;
    private void Start()
    {
        spawnobj = FindObjectOfType<SpawnObjects>();
        audioSource = GetComponent<AudioSource>();  
        door = GameObject.Find("Door");
        door.SetActive(false);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {
            audioSource.Play();
            spawnobj.ReturnToPool(collision.gameObject);

            coin++;
            if (coin == ((spawnobj.poolSize) * 2)-1)  //pool size'ın 2 katına ulaştığında çıkış kapısının aktif edilmesi
            {
                door.SetActive(true);
                StartCoroutine("DoorPanelIE");
              
            }
        }
    }
    IEnumerator DoorPanelIE()
    {
        DoorPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        DoorPanel.SetActive(false);

    }

}
