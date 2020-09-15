using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
    public class ServiceInfo : Result
    {
        public int ActiveServices { get; set; }
        public int UnconfirmedJobs { get; set; }
        public int ServiceTypeId { get; set; }
        public int ServiceStatusId { get; set; }
        public int JobStatusId { get; set; }
        public int TotalServices { get; set; }
        public int TotalContractors { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceStatusName { get; set; }
        public string JobStatusName { get; set; }
        public string CustomerStatusName { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public List<ServiceInfo> lstActiveServicesInfo { get; set; }
        public List<ServiceInfo> lstUnconfirmedJobsInfo { get; set; }
        public List<ServiceInfo> lstCustomerServiceInfo { get; set; }
        public List<ServiceBasicInfo> lstServiceBasicInfo { get; set; }
        public List<ServiceSite> lstServiceSites { get; set; }
        public List<OrderEmailTemplate> lstOrderEmailTemplates { get; set; }
        public string JobIds { get; set; }
        public DateTime Confirmation_ActualDateofDelivery { get; set; }
        public int CreatedBy { get; set; }
    }
}
