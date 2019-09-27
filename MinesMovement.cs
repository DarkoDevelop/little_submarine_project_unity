using UnityEngine;

public class MinesMovement : MonoBehaviour
{
    public float minesSpeed = 1f;
    // Moving mines to left
    void Update()
    {
        transform.position += Vector3.left * minesSpeed * Time.deltaTime; //Moving mines depending on minesSpeed variable which is set in inspector
    }
}
