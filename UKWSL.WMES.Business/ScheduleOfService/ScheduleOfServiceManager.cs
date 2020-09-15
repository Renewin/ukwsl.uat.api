using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Repositories.ScheduleofServices;
using UKWSL.WMES.Utility;

namespace UKWSL.WMES.Business.ScheduleOfService
{
    public class ScheduleOfServiceManager : IScheduleOfServiceManager
    {

        private IScheduleOfServiceRepository _scheduleOfServiceRepository;

        public ScheduleOfServiceManager(IScheduleOfServiceRepository scheduleOfServiceRepository)
        {
            _scheduleOfServiceRepository = scheduleOfServiceRepository;
        }


        public SOSInfo UpdateScheduleofService(ScheduleofService scheduleofServices)
        {
            return _scheduleOfServiceRepository.UpdateScheduleofService(scheduleofServices);
        }

        public SOSInfo CreateScheduleofService(ScheduleofService scheduleofServices)
        {
            return _scheduleOfServiceRepository.CreateScheduleofService(scheduleofServices);
        }

        public SOSInfo GetScheduleofService(ScheduleofService scheduleofServices)
        {
            return _scheduleOfServiceRepository.GetScheduleofService(scheduleofServices);
        }

        public SOSInfo GetSOSHeaderByDeal(ScheduleofService scheduleofService)
        {
            return _scheduleOfServiceRepository.GetSOSHeaderByDeal(scheduleofService);
        }

        public SOSInfo CheckScheduleofServices(ScheduleofService scheduleofServices)
        {
            return _scheduleOfServiceRepository.CheckScheduleofServices(scheduleofServices);
        }

        public SOSInfo GetScheduleofServiceBySosId(ScheduleofService scheduleofServices)
        {
            return _scheduleOfServiceRepository.GetScheduleofServiceBySosId(scheduleofServices);
        }

        public SOSInfo UploadCSVRawData(ScheduleofService scheduleofService, SOSFileDetails sOSFileDetails, List<SOSUDTFileData> sOSUDTFileData)
        {

            DataTable _dtSOS = new DataTable();
            _dtSOS = ListtoDataTableConverter.ToDataTable(sOSUDTFileData);
            return _scheduleOfServiceRepository.UploadCSVRawData(scheduleofService, sOSFileDetails, _dtSOS);

        }

        public SOSInfo InsertUploadedData(SOSInfo sOSInfo)
        {
            return _scheduleOfServiceRepository.InsertUploadedData(sOSInfo);
        }

        public SOSInfo DeleteSOSInfo(ScheduleofService scheduleofServices)
        {
            return _scheduleOfServiceRepository.DeleteSOSInfo(scheduleofServices);
        }
    }
}
