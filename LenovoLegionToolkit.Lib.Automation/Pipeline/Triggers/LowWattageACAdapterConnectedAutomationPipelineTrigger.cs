﻿using System;
using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.System;
using Newtonsoft.Json;

namespace LenovoLegionToolkit.Lib.Automation.Pipeline.Triggers
{
    public class LowWattageAcAdapterConnectedAutomationPipelineTrigger : IAutomationPipelineTrigger, IPowerStateAutomationPipelineTrigger, IDisallowDuplicatesAutomationPipelineTrigger
    {
        [JsonIgnore]
        public string DisplayName => "When low wattage AC power adapter is connected";

        public async Task<bool> IsSatisfiedAsync(IAutomationEvent automationEvent)
        {
            if (automationEvent is not (PowerStateAutomationEvent or StartupAutomationEvent))
                return false;

            return await Power.IsPowerAdapterConnectedAsync().ConfigureAwait(false) == PowerAdapterStatus.ConnectedLowWattage;
        }

        public IAutomationPipelineTrigger DeepCopy() => new LowWattageAcAdapterConnectedAutomationPipelineTrigger();

        public override bool Equals(object? obj) => obj is LowWattageAcAdapterConnectedAutomationPipelineTrigger;

        public override int GetHashCode() => HashCode.Combine(DisplayName);
    }
}