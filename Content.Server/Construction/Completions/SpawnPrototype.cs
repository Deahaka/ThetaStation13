﻿using Content.Server.Stack;
using Content.Shared.Construction;
using Content.Shared.Prototypes;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Construction.Completions
{
    [UsedImplicitly]
    [DataDefinition]
    public sealed class SpawnPrototype : IGraphAction
    {
        [DataField("prototype", customTypeSerializer:typeof(PrototypeIdSerializer<EntityPrototype>))]
        public string Prototype { get; private set; } = string.Empty;
        [DataField("amount")]
        public int Amount { get; private set; } = 1;

        public void PerformAction(EntityUid uid, EntityUid? userUid, IEntityManager entityManager)
        {
            if (string.IsNullOrEmpty(Prototype))
                return;

            var coordinates = entityManager.GetComponent<TransformComponent>(uid).Coordinates;

            if (EntityPrototypeHelpers.HasComponent<StackComponent>(Prototype))
            {
                var stackEnt = entityManager.SpawnEntity(Prototype, coordinates);
                var stack = entityManager.GetComponent<StackComponent>(stackEnt);
                entityManager.EntitySysManager.GetEntitySystem<StackSystem>().SetCount(stackEnt, Amount, stack);
            }
            else
            {
                for (var i = 0; i < Amount; i++)
                {
                    entityManager.SpawnEntity(Prototype, coordinates);
                }
            }

        }
    }
}
