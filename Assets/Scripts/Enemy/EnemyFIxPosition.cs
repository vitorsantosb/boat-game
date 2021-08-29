using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyFIxPosition : MonoBehaviour
{
    /*
    void ShootRay(Vector2 dir, int dist)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.Lerp(-dir,dir, dist), dist, enemyLayer);
        
        if (hit.collider != null)
        {
            float distBtw = Mathf.Abs(hit.point.x - transform.position.x);
            
            transform.DOBlendableMoveBy(Vector2.Lerp(Vector2.left, Vector2.right, distBtw) * .65f, Random.Range(.5f,1f));
        }
    }
    */
    //public bool isInside;

    private Damage dmg;

    private void Start()
    {
        dmg = GetComponent<Damage>();
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     
    //     if (other.CompareTag("Enemy"))
    //     {
    //         dmg.DamageHit(100);
    //     }
    // }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            //Tween otherBoatSteer = other.transform.DOBlendableMoveBy(Vector3.right, 1f);
            //yield return new WaitForSeconds(otherBoatSteer.Duration());
            //transform.DOBlendableMoveBy(Vector3.left * .65f, 1f);
            
            float to_distance = 2;
            // float x = gameObject.transform.position.x;
            // x += to_distance + Time.deltaTime;
            
            //other.transform.DOBlendableMoveBy(Vector3.right, 1f);
           
            transform.DOBlendableMoveBy(Vector3.right * 2, to_distance);

        }
    }
}
