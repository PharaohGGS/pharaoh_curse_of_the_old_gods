using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDamage : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private FadeToBlack _fade;

    [Tooltip("What layer is the Moving Block ?")]
    public LayerMask whatIsMovingBlock;
    [Tooltip("What layer is the Spike ?")]
    public LayerMask whatIsSpike;
    [Tooltip("Transform at which the player will respawn")]
    public Transform DEBUGRespawnPoint;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _fade = FindObjectOfType<FadeToBlack>();

        if (DEBUGRespawnPoint == null)
        {
            GameObject go = new GameObject();
            go.name = "DefaultRespawnPoint";
            go.transform.position = transform.position;
            DEBUGRespawnPoint = go.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Block falling on the player
        if (whatIsMovingBlock == (whatIsMovingBlock | (1 << collision.gameObject.layer)) && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < -0.1f)
            DamageAndRespawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (whatIsSpike == (whatIsSpike | (1 << collision.gameObject.layer)))
            DamageAndRespawn();
    }

    private void DamageAndRespawn()
    {
        // Damage player and spawn him back to spawnpoint
        _fade.Fade();

        //damage player
        Debug.Log("PlayerDamage : need to implement the health component to damage (1) the player");
        _rigidBody.position = DEBUGRespawnPoint.position;
    }

}