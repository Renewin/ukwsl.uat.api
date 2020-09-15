using System;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Globalization;
using System.Threading;
using UKWSL.WMES.Business.Authentication;
using UKWSL.WMES.Business.Customer;
using UKWSL.WMES.Repositories.Authentication;
using UKWSL.WMES.Repositories.Customer;
using UKWSL.WMES.WEBAPP.Controllers.Api;
using UKWSL.WMES.WEBAPP.WebHelper;
using UKWSL.WMES.Business.Integration;
using UKWSL.WMES.Repositories.Integration;
using Unity;
using Unity.Lifetime;
using System.Configuration;
using Unity.Injection;
using UKWSL.WMES.Business.Master;
using UKWSL.WMES.Repositories.Master;
using UKWSL.WMES.Business.ScheduleOfService;
using UKWSL.WMES.Repositories.ScheduleofServices;
using UKWSL.WMES.Business.Workflow;
using UKWSL.WMES.Repositories.Workflow;
using UKWSL.WMES.Business.Pricing;
using UKWSL.WMES.Repositories.Pricing;
using UKWSL.WMES.Business.Exports;
using UKWSL.WMES.Repositories.Exports;
using UKWSL.WMES.Business.UserRoleMangement;
using UKWSL.WMES.Repositories.UserRoleMangement;
using UKWSL.WMES.Business.Notification;
using UKWSL.WMES.Repositories.Notification;
using UKWSL.WMES.Repositories.ApprovedPricing;
using UKWSL.WMES.Business.ApprovedPricing;
using UKWSL.WMES.Repositories.Service;
using UKWSL.WMES.Business.Service;
using UKWSL.WMES.Repositories.Facility;
using UKWSL.WMES.Business.Facility;
using UKWSL.WMES.Repositories.Contractors;
using UKWSL.WMES.Business.Contractors;
using UKWSL.WMES.Business.ContractorRegister;
using UKWSL.WMES.Repositories.ContractorRegister;
using UKWSL.WMES.Business.PricingMatrix;
using UKWSL.WMES.Repositories.PricingMatrix;
using UKWSL.WMES.Repositories.ContractorWeight;
using UKWSL.WMES.Business.ContractorWeight;
using UKWSL.WMES.Business.DutyOfCare;
using UKWSL.WMES.Repositories.DutyofCare;

namespace UKWSL.WMES.WEBAPP
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private string _connectionString;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureApi(GlobalConfiguration.Configuration);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

        }

        void ConfigureApi(HttpConfiguration config)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hub2Connection"].ConnectionString;
            var unity = new UnityContainer();
            unity.RegisterType<AuthenticationController>();
            unity.RegisterType<IAuthenticationManager, AuthenticationManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IAuthenticationRepository, AuthenticationRepository>(new HierarchicalLifetimeManager());

            unity.RegisterType<CompanyController>();
            unity.RegisterType<ICustomerManager, CustomerManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<ICustomerRepository, CustomerRepository>(new InjectionConstructor(_connectionString) );

            unity.RegisterType<DealController>();
            unity.RegisterType<IDealManager, DealManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IDealRepository, DealRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<SiteController>();
            unity.RegisterType<ISiteManager, SiteManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<ISiteRepository, SiteRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<DealController>();
            unity.RegisterType<IDealManager, DealManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IDealRepository, DealRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<IntegrationController>();
            unity.RegisterType<IIntegrationManager, IntegrationManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IIntegrationRepository, IntegrationRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<ScheduleOfServiceController>();
            unity.RegisterType<IScheduleOfServiceManager, ScheduleOfServiceManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IScheduleOfServiceRepository, ScheduleOfServiceRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<MasterController>();
            unity.RegisterType<IMasterManager, MasterManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IMasterRepository, MasterRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<WorkflowController>();
            unity.RegisterType<IWorkflowManager, WorkflowManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IWorkflowRepository, WorkflowRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<ExportController>();
            unity.RegisterType<IExportManager, ExportManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IExportRepository, ExportRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<PricingController>();
            unity.RegisterType<IPricingOptimizationManager, PricingOptimizationManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IPricingOptimizationRepository, PricingOptimizationRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<UserRoleManagementController>();
            unity.RegisterType<IUserRoleManagementManager, UserRoleManagementManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IUserRoleManagementRepository, UserRoleManagementRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<NotificationController>();
            unity.RegisterType<INotificationManager, NotificationManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<INotificationRepository, NotificationRepository>(new InjectionConstructor(_connectionString));
            unity.RegisterType<CustomerController>();

            unity.RegisterType<ApprovedPricingController>();
            unity.RegisterType<IApprovedPricingManager, ApprovedPricingManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IApprovedPricingRepository, ApprovedPricingRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<ServiceController>();
            unity.RegisterType<IServiceManager, ServiceManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IServiceRepository, ServiceRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<FacilityController>();
            unity.RegisterType<IFacilityManager, FacilityManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IFacilityRepository, FacilityRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<ContractorController>();
            unity.RegisterType<IContractorManager, ContractorManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IContractorRepository, ContractorRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<ContractorRegisterController>();
            unity.RegisterType<IContractorRegisterManager, ContractorRegisterManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IContractorRegisterRepository, ContractorRegisterRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<PricingMatrixController>();
            unity.RegisterType<IPricingMatrixManager, PricingMatrixManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IPricingMatrixRepository, PricingMatrixRepository>(new InjectionConstructor(_connectionString));

            unity.RegisterType<ContractorWeightController>();
            unity.RegisterType<IContractorWeightManager, ContractorWeightManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IContractorWeightRepository, ContractorWeightRepository>(new InjectionConstructor(_connectionString));


            unity.RegisterType<DutyOfCareController>();
            unity.RegisterType<IDutyOfCareManager, DutyOfCareManager>(new HierarchicalLifetimeManager());
            unity.RegisterType<IDutyofCareRepository, DutyofCareRepository>(new InjectionConstructor(_connectionString));

            config.DependencyResolver = new HubContainer(unity);
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            SetCache();
            SetDatePattern();
        }

        private static void SetDatePattern()
        {
            var newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }
        private void SetCache()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

    }
}
