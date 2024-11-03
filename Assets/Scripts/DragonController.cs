using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;

    private FixedJoystick fixedJoystick;
    private Rigidbody rb;

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xValue = fixedJoystick.Horizontal;
        float yValue = fixedJoystick.Vertical;

        Vector3 movementDir = new(xValue, 0f, yValue);
        rb.velocity = movementDir * speed;

        if (xValue != 0f && yValue != 0f)
            transform.eulerAngles = new(transform.eulerAngles.x, Mathf.Atan2(xValue, yValue) * Mathf.Rad2Deg, transform.eulerAngles.z);
    }
}
