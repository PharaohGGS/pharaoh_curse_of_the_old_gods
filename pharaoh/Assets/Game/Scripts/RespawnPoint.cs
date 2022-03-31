using UnityEngine;

public class RespawnPoint : MonoBehaviour
{

    private PlayerRespawn _playerRespawn;

    public LayerMask whatIsPlayer;
    public Transform respawnPoint;

    private void Awake()
    {
        _playerRespawn = FindObjectOfType<PlayerRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (whatIsPlayer == (whatIsPlayer | 1 << collision.gameObject.layer))
        {
            //Binds this respawn point to the player
            _playerRespawn.respawnPoint = respawnPoint.transform.position;
        }
    }

}
