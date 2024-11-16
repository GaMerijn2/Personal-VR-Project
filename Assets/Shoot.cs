using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 10f;

    void Start()
    {
        // Get the grab interactable component
        grabInteractable = GetComponent<XRGrabInteractable>();
        // Subscribe to the activate event
        grabInteractable.activated.AddListener(OnTriggerPulled);
    }

    void OnTriggerPulled(ActivateEventArgs args)
    {
        ShootBullet();
    }

    void ShootBullet()
    {
        if (bulletPrefab != null && bulletSpawn != null)
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        
            // Add force to the bullet in the forward direction of the gun
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse); // Adjust the speed (20f) as needed
            }
        
            // Destroy the bullet after 1 second
            Destroy(bullet, 1f);
        }
    }


    private void OnDestroy()
    {
        grabInteractable.activated.RemoveListener(OnTriggerPulled);
    }
}
