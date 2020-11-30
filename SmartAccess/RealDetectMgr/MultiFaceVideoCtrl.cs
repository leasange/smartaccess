using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.RealDetectMgr
{
    public partial class MultiFaceVideoCtrl : UserControl
    {
        private List<VideoPlayer> videoPlayers = new List<VideoPlayer>();
        private MultiVideoType multiVideoType = MultiVideoType.Four;

        public MultiVideoType MultiVideoType 
        {
            get { return multiVideoType; }
            set
            {
                SetArrayType(value);
            }
        }

        public MultiFaceVideoCtrl()
        {
            InitializeComponent();
            SetArrayType(MultiVideoType.Four);

        }
        private void SetArrayType(MultiVideoType type)
        {
            int count = 1;
            multiVideoType = type;
            switch (multiVideoType)
            {
                case MultiVideoType.One:
                    {
                        count = 1;
                    }
                    break;
                case MultiVideoType.Four:
                    {
                        count = 4;
                    }
                    break;
                default:
                    break;
            }
            while (videoPlayers.Count< count)
            {
                VideoPlayer videoPlayer = new VideoPlayer();
                videoPlayer.MouseDoubleClick += VideoPlayer_MouseDoubleClick;
                videoPlayer.MouseDown += VideoPlayer_MouseDown;
                videoPlayers.Add(videoPlayer);
                this.Controls.Add(videoPlayer);
            }
            while (videoPlayers.Count>count)
            {
                VideoPlayer videoPlayer = videoPlayers[videoPlayers.Count - 1];
                this.Controls.Remove(videoPlayer);
                videoPlayers.Remove(videoPlayer);
                videoPlayer.CloseVideo();
                videoPlayer.MouseDoubleClick -= VideoPlayer_MouseDoubleClick;
                videoPlayer.MouseDown -= VideoPlayer_MouseDown;
                videoPlayer.Dispose();
            }
            VideoPlayer vp = null;
            foreach (var item in videoPlayers)
            {
                item.IsFull = false;
                if (item.IsSelected&& vp==null)
                {
                    vp = item;
                }
                else
                {
                    item.IsSelected = false;
                }
            }
            if (videoPlayers.Count>0)
            {
                if (vp == null)
                {
                    videoPlayers[0].IsSelected = true;
                }
                UpdateArray();
            }
        }

        public void CloseAll()
        {
            foreach (var item in videoPlayers)
            {
                item.CloseVideo();
            }
        }

        private void VideoPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            VideoPlayer videoPlayer = (VideoPlayer)sender;
            videoPlayer.IsSelected = true;
            foreach (var item in videoPlayers)
            {
                if (item != videoPlayer)
                {
                    item.IsSelected = false;
                }
            }
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                VideoPlayer_MouseDoubleClick(sender, e);
            }
            this.Refresh();
        }

        private void VideoPlayer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button== MouseButtons.Left)
            {
                VideoPlayer videoPlayer = (VideoPlayer)sender;
                if (videoPlayer.IsFull)
                {
                    foreach (var item in videoPlayers)
                    {
                        item.IsFull = false;
                    }
                }
                else
                {
                    foreach (var item in videoPlayers)
                    {
                        if (item == sender)
                        {
                            item.IsFull = true;
                        }
                        else
                        {
                            item.IsFull = false;
                        }
                    }
                }
                UpdateArray();
            }
        }

        /// <summary>
        /// 更新布局
        /// </summary>
        private void UpdateArray()
        {
            if (videoPlayers.Count==0)
            {
                return;
            }
            switch (multiVideoType)
            {
                case MultiVideoType.One:
                    {
                        videoPlayers[0].SetBounds(0, 0, this.Width, this.Height);
                    }
                    break;
                case MultiVideoType.Four:
                    {
                        int dw = this.Width / 2;
                        int dh = this.Height / 2;
                        for (int r = 0; r < 2; r++)
                        {
                            for (int c = 0; c < 2; c++)
                            {
                                int index = r * 2 + c;
                                if (videoPlayers[index].IsFull)
                                {
                                    videoPlayers[index].BringToFront();
                                    videoPlayers[index].SetBounds(0, 0, this.Width, this.Height);
                                }
                                else
                                {
                                    videoPlayers[index].SetBounds(c * dw + 2, r * dh + 2, dw - 3, dh - 3);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            this.Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var item in videoPlayers)
            {
                if (item.IsSelected)
                {
                    Rectangle rectangle = new Rectangle(item.Location.X - 1, item.Location.Y - 1, item.Width + 1, item.Height + 1);
                    e.Graphics.DrawRectangle(Pens.Yellow, rectangle);
                    break;
                }
            }
            
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateArray();
        }

        private void MultiFaceVideoCtrl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public enum MultiVideoType
    {
        One,
        Four
    }
}
