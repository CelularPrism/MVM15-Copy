using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int PlayerCurrentHP;
    [Header("Movement variables")]
    public float movementSpeed;
    public float jumpForce;

    [Header("Health System")]
    public int maxHealth;

    private float _horizontal;
    private float _lowMovementSpeed;
    private float _normalMovementSpeed;
    private int _playerHealth;

    private Dictionary<string, int> _dictCore;

    [Header("Inventory")]
    [SerializeField] private GameObject inventoryPanel;
    private Dictionary<DataLoot, int> _listLoot;

    private bool _jumping;

    private float _timeDashLeft; // Time the first touch on "A"
    private float _timeDashRight; // Time the first touch on "D"
    private float _dashTime = 0.5f;

    private float timeStun = -1f;
    private bool isStun = true;

    private Walk _walk;
    private Jump _jump;
    private Dash _dash;
    private Crouch _crouch;
    private Collision _collision;
    private Rigidbody2D _rigidbody2D;

    private HealthSystem _playerHealthSystem;


    void Start()
    {
        _walk = GetComponent<Walk>();
        _jump = GetComponent<Jump>();
        _dash = GetComponent<Dash>();
        _crouch = GetComponent<Crouch>();
        _collision = GetComponent<Collision>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        //_playerHealthSystem = new HealthSystem(maxHealth);
        _playerHealthSystem = GetComponent<HealthSystem>();
        _playerHealthSystem.SetHealth(maxHealth);

        //_playerHealth = maxHealth;
        _lowMovementSpeed = movementSpeed / 2;
        _normalMovementSpeed = movementSpeed;

        _listLoot = new Dictionary<DataLoot, int>();
        _dictCore = new Dictionary<string, int>();
    }

    void Update()
    {
        //gets horizontal axis (Like a buttons A or D,keyboard arrows or gamepad axis
        _horizontal = Input.GetAxisRaw("Horizontal");

        //Dash. If the player press A and time difference between the first and second touch < 0.5s
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            if (Time.time - _timeDashLeft < _dashTime)
            {
                movementSpeed *= _dash.Dashed();
            } else
            {
                _horizontal = Input.GetAxisRaw("Horizontal");
                _timeDashLeft = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            if (Time.time - _timeDashRight < _dashTime)
            {
                movementSpeed *= _dash.Dashed();
            }
            else
            {
                _horizontal = Input.GetAxisRaw("Horizontal");
                _timeDashRight = Time.time;
            }
        }

        //If the player presses the jump button, then the jump variable changes to true
        if (Input.GetButtonDown("Jump") && _collision.onGround && PauseMenu.gameIsPaused == false)
        {
            _jumping = true;
        }

        //Check healthsystem to work
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _playerHealthSystem.Damage(1);                     //Get damage
            _playerHealth = _playerHealthSystem.GetHealth();   
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _playerHealthSystem.Heal(1);                      // Heal player
            _playerHealth = _playerHealthSystem.GetHealth();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Player health - " + _playerHealth);   // Get current hp
        }
        if (Input.GetKeyDown(KeyCode.S)) // Crouch
        {
            _crouch.SeatDown();
            movementSpeed = _lowMovementSpeed;
        } else if (Input.GetKeyUp(KeyCode.S))
        {
            _crouch.StandUp();
            movementSpeed = _normalMovementSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && PauseMenu.gameIsPaused == false) // Open Inventory
        {
            if (inventoryPanel.activeSelf)
                inventoryPanel.SetActive(false);
            else
            {
                inventoryPanel.GetComponent<InventoryManager>().SetListLoot(_listLoot);
                inventoryPanel.GetComponent<InventoryManager>().SetCores(_dictCore);
                inventoryPanel.SetActive(true);
            }
        }
        PlayerCurrentHP = _playerHealth;
    }

    private void FixedUpdate()
    {
        if (Time.time > timeStun)
            isStun = false;

        if (!isStun)
            _walk.Walking(_rigidbody2D, _horizontal, movementSpeed);
        else
            _walk.Walking(_rigidbody2D, 0f, movementSpeed);
        movementSpeed = _normalMovementSpeed;

        
        if (_jumping && !isStun)
        {
            _jump.doJump(_rigidbody2D, jumpForce); //Calling the jump method
            _jumping = false;                      // return jumping bool to the false
        }
    }

    public void SetLoot(DataLoot dataLoot, int count)
    {
        if (_listLoot.ContainsKey(dataLoot))
            _listLoot[dataLoot] += count;
        else
            _listLoot[dataLoot] = count;
    }
 
    public void SetCore(string core, int count)
    {
        if (_dictCore.ContainsKey(core))
            _dictCore[core] += count;
        else
            _dictCore[core] = count;
    }

    public bool GetLoot(string loot, int count)
    {
        DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/" + loot);

        if (_listLoot.ContainsKey(dataLoot))
        {
            if (_listLoot[dataLoot] >= count)
            {
                _listLoot[dataLoot] -= count;
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public Dictionary<string, int> GetCore()
    {
        return _dictCore;
    }

    public void Stun(float time)
    {
        timeStun = time;
        _horizontal = 0;
        isStun = true;

    }
}
