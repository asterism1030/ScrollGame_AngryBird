using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { gold, heart };

[RequireComponent(typeof(ParticleSystem))]
public class Item : MonoBehaviour
{
    public ParticleSystem ps;
    [SerializeField]
    public ItemType itemType;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.GetComponent<Renderer>().sortingOrder = 5;

        if(ps == null) {
            Debug.LogError("ParticleSystem is null");
        }
    }

    void OnParticleTrigger()
    {
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        
        for(int i = 0; i < numEnter; i++) {
            switch(itemType) {
                case ItemType.gold :
                    GameManager.Instance.Gold += 10;
                    break;
                case ItemType.heart :
                    GameManager.Instance.Heart += 1;
                    break;
            }
        }
    }
}
