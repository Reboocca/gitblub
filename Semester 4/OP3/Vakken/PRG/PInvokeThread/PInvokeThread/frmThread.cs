using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PInvokeThread
{
    //delegate
    public delegate void DelegateStandardVoid();

    //class
    public partial class frmThread : Form
    {
        /// <summary>
        /// Field variabeles
        /// </summary>
        int cntSec = 0;
        System.Timers.Timer secondTimer;

        /// <summary>
        /// Constructor
        /// </summary>
        public frmThread()
        {            
            InitializeComponent();
            
            secondTimer = new System.Timers.Timer(1000);
            secondTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);

            // Start timer on the main thread.
            tmMain.Start();
        }

        /// <summary>
        /// Starts timer on the main thread
        /// </summary>
        private void tmMain_Tick(object sender, EventArgs e)
        {
            cntSec++;

            //update mainGroup
            lblMainCountSec.Text = cntSec.ToString();
            if (cntSec == 5)
            {
                tmMain.Stop();

                //start second timer in thread
                Thread t = new Thread(StartSecondTimer);
                t.Start();
            }
        }

        /// <summary>
        /// Start second timer in second thread
        /// </summary>
        private void StartSecondTimer()
        {
            secondTimer.Start();
        }

        /// <summary>
        /// Event on second timer
        /// </summary>
        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            //do something with the timer
            cntSec++;
            SetText();
                    
        }

        /// <summary>
        /// Parameterized delegate void to do some work
        /// </summary>
        private void SetText()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateStandardVoid(this.SetText));
            }
            else
            {
                lblSecondCntSeconds.Text = cntSec.ToString();
            }            
        }
    }
}
