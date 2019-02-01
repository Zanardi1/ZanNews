using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZanScore
{
    public partial class NewsLibrary : Form
    {
        List<string> NewsSourceNames = new List<string>() { "ABC News", "AFP", "Associated Press", "BBC", "CBC News", "CBS News", "The Christian Science Monitor", "CNN News", "The Daily Beast", "The Daily Mail", "Foreign Policy", "Fox News", "Global Post", "Harper's", "India Today", "International Business Times", "NBA News", "The New Yorker", "Newsweek", "NPR News", "The Root", "Salon", "Sky News", "The Telegraph", "Time Magazine", "U.S. News & World Report", "USA Today", "Vox.com", "The Washington Post", "The Washington Times", "Yahoo News", "BBC Sport", "Bleacher Report", "CBS Sports", "Complex", "Deadspin", "ESPN", "FIFA", "Golf Week", "MLB", "NASCAR", "NBA", "NBC Sports", "NFL", "NHL", "Rivals", "Rotoworld", "SB Nation", "Scout", "Sky Sports", "Sporting News", "Sports Illustrated", "The Sports Network", "Sportsgrid", "Teamtalk", "theScore", "TransWorld Skateboarding", "Yahoo Sports", "Destructoid", "Empire", "The Escapist", "Gamasutra", "Gamespot", "GamesRadar", "Gamezebo", "Giant Bomb", "IGN", "Kotaku", "Polygon", "Seeker", "Allure", "Architectural Digest", "Autoblog", "Barcroft TV", "Biography", "Bon Appetit", "Brides", "Car and Driver", "CityLab", "Cleveland Clinic", "Complex", "Conde Nast Traveler", "Consumer Reports", "The Consumerist", "Cooking Light", "Cosmopolitan", "Country Living", "Delish", "Drugs.com", "Dwell", "Eating Well", "Edmunds", "Elle", "Elle Decor", "Epicurious", "Esquire", "Essence", "Everyday Health", "Fashionista", "FitPregnancy", "Glamour", "Good Housekeeping", "GQ", "Harper's Bazar", "Harvard Health Publications", "Healthguru", "Instyle", "The Knot", "Liquour.com", "Lovefood", "Marie Claire", "Mayo Clinic", "MedicineNet", "Men's Fitness", "Men's Health", "Modernist Cuisine", "Motor Trend", "Motorist Research", "Natural Health Magazine", "The Nest", "Popular Mechanics", "Prevention", "Racked", "Real Simple", "Redbook", "Refinery 29", "Saveur", "Self", "Seventeen", "Shape", "Surfing", "Town and Country", "Vanity Fair", "Veranda", "Vogue", "Wanderlust", "WebMD", "Wine Folly", "Wine-Searcher", "Woman's Day", "Women's Fitness", "Working Mother", "AUX", "Billboard", "The Fader", "JamBase", "MTV News", "Pitchfork", "Rolling Stone", "Spin", "USA Today Music", "VH 1", "The Wire", "AccuWeather", "American Scientist", "Animalist", "Astronomy", "Climate Central", "Discover Magazine", "Earth Techling", "Focus", "Quest", "LiveScience", "National Geographic", "Nature", "New Scientist", "Popular Science", "Psychology Today", "Red Orbit", "Science Daily", "Scientific American", "Sky & Telescope", "Smithsonian", "The Weather Channel", "The eather Network" };

        //todo de adaugat surse de stiri cautate de catre mine

        public NewsLibrary()
        {
            InitializeComponent();
        }
    }
}
