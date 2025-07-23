using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    public static DestinationPoint Instance;
    
    public bool fishIn = false;
    public Fish CaughtFish { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetPosition(Vector3 position)
    {
        gameObject.SetActive(true);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            fishIn = true;
            CaughtFish = collision.GetComponent<Fish>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            fishIn = false;
            CaughtFish = null;
        }
    }

    
}

