using ServiceStack.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_nhom_C_
{
    public partial class Form1 : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        CongViecBLL bllCV;
        public Form1()
        {
            InitializeComponent();
            bllCV = new CongViecBLL();
            
        }

        public void ShowAllCongViec()
        {
            DataTable dt = bllCV.getAllCongViec();
            dataGridViewCV.DataSource = dt;
        }

        public bool check()
        {

            if (string.IsNullOrEmpty(txtMaCV.Text)) 
            {
                MessageBox.Show("Bạn chưa nhập MaCV.", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtMaCV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập Họ và tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCongViec.Text))
            {
                MessageBox.Show("Bạn chưa nhập Công việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCongViec.Focus();
                return false;
            }
            /*if (string.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Bạn chưa nhập Ghi chú.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGhiChu.Focus();
                return false;
            }*/
            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAllCongViec();
            dataGridViewCV.Columns["ID"].Visible = false;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thongBaoThoat = MessageBox.Show("Bạn có muốn thoát khỏi chuơng trình ?");
            if (thongBaoThoat == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (thongBaoThoat == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThem(object sender, EventArgs e)
        {
            if (check())
            {
                
                tblCongViec cv = new tblCongViec
                {
                    //ID = Id,
                    MaCV = txtMaCV.Text,
                    HoTen = txtHoTen.Text,
                    CongViec = txtCongViec.Text,
                    NgayThem = timeThem.Value.ToString("dd/MM/yyyy"),
                    NgayNop = timeNop.Value.ToString("dd/MM/yyyy"),
                    GhiChu = txtGhiChu.Text,
                    TrangThai = false,
                    UuTien = checkUuTien.Checked
                };

                if (bllCV.insertCongViec(cv))
                {
                    ShowAllCongViec();
                    // Xóa trắng các ô input sau khi thêm công việc thành công
                    txtMaCV.Text = "";
                    txtHoTen.Text = "";
                    txtCongViec.Text = "";
                    txtGhiChu.Text = "";
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCapnhat(object sender, EventArgs e)
        {
            if (check())
            {
                tblCongViec cv = new tblCongViec
                {
                    ID = Id,
                    MaCV = txtMaCV.Text,
                    HoTen = txtHoTen.Text,
                    CongViec = txtCongViec.Text,
                    NgayThem = timeThem.Value.ToString("dd/MM/yyyy"),
                    NgayNop = timeNop.Value.ToString("dd/MM/yyyy"),
                    GhiChu = txtGhiChu.Text,
                    TrangThai = true,
                    UuTien = checkUuTien.Checked
                };

                if (bllCV.updateCongViec(cv))
                {
                    ShowAllCongViec();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnXoa(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string maCV = dataGridViewCV.CurrentRow.Cells["MaCV"].Value.ToString();
                tblCongViec cv = new tblCongViec
                {
                    MaCV = maCV
                };
                if (bllCV.deleteCongViec(cv))
                {
                    ShowAllCongViec();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnXuatFile(object sender, EventArgs e)
        {
            if (dataGridViewCV.CurrentRow != null)
            {
                int index = dataGridViewCV.CurrentRow.Index;
                if (index >= 0)
                {
                    // Thực hiện các thao tác trên các đối tượng ở đây
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                            {
                                foreach (DataGridViewRow row in dataGridViewCV.Rows)
                                {
                                    string rowData = "";
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        rowData += cell.Value.ToString() + " - ";
                                    }
                                    writer.WriteLine(rowData.TrimEnd(' ', '-'));
                                }
                            }
                            MessageBox.Show("Dữ liệu đã được xuất ra file thành công!", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dữ liệu đã được xuất ra file! ");
                        }
                    }
                
                }
            }

        }
        //Chuc nang nu bao cao
        private void btnTimKiem(object sender, EventArgs e)
        {
        
                int totalTasks = dataGridViewCV.Rows.Count - 1;
                int completedTasks = 0;

                foreach (DataGridViewRow row in dataGridViewCV.Rows)
                {
                    bool isCompleted = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                    if (isCompleted)
                    {
                        completedTasks++;
                    }
                }

                if (totalTasks > 0)
                {
                    double completionPercentage = (double)completedTasks / totalTasks * 100;
                    string message = $"Số công việc đã hoàn thành: {completedTasks}/{totalTasks}\nPhần trăm hoàn thành: {completionPercentage:F2}%";
                    MessageBox.Show(message, "Báo cáo hoàn thành công việc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có công việc nào để báo cáo.", "Báo cáo hoàn thành công việc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

        }
        private int Id;
        private void dataGridViewCV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem ô đã được click có tồn tại không
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int index = e.RowIndex;

                    // Kiểm tra xem giá trị của ô có tồn tại không
                    if (dataGridViewCV.Rows[index].Cells["ID"].Value != null)
                    {
                        Id = Convert.ToInt32(dataGridViewCV.Rows[index].Cells["ID"].Value);
                        txtMaCV.Text = dataGridViewCV.Rows[index].Cells["MaCV"].Value.ToString();
                        txtHoTen.Text = dataGridViewCV.Rows[index].Cells["HoTen"].Value.ToString();
                        txtCongViec.Text = dataGridViewCV.Rows[index].Cells["CongViec"].Value.ToString();

                        // Lấy giá trị ngày tháng từ DataGridView và chuyển sang định dạng DateTime
                        DateTime ngayThem = DateTime.ParseExact(dataGridViewCV.Rows[index].Cells["NgayThem"].Value.ToString(), "dd/MM/yyyy", null);
                        DateTime ngayNop = DateTime.ParseExact(dataGridViewCV.Rows[index].Cells["NgayNop"].Value.ToString(), "dd/MM/yyyy", null);

                        // Gán giá trị DateTime cho DateTimePicker
                        timeThem.Value = ngayThem;
                        timeNop.Value = ngayNop;

                        txtGhiChu.Text = dataGridViewCV.Rows[index].Cells["GhiChu"].Value.ToString();
                    }
                    else
                    {
                        // Xử lý trường hợp ô không có giá trị
                        MessageBox.Show("Ô không có giá trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây, ví dụ: hiển thị thông báo lỗi hoặc ghi log lỗi.
                //MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Ô không có giá trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllCV.findCongViec(value);
                dataGridViewCV.DataSource = dt;
            }
            else
            {
                ShowAllCongViec();
            }
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCongViec_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
