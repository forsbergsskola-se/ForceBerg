using System.Collections.Generic;
using Events;
using UnityEngine;

namespace PhysicsObjects.Magnetism
{
    public class Magnet : MonoBehaviour
    {
        [SerializeField] private int triggerKey;
    
        public int attraction;
        private List<IMagnetic> attractees = new List<IMagnetic>();
        private PolygonCollider2D attractionFieldCollider;
        private ParticleSystem particleSystem;

        private void Start()
        {
            particleSystem = GetComponentInChildren<ParticleSystem>();
            particleSystem.Stop();
        }

        private void OnEnable()
        {
            attractionFieldCollider = GetComponentInChildren<PolygonCollider2D>();
            MessageHandler.Instance().SubscribeMessage<EventTriggerPlate>(ToggleMagnetism);
        }

        private void OnDisable()
        {
            attractees = new List<IMagnetic>();
            MessageHandler.Instance().UnsubscribeMessage<EventTriggerPlate>(ToggleMagnetism);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent<IMagnetic>(out var component))
                attractees.Add(component);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.TryGetComponent<IMagnetic>(out var component))
                attractees.Remove(component);
        }

        private void FixedUpdate()
        {
            foreach (var magnetic in attractees)
            {
                magnetic.Attract(this);
            }
        }

        private void ToggleMagnetism(EventTriggerPlate eventTriggerPlate)
        {
            if(eventTriggerPlate.triggerKey == this.triggerKey)
            {
                attractionFieldCollider.enabled = eventTriggerPlate.isActive;
                if(eventTriggerPlate.isActive)
                    particleSystem.Play();
                else
                    particleSystem.Stop();                
            }
        }
    }
}
