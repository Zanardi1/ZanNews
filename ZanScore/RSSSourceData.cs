using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace ZanScore
/*
O biblioteca ce contine toate functiile necesare prelucrarii unui fisier RSS:
1. Deschiderea unui fisier RSS;
2. Validarea acestuia;
3. Citirea si interpretarea lui;
4. Extragerea informatiilor din el si punerea lor in program;
5. 

 */

{
    public class RSSSourceData
    //O clasa ce retine datele dintr-un fisier RSS. Detalii despre acesta sunt la https://www.w3schools.com/xml/xml_rss.asp.
    {
        public List<string> NewsChannelTitle = new List<string>(); //Titlurile canalelor de stiri
        public List<string> NewsTitle = new List<string>(); //Titlurile stirilor
        public List<string> NewsLink = new List<string>(); //Link-urile catre stiri
        public List<string> NewsDescription = new List<string>(); //Descrierile stirilor

        public RSSSourceData()
        {

        }

        public bool FillRSSData(string FileToLoad)
        //Ideea si metoda am luat-o de la: https://stackoverflow.com/questions/10399400/best-way-to-read-rss-feed-in-net-using-c-sharp
        {
            XmlReader reader = XmlReader.Create(FileToLoad);
            SyndicationFeed feed = new SyndicationFeed();

            try
            {
                feed = SyndicationFeed.Load(reader);
            }

            catch (XmlException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(e.Message+ " Program will go to the next news source", "Error loading news source file", buttons, icon);
                return false;
            }

            finally
            {
                reader.Close();
            }

            foreach (SyndicationItem item in feed.Items)
            {
                NewsChannelTitle.Add(feed.Title == null ? "" : feed.Title.Text.ToString());
                NewsTitle.Add(item.Title == null ? "" : item.Title.Text);
                NewsLink.Add(item.Links[0].Uri.ToString() == null ? "" : item.Links[0].Uri.ToString());
                NewsDescription.Add(item.Summary == null ? "" : item.Summary.Text);
            }
            return true;
        }

        public void EmptyFields()
        {
            NewsChannelTitle.Clear();
            NewsDescription.Clear();
            NewsLink.Clear();
            NewsTitle.Clear();
        }
    }
}