using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostpeed = 50f;
    [SerializeField] ParticleSystem powerUpParticles;
    InputAction moveAction;
    Rigidbody2D rb;
    Vector2 moveVector;
    SurfaceEffector2D se2d;
    bool canControlPlayyer = true;
    float previousRotation;
    float totalRotation;
    int countFlipp = 0;
    int activePowerCount = 0;
    ScoreManager scoreManager;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        se2d = FindAnyObjectByType<SurfaceEffector2D>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    
    
    void Update()
    {
        if(canControlPlayyer)
        {
            playerRotation();
            playerBoost();
            CalculateFlips();

        }
    }

    void playerRotation()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        // print(moveVector);
        if(moveVector.x > 0)
            rb.AddTorque(-torqueAmount);
        else if(moveVector.x < 0)
            rb.AddTorque(torqueAmount);
    }

    void playerBoost()
    {
        if(moveVector.y > 0)
            se2d.speed = boostpeed;
        else 
            se2d.speed = baseSpeed;
    }

    public void disableControlls()
    {
        canControlPlayyer = false;
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if(totalRotation > 340 || totalRotation < -340)
        {
            countFlipp += 1;
            totalRotation = 0;
            print("Flips: " + countFlipp);
            scoreManager.AddScore(100);
        }
        // print(totalRotation);
        previousRotation = currentRotation;

    }

    public void ActivatePowerUp(PowerUpSO powerUp)
    {
        powerUpParticles.Play();
        activePowerCount += 1;
      if(powerUp.GetPowerType() == "speed")
        {
            baseSpeed += powerUp.GetValueChange();
            boostpeed += powerUp.GetValueChange();
        }

        else if(powerUp.GetPowerType() == "torque")
        {
            torqueAmount += powerUp.GetValueChange();
        }

    }


    public void DeactivatePowerUp(PowerUpSO powerUp)
    {
        activePowerCount -= 1;
        if(activePowerCount == 0)
        {
            powerUpParticles.Stop();
        }
      if(powerUp.GetPowerType() == "speed")
        {
            baseSpeed -= powerUp.GetValueChange();
            boostpeed -= powerUp.GetValueChange();
        }

        else if(powerUp.GetPowerType() == "torque")
        {
            torqueAmount -= powerUp.GetValueChange();
        }

    }
}
