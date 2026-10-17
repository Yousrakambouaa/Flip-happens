using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUpSO powerUpSO;
    playerController player;
    SpriteRenderer spriteRenderer;
    float timeRemaining;
    void Start()
    {
        player = FindAnyObjectByType<playerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeRemaining = powerUpSO.GetTime();
    }

    void Update()
    {
        CountDownPowerUpTime();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if(collision.gameObject.layer == layerIndex && spriteRenderer.enabled == true)
        {
            spriteRenderer.enabled = false;
            player.ActivatePowerUp(powerUpSO);
        }
    }


    void CountDownPowerUpTime()
    {
        if(spriteRenderer.enabled == false)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                if(timeRemaining <= 0)
                {
                    player.DeactivatePowerUp(powerUpSO);
                }
            }
        }
    }
}
