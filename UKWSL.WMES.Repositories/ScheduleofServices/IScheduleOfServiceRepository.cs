using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Repositories.ScheduleofServices
{
    public interface IScheduleOfServiceRepository
    {

        SOSInfo CreateScheduleofService(ScheduleofService scheduleofServices);

        SOSInfo UpdateScheduleofService(ScheduleofService scheduleofServices);

        SOSInfo GetScheduleofService(ScheduleofService scheduleofServices);

        SOSInfo GetSOSHeaderByDeal(ScheduleofService scheduleofService);

        SOSInfo CheckScheduleofServices(ScheduleofService scheduleofServices);
        SOSInfo UploadCSVRawData(ScheduleofService scheduleofService, SOSFileDetails sOSFileDetails, DataTable dataTable);
        SOSInfo InsertUploadedData(SOSInfo sOSInfo);
        SOSInfo GetScheduleofServiceBySosId(ScheduleofService scheduleofServices);

        SOSInfo DeleteSOSInfo(ScheduleofService scheduleofServices);
       
    }
}
