﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Pipelines.Environments.WebApi;
using Microsoft.TeamFoundation.DistributedTask.WebApi;
using Microsoft.VisualStudio.Services.WebApi;

namespace Microsoft.VisualStudio.Services.Agent
{
    [ServiceLocator(Default = typeof(EnvironmentsServer))]
    public interface IEnvironmentsServer : IAgentService
    {
        Task ConnectAsync(VssConnection agentConnection);

        // Configuration
        Task<List<EnvironmentInstance>> GetEnvironmentsAsync(string projectName, string environmentName);

        // Update Machine Group ( Used for adding tags)
        Task<VirtualMachineResource> UpdateEnvironmentVMsAsync(Guid projectId, int environmentId, List<VirtualMachineResource> virtualMachineResources);

        // Add Deployment Machine
        Task<VirtualMachineResource> AddEnvironmentVMAsync(Guid projectId, int environmentId, VirtualMachineResource virtualMachineResource);

        // Replace Deployment Machine
        Task<VirtualMachineResource> ReplaceEnvironmentVMAsync(Guid projectId, int environmentId, VirtualMachineResource virtualMachineResource);

        // Delete Deployment Machine
        Task DeleteEnvironmentVMAsync(string projectName, int environmentId, int virtualMachineId);

        Task DeleteEnvironmentVMAsync(Guid projectId, int environmentId, int virtualMachineId);

        // Get Deployment Machines
        Task<List<VirtualMachineResource>> GetEnvironmentVMsAsyncAsync(string projectName, int environmentId, string virtualMachine);

        Task<List<VirtualMachineResource>> GetEnvironmentVMsAsyncAsync(Guid projectGuid, int environmentId, string virtualMachine);
    }

    public sealed class EnvironmentsServer : AgentService, IEnvironmentsServer
    {
        private bool _hasConnection;
        private VssConnection _connection;
        private EnvironmentsHttpClient _environmentsHttpClient;

        public async Task ConnectAsync(VssConnection agentConnection)
        {
            _connection = agentConnection;
            if (!_connection.HasAuthenticated)
            {
                await _connection.ConnectAsync();
            }

            _environmentsHttpClient = _connection.GetClient<EnvironmentsHttpClient>();
            _hasConnection = true;
        }

        public Task<List<EnvironmentInstance>> GetEnvironmentsAsync(string projectName, string environmentName)
        {
            throw new NotImplementedException();
        }

        public Task<VirtualMachineResource> UpdateEnvironmentVMsAsync(Guid projectId, int environmentId, List<VirtualMachineResource> virtualMachineResources)
        {
            throw new NotImplementedException();
        }

        public Task<VirtualMachineResource> AddEnvironmentVMAsync(Guid projectId, int environmentId, VirtualMachineResource virtualMachineResource)
        {
            throw new NotImplementedException();
        }

        public Task<VirtualMachineResource> ReplaceEnvironmentVMAsync(Guid projectId, int environmentId, VirtualMachineResource virtualMachineResource)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEnvironmentVMAsync(string projectName, int environmentId, int virtualMachineId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEnvironmentVMAsync(Guid projectId, int environmentId, int virtualMachineId)
        {
            throw new NotImplementedException();
        }

        public Task<List<VirtualMachineResource>> GetEnvironmentVMsAsyncAsync(string projectName, int environmentId, string virtualMachine)
        {
            throw new NotImplementedException();
        }

        public Task<List<VirtualMachineResource>> GetEnvironmentVMsAsyncAsync(Guid projectGuid, int environmentId, string virtualMachine)
        {
            throw new NotImplementedException();
        }


        private void CheckConnection()
        {
            if (!_hasConnection)
            {
                throw new InvalidOperationException("SetConnection");
            }
        }
    }
}