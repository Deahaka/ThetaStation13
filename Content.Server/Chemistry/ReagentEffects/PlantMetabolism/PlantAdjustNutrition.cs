﻿using Content.Shared.Chemistry.Reagent;
using JetBrains.Annotations;

namespace Content.Server.Chemistry.ReagentEffects.PlantMetabolism
{
    [UsedImplicitly]
    public sealed class PlantAdjustNutrition : PlantAdjustAttribute
    {
        public override void Effect(ReagentEffectArgs args)
        {
            if (!CanMetabolize(args.SolutionEntity, out var plantHolderComp, args.EntityManager, mustHaveAlivePlant: false))
                return;

            plantHolderComp.AdjustNutrient(Amount);
            return;
        }
    }
}
