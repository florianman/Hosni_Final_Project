﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform bullet;
    public int damagetaken;
    bool shooting;
    public float bulletSpeed;
    private float yFire, xFire;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }



    void shoot()
    {
        if (Input.GetButtonDown("Fire1") && !shooting)
        {
            shooting = true;
            xFire = player.position.x;
            yFire = player.position.y;
            transform.position = new Vector2(xFire, yFire);

        }

        if (shooting)
        {
            //bullet.position = new Vector2(xFire, yFire);
            transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
            //Deal damage if reaches the enemy 
            //if bullet damages
            if (transform.position.y > 4.5f)
            {
                transform.position = new Vector2(player.position.x, -4.25f);
                shooting = false;
            }
        }

        else
        {
            transform.position = player.position;
        }




    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {


            //other.gameObject.GetComponent<EnemiesHealth>().Hurtenemies(damagetaken);
            Destroy(other.gameObject);
            transform.position = player.position;
            shooting = false;

            //Destroy(gameObject);
        }
    
    
         if (other.gameObject.tag == "UFO")
        {
            other.gameObject.GetComponent<EnemiesHealth>().Hurtenemies(damagetaken);
            //Destroy(other.gameObject);
            //Destroy(gameObject);

            transform.position = player.position;
            shooting = false;

            //Destroy(gameObject);
        }
    
    
    
    }
    


}


