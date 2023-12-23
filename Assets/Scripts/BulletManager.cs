using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            TriggerManager triggerManager = col.gameObject.GetComponent<TriggerManager>();
            triggerManager.SetPlayerAtCheckpointPosition();
        }
        
        Destroy(gameObject);
    }
}
