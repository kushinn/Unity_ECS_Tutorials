using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;

namespace RafeTutorials.Tutorials2
{
    public sealed class EntitySpawnManager
    {
        private static EntityArchetype sPlayerArchetype;

        public static void CreatePlayerArchetype(EntityManager entityManager)
        {
            sPlayerArchetype = entityManager.CreateArchetype(new ComponentType[]
            {
                typeof(Position),
                typeof(MeshInstanceRenderer),
            });
        }

        public static Entity CreatePlayer(EntityManager entityManager, MeshInstanceRenderer renderer)
        {
            var player = entityManager.CreateEntity(sPlayerArchetype);
            entityManager.SetSharedComponentData(player, renderer);
            return player;
        }

    }
}
