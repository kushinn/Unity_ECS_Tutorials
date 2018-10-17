using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace RafeTutorials.Tutorials5
{
    public class PlayerMoveSystem : ComponentSystem
    {
        public struct Data
        {
            public int length;
            public ComponentDataArray<Position> positions;
            public ComponentDataArray<PlayerInput> inputs;

            public void Execute()
            {
                float dt = Time.deltaTime;
                for (int index = 0; index < length; ++index)
                {
                    positions[index] = new Position { Value = positions[index].Value + dt * inputs[index].move * 5 };
                }
            }
        }

        //[Inject] private Data playerDatas;
        private ComponentGroup playerDatas;

        protected override void OnUpdate()
        {
            playerDatas = GetComponentGroup(typeof(Position), ComponentType.ReadOnly(typeof(PlayerInput)));
            new Data()
            {
                length = playerDatas.CalculateLength(),
                positions = playerDatas.GetComponentDataArray<Position>(),
                inputs = playerDatas.GetComponentDataArray<PlayerInput>(),
            }.Execute();

        }
    }
}
