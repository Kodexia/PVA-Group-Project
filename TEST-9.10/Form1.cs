using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST_9._10
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (getNumbers(textBox1.Text) is float[])
      {
        AnswerLabel.Text = getAvarage(getNumbers(textBox1.Text)) + "";

      }
    }

    private float[] getNumbers(string input)
    {
      float[] numbers;
      try
      {
        numbers = input.Split(',')
                       .Select(s => (float)Math.Round(Convert.ToDecimal(s, System.Globalization.CultureInfo.InvariantCulture)))
                       .ToArray();
        return numbers;
      }
      catch (FormatException e)
      {
        MessageBox.Show($"Špatne zadany input");
        return null;
      }
    }
    private float getAvarage(float[] numbers)
    {
      float avarage = 0;
      foreach (float num in numbers)
      {
        avarage += num;      
      }
      return avarage/numbers.Length;

    }
  }
}
