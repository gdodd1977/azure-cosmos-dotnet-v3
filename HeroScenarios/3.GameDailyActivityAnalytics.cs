﻿namespace HeroScenarios
{
    using Microsoft.Azure.Cosmos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class GameDailyActivityAnalytics : BaseScenario
    {
        private CosmosContainer leaseContainer;
        private ChangeFeedProcessor changeFeedProcessor;

        public async Task StartAsync()
        {
            this.changeFeedProcessor = this.containerItems
                .CreateChangeFeedProcessorBuilder<TwoPersonGame>("ActivityAnalytics", this.ProcessChanges)
                .WithInstanceName("DemoMachine")
                .WithCosmosLeaseContainer(leaseContainer)
                .Build();

            await this.changeFeedProcessor.StartAsync();
        }

        public async Task StopAsync()
        {
            if (this.changeFeedProcessor != null)
            {
                await this.changeFeedProcessor.StopAsync();
            }
        }

        private async Task ProcessChanges(IReadOnlyList<TwoPersonGame> changes, CancellationToken cancellationToken)
        {
            // Process the changes for analytics
            throw new NotImplementedException();
        }
    }
}