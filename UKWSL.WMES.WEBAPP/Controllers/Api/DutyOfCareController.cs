using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UKWSL.WMES.Business.DutyOfCare;
using UKWSL.WMES.Business.Entities;
using UKWSL.WMES.Business.Entities.DoC;
using UKWSL.WMES.Resources;
using UKWSL.WMES.WEBAPP.Validations;

namespace UKWSL.WMES.WEBAPP.Controllers.Api
{
    public class DutyOfCareController : ApiController
    {
        private IDutyOfCareManager _dutyOfCareManager;
        public DutyOfCareController(IDutyOfCareManager dutyOfCareManager)
        {
            _dutyOfCareManager = dutyOfCareManager;
        }

        #region Master Financial Years 
        /// <summary>
        /// API to Get All Financial Years from Master Table
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("GetFinancialYears")]
        public IHttpActionResult GetFinancialYears()
        {
            var result = _dutyOfCareManager.GetDOCFinancialYearMaster();
            return Ok(result);
        }

        /// <summary>
        /// API to Insert or Update Financial Years in Master Table
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("InsertOrUpdateFinancialYearMaster")]
        public IHttpActionResult InsertOrUpdateFinancialYearMaster(FinancialYearMaster financialYearMaster)
        {
            var result = _dutyOfCareManager.InsertOrUpdateFinancialYearMaster(financialYearMaster);
            return Ok(result);
        }
        #endregion
        #region Master Email Templates
        /// <summary>
        /// API to Get Templates from Master Table
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("GetEmailTemplatesMaster")]
        public IHttpActionResult GetEmailTemplatesMaster()
        {
            var result = _dutyOfCareManager.GetDOCEmailTemplates();
            return Ok(result);
        }

        /// <summary>
        /// API to Insert or Update Templates in Master Table
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("InsertOrUpdateEmailTemplate")]
        public IHttpActionResult InsertOrUpdateEmailTemplate(EmailTemplatesMaster emailTemplates)
        {
            var result = _dutyOfCareManager.InsertOrUpdateEmailTemplates(emailTemplates);
            return Ok(result);
        }
        #endregion
        #region WTNDocument
        /// <summary>
        /// API to Get WTN Details by Customer ID
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("GetWTNDetailsForCustomer")]
        public IHttpActionResult GetWTNDetailsForCustomer(Master_SOS_WasteType model)
        {
            if (model != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(model.CustomerId)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.GetWTNDetailsForCustomer(model);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }

        }

        ///// <summary>
        ///// API to Insert or Update WTN Details by Customer ID
        ///// </summary>
        ///// Delivery Point: DP4.5
        //[HttpPost]
        //[ActionName("InsertWTNDocument")]
        //public IHttpActionResult InsertOrUpdateWTNDocument(DOCViewModel model)
        //{
        //    if (model != null)
        //    {
        //        if (FieldValidator.NumberValidatorWithZero(Convert.ToString(model.dOC_HeaderDetails.FYId))
        //            && FieldValidator.NumberValidatorWithZero(Convert.ToString(model.dOC_HeaderDetails.CustomerId)))                  
        //        {
        //            return Ok(new DOCViewModel
        //            {
        //                Status = Status.Failed,
        //                Message = Messages.MissingFields
        //            }); ;
        //        }
        //        else
        //        {
        //            var result = _dutyOfCareManager.InsertOrUpdateWTNDocument(model);
        //            return Ok(result);
        //        }
        //    }
        //    else
        //    {
        //        return Ok(new DOCViewModel
        //        {
        //            Status = Status.Failed,
        //            Message = Messages.MissingFields
        //        });
        //    }
        //}

        /// <summary>
        /// API to GET WTN view Details by FYID
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("GetDocumentsByFY")]
        public IHttpActionResult GetDocumentsByFY(DoC_DocumentTracker doC_DocumentTracker)
        {
            if (doC_DocumentTracker != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(doC_DocumentTracker.FYId)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.GetDOCTrackerByFY(doC_DocumentTracker);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to GET HTML Skelton by FYID and Customer Id
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("GetPageDetailsByFy")]
        public IHttpActionResult GetPageDetailsByFy(DOC_PageDetails pageDetails)
        {
            if (pageDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pageDetails.DOCId)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.GetPageDetailsByFy(pageDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to GET Response Details by DOCID
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("GetPageResponseByDOCId")]
        public IHttpActionResult GetPageResponseByDOCId(DOCPageResponse pageResponse)
        {
            if (pageResponse != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(pageResponse.DOCId)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.GetPageResponseByDOCId(pageResponse);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        #endregion
        #region Letter Tracker
        /// <summary>
        /// API to GET Email Template by DOCID
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("GetLetterTrackerByDOCId")]
        public IHttpActionResult GetLetterTracker(LetterTracker letterTracker)
        {
            if (letterTracker != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.DOCId)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.GetLetterTracker(letterTracker);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to Insert or Update Email Template
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("InsertOrUpdateLetterTracker")]
        public IHttpActionResult InsertOrUpdateLetterTracker(LetterTracker letterTracker)
        {
            if (letterTracker != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.LetterTrackerId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.DOCId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.DOC_TemplateTypeId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.DOC_EmailLink))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.PostStatus))
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(letterTracker.DOC_ContactEmail))
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(letterTracker.IsLinkOpened)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.InsertOrUpdateLetterTracker(letterTracker);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        /// <summary>
        /// API to Insert or Update Email Details
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("InsertLTEmailDetails")]
        public IHttpActionResult InsertLTEmailDetails(LetterTracker letterTracker)
        {
            if (letterTracker != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.LetterTrackerId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.Sent_to))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.Sent_cc))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.EmailSubject))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(letterTracker.EmailBody))
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(letterTracker.IsEmailSent))
                    && FieldValidator.NumberValidatorWithoutZero(Convert.ToString(letterTracker.SentOn)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.InsertLTEmailDetails(letterTracker);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        #endregion
        #region Offline Upload
        /// <summary>
        /// API to Insert SP Upload Document details
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("InsertOffilneUploadDoc")]
        public IHttpActionResult InsertOrUploadOfflineUpload(DOC_OfflineUpload upload)
        {
             if (upload != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(upload.DOCId))
                    && FieldValidator.NumberValidatorWithZero(Convert.ToString(upload.DOC_SharepointURL)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.InsertOrUpdateOfflineUpload(upload);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
         
        }
        #endregion
        #region Generate DOC
        /// <summary>
        /// API to Insert or Update DOC Header Details
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("InsertOrUpdateDOCHeaderDetails")]
        public IHttpActionResult InsertOrUpdateDOCHeaderDetails(DOCViewModel model)
        {
            if (model != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(model.dOC_HeaderDetails.FYId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(model.dOC_HeaderDetails.CustomerId))
                    || FieldValidator.NumberValidatorWithZero(Convert.ToString(model.dOC_HeaderDetails.DOCId)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.InsertOrUpdateDOCHeaderDetails(model);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }

        /// <summary>
        /// API to GET Response Details by DOCID
        /// </summary>
        /// Delivery Point: DP4.5
        [HttpPost]
        [ActionName("GetDOCHeaderDetailsByCustomerId")]
        public IHttpActionResult GetDOCHeaderDetailsByCustomerId(DOC_HeaderDetails headerDetails)
        {
            if (headerDetails != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(headerDetails.CustomerId))
                  && FieldValidator.NumberValidatorWithZero(Convert.ToString(headerDetails.Customer_AccountId))
                  && FieldValidator.NumberValidatorWithZero(Convert.ToString(headerDetails.Customer_GroupId))
                  && FieldValidator.NumberValidatorWithZero(Convert.ToString(headerDetails.FYId)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.GetDOCHeaderDetailsByCustomerId(headerDetails);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        #endregion
        #region Backing Data
        [HttpPost]
        [ActionName("GetDOCBackingData")]
        public IHttpActionResult GetDOCBackingData(DOC_BackingData backingData)
        {
            if (backingData != null)
            {
                if (FieldValidator.NumberValidatorWithZero(Convert.ToString(backingData.DOCId)))
                {
                    return Ok(new DOCViewModel
                    {
                        Status = Status.Failed,
                        Message = Messages.MissingFields
                    }); ;
                }
                else
                {
                    var result = _dutyOfCareManager.GetDOCBackingData(backingData);
                    return Ok(result);
                }
            }
            else
            {
                return Ok(new DOCViewModel
                {
                    Status = Status.Failed,
                    Message = Messages.MissingFields
                });
            }
        }
        #endregion
    }
}
