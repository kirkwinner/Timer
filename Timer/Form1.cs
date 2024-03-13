using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer.Properties;

namespace Timer
{

    public partial class CheekyTimer : Form
    {
        private int timeLeft = 0;

        private int workTimer = 20;
        private int restTimer = 5;

        private bool isTicking = false;
        private bool isBlinking = false;
        private bool blinkToggle = false;
        private bool timerBlink = false;

        private Color faded = Color.FromArgb(50, 50, 50);

        private readonly CheekySound sound = new CheekySound();

        private Color CurrentColor
        {
            get => m_CurrentColor;
            set
            {
                m_CurrentColor = value;

                Timer.ForeColor = m_CurrentColor;
                LeftInc.ForeColor = m_CurrentColor;
                RightInc.ForeColor = m_CurrentColor;
                LeftDec.ForeColor = m_CurrentColor;
                RightDec.ForeColor = m_CurrentColor;
                LeftTime.ForeColor = m_CurrentColor;
                RightTime.ForeColor = m_CurrentColor;
                Quit.ForeColor = m_CurrentColor;
            }
        }

        //private SoundPlayer alarmPlayer = new SoundPlayer(Resources.ResourceManager.GetStream("Timer_Alarm_Long_Padded"));
        private Color m_CurrentColor;

        private void CheekyTimer_Load(object sender, EventArgs e)
        {
            workTimer = Settings.Default.LeftTimerValue;
            restTimer = Settings.Default.RightTimerValue;

            RepaintText();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void CheekyTimer_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CheekyTimer_Move(object sender, EventArgs e)
        {
            Settings.Default.LocationX = Location.X;
            Settings.Default.LocationY = Location.Y;

            Settings.Default.Save();
        }

        public CheekyTimer()
        {
            InitializeComponent();

            //WindowState = FormWindowState.Normal;
            Size = new Size(284, 30);

            LeftTime.Text = workTimer.ToString();
            RightTime.Text = restTimer.ToString();
            TopMost = true;
            //this.BackColor = Color.Black;
            //this.TransparencyKey = Color.Black;

            CurrentColor = Color.White;

            StartPosition = FormStartPosition.Manual;

            Location = new Point(Settings.Default.LocationX, Settings.Default.LocationY);

            ResetBlink();
        }

        private string CurrentTime => (timeLeft / 60).ToString("00") + ":" + (timeLeft % 60).ToString("00");

        private void Timer_Click(object sender, EventArgs e)
        {
            ResetBlink();
        }

        private void ResetBlink(bool skipIfNotBlinking = false)
        {
            if (skipIfNotBlinking && !isBlinking)
            {
                return;
            }

            //if (alarmPlayer != null)
            //{
            //    alarmPlayer.Stop();
            //}
            sound.AlarmStop();

            Size = new Size(284, 30);
            timerBlinkTimer.Start();

            blinkToggle = false;
            isBlinking = false;
            isTicking = false;
            timeLeft = 0;
            blinkTimer.Stop();
            tickTimer.Stop();

            CurrentColor = Color.White;
            SetColour();

            Timer.Text = CurrentTime;

            ActiveControl = null;
        }

        private void SetColour()
        {
            RootPanel.BackColor = blinkToggle ? Color.Gray : Color.Black;
        }

        private void StartBlinking()
        {
            isBlinking = true;
            blinkTimer.Start();
            //PlayAlarm();
            sound.AlarmStart();
            CurrentColor = Color.White;

            Size = new Size(284, 284);
            //WindowState = FormWindowState.Maximized;
        }

        private void tickTimer_Tick(object sender, EventArgs e)
        {
            if (isTicking)
            {
                timeLeft--;

                if (timeLeft <= 0)
                {
                    timeLeft = 0;
                    isTicking = false;

                    tickTimer.Stop();

                    StartBlinking();
                }

                Timer.Text = CurrentTime;
            }
        }

        private void RepaintText()
        {
            LeftTime.Text = workTimer.ToString();
            RightTime.Text = restTimer.ToString();

            Settings.Default.LeftTimerValue = workTimer;
            Settings.Default.RightTimerValue = restTimer;

            Settings.Default.Save();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetBlink();
            timeLeft = workTimer * 60;
            Timer.Text = CurrentTime;
            isTicking = true;
            tickTimer.Start();

            CurrentColor = faded;
            timerBlinkTimer.Stop();

            //SoundPlayer setPlayer = new SoundPlayer(Resources.ResourceManager.GetStream("Timer_Set_Long_Padded"));
            //setPlayer.Play();

            sound.LongTimerSet();

            ActiveControl = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ResetBlink();
            timeLeft = restTimer * 60;
            Timer.Text = CurrentTime;
            isTicking = true;
            tickTimer.Start();

            CurrentColor = faded;
            timerBlinkTimer.Stop();

            //SoundPlayer setPlayer = new SoundPlayer(Resources.ResourceManager.GetStream("Timer_Set_Short_Padded"));
            //setPlayer.Play();
            sound.ShortTimerSet();

            ActiveControl = null;
        }

        private void LeftDec_Click(object sender, EventArgs e)
        {
            ResetBlink(true);
            workTimer -= 1;

            if (workTimer <= 1)
            {
                workTimer = 1;
            }

            RepaintText();

            ActiveControl = null;
        }

        private void LeftInc_Click(object sender, EventArgs e)
        {
            ResetBlink(true);
            workTimer += 1;

            if (workTimer >= 99)
            {
                workTimer = 99;
            }

            RepaintText();

            ActiveControl = null;
        }

        private void RightDec_Click(object sender, EventArgs e)
        {
            ResetBlink(true);
            restTimer -= 1;

            if (restTimer <= 1)
            {
                restTimer = 1;
            }

            RepaintText();

            ActiveControl = null;
        }

        private void RightInc_Click(object sender, EventArgs e)
        {
            ResetBlink(true);
            restTimer += 1;

            if (restTimer >= 99)
            {
                restTimer = 99;
            }

            RepaintText();

            ActiveControl = null;
        }

        private void blinkTimer_Tick(object sender, EventArgs e)
        {
            blinkToggle = !blinkToggle;

            SetColour();

            ActiveControl = null;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlayAlarm()
        {
            //alarmPlayer.Stop();
            //alarmPlayer.PlayLooping();
            sound.AlarmStop();
            sound.AlarmStart();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            sound.AlarmStop();
            Close();
        }

        private void timerBlinkTimer_Tick(object sender, EventArgs e)
        {
            timerBlink = !timerBlink;

            Timer.ForeColor = timerBlink ? Color.White : BackColor;
        }
    }
    
}
