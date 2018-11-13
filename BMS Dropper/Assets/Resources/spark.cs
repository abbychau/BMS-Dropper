using UnityEngine;
public class spark : MonoBehaviour
{
    private float timeLeft;
    public void Awake()
    {
        ParticleSystem system = GetComponent<ParticleSystem>();
        timeLeft = system.main.startLifetime.constant;
    }
    public void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}