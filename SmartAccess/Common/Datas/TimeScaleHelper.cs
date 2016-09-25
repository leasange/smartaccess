using Li.Access.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    /// <summary>
    /// 时段帮助类
    /// </summary>
    public class TimeScaleHelper
    {
        public static TimeScaleNum ToTimeScale(Maticsoft.Model.SMT_TIMESCALE_INFO tsInfo)
        {
            TimeScaleNum tsNum = new TimeScaleNum();
            tsNum.Num = tsInfo.TIME_NO;
            tsNum.NextNum = tsInfo.TIME_NEXT_NO;
            tsNum.startDate = tsInfo.TIME_DATE_START;
            tsNum.endDate = tsInfo.TIME_DATE_END;
            tsNum.weekDaysEnable[0] = tsInfo.TIME_WEEK_DAY1;
            tsNum.weekDaysEnable[1] = tsInfo.TIME_WEEK_DAY2;
            tsNum.weekDaysEnable[2] = tsInfo.TIME_WEEK_DAY3;
            tsNum.weekDaysEnable[3] = tsInfo.TIME_WEEK_DAY4;
            tsNum.weekDaysEnable[4] = tsInfo.TIME_WEEK_DAY5;
            tsNum.weekDaysEnable[5] = tsInfo.TIME_WEEK_DAY6;
            tsNum.weekDaysEnable[6] = tsInfo.TIME_WEEK_DAY7;
            tsNum.timeScales.Add(new TimeScale()
                {
                    start=tsInfo.TIME_RANGE_START1,
                    end=tsInfo.TIME_RANGE_END1
                });
            tsNum.timeScales.Add(new TimeScale()
            {
                start = tsInfo.TIME_RANGE_START2,
                end = tsInfo.TIME_RANGE_END2
            });
            tsNum.timeScales.Add(new TimeScale()
            {
                start = tsInfo.TIME_RANGE_START3,
                end = tsInfo.TIME_RANGE_END3
            });
            return tsNum;
        }
    }
}
