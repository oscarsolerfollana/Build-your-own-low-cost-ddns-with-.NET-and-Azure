using Azure;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("/")]
    public class DdnsController : ControllerBase
    {
        private readonly KeyVaultService keyVaultService;
        public DdnsController(KeyVaultService keyVaultService)
        {
            this.keyVaultService = keyVaultService;
        }

        [HttpGet]
        public async Task<string> GetIp(string? password)
        {
            var passwordSecret = keyVaultService.GetSecret("password");
            if (!string.IsNullOrEmpty(password) && password == passwordSecret)
            {
                return Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            throw new Exception();
        }

        [HttpPost]
        public async Task<string> UpdateIP(string username, string password)
        {
            try
            {
                var passwordSecret = keyVaultService.GetSecret("password");
                if (username != "" && password != "" && password == passwordSecret)
                { 
                    ArmClient armClient = new ArmClient(new DefaultAzureCredential());
                    SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
                    string rgName = Environment.GetEnvironmentVariable("resourceGroupName");
                    ResourceGroupResource resourceGroup = subscription.GetResourceGroup(rgName).Value;
                    DnsZoneCollection dnsZoneCollection = resourceGroup.GetDnsZones();
                    AsyncPageable<DnsZoneResource> response = dnsZoneCollection.GetAllAsync();

                    await foreach (DnsZoneResource dnsZone in response)
                    {
                        string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                        if (dnsZone.Data.Name != Environment.GetEnvironmentVariable("domainName")) continue;
                        var records = dnsZone.GetDnsARecords();
                        foreach (DnsARecordResource recordResource in records)
                        {
                            var data = recordResource.Data;
                            if (data.Name == username)
                            {
                                data.DnsARecords[0].IPv4Address = System.Net.IPAddress.Parse(ip);
                                recordResource.Update(recordResource.Data);
                                return ip;
                            }
                        }
                        DnsARecordData newRecord = new DnsARecordData()
                        {
                            TtlInSeconds = 1,
                            DnsARecords =
                        {
                            new DnsARecordInfo()
                            {
                                IPv4Address=System.Net.IPAddress.Parse(ip)
                            }
                        }
                        };
                        await records.CreateOrUpdateAsync(WaitUntil.Completed, username, data: newRecord);
                        return ip;
                    }
                }
                else
                {
                    return "credenciales mal";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return null;
        }
    }
}