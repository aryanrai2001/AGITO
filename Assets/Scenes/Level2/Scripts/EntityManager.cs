using System;
using UnityEngine;

[Serializable]
public enum EntityType
{
    STAR_CLUSTER,
    NEBULA,
    HYPERGIANT_STAR,
    BINARY_SYSTEM,
    COLLIDER,
    STELLAR_JETS
}

public class EntityManager : MonoBehaviour
{
    public EntityType entityType;

}
