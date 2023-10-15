using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;

    public LayerMask layerMask;
    public Transform shootSource; // starting point of raycast
    public float maxDistance = 10; // maximum distance of raycast

    private bool rayActivate = false;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    public void StartShoot()
    {
        AudioManager.instance.Play("Pistol");
        particles.Play();
        rayActivate = true;
    }
    public void StopShoot()
    {
        AudioManager.instance.Stop("Pistol");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    void Update()
    {
        if (rayActivate)
        {
            RaycastCheck();
        }
        
    }

    void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, maxDistance, layerMask);

        if(hasHit)
        {
            // trigger Break() method
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }

}
