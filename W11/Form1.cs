using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SinhVien sv = new SinhVien();
        private void button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            sv.MaSV = int.Parse(txt_MaSV.Text);
            sv.HoTen = txt_TenSV.Text;
            sv.MaKhoa = txt_Khoa.Text;

            db.SinhViens.InsertOnSubmit(sv);
            db.SubmitChanges();
            Form1_Load(sender, e);
            txt_MaSV.Text = "";
            txt_TenSV.Text = "";
            txt_Khoa.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var lst = (from s in db.SinhViens select s).ToList();
            dataGridView1.DataSource = lst;
            txt_MaSV.DataBindings.Clear();
            txt_TenSV.DataBindings.Clear();

            txt_Khoa.DataBindings.Clear();
            txt_MaSV.DataBindings.Add("text", lst, "MaSV");
            txt_TenSV.DataBindings.Add("text", lst, "HoTen");

            txt_Khoa.DataBindings.Add("text", lst, "MaKhoa");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            sv = db.SinhViens.Where(s => s.MaSV == int.Parse(txt_MaSV.Text)).Single();

            sv.HoTen = txt_TenSV.Text;
            sv.MaKhoa = txt_Khoa.Text;
            db.SinhViens.DeleteOnSubmit(sv);
            db.SubmitChanges();
            Form1_Load(sender, e);

        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var lst = (from s in db.SinhViens where s.MaSV.ToString().Contains(textBox4.Text) select s).ToList();
            dataGridView1.DataSource = lst;
            txt_MaSV.DataBindings.Clear();
            txt_TenSV.DataBindings.Clear();

            txt_Khoa.DataBindings.Clear();
            txt_MaSV.DataBindings.Add("text", lst, "MaSV");
            txt_TenSV.DataBindings.Add("text", lst, "HoTen");

            txt_Khoa.DataBindings.Add("text", lst, "MaKhoa");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            sv = db.SinhViens.Where(s => s.MaSV == int.Parse(txt_MaSV.Text)).Single();

            sv.HoTen = txt_TenSV.Text;
            sv.MaKhoa = txt_Khoa.Text;
            
            db.SubmitChanges();
            Form1_Load(sender, e);

        }
    }
}
