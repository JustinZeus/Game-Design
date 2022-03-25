using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool isDashing;
    public bool isCharging;

    public Text UIcharges;

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
        dashAttempts = 3;
    }

    void Update()
    {
        HandleDash();
        UIcharges.text = dashAttempts.ToString();
    }

    void HandleDash()
    {
        if(dashAttempts < 3)
        {
            if(Time.time - chargeStartTime >= dashChargeTime){
                dashAttempts++;
                chargeStartTime = Time.time;
                if(dashAttempts == 3){
                    isCharging = false;
                } 
            }
        }

        bool isTryingToDash = Input.GetButtonDown("Jump");
        if (isTryingToDash && !isDashing)
        {
            if (dashAttempts > 0)
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
        dashAttempts -= 1;
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
