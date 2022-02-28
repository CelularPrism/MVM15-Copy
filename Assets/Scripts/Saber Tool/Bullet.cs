using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    public int damage;

    private void Update()
    {
        Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, Physics2D.AllLayers);
        if (collider.Length != 0)
        {
            if (collider[0].GetComponent<Enemy>() != null)
            {
                Enemy enemy = collider[0].GetComponent<Enemy>();
                Debug.Log("Damage Enemy - " + damage);
                enemy.Damage(damage);
            }
            else if (collider[0].GetComponent<Door>() != null)
            {
                Door door = collider[0].GetComponent<Door>();
                door.DestroyDoor();
            }
            Destroy(transform.gameObject);
        }

        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x + speed * Time.deltaTime, pos.y);
    }
}
