using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {



        }

        public List<Animal> Animals = new List<Animal>();                           //списки животных, птиц и млеко
        public List<Bird> Birds = new List<Bird>();
        public List<Mammalia> Mammalias = new List<Mammalia>();

        private void button3_Click(object sender, EventArgs e)           //сортировка по возрастанию
        {
           int year, food;
            string nm;
            for (int i = 0; i < (Animals.Count()) - 1; i++)
            {
                for (int j = i + 1; j < Animals.Count(); j++)
                {
                    if (Animals[i].Age > Animals[j].Age)
                    {
                        year = Animals[i].Age;
                        food = Animals[i].CountFood;
                        nm = Animals[i].Name;
                        Animals[i].Name = Animals[j].Name;
                        Animals[i].Age = Animals[j].Age;
                        Animals[i].CountFood = Animals[j].CountFood;
                        Animals[j].Age = year;
                        Animals[j].CountFood = food;
                        Animals[j].Name = nm;
                    }
                }



            }

            





        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || (String.IsNullOrEmpty(textBox5.Text) & comboBox1.SelectedIndex == 0)) { MessageBox.Show("Error"); }
            else
            {





                int weight = Convert.ToInt32(textBox4.Text);                           //считывание введёных данных
                string name = textBox1.Text;
                int countfood = Convert.ToInt32(textBox4.Text);
                int age = Convert.ToInt32(textBox2.Text);
                string wingsize = textBox5.Text;

                if (comboBox1.SelectedIndex == 0) { Animals.Add(new Bird(weight, name, age, countfood, wingsize)); Birds.Add(new Bird(weight, name, age, countfood, wingsize)); }      //занесение в список
                if (comboBox1.SelectedIndex == 1) { Animals.Add(new Mammalia(weight, name, age, countfood)); Mammalias.Add(new Mammalia(weight, name, age, countfood)); }
            }

        }
















        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox1.Text = "";                                                                   //очистка текстбоксов
            textBox2.Text = "";
           
            textBox4.Text = "";
            textBox5.Text = "";

            if (comboBox1.SelectedIndex == 0)

                textBox5.ReadOnly = false;

            else textBox5.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();


            /* int x = Animals.Count;
           string y = "Имя \t\t Возраст \t Количество еды \t \n";
             for (int i = 0; i < x; i++) { y = y + Animals[i].Name + " \t\t " + Animals[i].Age + "\t\t " + Animals[i].CountFood + "\n"; } */

            int x = Mammalias.Count;
            int z = Birds.Count;
            string y = "Имя \t\t Возраст \t Количество еды \t Вес \t Размах крыльев \n";
            for (int i = 0; i < x; i++) { y = y + Mammalias[i].Name + " \t\t " + Mammalias[i].Age + "\t\t " + Mammalias[i].CountFood + "\t\t " + Mammalias[i].Weight + "\n"; }
            for (int i = 0; i < z; i++) { y = y + Birds[i].Name + " \t\t " + Birds[i].Age + "\t\t " + Birds[i].CountFood + "\t\t " + Birds[i].Weight + "\t\t " + Birds[i].WingSize + "\n"; }


            richTextBox1.Text = y;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)                              //сортировка по убыванию
        {
            int year, food;
            string nm;
            for (int i = 0; i < (Animals.Count()) - 1; i++)
            {
                for (int j = i + 1; j < Animals.Count(); j++)
                {
                    if (Animals[i].Age < Animals[j].Age)
                    {
                        year = Animals[i].Age;
                        food = Animals[i].CountFood;
                        nm = Animals[i].Name;
                        Animals[i].Name = Animals[j].Name;
                        Animals[i].Age = Animals[j].Age;
                        Animals[i].CountFood = Animals[j].CountFood;
                        Animals[j].Age = year;
                        Animals[j].CountFood = food;
                        Animals[j].Name = nm;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int x = Mammalias.Count;
            int z = Birds.Count;
            int l = Animals.Count;
            string m = "Имя \t\t Возраст \t Количество еды \t Вес \t Размах крыльев \n";
            for (int i = 0; i < l; i++)
            {
                int j = 0;
                for (j = 0; j < z; j++)
                {
                    if (Animals[i].Name == Birds[j].Name)
                    {
                        m = m + Birds[j].Name + " \t\t " + Birds[j].Age + "\t\t " + Birds[j].CountFood + "\t\t " + Birds[j].Weight + "\t\t " + Birds[j].WingSize + "\n"; ;
                    }
                    else
                    {

                        for (int p = 0; p < x; p++)
                        {
                            if (Animals[i].Name == Mammalias[p].Name)
                            {
                                m = m + Mammalias[p].Name + " \t\t " + Mammalias[p].Age + "\t\t " + Mammalias[p].CountFood + "\t\t " + Mammalias[p].Weight + "\n";
                                j = z;
                            }
                        }
                        
                    }

                }
            }

            richTextBox1.Text = m;
        }
    }















    public abstract class Animal
    {
        public abstract string Name { get; set; }

        public abstract int Age { get; set; }

        public abstract int CountFood { get; set; }

        public Animal(string name, int age, int countFood)
        {
            Name = name;
            Age = age;
            CountFood = countFood;
        }


        


        public abstract int Nutrition(int Weight);
    }

    public class Bird : Animal
    {

        public override string Name { get; set; }
        public override int Age { get; set; }
        public override int CountFood { get; set; }
        public int Weight { get; set; }
        public string WingSize { get; set; }
        public Bird(int weight, string name, int age, int countFood, string wingSize) : base(name, age, countFood)

        {
            Weight = weight;
            Name = name;
            Age = age;
            CountFood = Nutrition(weight);
            WingSize = wingSize;
        }

        public override int Nutrition(int Weight)
        {
            CountFood = 1;
            return (CountFood);
        }
    }
    public class Mammalia : Animal
    {
        public override string Name { get; set; }
        public override int Age { get; set; }
        public override int CountFood { get; set; }
        public int Weight { get; set; }

        public override int Nutrition(int Weight)
        {
            if (Weight < 0) { Console.WriteLine("Error"); CountFood = 0; }
            else
            {
                if (Weight < 5)
                { CountFood = 1; }

                else
                {
                    if (Weight > 5 && Weight < 10) { CountFood = 2; }
                    else { if (Weight > 10) { CountFood = 3; } }
                }


            }
            return (CountFood);
        }

        public Mammalia(int weight, string name, int age, int countFood) : base(name, age, countFood)

        {
            Weight = weight;
            Name = name;
            Age = age;
            CountFood = Nutrition(weight);
        }


















    }

}