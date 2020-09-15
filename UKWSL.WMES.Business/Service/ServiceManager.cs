using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.Service;

namespace UKWSL.WMES.Business.Service
{
    public class ServiceManager : IServiceManager
    {
        private IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public ServiceInfo GetAllCustomerListForServiceDashboard(CompanyInfo companyInfo)
        {
            return _serviceRepository.GetAllCustomerListForServiceDashboard(companyInfo);
        }

        public ServiceInfo GetServiceDashboardOverView(CompanyInfo companyInfo)
        {
            return _serviceRepository.GetServiceDashboardOverView(companyInfo);
        }
        public ServiceInfo GetAllServicebySite(CustomerSite customerSite)
        {
            return _serviceRepository.GetAllServicebySite(customerSite);
        }
        public ServiceJobDetails GetServiceDetailsByJobId(ServiceBasicInfo serviceBasicInfo)
        {
            return _serviceRepository.GetServiceDetailsByJobId(serviceBasicInfo);
        }
        public ServiceJobDetails GetServiceHistoryByServiceId(ServiceBasicInfo serviceBasicInfo)
        {
            return _serviceRepository.GetServiceHistoryByServiceId(serviceBasicInfo);
        }

        public ServiceJobDetails AddNewService(ServiceJobDetails serviceJobDetails)
        {
            return _serviceRepository.AddNewService(serviceJobDetails);
        }

        public ServiceJobDetails UpdateService(ServiceJobDetails serviceJobDetails)
        {
            return _serviceRepository.UpdateService(serviceJobDetails);
        }

        public ServiceJobDetails AddNewJob(ServiceJobDetails serviceJobDetails)
        {
            return _serviceRepository.AddNewJob(serviceJobDetails);
        }
        public ServiceJobDetails UpdateJobConfirmation(ServiceJobDetails serviceJobDetails)
        {
            return _serviceRepository.UpdateJobConfirmation(serviceJobDetails);
        }
        public ServiceInfo GetAllServiceSitesByCustomer(CustomerBasicInfo customerBasicInfo)
        {
            var serviceInfo = _serviceRepository.GetAllServiceSitesByCustomer(customerBasicInfo);
            foreach (var site in serviceInfo.lstServiceSites)
            {
                CustomerSite customerSite = new CustomerSite() { Customer_SiteId = site.Customer_SiteId };
                var objServiceInfo = _serviceRepository.GetAllServicebySite(customerSite);
                site.AssociatedGeneralWasteMaterialTypes = String.Join(", ", objServiceInfo.lstServiceBasicInfo.Where(x => x.WasteType_Name.Trim() == "General").Select(x => x.MaterialType_Name).Distinct().ToList());
                site.AssociatedCapitalWasteMaterialTypes = String.Join(", ", objServiceInfo.lstServiceBasicInfo.Where(x => x.WasteType_Name.Trim() == "Capital").Select(x => x.MaterialType_Name).Distinct().ToList());
                site.AssociatedRecyclingWasteMaterialTypes = String.Join(", ", objServiceInfo.lstServiceBasicInfo.Where(x => x.WasteType_Name.Trim() == "Recycling").Select(x => x.MaterialType_Name).Distinct().ToList());
                site.AssociatedHazardousWasteMaterialTypes = String.Join(", ", objServiceInfo.lstServiceBasicInfo.Where(x => x.WasteType_Name.Trim() == "Hazardous").Select(x => x.MaterialType_Name).Distinct().ToList());
                site.AssociatedWashroomWasteMaterialTypes = String.Join(", ", objServiceInfo.lstServiceBasicInfo.Where(x => x.WasteType_Name.Trim() == "Washroom").Select(x => x.MaterialType_Name).Distinct().ToList());
            }
            return serviceInfo;
        }
        public ServiceInfo GetServiceSitesByAccountId(AccountInfo accountInfo)
        {
            return _serviceRepository.GetServiceSitesByAccountId(accountInfo);
        }
        public ServiceJobDetails GetServiceReportServiceTracker()
        {
            return _serviceRepository.GetServiceReportServiceTracker();
        }
        public SettingUp GetProcessAccountDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            return _serviceRepository.GetProcessAccountDetails(approvedPricingSolution);
        }
        public SettingUp GetProcessSiteDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            return _serviceRepository.GetProcessSiteDetails(approvedPricingSolution);
        }
        public SettingUp GetProcessContactDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            return _serviceRepository.GetProcessContactDetails(approvedPricingSolution);
        }
        public SettingUp GetProcessServiceDetails(ApprovedPricingSolution approvedPricingSolution)
        {
            return _serviceRepository.GetProcessServiceDetails(approvedPricingSolution);
        }
        public SettingUp GetCreateServices(ApprovedPricingSolution approvedPricingSolution)
        {
            return _serviceRepository.GetCreateServices(approvedPricingSolution);
        }

        public ServiceJobDetails GetCustomFieldsByCustomer(ServiceJobDetails serviceJobDetails)
        {
            return _serviceRepository.GetCustomFieldsByCustomer(serviceJobDetails);
        }
        public ServiceInfo GetOrderEmailTemplate()
        {
            return _serviceRepository.GetOrderEmailTemplate();
        }
        public ServiceOrderDetails CreateNewOrder(ServiceOrderDetails serviceOrderDetails)
        {
            return _serviceRepository.CreateNewOrder(serviceOrderDetails);
        }
        public ServiceOrderDetails GetDetailsforSingleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            return _serviceRepository.GetDetailsforSingleOrder(serviceOrderDetails);
        }
        public ServiceOrderDetails GetDetailsforAmendmentOrder(ServiceOrderDetails serviceOrderDetails)
        {
            return _serviceRepository.GetDetailsforAmendmentOrder(serviceOrderDetails);
        }
        public ServiceOrderDetails GetDetailsforMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            return _serviceRepository.GetDetailsforMultipleOrder(serviceOrderDetails);
        }
        public ServiceOrderDetails GetMyOrderDetails(ServiceOrderDetails serviceOrderDetails)
        {
            return _serviceRepository.GetMyOrderDetails(serviceOrderDetails);
        }
        public ServiceOrderDetails ClearMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            return _serviceRepository.ClearMultipleOrder(serviceOrderDetails);
        }
        public ServiceOrderDetails CreateMultipleOrder(ServiceOrderDetails serviceOrderDetails)
        {
            return _serviceRepository.CreateMultipleOrder(serviceOrderDetails);
        }
        public ServiceOrderEmailDetails InsertOrderEmailDetails(ServiceOrderEmailDetails serviceOrderEmailDetails)
        {
            return _serviceRepository.InsertOrderEmailDetails(serviceOrderEmailDetails);
        }
        public ServiceOrderEmailDetails GetEmailTemplate(ServiceOrderEmailDetails serviceOrderEmailDetails) 
        {
            return _serviceRepository.GetEmailTemplate(serviceOrderEmailDetails);
        }
        public ServiceInfo BulkConfirmDeliveryDate(ServiceInfo serviceInfo)
        {
            return _serviceRepository.BulkConfirmDeliveryDate(serviceInfo);
        }
    }
}
