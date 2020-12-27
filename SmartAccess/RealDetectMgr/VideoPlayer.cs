using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Access.Core;
using System.Threading;

namespace SmartAccess.RealDetectMgr
{
    public partial class VideoPlayer : UserControl
    {
        public bool IsFull;
        public bool IsSelected;
        public PlayerState PlayerState
        {
            get
            {
                if (playerObject==null)
                {
                    return PlayerState.None;
                }
                return playerObject.PlayerState;
            }
        }
        private PlayerObject playerObject;
        private PlayerObject Player
        {
            get
            {
                return playerObject;
            }
            set
            {
                lock (this)
                {
                    if (playerObject != null)
                    {
                        playerObject.ClosePlay();
                    }
                    playerObject = value;
                }
            }
        }
        public VideoPlayer()
        {
            InitializeComponent();
            this.CreateControl();
        }

        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            timerCheck.Start();
            if (this.lbTip.Visible)
            {
                this.lbTip.Location = new Point(this.Width / 2 - this.lbTip.Width / 2, this.Height / 2 - this.lbTip.Height / 2);
            }
        }

        public void RealPlay(FaceWatchThread faceWatchThread)
        {
            this.Player = new PlayerObject(this);
            this.Player.RealPlay(faceWatchThread);
        }
        public void CloseVideo()
        {
            this.Player = null;
        }
        public void UpdateState()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    switch (this.PlayerState)
                    {
                        case PlayerState.None:
                            this.lbTip.Visible = true;
                            this.lbTip.Text = "暂无视频";
                            break;
                        case PlayerState.Loading:
                            this.lbTip.Visible = true;
                            this.lbTip.Text = "视频加载中...";
                            break;
                        case PlayerState.Playing:
                            this.lbTip.Visible = false;
                            this.lbTip.Text = "播放成功";
                            break;
                        case PlayerState.Failed:
                            this.lbTip.Visible = true;
                            this.lbTip.Text = "播放失败";
                            break;
                        default:
                            break;
                    }
                    if (this.lbTip.Visible)
                    {
                        this.lbTip.Location = new Point(this.Width / 2 - this.lbTip.Width / 2, this.Height / 2 - this.lbTip.Height / 2);
                    }
                }));
            }
            else
            {
                switch (this.PlayerState)
                {
                    case PlayerState.None:
                        this.lbTip.Visible = true;
                        this.lbTip.Text = "暂无视频";
                        break;
                    case PlayerState.Loading:
                        this.lbTip.Visible = true;
                        this.lbTip.Text = "视频加载中...";
                        break;
                    case PlayerState.Playing:
                        this.lbTip.Visible = false;
                        this.lbTip.Text = "播放成功";
                        break;
                    case PlayerState.Failed:
                        this.lbTip.Visible = true;
                        this.lbTip.Text = "播放失败";
                        break;
                    default:
                        break;
                }
                if (this.lbTip.Visible)
                {
                    this.lbTip.Location = new Point(this.Width / 2 - this.lbTip.Width / 2, this.Height / 2 - this.lbTip.Height / 2);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseVideo();
        }
        protected override void DestroyHandle()
        {
            this.CloseVideo();
            base.DestroyHandle();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            Point point = this.PointToClient(Cursor.Position);
            if (point.X > 0 && point.X < this.Width && point.Y > 0 && point.Y < this.Height)
            {
                plClose.Visible = true;
            }
            else
            {
                plClose.Visible = false;
            }
        }

        private void VideoPlayer_DragDrop(object sender, DragEventArgs e)
        {
            object[] arr = e.Data.GetData(typeof(object[])) as object[];
            RealDoorState state = arr[0] as RealDoorState;
            this.Player = new PlayerObject(this);
            state.StartRealDetect((ListViewItem)arr[1], this.Player);
        }

        private void VideoPlayer_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(object[])))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void VideoPlayer_SizeChanged(object sender, EventArgs e)
        {
            if (this.lbTip.Visible)
            {
                this.lbTip.Location = new Point(this.Width / 2 - this.lbTip.Width / 2, this.Height / 2 - this.lbTip.Height / 2);
            }
        }
    }

    public enum PlayerState
    {
        None,
        Loading,
        Playing,
        Failed
    }

    public class PlayerObject
    {
        private bool bSetClosed = false;
        private FaceWatchThread faceWatchThread;
        private PlayerState playerState;
        public PlayerState PlayerState
        {
            get
            {
                if (bSetClosed)
                {
                    return PlayerState.None;
                }
                return playerState;
            }
        }

        private VideoPlayer videoPlayer;
        private IntPtr winHandle;
        public PlayerObject(VideoPlayer videoPlayer)
        {
            this.videoPlayer = videoPlayer;
            winHandle = this.videoPlayer.Handle;
            this.playerState = PlayerState.Loading;
            videoPlayer.UpdateState();
        }

        public void ClosePlay()
        {
            bSetClosed = true;
            if (this.playerState == PlayerState.Playing)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        this.faceWatchThread.FaceRecg.StopPlayVideo(winHandle);
                    }
                    catch (Exception )
                    {
                    }

                }));
            }
            this.playerState = PlayerState.None;
            videoPlayer.UpdateState();
        }

        public void RealPlay(FaceWatchThread faceWatchThread)
        {
            this.faceWatchThread = faceWatchThread;
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
            {
                try
                {
                    while (!bSetClosed)
                    {
                        if (this.faceWatchThread.FaceRecg!=null)
                        {
                            if (!this.faceWatchThread.FaceRecg.StartPlayVideo(winHandle))
                            {
                                this.playerState = PlayerState.Failed;
                            }
                            else
                            {
                                this.playerState = PlayerState.Playing ;

                            }
                            videoPlayer.UpdateState();

                            break;
                        }
                        else
                        {
                            Thread.Sleep(200);
                        }
                    }
                    if (bSetClosed&&this.playerState== PlayerState.Playing)
                    {
                        this.faceWatchThread.FaceRecg.StopPlayVideo(winHandle);
                        this.playerState = PlayerState.None;
                        videoPlayer.UpdateState();
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        if(this.playerState == PlayerState.Playing)
                        {
                            this.faceWatchThread.FaceRecg.StopPlayVideo(winHandle);
                        }
                        this.playerState = PlayerState.Failed;
                        videoPlayer.UpdateState();
                    }
                    catch (Exception)
                    { 
                    }
                }
            }));
        }
    }
}
