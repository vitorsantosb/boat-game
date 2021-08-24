using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    private const float maxSpeed = 20f;
    
    [SerializeField] private bool normalizeSpeed;
    
    public float GetSpeed => speed;

    public bool Normalize => normalizeSpeed;

    private Rigidbody2D myBody;
    
    void Awake()
    {
        if (speed >= maxSpeed)
            speed = maxSpeed;
        myBody = GetComponent<Rigidbody2D>();
    }
    
    /// <summary>
    /// Movimento sem usar o RigidBody
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="normalize"></param>
    /// <returns></returns>
    public Vector2 Move(Vector2 dir, bool normalize)
    {
        myBody.velocity = normalize ? (dir * speed).normalized : dir * speed;
        
        return myBody.velocity * Time.fixedDeltaTime;
    }
    
    public Vector2 Move(float x, float y, bool normalize)
    {
        Vector2 movement = new Vector2(x, y);
        
        //movement = movement / movement.magnitude;
        myBody.velocity = normalize ? movement.normalized * speed : movement * speed;
        
        return myBody.velocity * Time.fixedDeltaTime;
    }

    public Vector2 SineWaveMove(Vector2 dir, float amp, bool normalize)
    {
        float xSin = Mathf.Sin(Time.time + dir.x) * amp;
        float ySin = Mathf.Cos(Time.time + dir.y) * amp;

        myBody.velocity = normalize ? (dir * (xSin * ySin)).normalized : dir * (xSin * ySin);

        return myBody.velocity * Time.fixedDeltaTime;
    }

    public Vector2 SineWaveMove()
    {
        Vector2 sineDir = new Vector2(Mathf.Sin(Time.time), 0f);

        myBody.velocity = sineDir;

        return myBody.velocity;
    }
}
