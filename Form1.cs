using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;
using System.Threading;
using Memory;

namespace ETS2_DualSenseAT_Mod
{
    public partial class Form1 : Form
    {

        static UdpClient client;
        static IPEndPoint endPoint;

        static bool Server_Initialized = false;

        Mem meme = new Mem();
        static bool Connect()
        {
            try
            {
                client = new UdpClient();
                var portNumber = File.ReadAllText(@"C:\Temp\DualSenseX\DualSenseX_PortNumber.txt");
                endPoint = new IPEndPoint(Triggers.localhost, Convert.ToInt32(portNumber));
                Server_Initialized = true;
                return true;
            }catch(Exception ex)
            {
                Server_Initialized = false;
                return false;
            }
        }

        static void Send(Packet data)
        {
            if (!Server_Initialized)
                return;
            var RequestData = Encoding.ASCII.GetBytes(Triggers.PacketToJson(data));
            client.Send(RequestData, RequestData.Length, endPoint);
        }

        public Form1()
        {
            InitializeComponent();

            statusLbl.Text = "Status: Ready!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int PID = meme.GetProcIdFromName("bio4");

            if (PID > 0)
            {
                if (!Connect())
                {
                    MessageBox.Show("Failed to connect to the DSX UDP Server (" + Triggers.localhost, Convert.ToInt32(File.ReadAllText(@"C:\Temp\DualSenseX\DualSenseX_PortNumber.txt")) + ")");
                    Application.Exit();
                }
                else
                {
                    timer1.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Resident Evil 4 isn't running, please open game first!", "DualSense AT Mod");
                Application.Exit();
            }
        }

        static int iStep = 0;
        static int iMaxSteps = 0;
        private void InitializationEffect()
        {

            if (iMaxSteps < 5){
                Packet p = new Packet();

                int controllerIndex = 0;
                p.instructions = new Instruction[4];

                if (iStep == 0)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 237, 61, 7 };
                    
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, true, false, false, false, false };
                    
                    iStep = 1;
                }
                else if (iStep == 1)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 252, 0, 0 };
                    
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, false, true, false, false, false };
                    
                    iStep = 2;
                }
                else if (iStep == 2)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 148, 22, 0 };
                    
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, false, false, true, false, false };
                    
                    iStep = 3;
                }
                else if (iStep == 3)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 237, 61, 7 };
                   
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, false, false, false, true, false };
                    

                    iStep = 4;
                }
                else if (iStep == 4)
                {
                    p.instructions[0].type = InstructionType.RGBUpdate;
                    p.instructions[0].parameters = new object[] { controllerIndex, 148, 22, 0 };
                    
                    // PLAYER LED 1-5 true/false state
                    p.instructions[1].type = InstructionType.PlayerLED;
                    p.instructions[1].parameters = new object[] { controllerIndex, false, false, false, false, true };
                    

                    iStep = 0;
                    iMaxSteps += +1;
                }

                

                Send(p);
            }
            else
            {
                Packet p = new Packet();

                int controllerIndex = 0;
                p.instructions = new Instruction[4];

                p.instructions[0].type = InstructionType.RGBUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, 119, 3, 252 };

                // PLAYER LED 1-5 true/false state
                p.instructions[1].type = InstructionType.PlayerLED;
                p.instructions[1].parameters = new object[] { controllerIndex, true, false, false, false, false };

                Send(p);

                timer1.Enabled = false;
                DynamicTriggers.RunWorkerAsync();
            }

        }

        private void gameStaticTriggerValues()
        {

            Packet p = new Packet();

            int controllerIndex = 0;
            p.instructions = new Instruction[4];

            p.instructions[0].type = InstructionType.TriggerUpdate;
            p.instructions[0].parameters = new object[] { controllerIndex, Trigger.Right, TriggerMode.CustomTriggerValue, CustomTriggerValueMode.VibratePulseAB, 61, 255, 255, 5, 67, 119, 0 };

            p.instructions[1].type = InstructionType.TriggerUpdate;
            p.instructions[1].parameters = new object[] { controllerIndex, Trigger.Left, TriggerMode.Bow, 0, 1, 8, 8};

            Send(p);

        }

        private void gameDynamicTriggers()
        {
            Mem dynaMemory = new Mem();
            bool processOpen = dynaMemory.OpenProcess("bio4");
            if (processOpen)
            {
                int iHeath = dynaMemory.Read2Byte("bio4.exe+85F714");
                int iAmmo = dynaMemory.Read2Byte("bio4.exe+85F714");

                Packet p = new Packet();

                int controllerIndex = 0;
                int inst_index = 0;

                p.instructions = new Instruction[4];

                //RGB Led Health Tracker
                if (rgbledHealth.Checked)
                {
                    if (iHeath >= 800)
                    {
                        p.instructions[inst_index].type = InstructionType.RGBUpdate;
                        p.instructions[inst_index].parameters = new object[] { controllerIndex, 0, 255, 0 };
                        inst_index++;
                    }
                    else if (iHeath >= 400)
                    {
                        p.instructions[inst_index].type = InstructionType.RGBUpdate;
                        p.instructions[inst_index].parameters = new object[] { controllerIndex, 255, 187, 0 };
                        inst_index++;
                    }
                    else if (iHeath >= 1)
                    {
                        p.instructions[inst_index].type = InstructionType.RGBUpdate;
                        p.instructions[inst_index].parameters = new object[] { controllerIndex, 255, 0, 0 };
                        inst_index++;
                    }

                    else if (iHeath == 0)
                    {

                        int counter = 0;
                        while (counter < 3)
                        {

                            if (counter == 0)
                            {
                                p.instructions[inst_index].type = InstructionType.RGBUpdate;
                                p.instructions[inst_index].parameters = new object[] { controllerIndex, 250, 75, 75 };
                                inst_index++;
                            }
                            else if (counter == 1)
                            {
                                p.instructions[inst_index].type = InstructionType.RGBUpdate;
                                p.instructions[inst_index].parameters = new object[] { controllerIndex, 156, 6, 6 };
                                inst_index++;
                            }
                            else if (counter == 2)
                            {
                                p.instructions[inst_index].type = InstructionType.RGBUpdate;
                                p.instructions[inst_index].parameters = new object[] { controllerIndex, 159, 13, 13 };
                                inst_index++;
                            }
                            else if (counter == 3)
                            {
                                p.instructions[inst_index].type = InstructionType.RGBUpdate;
                                p.instructions[inst_index].parameters = new object[] { controllerIndex, 222, 113, 113 };
                                inst_index++;
                            }
                            else if (counter == 4)
                            {
                                p.instructions[inst_index].type = InstructionType.RGBUpdate;
                                p.instructions[inst_index].parameters = new object[] { controllerIndex, 181, 27, 27 };
                                inst_index++;
                            }
                            else if (counter == 5)
                            {
                                p.instructions[inst_index].type = InstructionType.RGBUpdate;
                                p.instructions[inst_index].parameters = new object[] { controllerIndex, 64, 0, 0 };
                                inst_index++;
                            }
                            Send(p);
                            counter++;
                            Thread.Sleep(200);
                        }


                    }
                }
                
                if (ammoAdpTriggers.Checked)
                {

                }


                Send(p);

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Packet p = new Packet();

            int controllerIndex = 0;

            p.instructions = new Instruction[4];

            p.instructions[0].type = InstructionType.TriggerUpdate;
            p.instructions[0].parameters = new object[] { controllerIndex, Trigger.Right, TriggerMode.Normal };


            p.instructions[1].type = InstructionType.TriggerUpdate;
            p.instructions[1].parameters = new object[] { controllerIndex, Trigger.Left, TriggerMode.Normal };


            p.instructions[2].type = InstructionType.RGBUpdate;
            p.instructions[2].parameters = new object[] { controllerIndex, 66, 135, 245 };

            Send(p);
            statusLbl.Text = "Status: Closing";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InitializationEffect();
        }

        private void DynamicTriggers_DoWork(object sender, DoWorkEventArgs e)
        {
            gameDynamicTriggers();
        }

        private void DynamicTriggers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DynamicTriggers.RunWorkerAsync();
        }
    }
}
