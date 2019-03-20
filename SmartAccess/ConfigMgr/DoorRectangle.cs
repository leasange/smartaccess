using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SmartAccess.ConfigMgr
{
    public class DoorRectangle
    {
        private decimal id;//id号
        private int doorType = 1;//门类型
        private string doorName;//门禁名称
        private bool isSelected = false;
        private bool isOpen = false;//打开
        private bool isOnline = true;//在线
        private double _ratioX = 0;
        private double _ratioY = 0;
        private double _ratioWidth = 0;
        private double _ratioHeight = 0;
        public decimal Id
        {
            get { return id; }
            set { id = value; }
        }

        public int DoorType
        {
            get { return doorType; }
            set { doorType = value; }
        }

        public string MapDoorID
        {
            get { return id + "-" + doorType; }
        }

        public double RatioX
        {
            get { return _ratioX; }
            set
            {
                _ratioX = value;
            }
        }
        public double RatioY
        {
            get { return _ratioY; }
            set
            {
                _ratioY = value;
            }
        }
        public double RatioWidth
        {
            get { return _ratioWidth; }
            set
            {
                _ratioWidth = value;
            }
        }
        public double RatioHeight
        {
            get { return _ratioHeight; }
            set
            {
                _ratioHeight = value;
            }
        }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
            }
        }
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
            }
        }

        public bool IsOnline
        {
            get { return isOnline; }
            set
            {
                isOnline = value;
            }
        }
        public string DoorName
        {
            get { return doorName; }
            set
            {
                doorName = value;
            }
        }

        public Image GetImage()
        {
            if (doorType==1)
            {
                if (!isOnline)
                {
                    return Properties.Resources.door_dump;
                }
                else
                {
                    return isOpen ? Properties.Resources.room_open : Properties.Resources.door_close;
                }
            }
            else
            {
                return Properties.Resources.人脸识别设备;
            }
            
        }
        public RectangleF GetRect(RectangleF baseRect)
        {
            double x = baseRect.Width * _ratioX+baseRect.X;
            double y = baseRect.Height * _ratioY + baseRect.Y;
            double w = baseRect.Width * _ratioWidth;
            double h = baseRect.Height * _ratioHeight;
            return new RectangleF((float)x, (float)y, (float)w, (float)h);
        }

        public object Door { get; set; }
    }
}
