using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbBullet;
    [SerializeField] private float Speed;
    [SerializeField] private AudioClip Audio;

    private void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rbBullet.velocity = Vector2.up * Speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(Audio, transform.position);
          //  gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
