using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] public float hp;
    public DamageSink damage;
    // Start is called before the first frame update
    void Start()
    {
        
        damage = gameObject.GetComponent<DamageSink>();
        damage.hp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(damage.destroyed)
        {
            OnDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletBehavior>())
        {
            BulletBehavior bubble = collision.gameObject.GetComponent<BulletBehavior>();
            damage.TakeDamage(bubble.damage);
        }
    }

    public void OnDestroy()
    {
        Debug.Log("Chest is Destroyed");
    }
}
