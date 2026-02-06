using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayArea : MonoBehaviour
{

      public float damagePerSecondOutsidePlayArea = 5f;
      public float shrinkMultiplyer = 0.9f;
      public float shrinkSpeed = 2f;
      public bool randomizePosition = false;
      public float maxRandomOffset = 10f;

      Vector3 targetScale;
      Vector3 targetPosition;
      PlayerController player;
      bool isOutsidePlayArea = false;

      public float shrinkInterval = 30f;
      float timeSinceLastShrink = 0f;

      void Start()
      {
          targetScale = transform.localScale;
          targetPosition = transform.position;
          
      }


      void Update()
{
    ApplyDamageIfOutside();
    SmoothShrink();
    
    timeSinceLastShrink += Time.deltaTime;
    if (timeSinceLastShrink >= shrinkInterval)
    {
        ShrinkZone();
        timeSinceLastShrink = 0f;
    }
}

    void ApplyDamageIfOutside()
  {
    if (isOutsidePlayArea && player != null)
    {
        player.TakeDamage(damagePerSecondOutsidePlayArea * Time.deltaTime);
    }
  }
 
    void SmoothShrink()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * shrinkSpeed);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * shrinkSpeed);
    }

    void ShrinkZone()
    {
        targetScale = transform.localScale * shrinkMultiplyer;

        if (randomizePosition)
    {
        float randomX = Random.Range(-maxRandomOffset, maxRandomOffset);
        float randomZ = Random.Range(-maxRandomOffset, maxRandomOffset);
        targetPosition = transform.position + new Vector3(randomX, 0f, randomZ);
    }
    Debug.Log($"Shrinking play area to scale {targetScale} and moving to position {targetPosition}");
    }

    void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isOutsidePlayArea = true;
        player = other.GetComponent<PlayerController>();
        player.SetDamageVisual(true);
    }
}

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isOutsidePlayArea = false;
        if (player != null)
        {
            player.SetDamageVisual(false);
        }
    }
}

  
}
