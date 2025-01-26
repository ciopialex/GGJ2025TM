using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] public float hp;
    public DamageSink damage;
    public ChestOpening openChest;
    public ClosedChest closedChest;
    // Start is called before the first frame update
    void Start()
    {
        
        damage = gameObject.GetComponent<DamageSink>();
        damage.hp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletBehavior>())
        {
            BulletBehavior bubble = collision.gameObject.GetComponent<BulletBehavior>();
            damage.TakeDamage(bubble.damage);
            Destroy(bubble.gameObject);
            if (damage.destroyed)
            {
                OnDestroy();
            }
        }
    }

    public void OnDestroy()
    {
        Debug.Log("Chest is Destroyed");
        openChest = GetComponentInChildren<ChestOpening>(true);
        if(openChest!=null)
        {
            openChest.gameObject.SetActive(true);
            AudioManager.Instance.PlaySound("ChestOpen");
        }

        closedChest = GetComponentInChildren<ClosedChest>();
        if(closedChest!=null)
        {
            closedChest.DestroyYourselfNOW();
        }

    }
}
