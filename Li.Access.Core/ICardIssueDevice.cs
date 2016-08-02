using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Li.Access.Core
{
    /// <summary>
    /// 发卡器接口
    /// </summary>
    public interface ICardIssueDevice:IDisposable
    {
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="port">端口</param>
        /// <param name="baud">波特率</param>
        void OpenCom(int port, ComBuad baud);
        /// <summary>
        /// 是否打开
        /// </summary>
        /// <returns>状态</returns>
        bool IsOpen();
        /// <summary>
        /// 关闭
        /// </summary>
        void Close();
        /// <summary>
        /// 读取卡号
        /// </summary>
        /// <returns>卡号数组</returns>
        byte[] ReadCard();
        /// <summary>
        /// 读取卡号
        /// </summary>
        /// <returns>卡号数组</returns>
        string ReadCardX();
    }
    /// <summary>
    /// 串口波特率
    /// </summary>
    public enum ComBuad
    {
        CBR_9600 = 9600,
        CBR_14400 = 14400,
        CBR_19200 = 19200,
        CBR_38400 = 38400,
        CBR_57600 = 57600,
        CBR_115200 = 115200,
    }
}
