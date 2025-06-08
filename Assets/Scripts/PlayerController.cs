using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;

    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    [SerializeField] private float xRangePlayer = 10f;
    [SerializeField] private float zMinPlayer = -1.5f;
    [SerializeField] private float zMaxPlayer = 16.5f;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private KeyCode switchKey;
    private bool firePressed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() // Обрабатывается ввод
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(switchKey))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, rb.rotation);
        }
    }
    void FixedUpdate() // Обрабатывается физика
    {
        Vector3 movementForward = Vector3.forward * verticalInput * speed * Time.deltaTime;
        Vector3 movementAside = Vector3.right * horizontalInput * speed * Time.deltaTime;

        Vector3 newPosition = rb.position + movementAside + movementForward;

        newPosition.z = Mathf.Clamp(newPosition.z, zMinPlayer, zMaxPlayer);
        newPosition.x = Mathf.Clamp(newPosition.x, -xRangePlayer, xRangePlayer); // Clamp - это функция, которая ограничивает значение в заданном диапазоне
        rb.MovePosition(newPosition);
    }
}
// GetKeyUp - это функция, которая вызывается, когда клавиша отпускается
// GetKeyDown - это функция, которая вызывается, когда клавиша нажата
// GetKey - это функция, которая вызывается, когда клавиша удерживается нажатой