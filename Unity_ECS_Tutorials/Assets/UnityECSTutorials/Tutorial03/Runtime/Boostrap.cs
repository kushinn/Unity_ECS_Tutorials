using System.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace RafeTutorials.Tutorials3
{
    public class Boostrap : MonoBehaviour
    {
        public Mesh playerMesh;
        public Material playerMaterial;
        public float delayDestroyTime = 3f;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private IEnumerator Start()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            EntitySpawnManager.CreatePlayerArchetype(entityManager);
            EntitySpawnManager.CreatePlayer(entityManager, new MeshInstanceRenderer() { mesh = playerMesh, material = playerMaterial });

            var player = EntitySpawnManager.CreatePlayer(entityManager, new MeshInstanceRenderer() { mesh = playerMesh, material = playerMaterial });
            entityManager.SetComponentData(player, new Position() { Value = new float3(0, 3, 0) });

            yield return new WaitForSeconds(delayDestroyTime);
            entityManager.DestroyEntity(player);
        }

    }
}
