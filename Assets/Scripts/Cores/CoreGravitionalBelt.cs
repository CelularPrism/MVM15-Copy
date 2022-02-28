using UnityEngine;

public class CoreGravitionalBelt : MonoBehaviour, Core
{
    [SerializeField] private LayerMask mask;

    public LayerMask player { get; set; }
    public Color color { get; set; }

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
