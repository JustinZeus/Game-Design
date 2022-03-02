using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isDashing;
    public bool isCharging;

    private int dashAttempts;
    private float dashStartTime;
    private float dashChargeTime;
    private float chargeStartTime;

    Movement movement;
    private CharacterController characterController;


    void Start()
    {
        movement = GetComponent<Movement>();
        characterController = GetComponent<CharacterController>();
        dashChargeTime = 2.0f;
    }

    void Update()
    {
        HandleDash();
    }

    void HandleDash()
    {
        if(dashAttempts > 0)
        {
            if(Time.time - chargeStartTime >= dashChargeTime){
                dashAttempts--;
                if(dashAttempts == 0)
                {
                    chargeStartTime = 0;
                    isCharging = false;
                } else
                {
                    chargeStartTime = Time.time;
                }
            }
        }

        bool isTryingToDash = Input.GetButtonDown("Jump");

        if (isTryingToDash && !isDashing)
        {
            if (dashAttempts <= 2)
            {
                OnStartDash();
            }
        }

        if(isDashing)
        {
            if (Time.time - dashStartTime <= 0.15f)
            {
                if (movement.movementDirection.Equals(Vector3.zero))
                {
                    characterController.Move(transform.forward * 25f * Time.deltaTime);
                } else
                {
                    characterController.Move(movement.movementDirection.normalized * 25f * Time.deltaTime);
                }
            } else {
                OnEndDash();
            }
        }
    }

    void OnStartDash()
    {
        isDashing = true;
        dashStartTime = Time.time;
        dashAttempts += 1;
    }

    void OnEndDash()
    {
        isDashing = false;
        dashStartTime = 0;
        if(!isCharging){
            isCharging = true;
            chargeStartTime = Time.time;
        }
    }
}
