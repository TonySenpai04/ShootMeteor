using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public static EnemyLogic Instance;
    [SerializeField] public float Maxhp;
    [SerializeField] private float currentHp;
    [SerializeField] private Rigidbody2D rbEnemy;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject player;
  
    private void Start()
    {
        Instance=this;
        currentHp = Maxhp;
        rbEnemy= GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentHp -= 1;
        if (currentHp <= 0 || collision.tag=="Wall")
        {
            GameControllerUI.Instance.score += 1; 
            GetComponent<DropItem>().InstantiateLoot(transform.position);
            gameObject.SetActive(false);
            currentHp += Maxhp;
        }
        if (collision.tag == "Player")
        {
            PlayerHealth.instance.TakeDamage();
        }
    }
    private void Update()
    {
        if (GameControllerUI.Instance.TimeMinuate1 > 3)
        {
            Maxhp =5;
            
        }
         rbEnemy.velocity = Vector2.down * Speed;
       
    }

}
