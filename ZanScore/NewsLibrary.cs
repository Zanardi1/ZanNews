using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System;

namespace ZanScore
{
    /// <summary>
    /// Class that stores the news library window.
    /// </summary>
    public partial class NewsLibrary : Form
    {
        private static int absoluteindex = 0;

        /// <summary>
        /// List which stores the news sources from the news library.
        /// </summary>
        static public List<string> NewsSourcesList = new List<string>() { };
        /// <summary>
        /// List which stores the news categories from the news library.
        /// </summary>
        public List<string> NewsCategoriesList = new List<string>() { };
        /// <summary>
        /// List which stores the URL of the RSS feeds of the library news sources.
        /// </summary>
        static public List<string> NewsSourcesRSSList = new List<string>() { };

        /// <summary>
        /// Computes the index of a news from the news list that is read and stored in the three lists declared above.
        /// </summary>
        static public int AbsoluteIndex
        {
            get
            {
                return absoluteindex;
            }
            set
            {
                if (value >= 0)
                    absoluteindex = value;
                else
                    absoluteindex = 0;
            }
        }

        /// <summary>
        /// Class constructor.
        /// </summary>
        public NewsLibrary()
        {
            InitializeComponent();
            ClearLists();
            OpenLibraryFile();
        }

        /// <summary>
        /// Clears all the lists.
        /// </summary>
        private void ClearLists()
        {
            NewsSourcesList.Clear();
            NewsCategoriesList.Clear();
            NewsSourcesRSSList.Clear();
        }

        /// <summary>
        /// Reads the news library and fills the three lists. Set as public to be able to be unit tested.
        /// </summary>
        /// <returns>true if no exceptions were thrown. Else, returns false.</returns>
        /// <exception cref="FileNotFoundException">If the library file is not found.</exception>
        /// <exception cref="FileLoadException">If the library file cannot be loaded.</exception>
        /// <exception cref="IOException">Thrown when a I/O exception occurs.</exception>
        /// <exception cref="SecurityException">Thrown when a security exception occurs.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown at substring operations. Very unlikely to happen, but just to be safe.</exception>
        public bool ReadFromLibrary()
        {
            string[] ReadBuffer = new string[] { };
            try
            {
                ReadBuffer = File.ReadAllLines("Library.txt");
                int i = 0, found = 0, j = 0;
                for (i = 0; i < ReadBuffer.Length; i += 3)
                {
                    ReadBuffer[i] = ReadBuffer[i].Trim();
                    NewsSourcesList.Add(ReadBuffer[i]);
                    found = ReadBuffer[i].IndexOf(":");
                    NewsSourcesList[j] = (found == -1 ? "" : NewsSourcesList[j].Substring(found + 1));

                    ReadBuffer[i + 1] = ReadBuffer[i + 1].Trim();
                    NewsCategoriesList.Add(ReadBuffer[i + 1]);
                    found = ReadBuffer[i + 1].IndexOf(":");
                    NewsCategoriesList[j] = (found == -1 ? "" : NewsCategoriesList[j].Substring(found + 1));

                    ReadBuffer[i + 2] = ReadBuffer[i + 2].Trim();
                    NewsSourcesRSSList.Add(ReadBuffer[i + 2]);
                    found = ReadBuffer[i + 2].IndexOf(":");
                    NewsSourcesRSSList[j] = (found == -1 ? "" : NewsSourcesRSSList[j].Substring(found + 1));

                    j++;
                }
                return true;
            }
            catch (FileNotFoundException)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Warning;
                MessageBox.Show("The news library file could not be found. A new library file had been created.", "Warning!", MB, MI);
                CreateDefaultLibraryFile();
                return false;
            }
            catch (FileLoadException F)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(F.Message, "Error!", MB, MI);
                return false;
            }
            catch (IOException I)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(I.Message, "Error!", MB, MI);
                return false;
            }
            catch (SecurityException S)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(S.Message, "Error!", MB, MI);
                return false;
            }
            catch (ArgumentOutOfRangeException A)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error!", MB, MI);
                return false;
            }
        }

        /// <summary>
        /// Creates the default library file, should the file be missing.
        /// </summary>
        private void CreateDefaultLibraryFile()
        {
            List<string> buffer = new List<string>();
            buffer.Add("name: ABC News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://abcnews.go.com/abcnews/topstories");
            buffer.Add("name: AFP");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.afp.com/en/search/site/rss");
            buffer.Add("name: BBC");
            buffer.Add("category: National & World News");
            buffer.Add("URL:http://feeds.bbci.co.uk/news/rss.xml");
            buffer.Add("name: CBC News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.cbc.ca/cmlink/rss-topstories");
            buffer.Add("name: CBS News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.cbsnews.com/rss/");
            buffer.Add("name: The Christian Science Monitor");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://rss.csmonitor.com/feeds/csm");
            buffer.Add("name: CNN News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:http://rss.cnn.com/rss/edition.rss");
            buffer.Add("name: The Daily Beast");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://feeds.thedailybeast.com/rss/articles");
            buffer.Add("name: The Daily Mail");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.dailymail.co.uk/articles.rss");
            buffer.Add("name: Foreign Policy");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://foreignpolicy.com/feed/");
            buffer.Add("name: Fox News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.foxnews.com/about/rss/");
            buffer.Add("name: Global Post");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://cohort21.com/feed/globalpostsfeed?posttype=post");
            buffer.Add("name: India Today");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.indiatoday.in/rss/home");
            buffer.Add("name: International Business Times");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.ibtimes.co.uk/rss/feed");
            buffer.Add("name: NBA News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:http://www.nba.com/rss/nba_rss.xml");
            buffer.Add("name: The New Yorker");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.newyorker.com/feed/news");
            buffer.Add("name: Newsweek");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.newsweek.com/rss");
            buffer.Add("name: NPR News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.npr.org/rss/podcast.php?id=500005");
            buffer.Add("name: The Root");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.theroot.com/rss");
            buffer.Add("name: Sky News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:http://feeds.skynews.com/feeds/rss/home.xml");
            buffer.Add("name: The Telegraph");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.telegraph.co.uk/rss.xml");
            buffer.Add("name: Time Magazine");
            buffer.Add("category: National & World News");
            buffer.Add("URL:http://feeds.feedburner.com/time/topstories?format=xml");
            buffer.Add("name: USA Today");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.usatoday.com/rss/");
            buffer.Add("name: Vox.com");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.vox.com/rss/stream/5328445");
            buffer.Add("name: The Washington Post");
            buffer.Add("category: National & World News");
            buffer.Add("URL:http://feeds.washingtonpost.com/rss/politics");
            buffer.Add("name: The Washington Times");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://www.washingtontimes.com/rss/headlines/news/");
            buffer.Add("name: Yahoo News");
            buffer.Add("category: National & World News");
            buffer.Add("URL:https://news.yahoo.com/rss/mostviewed");
            buffer.Add("name: BBC Sport");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://feeds.bbci.co.uk/sport/rss.xml?edition=uk");
            buffer.Add("name: CBS Sports");
            buffer.Add("category: Sports");
            buffer.Add("URL:https://rss.cbssports.com/rss/headlines/");
            buffer.Add("name: Complex");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://assets.complex.com/feeds/channels/sports.xml");
            buffer.Add("name: ESPN");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://www.espn.com/espn/rss/news");
            buffer.Add("name: FIFA");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://static.fifa.com/rss/index.xml");
            buffer.Add("name: Golf Week");
            buffer.Add("category: Sports");
            buffer.Add("URL:https://golfweek.com/feed/");
            buffer.Add("name: MLB");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://mlb.mlb.com/partnerxml/gen/news/rss/mlb.xml");
            buffer.Add("name: NASCAR");
            buffer.Add("category: Sports");
            buffer.Add("URL:https://www.nascar.com/feed/");
            buffer.Add("name: NBA");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://www.nba.com/rss/nba_rss.xml");
            buffer.Add("name: NHL");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://ice.nhl.com/rss/news.xml");
            buffer.Add("name: Rotoworld");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://www.rotoworld.com/rss/feed.aspx?sport=nba&ftype=article&count=12&format=rss");
            buffer.Add("name: Sky Sports");
            buffer.Add("category: Sports");
            buffer.Add("URL:https://www.skysports.com/rss/12040");
            buffer.Add("name: Sports Illustrated");
            buffer.Add("category: Sports");
            buffer.Add("URL:https://www.si.com/rss/si_topstories.rss");
            buffer.Add("name: The Sports Network");
            buffer.Add("category: Sports");
            buffer.Add("URL:http://thesportsnetwork.com/index.php?option=com_obrss&task=feed&id=2:sports-news-information&format=feed&Itemid=121");
            buffer.Add("name: Teamtalk");
            buffer.Add("category: Sports");
            buffer.Add("URL:https://www.teamtalk.com/feed");
            buffer.Add("name: TransWorld Skateboarding");
            buffer.Add("category: Sports");
            buffer.Add("URL:https://skateboarding.transworld.net/news/feed/");
            buffer.Add("name: Yahoo Sports");
            buffer.Add("category: Sports");
            buffer.Add("URL:https://sports.yahoo.com/top/rss");
            buffer.Add("name: Destructoid");
            buffer.Add("category: Gaming");
            buffer.Add("URL:http://feeds.feedburner.com/Destructoid");
            buffer.Add("name: The Escapist");
            buffer.Add("category: Gaming");
            buffer.Add("URL:http://rss.escapistmagazine.com/news/0.xml");
            buffer.Add("name: Gamasutra");
            buffer.Add("category: Gaming");
            buffer.Add("URL:http://feeds.feedburner.com/GamasutraNews");
            buffer.Add("name: Gamespot");
            buffer.Add("category: Gaming");
            buffer.Add("URL:https://www.gamespot.com/feeds/mashup/");
            buffer.Add("name: Gamezebo");
            buffer.Add("category: Gaming");
            buffer.Add("URL:https://www.gamezebo.com/feed");
            buffer.Add("name: Giant Bomb");
            buffer.Add("category: Gaming");
            buffer.Add("URL:https://www.giantbomb.com/feeds/new_releases/");
            buffer.Add("name: IGN");
            buffer.Add("category: Gaming");
            buffer.Add("URL:http://feeds.ign.com/ign/video-guides");
            buffer.Add("name: Kotaku");
            buffer.Add("category: Gaming");
            buffer.Add("URL:https://kotaku.com/rss");
            buffer.Add("name: Polygon");
            buffer.Add("category: Gaming");
            buffer.Add("URL:https://www.polygon.com/rss/index.xml");
            buffer.Add("name: Allure");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.allure.com/feed/rss");
            buffer.Add("name: Autoblog");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://www.autoblog.com/rss.xml");
            buffer.Add("name: Biography");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://www.biography.com/.rss/full/");
            buffer.Add("name: Bon Appetit");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.bonappetit.com/feed/rss");
            buffer.Add("name: Car and Driver");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.caranddriver.com/features/rss-feeds");
            buffer.Add("name: CityLab");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.citylab.com/feeds/posts/");
            buffer.Add("name: Cleveland Clinic");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://www.clevelandclinic.org/health/health-info/RSS/HealthInfo.xml");
            buffer.Add("name: The Consumerist");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://www.consumerist.com/index.xml");
            buffer.Add("name: Cooking Light");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://feeds.cookinglight.com/CookingLight/latest?format=xml");
            buffer.Add("name: Cosmopolitan");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.cosmopolitan.com/rss/all.xml/");
            buffer.Add("name: Drugs.com");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.drugs.com/feeds/medical_news.xml");
            buffer.Add("name: Edmunds");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.edmunds.com/feeds/rss/articles.xml");
            buffer.Add("name: Elle");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.elle.com/rss/all.xml");
            buffer.Add("name: Epicurious");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.epicurious.com/services/rss/recipes");
            buffer.Add("name: Esquire");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.esquire.com/rss/all.xml/");
            buffer.Add("name: Fashionista");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://fashionista.com/.rss/full/tag/network");
            buffer.Add("name: FitPregnancy");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.fitpregnancy.com/pregnancy/pregnancy-news/feed");
            buffer.Add("name: Good Housekeeping");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.goodhousekeeping.com/rss/all.xml/");
            buffer.Add("name: GQ");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.gq.com/feed/rss");
            buffer.Add("name: Harvard Health Publications");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.hsph.harvard.edu/news/feed/?post_type=featured-news-story");
            buffer.Add("name: Instyle");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.instyle.com/feeds/all/ins.rss");
            buffer.Add("name: Lovefood");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://lovefood.libsyn.com/rss");
            buffer.Add("name: Marie Claire");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.marieclaire.co.uk/fashion/feed");
            buffer.Add("name: Mayo Clinic");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.mayoclinic.org/rss/all-health-information-topics");
            buffer.Add("name: MedicineNet");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.medicinenet.com/rss/dailyhealth.xml");
            buffer.Add("name: Men's Health");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.menshealth.com/uk/feeds/content");
            buffer.Add("name: Modernist Cuisine");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://modernistcuisine.com/feed/");
            buffer.Add("name: Motor Trend");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.motortrend.com/feed/");
            buffer.Add("name: Natural Health Magazine");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.naturalhealthmag.com.au/rss");
            buffer.Add("name: The Nest");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://nest.com/blog/feed.rss");
            buffer.Add("name: Popular Mechanics");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://www.popularmechanics.co.za/category/science/feed/");
            buffer.Add("name: Racked");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://www.racked.com/rss/index.xml");
            buffer.Add("name: Refinery 29");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://www.refinery29.com/fashion/rss.xml");
            buffer.Add("name: Saveur");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://www.saveur.com/syndication/site_default/1000580");
            buffer.Add("name: Shape");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.shape.com.sg/feed/");
            buffer.Add("name: Surfing");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://feeds.feedburner.com/surfertoday/surfing?format=xml");
            buffer.Add("name: Vanity Fair");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://feeds.feedburner.com/vfdotcomrss");
            buffer.Add("name: WebMD");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://rssfeeds.webmd.com/rss/rss.aspx?RSSSource=RSS_PUBLIC");
            buffer.Add("name: Wine Folly");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:http://winefolly.com/feed/");
            buffer.Add("name: Wine - Searcher");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.wine-searcher.com/rss-feed/dept/all");
            buffer.Add("name: Women's Fitness");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.womenfitnessmag.com/feed/");
            buffer.Add("name: Working Mother");
            buffer.Add("category: Lifestyle");
            buffer.Add("URL:https://www.workingmother.com/rss.xml");
            buffer.Add("name: Billboard");
            buffer.Add("category: Music");
            buffer.Add("URL:https://www.billboard.com/articles/rss.xml");
            buffer.Add("name: The Fader");
            buffer.Add("category: Music");
            buffer.Add("URL:http://feeds.feedburner.com/TheFaderMagazine");
            buffer.Add("name: JamBase");
            buffer.Add("category: Music");
            buffer.Add("URL:http://feeds.feedburner.com/jambase");
            buffer.Add("name: MTV News");
            buffer.Add("category: Music");
            buffer.Add("URL:https://www.mtv.com/overdrive/rss/news.jhtml");
            buffer.Add("name: Pitchfork");
            buffer.Add("category: Music");
            buffer.Add("URL:https://pitchfork.com/rss/");
            buffer.Add("name: Rolling Stones");
            buffer.Add("category: Music");
            buffer.Add("URL:http://www.rollingstones.com/news/feed/");
            buffer.Add("name: Spin");
            buffer.Add("category: Music");
            buffer.Add("URL:https://www.spin.com/feed/");
            buffer.Add("name: VH 1");
            buffer.Add("category: Music");
            buffer.Add("URL:https://www.feedspot.com/?followfeedid=4820772");
            buffer.Add("name: American Scientist");
            buffer.Add("category: Science");
            buffer.Add("URL:http://rss.sciam.com/ScientificAmerican-Global");
            buffer.Add("name: Astronomy Now");
            buffer.Add("category: Science");
            buffer.Add("URL:https://astronomynow.com/feed/");
            buffer.Add("name: Climate Central");
            buffer.Add("category: Science");
            buffer.Add("URL:https://www.climatecentral.org/breaking/rss");
            buffer.Add("name: Discover Magazine");
            buffer.Add("category: Science");
            buffer.Add("URL:http://feeds.feedburner.com/AllDiscovermagazinecomContent?format=xml");
            buffer.Add("name: Earth Techling");
            buffer.Add("category: Science");
            buffer.Add("URL:http://feeds.feedburner.com/Earthtechling?format=xml");
            buffer.Add("name: LiveScience");
            buffer.Add("category: Science");
            buffer.Add("URL:https://www.livescience.com/home/feed/site.xml");
            buffer.Add("name: National Geographic");
            buffer.Add("category: Science");
            buffer.Add("URL:http://news.nationalgeographic.com/index.rss");
            buffer.Add("name: Nature");
            buffer.Add("category: Science");
            buffer.Add("URL:http://feeds.nature.com/nature/rss/current?x=1");
            buffer.Add("name: New Scientist");
            buffer.Add("category: Science");
            buffer.Add("URL:https://www.newscientist.com/rss-feeds/");
            buffer.Add("name: Popular Science");
            buffer.Add("category: Science");
            buffer.Add("URL:http://www.popsci.com/rss");
            buffer.Add("name: Psychology Today");
            buffer.Add("category: Science");
            buffer.Add("URL:https://www.psychologytoday.com/intl/front/feed");
            buffer.Add("name: Science Daily");
            buffer.Add("category: Science");
            buffer.Add("URL:https://www.sciencedaily.com/rss/all.xml");
            buffer.Add("name: Scientific American");
            buffer.Add("category: Science");
            buffer.Add("URL:http://rss.sciam.com/ScientificAmerican-Global?format=xml");
            buffer.Add("name: Sky & Telescope");
            buffer.Add("category: Science");
            buffer.Add("URL:https://www.skyandtelescope.com/astronomy-news/feed/");
            buffer.Add("name: Smithsonian");
            buffer.Add("category: Science");
            buffer.Add("URL:https://www.smithsonianmag.com/rss/articles/");
            buffer.Add("name: Ars Technica");
            buffer.Add("category: Technology");
            buffer.Add("URL:http://feeds.arstechnica.com/arstechnica/index");
            buffer.Add("name: BGR");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://bgr.com/tech/feed/");
            buffer.Add("name: CNET");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://www.cnet.com/rss/news/");
            buffer.Add("name: Engadget");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://www.engadget.com/rss.xml");
            buffer.Add("name: Geekwire");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://www.geekwire.com/feed/");
            buffer.Add("name: Gizmodo");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://gizmodo.com/rss");
            buffer.Add("name: Lifehacker");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://lifehacker.com/rss");
            buffer.Add("name: Macworld");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://www.macworld.co.uk/latest/rss");
            buffer.Add("name: Mashable");
            buffer.Add("category: Technology");
            buffer.Add("URL:http://feeds.mashable.com/Mashable");
            buffer.Add("name: MIT Technology");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://www.technologyreview.com/stories.rss");
            buffer.Add("name: PC Magazine");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://www.pcmag.com/Rss.aspx/SectionArticles?sectionId=1489");
            buffer.Add("name: PC World");
            buffer.Add("category: Technology");
            buffer.Add("URL:https://www.pcworld.com/index.rss");
            buffer.Add("name: CNN Politics");
            buffer.Add("category: Politics");
            buffer.Add("URL:http://rss.cnn.com/rss/edition.rss");
            buffer.Add("name: Counterpunch");
            buffer.Add("category: Politics");
            buffer.Add("URL:https://www.counterpunch.org/feed/");
            buffer.Add("name: The Daily Caller");
            buffer.Add("category: Politics");
            buffer.Add("URL:http://feeds.feedburner.com/dailycaller");
            buffer.Add("name: Daily KOS");
            buffer.Add("category: Politics");
            buffer.Add("URL:https://www.dailykos.com/news/RSS");
            buffer.Add("name: Free Republic");
            buffer.Add("category: Politics");
            buffer.Add("URL:http://www.freerepublic.com/tag/news-forum/feed.rss");
            buffer.Add("name: The Hill");
            buffer.Add("category: Politics");
            buffer.Add("URL:https://thehill.com/rss/syndicator/19110");
            buffer.Add("name: Hot Air");
            buffer.Add("category: Politics");
            buffer.Add("URL:https://hotair.com/feed/");
            buffer.Add("name: Empire");
            buffer.Add("category: Entertainment");
            buffer.Add("URL:https://www.empireonline.com/podcast/podcast.xml");
            buffer.Add("name: Complex");
            buffer.Add("category: Entertainment");
            buffer.Add("URL:https://assets.complex.com/feeds/channels/all.xml");
            buffer.Add("name: BuzzFeed");
            buffer.Add("category: Entertainment");
            buffer.Add("URL:https://www.buzzfeed.com/index.xml");
            buffer.Add("name: ETOnline");
            buffer.Add("category: Entertainment");
            buffer.Add("URL:http://feeds.feedburner.com/EtsBreakingNews");
            buffer.Add("name: Gossip Cop");
            buffer.Add("category: Entertainment");
            buffer.Add("URL:http://www.gossipcop.com/feed/");
            buffer.Add("name: The Hollywood Gossip");
            buffer.Add("category: Entertainment");
            buffer.Add("URL:http://feeds.thehollywoodgossip.com/TheHollywoodGossip");
            buffer.Add("name: Mental Floss");
            buffer.Add("category: Entertainment");
            buffer.Add("URL:http://mentalfloss.com/rss.xml");
            buffer.Add("name: 24 / 7 Wall Street");
            buffer.Add("category: Business");
            buffer.Add("URL:http://feeds.feedburner.com/typepad/RyNm?format=xml");
            buffer.Add("name: Benzinga");
            buffer.Add("category: Business");
            buffer.Add("URL:http://feeds.benzinga.com/benzinga/news");
            buffer.Add("name: Business Insider");
            buffer.Add("category: Business");
            buffer.Add("URL:https://markets.businessinsider.com/rss/news");
            buffer.Add("name: Business World Online");
            buffer.Add("category: Business");
            buffer.Add("URL:http://www.businessworld.in/rss/all-article.xml");
            buffer.Add("name: CNBC");
            buffer.Add("category: Business");
            buffer.Add("URL:https://www.cnbc.com/id/100003114/device/rss/rss.html");
            buffer.Add("name: CNN Money");
            buffer.Add("category: Business");
            buffer.Add("URL:https://money.cnn.com/services/rss/");
            buffer.Add("name: Curbed");
            buffer.Add("category: Business");
            buffer.Add("URL:https://ny.curbed.com/rss/index.xml");
            File.WriteAllLines("Library.txt", buffer.ToArray());
        }

        /// <summary>
        /// Ia datele din cele trei liste si umple data grid-ul in functie de categoria selectata.
        /// </summary>
        /// <param name="Category">Categoria selectata</param>
        /// <remarks>Valorile pentru Category sunt:
        /// 0 - National and World News;
        /// 1 - Sports;
        /// 2 - Gaming;
        /// 3 - Lifestyle;
        /// 4 - Music;
        /// 5 - Science;
        /// 6 - Technology;
        /// 7 - Politics;
        /// 8 - Entertainment;
        /// 9 - Business;
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown if an error happens in the filling stage.</exception>
        private void FillWindowDatagrid(int Category)
        {
            int LowerBound = 0, UpperBound = 0, j = 0;
            try
            {
                NewsLibrarySourcesView.Rows.Clear();
                switch (Category)
                {
                    case 0:
                        {
                            LowerBound = 0;
                            UpperBound = 26;
                            break;
                        }
                    case 1:
                        {
                            LowerBound = 27;
                            UpperBound = 43;
                            break;
                        }
                    case 2:
                        {
                            LowerBound = 44;
                            UpperBound = 52;
                            break;
                        }
                    case 3:
                        {
                            LowerBound = 53;
                            UpperBound = 94;
                            break;
                        }
                    case 4:
                        {
                            LowerBound = 95;
                            UpperBound = 102;
                            break;
                        }
                    case 5:
                        {
                            LowerBound = 103;
                            UpperBound = 117;
                            break;
                        }
                    case 6:
                        {
                            LowerBound = 118;
                            UpperBound = 129;
                            break;
                        }
                    case 7:
                        {
                            LowerBound = 130;
                            UpperBound = 136;
                            break;
                        }
                    case 8:
                        {
                            LowerBound = 137;
                            UpperBound = 143;
                            break;
                        }
                    case 9:
                        {
                            LowerBound = 144;
                            UpperBound = 150;
                            break;
                        }
                    default: //Pentru cazurile in care functia primeste o alta valoare, care nu se afla in vreo categorie. Nu cred ca acest lucru se va intampla, dar prefer sa fiu precaut
                        {
                            LowerBound = 0;
                            UpperBound = 26;
                            break;
                        }
                }
                for (int i = LowerBound; i <= UpperBound; i++)
                {
                    NewsLibrarySourcesView.Rows.Add();
                    NewsLibrarySourcesView.Rows[j].Cells[0].Value = NewsSourcesList[i];
                    j++;
                }
                NewsLibrarySourcesView.Rows[0].Selected = true;
            }
            catch (InvalidOperationException I)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(I.Message, "Error!", MB, MI);
            }
        }

        /// <summary>
        /// Opens the library file.
        /// </summary>
        private void OpenLibraryFile()
        {
            if (ReadFromLibrary())
            {
                CategoryListBox.SelectedIndex = 0;
                FillWindowDatagrid(0);
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Displays the sources on the selected category.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ChangeNewsSourcesCategory(object sender, System.EventArgs e)
        {
            FillWindowDatagrid(CategoryListBox.SelectedIndex);
        }

        /// <summary>
        /// Return the first selected item from th grid.
        /// </summary>
        /// <param name="Grid">The grid in which the item will be searched.</param>
        /// <returns>The position of the first selected item.</returns>
        private int ReturnFirstSelected(DataGridView Grid)
        {
            int SelectedPosition = 0;
            for (int i = 0; i < Grid.RowCount; i++)
                if (Grid.Rows[i].Selected)
                    SelectedPosition = i;
            return SelectedPosition;
        }

        /// <summary>
        /// Calculeaza indexul absolut.
        /// </summary>
        /// <returns>Indexul absolut.</returns>
        /// <remarks>Ideea din spatele acestui index este aceea de a calcula un indice, care nu tine cont de categoria de stire, la care sa se uite programul atunci cand alege una sau mai multe stiri. Deci trebuie calculat din numarul total de stiri de la categoriile anterioare si din numarul stirii selectate.</remarks>
        private int ComputeAbsoluteIndex()
        {
            int Category = 0, Place = 0;
            switch (CategoryListBox.SelectedIndex)
            {
                case 0:
                    {
                        Category = 0;
                        break;
                    }
                case 1:
                    {
                        Category = 27;
                        break;
                    }
                case 2:
                    {
                        Category = 44;
                        break;
                    }
                case 3:
                    {
                        Category = 53;
                        break;
                    }
                case 4:
                    {
                        Category = 95;
                        break;
                    }
                case 5:
                    {
                        Category = 103;
                        break;
                    }
                case 6:
                    {
                        Category = 118;
                        break;
                    }
                case 7:
                    {
                        Category = 130;
                        break;
                    }
                case 8:
                    {
                        Category = 137;
                        break;
                    }
                case 9:
                    {
                        Category = 144;
                        break;
                    }
            }
            Place = ReturnFirstSelected(NewsLibrarySourcesView);
            return Category + Place;
        }

        /// <summary>
        /// Procedura de vizitare a sursei selectate.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        public void VisitTheSelectedSource(object sender, System.EventArgs e)
        {
            AbsoluteIndex = ComputeAbsoluteIndex();
            ((Form1)Owner).DownloadAllNewsProcess(false);
            ((Form1)Owner).AutomaticalDownloadFromSources = false;
            Close();
        }
    }
}
