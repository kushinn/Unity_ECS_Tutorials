using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace RafeTutorials.Tutorials4
{
    public class PlayerMoveSystem : ComponentSystem
    {
        public struct Data
        {
            public readonly int Length;
            public ComponentDataArray<Position> Position;
            public ComponentDataArray<PlayerInput> Input;
        }

        [Inject] private Data playerDatas;

        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;
            for (int index = 0; index < playerDatas.Length; ++index)
            {
                playerDatas.Position[index] = new Position { Value = playerDatas.Position[index].Value + dt * playerDatas.Input[index].move * 5 };
            }
        }
    }
}
