using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WaterResource.Models
{
    public class WellViolation
    {
        public int ID { get; set; }


        [DisplayName("تاریخ اخطار اول")]
        
        public DateTime DateFirstWarning { get; set; }

        [DisplayName("مهلت مراجعه اول")]
       
        public string DeadlineReferralFirstWarning { get; set; }

        [DisplayName("فایل اخطار اول")]
        
        public string FileFirstWarning { get; set; }

        [DisplayName("تاریخ اخطار دوم")]
        
        public DateTime SecondWarningDate { get; set; }

        [DisplayName("مهلت مراجعه دوم")]
        
        public string DeadlineReferralSecondWarning { get; set; }

        [DisplayName("فایل اخطار دوم")]
        
        public string FileSecondWarning { get; set; }

        [DisplayName("فایل بررسی کارشناسی")]
        
        public string CheckFile { get; set; }

        [DisplayName("وضعیت چاه")]
        
        public string WellPosition { get; set; }

        //محاسباتی توسط سیستم
        [DisplayName("تعداد تخلفات")]
        
        public int NumberInFraction { get; set; }

        [DisplayName("نوع تخلف")]
        
        public string Violations { get; set; }

        [DisplayName("فایل مختومه ")]
        
        public string FileClosed { get; set; }

        [DisplayName("تاریخ مختومه شدن")]
        
        public DateTime DateClosed { get; set; }

        [DisplayName("فایل های میزان صرفه جویی")]
      
        public string SavingFiles { get; set; }

        [DisplayName("میزان صرفه جویی (هزارمترمکعب)")]
       
        public decimal SavingAmount { get; set; }

        [DisplayName("نتیجه اقدامات قانونی")]
        
        public string ResultActions { get; set; }
        //توسط سیستم پر می شود
        [DisplayName("وضعیت")]
        
        public string Status { get; set; }

        [DisplayName("توضیحات")]
        
        public string Description { get; set; }

    }
}