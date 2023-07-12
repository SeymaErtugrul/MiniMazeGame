using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public List<Sprite> SpriteKuzey;

    public List<Sprite> SpriteKuzeyDogu;

    public List<Sprite> SpriteGuney;

    public List<Sprite> SpriteGuneyDogu;

    public List<Sprite> SpriteDogu;

    public List<Sprite> SpriteBati;

    public float WalkSpeed;

    public float FrameRate;


    public float idleTime;

    Vector2 direction;
    void Update()
    {
      
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (direction.x != 0 && direction.y != 0)
        {
            // Yatay ve dikey girişin ikisine birden basılırsa, sadece bir yöne hareket etmesini sağlar
            direction.x = Mathf.Round(direction.x);
            direction.y = 0;
        }

        rb.velocity = direction * WalkSpeed;

        List<Sprite> directionSprites = GetSpriteDirection();
        if (directionSprites != null)
        {
            float playTime = Time.time - idleTime;
            int totalFrames = (int)(playTime * FrameRate);
            int frame = totalFrames % directionSprites.Count;
            spriteRenderer.sprite = directionSprites[frame];
        }

        else
        {
            idleTime = Time.time;
        }
    }

 
    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> SelectedSprites = null;

        if (direction.y > 0) //kuzey
        {

                SelectedSprites = SpriteKuzey;   

        }

        else if (direction.y < 0)//güney
        {

                SelectedSprites = SpriteGuney;
         
        }
        else
        {

            if (direction.x > 0) //doğu veya batı
            {
                SelectedSprites = SpriteDogu;
            }

            else if(direction.x < 0)
            {
                SelectedSprites = SpriteBati;
            }
        }
        return SelectedSprites;

    }

}
