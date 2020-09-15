using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.Service
{
    public interface IServiceManager
    {
        ServiceInfo GetServiceDashboardOverView(CompanyInfo companyInfo);
        ServiceInfo GetAllCustomerListForServiceDashboard(CompanyInfo companyInfo);
        ServiceInfo GetAllServicebySite(CustomerSite customerSite);
        ServiceJobDetails GetServiceDetailsByJobId(ServiceBasicInfo serviceBasicInfo);
        ServiceJobDetails GetServiceHistoryByServiceId(ServiceBasicInfo serviceBasicInfo);
        ServiceJobDetails AddNewService(ServiceJobDetails service);
        ServiceJobDetails UpdateService(ServiceJobDetails serviceJobDetails);
        ServiceJobDetails AddNewJob(ServiceJobDetails job);
        ServiceJobDetails UpdateJobConfirmation(ServiceJobDetails serviceJobDetails);
        ServiceInfo GetAllServiceSitesByCustomer(CustomerBasicInfo customerBasicInfo);
        ServiceInfo GetServiceSitesByAccountId(AccountInfo accountInfo);
        ServiceJobDetails GetServiceReportServiceTracker();
        SettingUp GetProcessAccountDetails(ApprovedPricingSolution approvedPricingSolution);
        SettingUp GetProcessSiteDetails(ApprovedPricingSolution approvedPricingSolution);
        SettingUp GetProcessContactDetails(ApprovedPricingSolution approvedPricingSolution);
        SettingUp GetProcessServiceDetails(ApprovedPricingSolution approvedPricingSolution);
        SettingUp GetCreateServices(ApprovedPricingSolution approvedPricingSolution);

        ServiceJobDetails GetCustomFieldsByCustomer(ServiceJobDetails serviceJobDetails);
        ServiceInfo GetOrderEmailTemplate();
        ServiceOrderDetails CreateNewOrder(ServiceOrderDetails serviceOrderDetails);
        ServiceOrderDetails GetDetailsforSingleOrder(ServiceOrderDetails serviceOrderDetails);
        ServiceOrderDetails GetDetailsforAmendmentOrder(ServiceOrderDetails serviceOrderDetails);
        ServiceOrderDetails GetDetailsforMultipleOrder(ServiceOrderDetails serviceOrderDetails);
        ServiceOrderDetails GetMyOrderDetails(ServiceOrderDetails serviceOrderDetails);
        ServiceOrderDetails ClearMultipleOrder(ServiceOrderDetails serviceOrderDetails);
        ServiceOrderDetails CreateMultipleOrder(ServiceOrderDetails serviceOrderDetails);
        ServiceOrderEmailDetails InsertOrderEmailDetails(ServiceOrderEmailDetails serviceOrderEmailDetails);
        ServiceOrderEmailDetails GetEmailTemplate(ServiceOrderEmailDetails serviceOrderEmailDetails);
        ServiceInfo BulkConfirmDeliveryDate(ServiceInfo serviceInfo);
    }
}
