﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;
    public float _Tiempo;

    private float _startingTime;
    private Transform _firePoint;

    public GameObject explosionEffect;
    public LineRenderer lineRenderer;

    void Awake()
    {
        _firePoint = transform.Find("Firepoint");
    }
    // Start is called before the first frame update
    void Start()
    {
        _startingTime = Time.time;
        //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity);

        //StartCoroutine("Disparos");
    }

    // Update is called once per frame
    void Update()
    {
        
           
        
    }
    public void Shoot()
    {
        if(bulletPrefab != null && _firePoint != null && shooter != null)
        {
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Bullet bulletComponent = myBullet.GetComponent<Bullet>();
            if(shooter.transform.localScale.x < 0f)
            {
                //Bala hacia la Izquierda
                bulletComponent.direction = Vector2.left;
            }
            else
            {
                bulletComponent.direction = Vector2.right;
            }
        }
       

    }
    
    public IEnumerator ShootWithRaycast()
    {
        if(explosionEffect != null && lineRenderer != null)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right);

            if (hitInfo)
            {
                //Example code
                //if (hitInfo.collider.tag == "Player"){
                // Transform player = hitInfo.transform;
                // player.GetComponent<PlayerHealth>().ApllyDamage(5);
                //}

                Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);

                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point + Vector2.right*100);
            }

            lineRenderer.enabled = true;
            yield return null;
            lineRenderer.enabled = false;
        }
    }
}
