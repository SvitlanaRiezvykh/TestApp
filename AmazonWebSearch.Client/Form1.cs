using AmazonWebSearch.Client.Services;

namespace AmazonWebSearch.Client
{
    public partial class Form1 : Form
    {
        const string PRICE_LABEL = "Price: {0}";
        private IAmazonSearch _search;

        public Form1()
        {
            InitializeComponent();
            _search = new AmazonWebSearchClient("http://localhost:5068");
        }

        public Form1(IAmazonSearch search)
        {
            InitializeComponent();
            _search = search;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
        }

        private async void Search(object sender, EventArgs e)
        {
            var category = textBox1.Text;
            var country = textBox2.Text;

            var price = await _search.FindPrice(category, country);

            label3.Text = string.Format(PRICE_LABEL, price);

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ClearPriceField();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            ClearPriceField();
        }

        private void ClearPriceField()
        {
            label3.Text = string.Empty;
        }
    }
}