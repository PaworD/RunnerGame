using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_RandomMovement : MonoBehaviour
{

    private Vector3 _newPosition;
    private Quaternion _newRotation;

    [SerializeField]
    private Vector3 min;
    [SerializeField]
    private Vector3 max;
    [SerializeField]
    private Vector2 yRotation;
    [SerializeField]
    [Range(0.01f, 0.1f)]
    private float lerpSpeed = 0.02f;

    private void Awake()
    {
        _newPosition = transform.position;
        _newRotation = transform.rotation;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * lerpSpeed);

        if(Vector3.Distance(transform.position, _newPosition) < 1f)
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        var xPos = Random.Range(min.x, max.y);
        var zPos = Random.Range(min.z, max.z);
        _newRotation = Quaternion.Euler(0, Random.Range(yRotation.x, yRotation.y), 0);
        _newPosition = new Vector3(xPos, zPos);     
    }

}
