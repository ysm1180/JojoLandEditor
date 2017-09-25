using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using XnaFan.ImageComparison;

namespace LandEditor
{
    public partial class LandEditor : Form
    {
        private readonly static String[] landNames = { "평지", "초원", "숲", "황무지", "산지",
        "바위산", "벼랑", "설원", "다리", "여울", "습지", "연못", "강", "대하", "울타리",
        "성벽", "성내", "성문", "성", "관문", "요새", "마을", "병영", "민가", "보물고",
        "도랑", "불", "배", "제단", "지하"};

        private Bitmap[] landBitmaps = new Bitmap[30];
        private Bitmap[] smallLandBitmaps = new Bitmap[30];
        private PictureBox[] pbClickLands = new PictureBox[30];
        private int activeClickLand = 0;
        private Point landCoordination = new Point(-1, -1);
        private int[,,] lands;
        private int[,,] originalLands;
        private Bitmap mapBitmap = null;
        private Size[] landSizes;
        private int workNumber = 0; // 0 : Add, 1 : Sizing
        private bool isMouseDown = false;

        /* 닫기 버튼 비활성화를 위한 코드 */
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x0;
        private const int MF_GRAYED = 0x1;
        private const int MF_DISABLED = 0x2;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

        public static String[] LandNames
        {
            get
            {
                return landNames;
            }
        }

        public LandEditor()
        {
            InitializeComponent();

            landBitmaps[0] = Properties.Resources.평지;
            landBitmaps[1] = Properties.Resources.초원;
            landBitmaps[2] = Properties.Resources.숲;
            landBitmaps[3] = Properties.Resources.황무지;
            landBitmaps[4] = Properties.Resources.산지;
            landBitmaps[5] = Properties.Resources.바위산;
            landBitmaps[6] = Properties.Resources.벼랑;
            landBitmaps[7] = Properties.Resources.설원;
            landBitmaps[8] = Properties.Resources.다리;
            landBitmaps[9] = Properties.Resources.여울;
            landBitmaps[10] = Properties.Resources.습지;
            landBitmaps[11] = Properties.Resources.연못;
            landBitmaps[12] = Properties.Resources.강;
            landBitmaps[13] = Properties.Resources.대하;
            landBitmaps[14] = Properties.Resources.울타리;
            landBitmaps[15] = Properties.Resources.성벽;
            landBitmaps[16] = Properties.Resources.성내;
            landBitmaps[17] = Properties.Resources.성문;
            landBitmaps[18] = Properties.Resources.성;
            landBitmaps[19] = Properties.Resources.관문;
            landBitmaps[20] = Properties.Resources.요새;
            landBitmaps[21] = Properties.Resources.마을;
            landBitmaps[22] = Properties.Resources.병영;
            landBitmaps[23] = Properties.Resources.민가;
            landBitmaps[24] = Properties.Resources.보물고;
            landBitmaps[25] = Properties.Resources.도랑;
            landBitmaps[26] = Properties.Resources.불;
            landBitmaps[27] = Properties.Resources.배;
            landBitmaps[28] = Properties.Resources.제단;
            landBitmaps[29] = Properties.Resources.지하;

            for (int i = 0; i < 30; ++i)
            {
                smallLandBitmaps[i] = (Bitmap)landBitmaps[i].Clone();
                smallLandBitmaps[i] = (Bitmap)smallLandBitmaps[i].Resize(16, 16);

                pbClickLands[i] = new PictureBox();
                pbClickLands[i].Parent = groupLand;
                pbClickLands[i].Location = new Point(27 + (i / 10) * 48, 25 + (i % 10) * 48);
                pbClickLands[i].Size = new Size(48, 48);
                pbClickLands[i].Cursor = Cursors.Hand;
                pbClickLands[i].Image = landBitmaps[i].GetGrayScaleVersion();
                pbClickLands[i].MouseClick += new MouseEventHandler(clickLands_MouseClick);
                pbClickLands[i].MouseEnter += new EventHandler(clickLands_MouseEnter);
                pbClickLands[i].MouseLeave += new EventHandler(clickLands_MouseLeave);
                pbClickLands[i].Paint += new PaintEventHandler(clickLands_Paint);
                pbClickLands[i].Tag = i;
            }
        }

        ~LandEditor()
        {
        }

        #region FILE_FUNCTION

        private void OpenFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Program.FilePath = openFileDialog.FileName;
                E5FileData e5File = new E5FileData(Program.FilePath);
                var count = e5File.GetItemCount();
                lands = new int[count, 40, 40];
                originalLands = new int[count, 40, 40];
                landSizes = new Size[count];

                progress.Visible = true;
                progress.Maximum = count;
                progress.Value = 0;

                for (int i = 0; i < count; ++i)
                {
                    var bytes = e5File.GetItemBytes(i);
                    landSizes[i] = new Size(bytes[0] / 3, bytes[1] / 3);

                    for (int j = 0; j < landSizes[i].Height; ++j)
                    {
                        for (int k = 0; k < landSizes[i].Width; ++k)
                        {
                            originalLands[i, j, k] = bytes[2 + k + j * landSizes[i].Width];
                            lands[i, j, k] = originalLands[i, j, k];
                        }
                    }

                    listLand.Items.Add(i);
                    progress.Value++;
                }
                e5File.Dispose();

                listLand.SelectedIndex = 0;
                menuEdit.Enabled = true;
                menuMap.Enabled = true;
                progress.Visible = false;
                pbLand.Visible = true;
            }
        }

        private void SaveFile()
        {
            E5FileData e5File = new E5FileData(Program.FilePath);
            var count = listLand.Items.Count;
            var temp = e5File.ReadByteArr(0, 0x110);
            e5File.Dispose();

            /* Create new file */
            File.Delete(Program.FilePath);
            e5File = new E5FileData(Program.FilePath);
            e5File.WriteByteArr(0, temp);

            progress.Visible = true;
            progress.Maximum = count;
            progress.Value = 0;

            
            for (int i = 0; i < count; ++i)
            {
                var bytes = e5File.GetItemBytes(i);
                landSizes[i] = new Size(bytes[0] / 3, bytes[1] / 3);

                for (int j = 0; j < landSizes[i].Height; ++j)
                {
                    for (int k = 0; k < landSizes[i].Width; ++k)
                    {
                        originalLands[i, j, k] = bytes[2 + k + j * landSizes[i].Width];
                        lands[i, j, k] = originalLands[i, j, k];
                    }
                }

                progress.Value++;
            }
            e5File.Dispose();
        }

        #endregion FILE_FUNCTION

        #region USER_FUNCTION

        private void GetMaps(int n)
        {
            for (int i = 0; i < n; ++i)
            {
            }
        }

        private Bitmap GetMap(int index)
        {
            string directory = Path.GetDirectoryName(Program.FilePath);
            string hmFileName = String.Format("HM{0:00}.E5", index);
            if (File.Exists(directory + "\\" + hmFileName))
            {
                E5FileData hmFile = new E5FileData(directory + "\\" + hmFileName);
                E5FileData paletteFile = new E5FileData(directory + "\\SPALET.E5");

                int width = landSizes[index].Width * 48;
                int height = landSizes[index].Height * 48;

                if (width != 0 && height != 0)
                {
                    var bytes = new byte[hmFile.Length];
                    var pixels = new byte[48];
                    var offset = 0;
                    for (int i = 0; i < height / 48; ++i)
                    {
                        for (int j = 0; j < 48; ++j)
                        {
                            for (int k = i * (width / 48); k < (i + 1) * (width / 48); ++k)
                            {
                                pixels = hmFile.ReadByteArr(k * 0x900 + 48 * j, 48);
                                pixels.CopyTo(bytes, offset);
                                offset += 48;
                            }
                        }
                    }

                    GCHandle pinnedArray = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                    IntPtr pointer = pinnedArray.AddrOfPinnedObject();
                    Bitmap bitmap24Bit = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                    using (Bitmap bitmap = new Bitmap(width, height, ((width - 1) / 4 + 1) * 4,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed,
                        pointer))
                    {
                        ColorPalette palette = bitmap.Palette;
                        Color[] entries = palette.Entries;
                        var paletteBytes = paletteFile.GetItemBytes(index);
                        for (int i = 0; i < paletteBytes.Length / 3; ++i)
                        {
                            entries[i] = Color.FromArgb(paletteBytes[i * 3 + 1], paletteBytes[i * 3 + 2],
                                paletteBytes[i * 3]);
                        }
                        bitmap.Palette = palette;

                        using (Graphics g = Graphics.FromImage(bitmap24Bit))
                        {
                            g.DrawImage(bitmap, 0, 0, width, height);
                        }
                    }

                    pinnedArray.Free();
                    hmFile.Dispose();
                    paletteFile.Dispose();

                    return bitmap24Bit;
                }
            }
            return null;
        }

        #endregion USER_FUNCTION

        private void LandEditor_Load(object sender, EventArgs e)
        {
            pbClickLands[0].Image = landBitmaps[0];
            IniUtil ini = null;
            if (!File.Exists(Application.StartupPath + "\\option.ini"))
            {
                FileStream f = File.Create(Application.StartupPath + "\\option.ini");
                f.Close();

                ini = new IniUtil(Application.StartupPath + "\\option.ini");
                ini.SetIniValue("Option", "Loading_Map", bool.TrueString);
            }

            ini = new IniUtil(Application.StartupPath + "\\option.ini");
            String value = ini.GetIniValue("Option", "Loading_Map");
            menuLoadMap.Checked = bool.Parse(value);
        }

        private void listLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int width = landSizes[listLand.SelectedIndex].Width;
            int height = landSizes[listLand.SelectedIndex].Height;
            lbMapSize.Text = (width * 48).ToString() + " x " + (height * 48).ToString();
            if (width > 30)
            {
                pbLand.Width = 480;
                hScroll.Maximum = width - 30;
                hScroll.Value = 0;
                if (height <= 30)
                {
                    hScroll.Top = 16 * height + 53;
                }
                else
                {
                    hScroll.Top = 533;
                }
                hScroll.Visible = true;
            }
            else
            {
                pbLand.Width = 16 * width;
                hScroll.Top = 533;
                hScroll.Visible = false;
                hScroll.Value = 0;
            }

            if (height > 30)
            {
                pbLand.Height = 480;
                vScroll.Maximum = height - 30;
                vScroll.Value = 0;
                if (width <= 30)
                {
                    vScroll.Left = 16 * width + 52;
                }
                else
                {
                    vScroll.Left = 532;
                }
                vScroll.Visible = true;
            }
            else
            {
                pbLand.Height = 16 * height;
                vScroll.Left = 532;
                vScroll.Visible = false;
                vScroll.Value = 0;
            }

            if (mapBitmap != null)
            {
                mapBitmap.Dispose();
            }

            if (menuLoadMap.Checked)
            {
                mapBitmap = GetMap(listLand.SelectedIndex);
            }
            pbLand.Refresh();
        }

        private void pbLand_MouseDown(object sender, MouseEventArgs e)
        {
            var selectedIndex = listLand.SelectedIndex;
            var x = e.X / 16;
            var y = e.Y / 16;

            if (listLand.Items.Count > 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Modify land
                    lands[selectedIndex, y, x] = activeClickLand;
                    isMouseDown = true;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    // Restore land
                    lands[selectedIndex, y, x] = originalLands[selectedIndex, y, x];
                }
                Rectangle rect = new Rectangle(new Point(x * 16, y * 16), new Size(16, 16));
                pbLand.Invalidate(rect);

                lbLand.Text = landNames[lands[selectedIndex, y, x]];
                pbViewLand.Image = landBitmaps[lands[selectedIndex, y, x]];
            }
        }

        private void pbLands_MouseMove(object sender, MouseEventArgs e)
        {
            var selectedIndex = listLand.SelectedIndex;
            var x = e.X / 16;
            var y = e.Y / 16;
            Rectangle rect = new Rectangle();

            if (x < 0 || y < 0)
            {
                return;
            }

            if (listLand.Items.Count > 0)
            {
                // Remove previous rectangle
                rect = new Rectangle(new Point(landCoordination.X * 16, landCoordination.Y * 16),
                    new Size(16, 16));
                landCoordination = new Point(x, y);
                pbLand.Invalidate(rect);

                // Draw current rectangle and land
                rect = new Rectangle(new Point(x * 16, y * 16), new Size(16, 16));
                if (e.Button == MouseButtons.Left && isMouseDown)
                {
                    lands[listLand.SelectedIndex, y, x] = activeClickLand;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    lands[selectedIndex, y, x] = originalLands[selectedIndex, y, x];
                }
                pbLand.Invalidate(rect);

                lbCoordination.Text = "(" + x.ToString() + ", " + y.ToString() + ")";
                lbLand.Text = landNames[lands[selectedIndex, y, x]];
                pbViewLand.Image = landBitmaps[lands[selectedIndex, y, x]];

                if (menuLoadMap.Checked)
                {
                    pbMap.Image = mapBitmap;
                    pbMap.Left = -x * 48 + 48;
                    pbMap.Top = -y * 48 + 48;
                }
            }
        }

        private void pbLands_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            landCoordination = new Point(-1, -1);
            pb.Refresh();
        }

        private void pbLands_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (listLand.Items.Count > 0)
            {
                SolidBrush backBrush = new SolidBrush(this.BackColor);
                e.Graphics.FillRectangle(backBrush, e.ClipRectangle);

                int startX = e.ClipRectangle.Left / 16, startY = e.ClipRectangle.Top / 16;
                int endX = e.ClipRectangle.Right / 16, endY = e.ClipRectangle.Bottom / 16;
                if (endX >= landSizes[listLand.SelectedIndex].Width)
                {
                    endX = landSizes[listLand.SelectedIndex].Width;
                }
                if (endY >= landSizes[listLand.SelectedIndex].Height)
                {
                    endY = landSizes[listLand.SelectedIndex].Height;
                }

                Point pt = new Point(0, 0);
                for (int x = startX; x < endX; ++x)
                {
                    for (int y = startY; y < endY; ++y)
                    {
                        pt.X = 16 * x;
                        pt.Y = 16 * y;

                        e.Graphics.DrawImage(
                        smallLandBitmaps[lands[listLand.SelectedIndex, y + vScroll.Value, x + hScroll.Value]],
                        pt);

                        if (landCoordination.X == pt.X / 16 && landCoordination.Y == pt.Y / 16)
                        {
                            e.Graphics.DrawRectangle(Pens.Yellow,
                                new Rectangle(pt.X, pt.Y, 15, 15));
                        }
                    }
                }
            }
        }

        private void clickLands_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pbClickLands[activeClickLand].Image = landBitmaps[activeClickLand].GetGrayScaleVersion();
            activeClickLand = (int)pb.Tag;
            pb.Refresh();
        }

        private void clickLands_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Image = landBitmaps[(int)pb.Tag];
        }

        private void clickLands_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if ((int)pb.Tag != activeClickLand)
            {
                pb.Image = landBitmaps[(int)pb.Tag].GetGrayScaleVersion();
            }
        }

        private void clickLands_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            using (Font myFont = new Font("맑은 고딕", 10, FontStyle.Bold))
            {
                if ((int)pb.Tag != activeClickLand)
                {
                    e.Graphics.DrawString(landNames[(int)pb.Tag], myFont, Brushes.White, new Point(2, 2));
                }
                else
                {
                    e.Graphics.DrawString(landNames[(int)pb.Tag], myFont, Brushes.Yellow, new Point(2, 2));
                }
            }
        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Yellow, 48 - pbMap.Left, 48 - pbMap.Top, 48, 48);
        }

        private void tbWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue < '0' || e.KeyValue > '9')
            {
                e.SuppressKeyPress = true;
            }
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(tbWidth.Text) > 40 || Int32.Parse(tbHeight.Text) > 40)
            {
                MessageBox.Show("어느 한 쪽의 크기가 40을 초과하였습니다.\n 40을 넘지 않게 조정해주세요!",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int width = Int32.Parse(tbWidth.Text);
                int height = Int32.Parse(tbHeight.Text);
                if (workNumber == 0)
                {
                    listLand.Items.Add(listLand.Items.Count);
                    lands = (int[,,])Program.ResizeArray<int>(lands, listLand.Items.Count, 40, 40);
                    originalLands = (int[,,])Program.ResizeArray<int>(originalLands, listLand.Items.Count, 40, 40);
                    Array.Resize<Size>(ref landSizes, listLand.Items.Count);
                    landSizes[listLand.Items.Count - 1] = new Size(width, height);
                }
                else if (workNumber == 1)
                {
                    landSizes[listLand.SelectedIndex] = new Size(width, height);
                    listLand_SelectedIndexChanged(listLand, new EventArgs());
                }

                tbWidth.Enabled = false;
                tbHeight.Enabled = false;
                tbWidth.Text = "";
                tbHeight.Text = "";
                btnDo.Enabled = false;
                btnCancel.Enabled = false;
                lbInformation.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbWidth.Enabled = false;
            tbHeight.Enabled = false;
            tbWidth.Text = "";
            tbHeight.Text = "";
            btnDo.Enabled = false;
            btnCancel.Enabled = false;
            lbInformation.Text = "";
        }

        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void toolOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            tbWidth.Enabled = true;
            tbHeight.Enabled = true;
            tbWidth.Text = "1";
            tbHeight.Text = "1";
            btnDo.Enabled = true;
            btnCancel.Enabled = true;
            lbInformation.Text = "추가할 지형의 너비 X 높이 입력 후 -> 버튼을 눌러주세요! 취소는 <- 버튼입니다.";
            workNumber = 0;
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
        }

        private void menuSizing_Click(object sender, EventArgs e)
        {
            tbWidth.Enabled = true;
            tbHeight.Enabled = true;
            tbWidth.Text = landSizes[listLand.SelectedIndex].Width.ToString();
            tbHeight.Text = landSizes[listLand.SelectedIndex].Height.ToString();
            btnDo.Enabled = true;
            btnCancel.Enabled = true;
            lbInformation.Text = "선택된 지형의 수정될 너비 X 높이 입력 후 -> 버튼을 눌러주세요! 취소는 <- 버튼입니다.";
            workNumber = 1;
        }

        private void menuRestore_Click(object sender, EventArgs e)
        {
            lands = (int[,,])originalLands.Clone();
            pbLand.Refresh();
        }

        private void menuSaveFile_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void toolSaveFile_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuLoadMap_Click(object sender, EventArgs e)
        {
            IniUtil ini = new IniUtil(Application.StartupPath + "\\option.ini");
            menuLoadMap.Checked = !menuLoadMap.Checked;
            ini.SetIniValue("Option", "Loading_Map", menuLoadMap.Checked.ToString());

            if (menuLoadMap.Checked)
            {
                mapBitmap = GetMap(listLand.SelectedIndex);
                pbMap.Image = mapBitmap;
                pbMap.Visible = true;
            }
            else
            {
                pbMap.Visible = false;
            }
        }

        private void hScroll_Scroll(object sender, ScrollEventArgs e)
        {
            pbLand.Refresh();
        }

        private void vScroll_Scroll(object sender, ScrollEventArgs e)
        {
            pbLand.Refresh();
        }
    }
}