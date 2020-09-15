using System;
using System.Web.Http;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.ScheduleOfService;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;
using System.Web;
using System.Net.Http;
using System.Net;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class ScheduleOfServiceController : ApiController
    {
        private IScheduleOfServiceManager scheduleOfServiceManager;

        public ScheduleOfServiceController(IScheduleOfServiceManager manager)
        {
            scheduleOfServiceManager = manager;
        }


        [HttpPost]
        [ActionName("CreateScheduleOfService")]
        public IHttpActionResult CreateScheduleOfService(ScheduleofService scheduleofService)
        {
            if (scheduleofService != null)
            {
                if (string.IsNullOrEmpty(scheduleofService.EWCCode)
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.DealId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.SiteId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.WasteTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.MaterialTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.ContainerTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.ContainerSizeId))
                    || string.IsNullOrEmpty(scheduleofService.Quantity)
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.QuantityTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.FrequencyId))
                    || FieldValidator.DecimalValidator(Convert.ToString(scheduleofService.AverageContainerWeightTonnes))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.FrequencyTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.CreatedBy)))
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = scheduleOfServiceManager.CreateScheduleofService(scheduleofService);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("UpdateScheduleOfService")]
        public IHttpActionResult UpdateScheduleOfService(ScheduleofService scheduleofService)
        {
            if (scheduleofService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.SOSId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.DealId))
                     || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.SiteId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.WasteTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.MaterialTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.ContainerTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.ContainerSizeId))
                    || string.IsNullOrEmpty(scheduleofService.Quantity)
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.QuantityTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.FrequencyId))
                    || FieldValidator.DecimalValidator(Convert.ToString(scheduleofService.AverageContainerWeightTonnes))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.FrequencyTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.CreatedBy))
                    )
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = scheduleOfServiceManager.UpdateScheduleofService(scheduleofService);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        [HttpPost]
        [ActionName("GetScheduleService")]
        public IHttpActionResult GetScheduleService(ScheduleofService scheduleofService)
        {

            if (scheduleofService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.DealId)) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.SOSHeaderId)))
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = scheduleOfServiceManager.GetScheduleofService(scheduleofService);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        [HttpPost]
        [ActionName("GetScheduleServiceBySOSId")]
        public IHttpActionResult GetScheduleServiceBySOSId(ScheduleofService scheduleofService)
        {

            if (scheduleofService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.SOSId)))
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = scheduleOfServiceManager.GetScheduleofServiceBySosId(scheduleofService);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        [HttpPost]
        [ActionName("GetSOSHeaderByDeal")]
        public IHttpActionResult GetSOSHeaderByDeal(ScheduleofService scheduleofService)
        {
            if (scheduleofService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.DealId)))
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = scheduleOfServiceManager.GetSOSHeaderByDeal(scheduleofService);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }


        [HttpPost]
        [ActionName("CheckScheduleofServices")]
        public IHttpActionResult CheckScheduleofServices(ScheduleofService scheduleofService)
        {
            if (scheduleofService != null)
            {
                if (FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.DealId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.SiteId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.WasteTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.MaterialTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.ContainerTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.ContainerSizeId))
                    || string.IsNullOrEmpty(scheduleofService.Quantity)
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.FrequencyId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.FrequencyTypeId))
                    || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.CreatedBy)))
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = scheduleOfServiceManager.CheckScheduleofServices(scheduleofService);
                    result.Status = Status.Success;
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        [HttpPost]
        [ActionName("UploadSOS")]
        public IHttpActionResult UploadSOS(SOSInfo sOSInfo)
        {
            var result = scheduleOfServiceManager.UploadCSVRawData(sOSInfo.scheduleofServices, sOSInfo.sOSFileDetails, sOSInfo.sOSUDTFileData);

            return Ok(result);
        }

        [HttpPost]
        [ActionName("InsertUploadedData")]
        public IHttpActionResult InsertUploadedData(SOSInfo sOSInfo)
        {
            var result = scheduleOfServiceManager.InsertUploadedData(sOSInfo);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("DeleteSOSInfo")]
        public IHttpActionResult DeleteSOSInfo(ScheduleofService scheduleofService)
        {

            if (scheduleofService != null)
            {
                if (string.IsNullOrEmpty(Convert.ToString(scheduleofService.SOSIds)) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.SOSHeaderId)) || FieldValidator.NumberValidatorWithoutZero(Convert.ToString(scheduleofService.CreatedBy)))
                {
                    return Ok(new SOSInfo
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = scheduleOfServiceManager.DeleteSOSInfo(scheduleofService);

                    return Ok(result);
                }
            }
            else
            {
                return Ok(new SOSInfo
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

    }
}
