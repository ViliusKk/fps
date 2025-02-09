using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float lifeTime = 3;
    public Vector2 damageRange = new Vector2(10f, 20f);
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void onCollisionEnter2D(Collision2D collision)
    {
        // todo: deal damage
        //print($"Hit {collision.gameObject.name} for {Random.Range(damageRange.x, damageRange.y)} damage");
        
        var damage = Random.Range(damageRange.x, damageRange.y);
        DamageIndicatorManager.instance.ShowDamageIndicator((int)damage, transform.position);
        
        Destroy(gameObject);
    }
}
