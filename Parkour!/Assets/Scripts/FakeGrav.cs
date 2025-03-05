using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGrav : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Vector3 gravity = new Vector3(0, -9.8f, 0);
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
