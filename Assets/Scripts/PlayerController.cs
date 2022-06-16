using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    void Start()
    {
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 offset = new Vector3(x, 0, z);

        transform.position = transform.position + (offset * speed * Time.deltaTime);
    }
    private void FixedUpdate() {

    }
}
