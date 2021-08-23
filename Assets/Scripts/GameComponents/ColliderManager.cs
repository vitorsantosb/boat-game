using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderManager : MonoBehaviour
{
    
    /*;
         OnCollisionEnter2D(Collision2D other, string tagName, string action)
         @param = other = objeto a ser colidido
         @param = tagname = tag do objeto colidido
         @param = action = ação a ser executada
    */
    
    [SerializeField] private bool useCollisionEvents, useTriggerEvents;
    [SerializeField] private string otherObjTag;
    [SerializeField] private UnityEvent collisionActionEvents, triggerActionEvents;
    
    
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if ((useCollisionEvents) && other.gameObject.CompareTag(otherObjTag))
        {
            collisionActionEvents?.Invoke();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (useTriggerEvents && other.gameObject.CompareTag(otherObjTag))
        {
            other.GetComponent<IHit>()?.DamageHit(10f);
            triggerActionEvents?.Invoke();
        }
    }
}
