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

namespace PInvokeThreadParameterized
{
    //delegate
    public delegate void DelegateParameterizedVoid(int getal);

    //class
    public partial class frmThread : Form
    {
        /// <summary>
        /// Field variabeles
        /// </summary>

        public int cntSec { get; set; }
        //int cntSec = 0;
        System.Timers.Timer secondTimer;

        /// <summary>
        /// Constructor
        /// </summary>
        public frmThread()
        {
            InitializeComponent(); 
            cntSec = 0;

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
            SetText(cntSec);           
        }

        /// <summary>
        /// Parameterized delegate void to do some work
        /// </summary>
        private void SetText(int getal)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateParameterizedVoid(this.SetText), new object[] { getal });
            }
            else
            {
                lblSecondCntSeconds.Text = getal.ToString();
            }
        }


        public delegate void DelegateIetsAnders();
        // ik zit in een thread
        private void DoeIetsAnders()
        {
            if (InvokeRequired)
            {
                this.Invoke(new DelegateIetsAnders(this.DoeIetsAnders));
            }
            else
            {
                lblMainCountSec.Text = "labeltje zetten";
            }
        }
    }
}
