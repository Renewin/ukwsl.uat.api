using System.Collections.Generic;
using UKWSL.WMES.Business.Entities;

namespace UKWSL.WMES.Business.ScheduleOfService
{
    public interface IScheduleOfServiceManager
    {

        SOSInfo CreateScheduleofService(ScheduleofService scheduleofServices);

        SOSInfo UpdateScheduleofService(ScheduleofService scheduleofServices);

        SOSInfo GetScheduleofService(ScheduleofService scheduleofServices);

        SOSInfo GetSOSHeaderByDeal(ScheduleofService scheduleofService);

        SOSInfo CheckScheduleofServices(ScheduleofService scheduleofServices);
        SOSInfo UploadCSVRawData(ScheduleofService scheduleofService, SOSFileDetails sOSFileDetails, List<SOSUDTFileData> sOSUDTFileData);

        SOSInfo InsertUploadedData(SOSInfo sOSInfo);

        SOSInfo GetScheduleofServiceBySosId(ScheduleofService scheduleofServices);


        SOSInfo DeleteSOSInfo(ScheduleofService scheduleofServices);

    }
}
