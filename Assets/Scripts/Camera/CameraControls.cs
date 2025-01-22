using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
//TODO make player unable to move if currently in boss fight

    //---Variables---
    Vector3 prev;
    private Vector3 targetLocation;
    float distance = 15.0f;
    public float speed = 10.0f;
    private String direction = "forward";
    private float cameraDirection = 90.0f;
    public float cameraRotationSpeed = 130.0f;
    

    //-> Input Restrictions Variables
    private float inputCoolDown = 1.0f;
    private float inputCoolDownTimer = 0.0f;
    private bool quitMovement = false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prev = transform.position;
        targetLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Updates input cooldown timer
        inputCoolDownTimer += Time.deltaTime;
        
        //Checks if player wants to move forward
        if (Input.GetKeyUp(KeyCode.W) && inputCoolDownTimer >= inputCoolDown)
        {
            //Resets input cooldown timer & lets player move again
            inputCoolDownTimer = 0.0f;
            quitMovement = false;

            //stores prevoious position
            prev = transform.position;

            //sets target location based on direction
            if (direction == "forward")
            {
                targetLocation = transform.position + Vector3.right * distance;
            }
            else if (direction == "left")
            {
                targetLocation = transform.position + Vector3.forward * distance;
            }
            else if (direction == "right")
            {
                targetLocation = transform.position - Vector3.forward * distance;
            }
            else if (direction == "back")
            {
                targetLocation = transform.position - Vector3.right * distance;
            }
        }
        
        //Moves camera one floor towards direction
        if (transform.position != targetLocation && quitMovement == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
        } 

        
        
        //Rotates camera
        if (Input.GetKeyUp(KeyCode.D)){

            cameraDirection = setCameraDirection(90.0f);
            direction = setDirection();
            Debug.Log(transform.rotation.eulerAngles.y);
        
        } else if (Input.GetKeyUp(KeyCode.A)){
            
            cameraDirection = setCameraDirection(-90.0f);
            direction = setDirection();
            Debug.Log(transform.rotation.eulerAngles.y);
            
        }

        if (transform.rotation.eulerAngles.y != cameraDirection){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, cameraDirection, 0), cameraRotationSpeed * Time.deltaTime);
        }
        
    }

    private float setCameraDirection(float add)
    {
        cameraDirection += add;
        if (cameraDirection > 360.0f){
            cameraDirection = 0.0f;
        }
        if (cameraDirection < 0.0f){
            cameraDirection = 270.0f;
        }
        return cameraDirection;
    }
    private String setDirection()
    {
        //gets current rotation of camera
        float initial = cameraDirection;
        
        //sets direction based on rotation
        if (initial == 0){
            direction = "left";
        } else if (initial == 90){
            direction = "forward";
        } else if (initial == 180){
            direction = "right";
        } else if (initial == -90 || initial == 270){
            direction = "back";
        }
        return direction;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Environment")
        {
            transform.position = prev;
            targetLocation = prev;
            quitMovement = true;
            //Debug.Log("Collided with " + other.name);
        }
    }
}
