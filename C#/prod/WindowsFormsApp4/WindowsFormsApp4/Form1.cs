using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        List<Movie> movies = new List<Movie>();
        List<Category> categoris = new List<Category>();
        List<Cast> nomes = new List<Cast>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new MyConnection().GetConnection();
            conn.Open();
            SqlCommand cmdCate = new SqlCommand("SELECT * FROM tb_categories", conn);
            SqlDataReader dr = cmdCate.ExecuteReader();
            while (dr.Read())
            {
                comboBoxCategory.Items.Add(dr["cate_name"]);
                categoris.Add(new Category()
                {
                    id = ((int)dr["cate_id"]),
                    cate_name = dr["cate_name"] as string,
                });
            }
            conn.Close();
            conn.Open();
            SqlCommand cmdMovie = new SqlCommand("SELECT * FROM tb_movies", conn);
            SqlDataReader dr1 = cmdMovie.ExecuteReader();
            while (dr1.Read())
            {
                movies.Add(new Movie()
                {
                    id = ((int) dr1 ["id"]),
                    movie_name = dr1["movie_name"] as string,
                    cate_id = ((int) dr1["cate_id"]),
                    
                });
            }
            conn.Close();

            conn.Open();
            SqlCommand cmdCast = new SqlCommand("SELECT * FROM tb_cast", conn);
            SqlDataReader dr2 = cmdCast.ExecuteReader();

            while (dr2.Read())
            {
                nomes.Add(new Cast()
                {
                    id = ((int) dr2 ["id"]),
                    nomes = dr2["nomes"] as string,
                    movies_id = ((int)dr2["movies_id"]),

                });
            }
            conn.Close();

        }
        private string[] GetMovieById(int id)
        {
            return movies.Where(line => line.cate_id == id).Select(l => l.movie_name).ToArray();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMovie.Items.Clear();
            int id = categoris[comboBoxCategory.SelectedIndex].id;
            foreach(string name in GetMovieById(id))
            {
                this.comboBoxMovie.Items.Add(name);
            }

        }

        private string[] GetCastById(int id)
        {
            return nomes.Where(line => line.movies_id== id).Select(l => l.nomes).ToArray();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            int id = movies[comboBoxMovie.SelectedIndex].id; // here we used comboBoxMovie
            foreach (string name1 in GetCastById(id))
            {
                this.comboBox1.Items.Add(name1);
            }
        }
    }

    [Serializable]
    class Category
    {
        public int id { get; set; }
        public string cate_name { get; set; }
    }
    class Movie
    {
        public int id { get; set; }
        public string movie_name { get; set; }
        public int cate_id { get; set; }
    }
    class Cast
    {
        public int id { get; set; }
        public string nomes { get; set; }
        public int movies_id { get; set; }
    }
}
