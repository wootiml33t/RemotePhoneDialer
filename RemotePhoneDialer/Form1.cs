using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustRemotePhone.RemotePhoneService;

namespace RemotePhoneDialer
{
    public partial class Form1 : Form
    {
        JustRemotePhone.RemotePhoneService.Application app;
        public Form1()
        {

            InitializeComponent();
            app = new JustRemotePhone.RemotePhoneService.Application("Dialer-demo");
            app.BeginConnect(true);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_1_Click(object sender, EventArgs e)
        {
            inputValidator('1');
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            inputValidator('2');
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            inputValidator('3');
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            inputValidator('4');
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            inputValidator('5');
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            inputValidator('6');
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            inputValidator('7');
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            inputValidator('8');
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            inputValidator('9');
        }

        private void button_pound_Click(object sender, EventArgs e)
        {
            inputValidator('#');
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            inputValidator('0');
        }

        private void button_star_Click(object sender, EventArgs e)
        {
            inputValidator('*');
        }

        private void button_call_Click(object sender, EventArgs e)
        {
            //Sets it so that the remotephone menu doesnt popup when the call is made
            app.RequestWindowActivationModes(WindowActivationModes.SuppressActivationForOutgoingCalls); 
            app.Phone.Call(textBoxPhoneNumber.Text);
            //now that the call has been made it tells it not to activate if a call is recieved. must be invoked here so that it counteracts the first incovation of this method
            app.RequestWindowActivationModes(WindowActivationModes.SuppressActivationForIncomingCalls);
        }

        private void inputValidator(char keyIn)
        {
            if(/*not international &&*/ textBoxPhoneNumber.Text.Length <= 9)
            {
                textBoxPhoneNumber.Text += keyIn;
            }
            else if (false/*if in call*/)
            {
                textBoxPhoneNumber.Text += keyIn;
                //dial keyIn
            }
        }

        private void textBoxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            //if not international is checked then if text length is greater than 10 trim last digit
            if(true/*international not checked*/) //this should be combined into the nested if conditions
            {
                if(textBoxPhoneNumber.Text.Length > 9)
                {
                    textBoxPhoneNumber.Text.TrimEnd();
                }
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                textBoxPhoneNumber.Text.TrimEnd(textBoxPhoneNumber.Text[textBoxPhoneNumber.Text.Length - 1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Guid smsId = new Guid();
            //string[] phoneNumbersToSendSMS = new string[1];
            //phoneNumbersToSendSMS[0] = "5555555555";
            //app.Phone.SendSMS(phoneNumbersToSendSMS, "test", out smsId);
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            app.Phone.EndCall();
        }
    }
}
