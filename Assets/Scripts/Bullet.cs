using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float lifeTime = 3;
    public Vector2 damageRange = new Vector2(10f, 20f);
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) return;
        // todo: deal damage
        //print($"Hit {collision.gameObject.name} for {Random.Range(damageRange.x, damageRange.y)} damage");
        
        var damage = Random.Range(damageRange.x, damageRange.y);
        DamageIndicatorManager.instance.ShowDamageIndicator((int)damage, transform.position);
        
        Destroy(gameObject);
    }
}
