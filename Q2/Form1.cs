using Q2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new PE_Spr22B5Context())
            {
                comboBox1.DataSource = context.Employees
                    .Select(x => new
                    {
                        x.Position
                    })
                    .Distinct()
                    .ToList();
                comboBox1.DisplayMember = "Position";
            }
            loadData();
        }

        public void loadData()
        {
            using (var context = new PE_Spr22B5Context())
            {
                dataGridView1.DataSource = context.Employees.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Sex,
                    x.Dob,
                    x.Position
                })
                    .ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new PE_Spr22B5Context())
            {
                string name = textBox2.Text;
                string sex = "";
                if (radioButton1.Checked)
                {
                    sex = radioButton1.Text;
                } 
                if (radioButton2.Checked)
                {
                    sex = radioButton2.Text;
                }
                DateTime date = dateTimePicker1.Value;
                string position = comboBox1.Text;
                context.Employees.Add(new Employee { Name = name, Sex = sex, Dob = date, Position = position });
                context.SaveChanges();
            }
            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new PE_Spr22B5Context())
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int Id = Convert.ToInt32(row.Cells[0].Value);
                    Employee employee = context.Employees.FirstOrDefault(x => x.Id == Id);
                    if (employee != null)
                    {
                        textBox1.Text = employee.Id.ToString();
                        textBox2.Text = employee.Name;
                        if (employee.Sex.Equals(radioButton1.Text))
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                        dateTimePicker1.Value = employee.Dob;
                        comboBox1.Text = employee.Position;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new PE_Spr22B5Context())
            {
                int Id = Convert.ToInt32(textBox1.Text);
                Employee employee = context.Employees.FirstOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    employee.Name = textBox2.Text;
                    if (radioButton1.Checked)
                    {
                        employee.Sex = radioButton1.Text;
                    }
                    if (radioButton2.Checked)
                    {
                        employee.Sex = radioButton2.Text;
                    }
                    employee.Dob = dateTimePicker1.Value;
                    employee.Position = comboBox1.Text;
                    context.Employees.Update(employee);
                }
                context.SaveChanges();
            }
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new PE_Spr22B5Context())
            {
                comboBox1.DataSource = context.Employees
                    .Select(x => new
                    {
                        x.Position
                    })
                    .Distinct()
                    .ToList();
                comboBox1.DisplayMember = "Position";
            }
            loadData();
            textBox1.Text = "";
            textBox2.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
