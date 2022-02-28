using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberToolManager : MonoBehaviour
{
    [SerializeField] private LayerMask maskEnemyTrapdoor; // LayerMask for Trapdoor and Enemy
    [SerializeField] private GameObject upgradeBtn; // Button for upgrade Saber Tool
    [SerializeField] private GameObject bulletPrefab;

    public float range = 1.5f;

    private float timeShoot = 0;
    private Dictionary<string, int> cores; // Current count of cores
    private CoreSaberTool core = new CoreSaberTool();

    private Vector2 posShootZone; // The side the shotgun will shoot at
    private SaberToolInterface saberTool = new SaberToolLvl1(); // Current Level of Saber Tool
    void Start()
    {
        cores = new Dictionary<string, int>() { { core.GetType().Name, 0 } };
        CheckCore();
        timeShoot = Time.time;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (saberTool.GetTimeReload() > 0)
                if (Time.time - timeShoot > saberTool.GetTimeReload()) // Check time reload
                {
                    timeShoot = Time.time;
                    Shoot();
                }
                else
                {
                    Debug.Log("Reload " + (Time.time - timeShoot));
                }
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            // Shotgun shoot at left
            posShootZone = new Vector2(transform.position.x - saberTool.GetShootRange() / 2, transform.position.y);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            // Shotgun shoot at right
            posShootZone = new Vector2(transform.position.x + saberTool.GetShootRange() / 2, transform.position.y);
        }
    }

    public void SetCore(string core, int count)
    {
        if (cores.ContainsKey(core))
            cores[core] += count;
        else
            cores[core] = count;
        CheckCore();
    }

    public void UpgradeSaberTool()
    {
        int countCores = cores[core.GetType().Name];
        cores[core.GetType().Name] -= saberTool.upgradeCores;
        saberTool = saberTool.Upgrade(countCores); // Assignment new Level of Saber Tool
        bulletPrefab.GetComponent<Bullet>().damage = saberTool.Attack();
        Debug.Log("Damage " + saberTool.GetType().Name + " - " + saberTool.Attack());
        CheckCore();
    }

    private void CheckCore()
    {
        //Check count cores to enable button
        if (saberTool.Upgrade(cores[core.GetType().Name]) != null)
            upgradeBtn.SetActive(true);
        else
            upgradeBtn.SetActive(false);
    }

    private void Shoot()
    {
        GameObject gameObject = bulletPrefab as GameObject;
        Vector2 posBullet = new Vector2();

        if (posShootZone.x < transform.position.x)
        {
            posBullet = new Vector2(transform.position.x - transform.localScale.x * 2, transform.position.y);
            gameObject.GetComponent<Bullet>().speed = -25f;
        }
        else if (posShootZone.x > transform.position.x)
        {
            posBullet = new Vector2(transform.position.x + transform.localScale.x * 2, transform.position.y);
            gameObject.GetComponent<Bullet>().speed = 25f;
        }

        gameObject.GetComponent<Bullet>().damage = saberTool.Attack();
        Instantiate(gameObject, posBullet, new Quaternion());


        /*Vector2 size = new Vector2(saberTool.GetShootRange(), 1f);
        Collider2D collider = Physics2D.OverlapBox(posShootZone, size, 0, maskEnemyTrapdoor); // Get near GameObject (Enemy or Trapdoor)
        Debug.Log(collider);
        if (collider.GetComponent<Enemy>() != null) // If GameObject - Enemy, then attack him
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Damage(saberTool.Shoot());
        } else if (collider.GetComponent<Door>()) // Destroy door
        {
            collider.GetComponent<Door>().DestroyDoor();
        }*/
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 
            saberTool.GetRange() * range, maskEnemyTrapdoor); // Get all enemy and door GameObjects in radius
        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.transform.GetComponent<Enemy>(); // If GameObject - Enemy, then we attack him
            if (enemy != null)
                enemy.Damage(saberTool.Attack());
        }
    }
}
