using UnityEngine;

class CoreSaberTool: MonoBehaviour, Core 
{
    public LayerMask player { get; set; }
    public Color color { get; set; }

    [SerializeField] private LayerMask mask;

    private void Start()
    {
        player = mask;
    }

    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.2f, player); // We check the Player Collider
        if (collider != null)
        {
            //collider.GetComponent<PlayerController>().SetCore(); // Set Core for PlayerController
            collider.GetComponent<PlayerController>().SetCore(this.GetType().Name, 1); // Set Core for PlayerController
            collider.GetComponent<SaberToolManager>().SetCore(this.GetType().Name, 1); // Set Core for Dictionary of SaberToolManager
            Destroy(transform.gameObject);
        }
    }
}
