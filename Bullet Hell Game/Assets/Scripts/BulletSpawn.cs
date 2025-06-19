using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    enum SpawnerType {Straight, Spin}
    [Header("Bullet Attributes")]
    public GameObject Bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    
    private GameObject spawnedBullet;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(spawnerType == SpawnerType.Spin)
        {
            transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+1f);
        }

        if(timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        if(Bullet)
        {
            spawnedBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
