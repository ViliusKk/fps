using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageIndicator : MonoBehaviour
{
    public TextMeshProUGUI damageText;
    public float lifetime = 1f;
    public Vector2 speedRange = new Vector2(1f, 3f);
    
    private float speed;

    void Start()
    {
        speed = Random.Range(speedRange.x, speedRange.y);
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
