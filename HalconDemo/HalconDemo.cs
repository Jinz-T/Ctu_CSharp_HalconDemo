using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HalconDemo
{
    public struct CurrentCom
    {
        public int CurrentModel;
        public HWindow hv;
        public HTuple AcqHandle;
        public HObject ho_Image;
        public HTuple ho_Width;
        public HTuple ho_Height;
        public bool ThreadFlag;
        public HObject ModelROI;
        public CurrentCom(int a, HWindow b, HTuple c, HObject d, HTuple e,HTuple f,bool g,HObject h)
        { 
            CurrentModel = a;
            hv = b;
            AcqHandle = c;
            ho_Image = d;
            ho_Width = e;
            ho_Height = f;
            ThreadFlag = g;
            ModelROI = h;
        }
    };

    struct ModelCom
    {
        public bool EffectiveFlag;
        public HObject h_img;
        public HObject h_roi;
        public HTuple hv_ModelID;
        public HObject ho_ShapeModel;
        public HTuple hv_Orgin_Row;
        public HTuple hv_Orgin_Column;
        public HTuple hv_Orgin_Angle;
    }; 

    public partial class HalconDemo : Form
    {
        CurrentCom MyCurCom;
        ModelCom[] MyModel = new ModelCom[3];
        HHomMat2D RobotHommat = null;
        private readonly object locker1 = new object();

        private static byte[] result = new byte[1024];
        private Socket MyServerSocket;
        private Socket MyClientSocket;
        public bool ServerFlag = false;

        public HalconDemo()
        {
            InitializeComponent();
            TcpInit(7788);
            InitParse();
            SearchCamera();

            for (int i = 0; i < 3;i++)
                ReadModel(i);
            ReadCalibData();
        }

        private void TcpInit(int Port)
        { 
            try{
                MyServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                MyServerSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
                MyServerSocket.Listen(10);
                MyServerSocket.BeginAccept(new AsyncCallback(ClientAccepted), MyServerSocket);
                ServerFlag = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ClientAccepted(IAsyncResult ar)
        {
            if (ServerFlag == false)
                return;
            Socket socket = ar.AsyncState as Socket;
            MyClientSocket = socket.EndAccept(ar);
            if (MyClientSocket == null)
                return;
            MyClientSocket.BeginReceive(result, 0, result.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), MyClientSocket);
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
        }
        public void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;
                var length = socket.EndReceive(ar);
                string message = Encoding.ASCII.GetString(result, 0, length);
                TcpServerRecv(message);
                //接收下一个消息(因为这是一个递归的调用，所以这样就可以一直接收消息了）
                socket.BeginReceive(result, 0, result.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
            }
            catch
            {
            }
        }
        public void SendData(string Command_send)
        {
            try
            {
                MyClientSocket.Send(Encoding.ASCII.GetBytes(Command_send));
            }
            catch { }
        }

        private void InitParse()
        {
            Action_ColorType.SelectedIndex = 0;
            MyCurCom = new CurrentCom(0, hv_Window.HalconWindow, -1, null, -1, -1, false, null);
            HOperatorSet.SetDraw(MyCurCom.hv, "margin");
        }
       
        private void SearchCamera()
        {
            ComboBox_CameraList.Items.Clear();
            HTuple Information = null, ValueList = null;
            HTuple Length = null;
            try
            {
                HOperatorSet.InfoFramegrabber("DirectShow", "device", out Information, out ValueList); 
                HOperatorSet.TupleLength(ValueList, out Length);

                for (int i = 0; i <  Length[0].I; i++)
                {
                    string strDevice = ValueList[i].S;
                    ComboBox_CameraList.Items.Add(strDevice);
                }
            }
            catch{}
            if (ComboBox_CameraList.Items.Count > 0)
                ComboBox_CameraList.SelectedIndex = 0;
        }

        private void hv_Window_HMouseMove(object sender, HMouseEventArgs e)
        {
            if (MyCurCom.ho_Image == null)
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    PixelLabel.Text = "[-1,-1]->[-1]";
                }));
            }
            else
            {
                double current_beginX, current_beginY, current_width, current_heigth;
                string mes = ((int)e.X).ToString() + "," + ((int)e.Y).ToString();
                string ShowMes = "[" + mes + "]->";
                HTuple row = new HTuple();
                HTuple col = new HTuple();
                HTuple grayval = new HTuple();
                string PixelMes = "";
                lock (locker1)
                {
                    try
                    {
                        HOperatorSet.GetGrayval(MyCurCom.ho_Image, (int)e.Y, (int)e.X, out grayval);
                        PixelMes = grayval.ToString();
                    }
                    catch
                    {
                        PixelMes = "[-1]";
                    }
                }
                ShowMes = ShowMes + PixelMes;
                BeginInvoke(new MethodInvoker(delegate
                {
                    PixelLabel.Text = ShowMes;
                }));
            }
        }

        private void Action_ConnectCamera_Click(object sender, EventArgs e)
        {
            MyCurCom.hv.ClearWindow();
            if (Action_ConnectCamera.Text == "连接")
            {
                OpenCamrea();
            }
            else if (Action_ConnectCamera.Text == "断开")
            {
                CloseCamera();
            }
        }

        private void OpenCamrea()
        {
            string CamreaName = ComboBox_CameraList.SelectedItem.ToString();
            string ColorZone = Action_ColorType.SelectedItem.ToString();
            
            try
            {
                HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, ColorZone, -1, "false", "default", CamreaName, 0, -1, out MyCurCom.AcqHandle);
                HOperatorSet.GrabImageStart(MyCurCom.AcqHandle, -1);
                HOperatorSet.GrabImageAsync(out MyCurCom.ho_Image, MyCurCom.AcqHandle, -1);
                HOperatorSet.GetImageSize(MyCurCom.ho_Image, out MyCurCom.ho_Width, out MyCurCom.ho_Height);
                MyCurCom.hv.SetPart(0, 0, MyCurCom.ho_Height - 1, MyCurCom.ho_Width - 1);
                Action_ConnectCamera.Text = "断开";
            }
            catch
            {
                MessageBox.Show("相机连接失败");
                CloseCamera();
            }
        }

        private void CloseCamera()
        {
            if (Action_ThreadGetImage.Text == "停止预览")
                Action_ThreadGetImage_Click(null, null);
            Action_ConnectCamera.Text = "连接";
            HOperatorSet.CloseAllFramegrabbers();
            MyCurCom.AcqHandle = null;
        }

        private void Action_ThreadGetImage_Click(object sender, EventArgs e)
        {
            if (Action_ThreadGetImage.Text == "开始预览")
            {
                if (MyCurCom.AcqHandle != null)
                {
                    MyCurCom.ThreadFlag = true;
                    Thread thread = new Thread(ThreadWorking);
                    thread.Start();
                    Action_ThreadGetImage.Text = "停止预览";
                }
            }
            else
            {
                MyCurCom.ThreadFlag = false;
                Action_ThreadGetImage.Text = "开始预览";
            }
        }

        private void ThreadWorking()
        {
            while (MyCurCom.ThreadFlag)
            {
                try
                {
                    lock (locker1)
                    {
                        MyCurCom.ho_Image.Dispose();
                        HOperatorSet.GrabImageAsync(out MyCurCom.ho_Image, MyCurCom.AcqHandle, -1);
                        MyCurCom.hv.DispObj(MyCurCom.ho_Image);
                        Thread.Sleep(50);
                    }
                }
                catch
                {

                }
            }
        }

        private void Btn_GetOnceImage_ButtonClick(object sender, EventArgs e)
        {
            if (Action_ThreadGetImage.Text == "停止预览")
                Action_ThreadGetImage_Click(null, null);
            try
            {
                MyCurCom.ho_Image.Dispose();
                HOperatorSet.GrabImageAsync(out MyCurCom.ho_Image, MyCurCom.AcqHandle, -1);
                MyCurCom.hv.DispObj(MyCurCom.ho_Image);
            }
            catch { }
        }

        private void Action_DrawROI_ButtonClick(object sender, EventArgs e)
        {
            if (MyCurCom.ho_Image == null)
                return;
            toolStrip1.Enabled = false;
            MyCurCom.hv.SetColor("red");
            HTuple hv_Row1, hv_Column1, hv_Row2, hv_Column2;
            HOperatorSet.DrawRectangle1(MyCurCom.hv, out hv_Row1, out hv_Column1, out hv_Row2, out hv_Column2);
            HOperatorSet.GenRectangle1(out MyCurCom.ModelROI, hv_Row1, hv_Column1, hv_Row2, hv_Column2);
            MyCurCom.hv.DispObj(MyCurCom.ModelROI);
            toolStrip1.Enabled = true;
        }

        private void Action_ClearROI_Click(object sender, EventArgs e)
        {
            MyCurCom.ModelROI = null;
            MyCurCom.hv.ClearWindow();
            if (MyCurCom.ho_Image !=null)
                MyCurCom.hv.DispObj(MyCurCom.ho_Image);
        }
        
        private void SingleCheck(object sender)
        {
            Action_Model1.Checked = false;
            Action_Model2.Checked = false;
            Action_Model3.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
        }
        private void Action_Model_Click(object sender, EventArgs e)
        {
            string modelName = sender.ToString();
            SingleCheck(sender);
            MyCurCom.CurrentModel = Convert.ToInt32(sender.ToString()[2]) - 49;
        }

        private void Btn_CreateModel_ButtonClick(object sender, EventArgs e)
        {
            if (MyCurCom.ModelROI == null || MyCurCom.ho_Image == null)
                return;
            HObject hv_ImageReduced, ShapeModelImages, ShapeModelRegions;
            HOperatorSet.ReduceDomain(MyCurCom.ho_Image, MyCurCom.ModelROI, out hv_ImageReduced);
            try
            {
                HOperatorSet.CreateShapeModel(hv_ImageReduced, "auto", -0.39, 0.79, "auto", "auto", "use_polarity", "auto", "auto", out MyModel[MyCurCom.CurrentModel].hv_ModelID);
            }
            catch {
                ShowStatus("mes:创建模板失败！");    
                return; 
            }
            HOperatorSet.InspectShapeModel(hv_ImageReduced, out ShapeModelImages, out ShapeModelRegions, 1, 30);

            HOperatorSet.GetShapeModelContours(out MyModel[MyCurCom.CurrentModel].ho_ShapeModel, MyModel[MyCurCom.CurrentModel].hv_ModelID, 1);

            MyCurCom.hv.ClearWindow();
            MyCurCom.hv.DispObj(MyCurCom.ho_Image);
            MyCurCom.hv.SetColor("green");
            MyCurCom.hv.DispObj(ShapeModelRegions);

            HOperatorSet.AreaCenter(MyCurCom.ModelROI, out MyModel[MyCurCom.CurrentModel].hv_Orgin_Angle, out MyModel[MyCurCom.CurrentModel].hv_Orgin_Row, out MyModel[MyCurCom.CurrentModel].hv_Orgin_Column);
            MyCurCom.hv.SetColor("blue");
            MyCurCom.hv.DispObj(MyCurCom.ModelROI);
            MyCurCom.hv.SetColor("red");
            HOperatorSet.DispCross(MyCurCom.hv, MyModel[MyCurCom.CurrentModel].hv_Orgin_Row, MyModel[MyCurCom.CurrentModel].hv_Orgin_Column, MyCurCom.ho_Width/24, 0);

            MyModel[MyCurCom.CurrentModel].h_img = MyCurCom.ho_Image;
            MyModel[MyCurCom.CurrentModel].h_roi = MyCurCom.ModelROI;
            MyModel[MyCurCom.CurrentModel].EffectiveFlag = true;
            ShowStatus("mes:创建模板成功！");
            WriteModel(MyCurCom.CurrentModel);
        }

        private void Action_ClearModel_Click(object sender, EventArgs e)
        {
            MyModel[MyCurCom.CurrentModel].EffectiveFlag = false;
            MyModel[MyCurCom.CurrentModel].h_img = null;
            MyModel[MyCurCom.CurrentModel].h_roi = null;
            MyModel[MyCurCom.CurrentModel].hv_ModelID = -1;
            MyModel[MyCurCom.CurrentModel].ho_ShapeModel = null;
            MyModel[MyCurCom.CurrentModel].hv_Orgin_Angle = -1;
            MyModel[MyCurCom.CurrentModel].hv_Orgin_Row = -1;
            MyModel[MyCurCom.CurrentModel].hv_Orgin_Column = -1;
            DeleteModel(MyCurCom.CurrentModel);
            ShowStatus("mes:删除模板成功！");   
        }

        private void Action_RunModel_Click(object sender, EventArgs e)
        {
            if (MyModel[MyCurCom.CurrentModel].EffectiveFlag == false)
            {
                ShowStatus("mes:无模版");
                return;
            }
            string mes = findModel(MyCurCom.CurrentModel);
            if (mes == "-1,-1,-1")
            {
                ShowStatus("mes:模版匹配失败");
                return;
            }
            ShowStatus("mes:模版匹配成功-->" + mes);
        }

        private string findModel(int ModelNum)
        {
            if (MyCurCom.ho_Image == null)
                return "-1,-1,-1";
            HTuple hv_RowCheck = null, hv_ColumnCheck = null, hv_AngleCheck = null, hv_Score = null;
            HOperatorSet.FindShapeModel(MyCurCom.ho_Image, MyModel[ModelNum].hv_ModelID, -0.39, 0.79, 0.5, 1, 0.5, "least_squares", 0, 0.7, out hv_RowCheck, out hv_ColumnCheck, out hv_AngleCheck, out hv_Score);
            HTuple HomMat2D;
            HObject ModelAtNewPosition, ROIAffinTrans;
            int CheckNum = (int)((new HTuple(hv_Score.TupleLength())));
            if (CheckNum > 0)
            {
                MyCurCom.hv.DispObj(MyCurCom.ho_Image);

                MyCurCom.hv.SetColor("yellow");
                HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RowCheck[0].D, hv_ColumnCheck[0].D, hv_AngleCheck[0].D, out HomMat2D);
                HOperatorSet.AffineTransContourXld(MyModel[ModelNum].ho_ShapeModel, out ModelAtNewPosition, HomMat2D);
                MyCurCom.hv.DispObj(ModelAtNewPosition);

                MyCurCom.hv.SetColor("blue");
                HOperatorSet.VectorAngleToRigid(MyModel[ModelNum].hv_Orgin_Row, MyModel[ModelNum].hv_Orgin_Column, 0, hv_RowCheck[0].D, hv_ColumnCheck[0].D, hv_AngleCheck[0].D, out HomMat2D);
                HOperatorSet.AffineTransRegion(MyModel[ModelNum].h_roi, out ROIAffinTrans, HomMat2D, "constant");
                MyCurCom.hv.DispObj(ROIAffinTrans);

                MyCurCom.hv.SetColor("green");
                HOperatorSet.DispCross(MyCurCom.hv, hv_RowCheck[0].D, hv_ColumnCheck[0].D, MyCurCom.ho_Width/24, hv_AngleCheck[0].D);
                return hv_RowCheck[0].D.ToString() + "," + hv_ColumnCheck[0].D.ToString() + "," + hv_AngleCheck[0].D.ToString();
            }
            else
            {
                return "-1,-1,-1";
            }
        }

        private void Action_Calib_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }

        private void Btn_SaveCalib_Click(object sender, EventArgs e)
        {
            RobotHommat = null;
            int Num = Calib_dataView.RowCount-1;
            HTuple Image_X = new HTuple(), Image_Y = new HTuple(), Robot_X = new HTuple(), Robot_Y = new HTuple();
            for (int i = 0; i < Num; i++)
            {
                double i_x,i_y,r_x,r_y;
                try
                {
                    i_x = Convert.ToDouble(Calib_dataView.Rows[i].Cells[0].Value.ToString());
                    i_y = Convert.ToDouble(Calib_dataView.Rows[i].Cells[1].Value.ToString());
                    r_x = Convert.ToDouble(Calib_dataView.Rows[i].Cells[2].Value.ToString());
                    r_y = Convert.ToDouble(Calib_dataView.Rows[i].Cells[3].Value.ToString());
                }
                catch { continue; }
                Image_X = Image_X.TupleConcat(i_x);
                Image_Y = Image_Y.TupleConcat(i_y);
                Robot_X = Robot_X.TupleConcat(r_x);
                Robot_Y = Robot_Y.TupleConcat(r_y);
            }

            try
            {
                HTuple Length;
                HOperatorSet.TupleLength(Image_X, out Length);
                if (Length[0].I < 3)
                {
                    ShowStatus("mes:有效标定点不足");
                }
                else
                {
                    RobotHommat = new HHomMat2D();
                    RobotHommat.VectorToHomMat2d(Image_X, Image_Y, Robot_X, Robot_Y);
                    ShowStatus("mes:标定成功");
                    WriteCalibData(Image_X, Image_Y, Robot_X, Robot_Y);
                }

            }
            catch
            {
                RobotHommat = null;
                ShowStatus("mes:标定失败");
            }
        }

        private bool PixelToRobot(double img_x, double img_y, out double robot_x, out double robot_y)
        {
            robot_x = robot_y = -1.0;
            if (RobotHommat != null)
            {
                try
                {
                    robot_x = RobotHommat.AffineTransPoint2d(img_x, img_y, out robot_y);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private void Btn_CheckCalib_Click(object sender, EventArgs e)
        {
            try
            {
                double robot_x, robot_y;
                bool res = PixelToRobot(Convert.ToDouble(LineEdit_CheckX.Text), Convert.ToDouble(LineEdit_CheckY.Text), out robot_x, out robot_y);
                Lab_CalibMes.Text = res ? (robot_x.ToString() + "," + robot_y.ToString()) : "-1,-1";
            }
            catch {
                Lab_CalibMes.Text = "-1,-1";
            }
        }

        private void Action_Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ShowStatus(string mes)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                Lab_ShowMes.Text = mes;
            }));
        }

        private void ReadModel(int index)
        {
            //if (System.IO.File.Exists(string.Format("./Model/Model{0}.bmp", index + 1)))
            //{ 
            //    HOperatorSet.ReadImage(out MyModel[index].h_img,string.Format("./Model/Model{0}.bmp", index + 1));
            //}
            //if (System.IO.File.Exists(string.Format("./Model/Model{0}.reg", index + 1)))
            //{
            //    HOperatorSet.ReadRegion(out MyModel[index].h_roi, string.Format("./Model/Model{0}.reg", index + 1));
            //}
            //if (System.IO.File.Exists(string.Format("./Model/Model{0}.tup", index + 1)))
            //{
            //    HOperatorSet.ReadShapeModel(string.Format("./Model/Model{0}.tup", index + 1),out MyModel[index].hv_ModelID);
            //}
            //if (System.IO.File.Exists(string.Format("./Model/Model{0}.dxf", index + 1)))
            //{ 
            //    HTuple hv_DxfStatus = -1;
            //    HOperatorSet.ReadContourXldDxf(out MyModel[index].ho_ShapeModel, string.Format("./Model/Model{0}.dxf", index + 1), new HTuple(), new HTuple(), out hv_DxfStatus);
            //}
            //if (MyModel[index].h_img != null && MyModel[index].h_roi != null && MyModel[index].hv_ModelID != -1 && MyModel[index].ho_ShapeModel!=null)
            //{
            //    HOperatorSet.AreaCenter(MyModel[index].h_roi, out MyModel[index].hv_Orgin_Angle, out MyModel[index].hv_Orgin_Row, out MyModel[index].hv_Orgin_Column);
            //    MyModel[index].EffectiveFlag = true;
            //}

            //序列化
            if (System.IO.File.Exists(string.Format("./Model/Model{0}.dat", index + 1)))
            {
                FileStream fs = new FileStream(string.Format("./Model/Model{0}.dat", index + 1), FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                SaveModelSerial tempRead = bf.Deserialize(fs) as SaveModelSerial;
                fs.Close();

                MyModel[index].h_img = (HObject)tempRead.h_img;
                MyModel[index].h_roi = (HObject)tempRead.h_roi;
                MyModel[index].ho_ShapeModel = (HObject)tempRead.ho_ShapeModel;
                if (MyModel[index].h_img != null && MyModel[index].h_roi != null && MyModel[index].ho_ShapeModel != null)
                {
                    HOperatorSet.AreaCenter(MyModel[index].h_roi, out MyModel[index].hv_Orgin_Angle, out MyModel[index].hv_Orgin_Row, out MyModel[index].hv_Orgin_Column);
                    MyModel[index].EffectiveFlag = true;
                    HObject hv_ImageReduced;
                    HOperatorSet.ReduceDomain(MyModel[index].h_img, MyModel[index].h_roi, out hv_ImageReduced);
                    HOperatorSet.CreateShapeModel(hv_ImageReduced, "auto", -0.39, 0.79, "auto", "auto", "use_polarity", "auto", "auto", out MyModel[index].hv_ModelID);
                }
            }
        }

        private void WriteModel(int index)
        {
            //HOperatorSet.WriteImage(MyModel[index].h_img, "bmp", 0, string.Format("./Model/Model{0}.bmp", index + 1));
            //HOperatorSet.WriteRegion(MyModel[index].h_roi, string.Format("./Model/Model{0}.reg", index + 1));
            //HOperatorSet.WriteShapeModel(MyModel[index].hv_ModelID, string.Format("./Model/Model{0}.tup", index + 1));
            //HOperatorSet.WriteContourXldDxf(MyModel[index].ho_ShapeModel, string.Format("./Model/Model{0}.dxf", index + 1));

            //序列化
            SaveModelSerial tempSave = new SaveModelSerial();
            tempSave.h_img = MyModel[index].h_img;
            tempSave.h_roi = MyModel[index].h_roi;
            tempSave.ho_ShapeModel = MyModel[index].ho_ShapeModel;

            FileStream fs = new FileStream(string.Format("./Model/Model{0}.dat", index + 1), FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, tempSave);
            fs.Close();
        }

        private void DeleteModel(int index)
        {
            //if (System.IO.File.Exists(string.Format("./Model/Model{0}.bmp", index + 1)))
            //{
            //    File.Delete(string.Format("./Model/Model{0}.bmp", index + 1));
            //}
            //if (System.IO.File.Exists(string.Format("./Model/Model{0}.reg", index + 1)))
            //{
            //    File.Delete(string.Format("./Model/Model{0}.reg", index + 1));
            //}
            //if (System.IO.File.Exists(string.Format("./Model/Model{0}.tup", index + 1)))
            //{
            //    File.Delete(string.Format("./Model/Model{0}.tup", index + 1));
            //}
            //if (System.IO.File.Exists(string.Format("./Model/Model{0}.dxf", index + 1)))
            //{
            //    File.Delete(string.Format("./Model/Model{0}.dxf", index + 1));
            //}

            //序列化
            if (System.IO.File.Exists(string.Format("./Model/Model{0}.dat", index + 1)))
            {
                File.Delete(string.Format("./Model/Model{0}.dat", index + 1));
            }
        }

        private void ReadCalibData()
        {
            if (System.IO.File.Exists("./Model/Calib.dat"))
            {
                BinaryReader br;
                br = new BinaryReader(new FileStream("./Model/Calib.dat", FileMode.Open));
                HTuple Image_X = new HTuple(), Image_Y = new HTuple(), Robot_X = new HTuple(), Robot_Y = new HTuple();
                int Num = (int)br.ReadDouble();
                for (int i = 0; i < Num; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    int Count = Calib_dataView.Rows.Add(row);
                    double i_x = br.ReadDouble();
                    double i_y = br.ReadDouble();
                    double r_x = br.ReadDouble();
                    double r_y = br.ReadDouble();
                    Calib_dataView.Rows[Count].Cells[0].Value = i_x;
                    Calib_dataView.Rows[Count].Cells[1].Value = i_y;
                    Calib_dataView.Rows[Count].Cells[2].Value = r_x;
                    Calib_dataView.Rows[Count].Cells[3].Value = r_y;
                    Image_X = Image_X.TupleConcat(i_x);
                    Image_Y = Image_Y.TupleConcat(i_y);
                    Robot_X = Robot_X.TupleConcat(r_x);
                    Robot_Y = Robot_Y.TupleConcat(r_y);
                }
                try
                {
                    RobotHommat = new HHomMat2D();
                    RobotHommat.VectorToHomMat2d(Image_X, Image_Y, Robot_X, Robot_Y);
                }
                catch {
                    RobotHommat = null;
                }
            }
        }

        private void WriteCalibData(HTuple ImageX,HTuple ImageY,HTuple RobotX,HTuple RobotY)
        {
            BinaryWriter bw;
            bw = new BinaryWriter(new FileStream("./Model/Calib.dat", FileMode.Create));
            double Num = (int)((new HTuple(ImageX.TupleLength())));
            bw.Write(Num);
            for (int i = 0; i < Num; i++)
            {
                bw.Write(ImageX[i].D);
                bw.Write(ImageY[i].D);
                bw.Write(RobotX[i].D);
                bw.Write(RobotY[i].D);
            }
            bw.Close();
        }

        private void TcpServerRecv(string mes)
        {
            if (mes[0] == 'Q')
            {
                try
                {
                    MyCurCom.ho_Image.Dispose();
                    HOperatorSet.GrabImageAsync(out MyCurCom.ho_Image, MyCurCom.AcqHandle, -1);
                    MyCurCom.hv.DispObj(MyCurCom.ho_Image);
                    int ModelNum = -1;
                    try
                    {
                        ModelNum = Convert.ToInt32(mes[1] - 48) - 1;
                    }
                    catch {
                        ShowStatus("mes:协议异常");
                        SendData("-1,-1,-1");
                        return;
                    }
                    if (ModelNum > 3 || ModelNum < 0)
                    {
                        ShowStatus("mes:协议异常");
                        SendData("-1,-1,-1");
                        return;
                    }
                    if (MyModel[ModelNum].EffectiveFlag == false)
                    {
                        ShowStatus("mes:无模版");
                        SendData("-1,-1,-1");
                        return;
                    }
                    string VisionMes = findModel(ModelNum);
                    if (VisionMes == "-1,-1,-1")
                    {
                        ShowStatus("mes:模版匹配失败");
                        SendData("-1,-1,-1");
                        return;
                    }
                    else 
                    {
                        if (RobotHommat == null)
                        {
                            ShowStatus("mes:机器人数据未标定");
                            SendData("-1,-1,-1");
                        }
                        else
                        {
                            string[] VisionData = VisionMes.Split(',');
                            double robot_x, robot_y;
                            bool res = PixelToRobot(Convert.ToDouble(VisionData[0]), Convert.ToDouble(VisionData[1]), out robot_x, out robot_y);
                            if (res == false)
                            {
                                ShowStatus("mes:标定数据转化失败");
                                SendData("-1,-1,-1");
                            }
                            else
                            {
                                string SendOKData = robot_x.ToString() + "," + robot_y.ToString() + "," + VisionData[2];
                                ShowStatus("mes:视觉拍照识别成功:" + SendOKData);
                                SendData(SendOKData);
                            }
                        }
                    }
                }
                catch {
                    ShowStatus("mes:协议异常");
                    SendData("-1,-1,-1");
                }
            }
            else
            {
                ShowStatus("mes:协议异常");
                SendData("-1,-1,-1");
            }
        }

        
    }

    [Serializable]
    public class SaveModelSerial
    {
        public HObject h_img { get; set; }
        public HObject h_roi { get; set; }
        public HObject ho_ShapeModel { get; set; }
    }
}
