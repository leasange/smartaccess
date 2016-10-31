using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace SmartAccess.ConfigMgr
{
    public partial class MapCtrl : UserControl
    {
        private Image _mapImage = null;//地图背景
        private RectangleF _mapRect = RectangleF.Empty;//地图区域
        private Color _textBoundColor = Color.Black;
        private bool _isEditMode = false;
        private string _mapName = "";
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set { _isEditMode = value; }
        }
        public System.Drawing.Color TextBoundColor
        {
            get 
            { return _textBoundColor; }
            set { 
                _textBoundColor = value;
                this.Invalidate();
            }
        }
        private List<DoorRectangle> _doors = new List<DoorRectangle>();
        public System.Drawing.RectangleF MapRect
        {
            get { return _mapRect; }
            set
            { 
                _mapRect = value;
                this.Refresh();
            }
        }
        public System.Drawing.Image MapImage
        {
            get { return _mapImage; }
            set
            {
                try
                {
                    if (_mapImage != null && _mapImage == value)
                    {
                        return;
                    }
                    if (_mapImage != null)
                    {
                        _mapImage.Dispose();
                        _mapImage = null;
                    }
                    _mapImage = value;
                    FullExtent();
                    this.Refresh();
                }
                catch (Exception)
                {
                }
                
            }
        }

        public MapCtrl()
        {
            InitializeComponent();
            FullExtent();
            this.AddDoors(new DoorRectangle()
            {
                Id = 0,
                DoorName = "你好哦",
                RatioX = 0.1,
                RatioY = 0.1,
                RatioWidth = 0.1,
                RatioHeight = 0.1
            });
        }

        public void LoadMapInfo(Maticsoft.Model.SMT_MAP_INFO mapInfo)
        {
            _doors.Clear();
            _mapImage = null;
            if (mapInfo==null)
            {
                this.Invalidate();
                return;
            }
            _mapName = mapInfo.MAP_NAME;
            if (mapInfo.MAP_IMAGE!=null&&mapInfo.MAP_IMAGE.Length>0)
            {
                MemoryStream ms=new MemoryStream(mapInfo.MAP_IMAGE);
                //Image image = Image.FromStream(ms);
                _mapImage = Image.FromStream(ms);
                //image.Dispose();
                ms.Dispose();
            }
            if (mapInfo.MAP_DOORS!=null&&mapInfo.MAP_DOORS.Count>0)
            {
                foreach (var item in mapInfo.MAP_DOORS)
                {
                    DoorRectangle dr = new DoorRectangle();
                    dr.Id = item.DOOR_ID;
                    dr.IsSelected = false;
                    dr.RatioX = (double)item.LOCATION_X;
                    dr.RatioY = (double)item.LOCATION_Y;
                    dr.RatioWidth = (double)item.WIDTH;
                    dr.RatioHeight = (double)item.HEIGHT;
                    if (item.DOOR!=null)
                    {
                        dr.IsOnline = item.DOOR.OPEN_STATE != 2;
                        if (item.DOOR.CTRL_STYLE == 1)
                        {
                            dr.IsOpen = true;
                        }
                        else if (item.DOOR.CTRL_STYLE == 2)
                        {
                            dr.IsOpen = false;
                        }
                        else
                        {
                            dr.IsOpen = item.DOOR.OPEN_STATE == 1;
                        }
                        dr.DoorName = item.DOOR.DOOR_NAME;
                    }
                    _doors.Add(dr);
                }
            }
            this.Invalidate();
        }

        private PointF ToExtentPoint(Point ctrlPoint)
        {
            float x = (ctrlPoint.X - _mapRect.Left) / _mapRect.Width;
            float y = (ctrlPoint.Y - _mapRect.Top) / _mapRect.Height;
            return new PointF(x, y);
        }

        public void AddDoorInfo(Maticsoft.Model.SMT_DOOR_INFO doorInfo, Point ctrlPoint)
        {
            if (_doors.Exists(m => m.Id == doorInfo.ID))
            {
                return;
            }
            DoorRectangle dr = new DoorRectangle();
            dr.Id = doorInfo.ID;
            dr.IsOnline = true;
            dr.IsOpen = false;
            dr.IsSelected = false;
            PointF pf = ToExtentPoint(ctrlPoint);
            dr.RatioX = pf.X;
            dr.RatioY = pf.Y;
            dr.RatioWidth = (double)32 / _mapRect.Width;
            dr.RatioHeight = (double)32 / _mapRect.Height;

            RectangleF rect= dr.GetRect(_mapRect);
            if (rect.Left-_mapRect.Left<0)
            {
                dr.RatioX = 0;
            }
            if (rect.Top-_mapRect.Top<0)
            {
                dr.RatioY = 0;
            }
            if (rect.Right>_mapRect.Right)
            {
                dr.RatioX -= (rect.Right - _mapRect.Right) / _mapRect.Width;
            }
            if (rect.Bottom>_mapRect.Bottom)
            {
                dr.RatioY-=(rect.Bottom - _mapRect.Bottom) / _mapRect.Height;
            }

            dr.DoorName = doorInfo.DOOR_NAME;
            _doors.Add(dr);
            this.Invalidate();
        }


        public void AddDoors(params DoorRectangle[] doors)
        {
            if (doors!=null&&doors.Length>0)
            {
                foreach (var item in doors)
                {
                    if (_doors.Exists(m => m.Id == item.Id)) continue;
                    _doors.Add(item);
                }
            }
            this.Invalidate();
        }
        public DoorRectangle[] GetDoors()
        {
            return _doors.ToArray();
        }
        public DoorRectangle GetDoor(decimal id)
        {
            return _doors.Find(m => m.Id == id);
        }

        public void RemoveDoors(params decimal[] doorIds)
        {
            if (doorIds!=null&&doorIds.Length>0)
            {
               _doors.RemoveAll(m => doorIds.Contains(m.Id));
               this.Invalidate();
            }
        }

        public List<DoorRectangle> DeleteSelectDoors()
        {
             var ds=_doors.FindAll(m => m.IsSelected);
             foreach (var item in ds)
             {
                 _doors.Remove(item);
             }
            this.Invalidate();
            return ds;
        }

        public void ClearDoors()
        {
            _doors.Clear();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawMapImage(e.Graphics);
        }

        private void MapCtrl_Load(object sender, EventArgs e)
        {
           // FullExtent();
        }


        protected override void OnHandleDestroyed(EventArgs e)
        {
            CloseMap();
            base.OnHandleDestroyed(e);
        }

        public void CloseMap()
        {
            try
            {
                if (_mapImage != null)
                {
                    _mapImage.Dispose();
                    _mapImage = null;
                }
                _doors.Clear();
                if (!this.IsDisposed)
                {
                    FullExtent();
                    this.Invalidate();
                }
            }
            catch (Exception)
            {
            }

        }

        //铺满窗口
        private void FillView()
        {
            _mapRect = new RectangleF(0, 0, this.Width, this.Height);
            this.Refresh();
        }
        //全图显示
        public void FullExtent()
        {
            if (_mapImage == null)
            {
                FillView();
            }
            else
            {
                double rati1 = this.Width / (double)this.Height;
                double rati2 = _mapImage.Width / (double)_mapImage.Height;
                if (rati1 > rati2)
                {
                    double w = rati2 * this.Height;
                    double h = this.Height;
                    _mapRect.X = (float)(this.Width / 2d - w / 2);
                    _mapRect.Y = 0;
                    _mapRect.Width = (float)w;
                    _mapRect.Height = (float)h;
                }
                else
                {
                    double w = this.Width;
                    double h = this.Width / rati2;
                    _mapRect.X = 0;
                    _mapRect.Y = (float)(this.Height / 2d - h / 2);
                    _mapRect.Width = (float)w;
                    _mapRect.Height = (float)h;
                }
                this.Refresh();
            }
        }

        public void DelayFullExtent(int miniSeconds = 200)
        {
            Timer t = new Timer();
            t.Interval = miniSeconds;
            t.Tick += delegate(object sender, EventArgs e)
                {
                    t.Stop();
                    FullExtent();
                };
            t.Start();
        }

       

        //绘制背景地图
        private void DrawMapImage(Graphics g)
        {
            if (_mapImage == null)
            {
                g.DrawRectangle(new Pen(Color.Black, 1), _mapRect.X, _mapRect.Y, _mapRect.Width, _mapRect.Height);
            }
            else
            {
                g.DrawImage(_mapImage, _mapRect);
            }

            foreach (var item in this._doors)
            {
                if (item != null)
                {
                    var rect = item.GetRect(_mapRect);
                    if (item.IsSelected)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Blue)), rect);
                    }
                    g.DrawImage(item.GetImage(), rect);
                    if ( !string.IsNullOrWhiteSpace(item.DoorName))
	                {
                        SizeF s = g.MeasureString(item.DoorName, this.Font);
                        float x = rect.Left + rect.Width / 2 - s.Width / 2;
                        float y = rect.Bottom + 2;
                        RectangleF rectText=new RectangleF(x,y,s.Width,s.Height);

                        DrawText(g, item.DoorName, rectText);

                        g.DrawString(item.DoorName, this.Font, new SolidBrush(this.ForeColor), rectText);
	                }
                }
            }
        }

        private void DrawText(Graphics g, string text, RectangleF rect)
        {
            StringFormat format = StringFormat.GenericTypographic;
            float dpi = g.DpiY;
            using (GraphicsPath path = GetStringPath(text, dpi, rect, this.Font, format))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;//设置字体质量
                g.DrawPath(new Pen(_textBoundColor,3), path);//绘制轮廓（描边）
                g.DrawString(text, this.Font, new SolidBrush(this.ForeColor), rect);//填充轮廓（填充）
            }
        }
        private GraphicsPath GetStringPath(string s, float dpi, RectangleF rect, Font font, StringFormat format)
        {
            GraphicsPath path = new GraphicsPath();
            // Convert font size into appropriate coordinates
            float emSize = dpi * font.SizeInPoints / 72;
            path.AddString(s, font.FontFamily, (int)font.Style, emSize, rect, format);

            return path;
        }

        private Point _lastMouseMoveDown = Point.Empty;
        public void MoveMap(float x, float y)
        {
            _mapRect.X += x;
            _mapRect.Y += y;
            this.Invalidate();
        }
        private void MapCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.None)
            {
                TestMousePositionDoor(e.Location);
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)//移动
            {
                if (_isEditMode && _downSelectDoor != null)
                {
                    if (this.Cursor == Cursors.SizeAll)//移动
                    {
                        RectangleF rect = _downSelectDoor.GetRect(_mapRect);
                        rect.X += Cursor.Position.X - _lastMouseMoveDown.X;
                        rect.Y += Cursor.Position.Y - _lastMouseMoveDown.Y;
                        if (rect.X >= _mapRect.Left - rect.Width + 4 &&
                            rect.Y >= _mapRect.Top - rect.Height + 4 &&
                            rect.Bottom <= _mapRect.Bottom + rect.Height - 4 &&
                            rect.Right <= _mapRect.Right + rect.Width - 4)
                        {
                            UpdateDoorAttri(_downSelectDoor, rect);
                        }
                    }
                    else if (this.Cursor == Cursors.SizeNWSE)
                    {
                        RectangleF rect = _downSelectDoor.GetRect(_mapRect);
                        rect.Width += Cursor.Position.X - _lastMouseMoveDown.X;
                        rect.Height += Cursor.Position.Y - _lastMouseMoveDown.Y;
                        if (rect.Width > 2 && rect.Height > 2)
                        {
                            UpdateDoorAttri(_downSelectDoor, rect);
                        }
                    }
                }
                else
                {
                    MoveMap(Cursor.Position.X - _lastMouseMoveDown.X, Cursor.Position.Y - _lastMouseMoveDown.Y);
                }
                _lastMouseMoveDown = Cursor.Position;
            }
        }
        private DoorRectangle _downSelectDoor = null;

        private void UpdateDoorAttri(DoorRectangle door, RectangleF rect)
        {
            door.RatioX = (rect.X - _mapRect.X) / _mapRect.Width;
            door.RatioY = (rect.Y - _mapRect.Y) / _mapRect.Height;
            door.RatioHeight = rect.Height / _mapRect.Height;
            door.RatioWidth = rect.Width / _mapRect.Width;
            this.Invalidate();
        }

        private void MapCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                _lastMouseMoveDown = Cursor.Position;
                _downSelectDoor = DoSelectedDoor(e.Location);
            }
        }
        public DoorRectangle DoSelectedDoor(Point p)
        {
            bool vali = false;
            DoorRectangle door = null;
            foreach (var item in this._doors)
            {
                RectangleF rect = item.GetRect(_mapRect);
                if (rect.Contains(p))
                {
                    item.IsSelected = true;
                    door = item;
                    vali = true;
                }
                else if (item.IsSelected)
                {
                    item.IsSelected = false;
                    vali = true;
                }
            }
            if (vali)
            {
                this.Invalidate();
            }
            return door;
        }

        public DoorRectangle TestMousePositionDoor(Point p)
        {
            foreach (var item in this._doors)
            {
                RectangleF rect = item.GetRect(_mapRect);
                if (rect.Contains(p))
                {
                    if (_isEditMode)
                    {
                        if (p.X >= rect.Right - 3 || p.Y >= rect.Bottom - 3)
                        {
                            this.Cursor = Cursors.SizeNWSE;
                        }
                        else
                        {
                            this.Cursor = Cursors.SizeAll;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Hand;
                    }
                    return item;
                }
            }
            this.Cursor = Cursors.Hand;
            return null;
        }

        public void ZoomPlus()
        {
            Point p=new Point(this.Width/2,this.Height/2);
            DoZoom(p, true);
        }
        public void ZoomMinus()
        {
            Point p = new Point(this.Width / 2, this.Height / 2);
            DoZoom(p, false);
        }
        private void DoZoom(Point e,bool plus=true)
        {
            if (timerWheel.Enabled)
            {
                return;
            }
            timerWheel.Start();
            if (plus)
            {
                if (_mapRect.Width * 2 > 40000 || _mapRect.Height * 2 > 40000)
                {
                    return;
                }
                float x = _mapRect.X - (e.X - _mapRect.X);
                float y = _mapRect.Y - (e.Y - _mapRect.Y);
                _mapRect.X = x;
                _mapRect.Y = y;
                _mapRect.Width = _mapRect.Width * 2;
                _mapRect.Height = _mapRect.Height * 2;
            }
            else
            {
                if (_mapRect.Width / 2 < 10 || _mapRect.Height / 2 < 10)
                {
                    return;
                }
                _mapRect.X = e.X / 2 + _mapRect.X / 2;
                _mapRect.Y = e.Y / 2 + _mapRect.Y / 2;
                _mapRect.Width = _mapRect.Width / 2;
                _mapRect.Height = _mapRect.Height / 2;

            }
            this.Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                DoZoom(e.Location,true);
            }
            else
            {
                DoZoom(e.Location, false);
            }
        }

        private void timerWheel_Tick(object sender, EventArgs e)
        {
            timerWheel.Stop();
        }

        private void tsmiFullMap_Click(object sender, EventArgs e)
        {
            FullExtent();
        }
    }
}
