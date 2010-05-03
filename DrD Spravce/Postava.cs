using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Pair<T1, T2>
    {
        public T1 first;
        public T2 second;

        public Pair()
        {
            first = default(T1);
            second = default(T2);
        }

        public Pair(T1 f, T2 s)
        {
            first = f;
            second = s;
        }
    }

    public class Oprava
    {
        public string vlastnost;
        public string name;
        public int bonus;
        public bool custom;
        
        public Oprava(string vlast, string desc, int bon)
        {
            vlastnost = vlast;
            name = desc;
            bonus = bon;
            custom = false;
        }

        public Oprava(string vlast, string desc, int bon, bool cust) : this(vlast, desc, bon)
        {
            custom = cust;
        }

        public string getParsedBonus()
        {
            return Program.parseBonus(bonus);
        }

        public string getDescription()
        {
            return name.Substring(name.IndexOf("|") + 1);
        }
    }

    public class Postava
    {
        public String jmeno;
        public String rasa;
        public bool zena;
        public String povolani;

        public int uroven;
        public int zkusenosti;
        public int zkusenostiNeeded;

        public float penize;

        public int zraneni;
        public int unava;

        private int _postihZ = 0;
        private int _postihU = 0;

        public int postihZ
        {
            get { return _postihZ; }
            set
            {
                _postihZ = value;
                Main form = Program.getMainForm();
                if (form.postavyMgr.GetOpened() == this)
                {
                    form.postihZL.Text = _postihZ.ToString();
                    form.postihZL.Tag = zraneni;
                    if (_postihZ == 0)
                        form.postihZL.Visible = false;
                    else
                        form.postihZL.Visible = true;
                }
            }
        }
        public int postihU
        {
            get { return _postihU; }
            set
            {
                _postihU = value;
                Main form = Program.getMainForm();
                if (form.postavyMgr.GetOpened() == this)
                {
                    form.postihUL.Text = _postihU.ToString();
                    form.postihUL.Tag = unava;
                    if (_postihU == 0)
                        form.postihUL.Visible = false;
                    else
                        form.postihUL.Visible = true;
                }
            }
        }

        private Pair<String, int>[] vlastnosti = new Pair<string, int>[27];
        public Pair<String, int>[] zvyseniVlastnosti = new Pair<String, int>[6];

        public List<Oprava> opravy = new List<Oprava>();

        public string[] poznamky = new string[]{"","","","","18","","","","","","",""};
        public string[] pozn_names = { "otec", "matka", "sourozenci", "narozeni", "vek", "nabozenstvi",
                                   "touhy", "sny", "cile", "povaha", "quest", "dalsi"};

        public String xmlFileName = "";
        private Panel sheet = new Panel();

        public ZbrojMgr zbrojMgr;
        public KombinaceMgr kombinaceZbrani;
        public VybavaMgr vybaveniMgr;
        public DovednostiMgr dovednostiMgr;
        public ZivotyMgr zivotyMgr;
        public UnavaMgr unavaMgr;

        public Postava()
        {
            penize = 0;

            for (int i = 0; i < vlastnosti.Length; i++)
            {
                vlastnosti[i] = new Pair<string, int>();
            }
            vlastnosti[0].first = "Sil";
            vlastnosti[1].first = "Obr";
            vlastnosti[2].first = "Zrč";
            vlastnosti[3].first = "Vol";
            vlastnosti[4].first = "Int";
            vlastnosti[5].first = "Chr";

            vlastnosti[6].first = "Odl";
            vlastnosti[7].first = "Vdr";
            vlastnosti[8].first = "Rch";
            vlastnosti[9].first = "Sms";
            vlastnosti[10].first = "Vel";
            vlastnosti[11].first = "Hmp";
            vlastnosti[12].first = "Výška";

            vlastnosti[13].first = "Boj";
            vlastnosti[14].first = "Útok";
            vlastnosti[15].first = "Obrana";
            vlastnosti[16].first = "Střelba";
            vlastnosti[17].first = "Mez zranění";
            vlastnosti[18].first = "Mez únavy";

            vlastnosti[19].first = "Krs";
            vlastnosti[20].first = "Nbz";
            vlastnosti[21].first = "Dst";

            vlastnosti[22].first = "Chůze";
            vlastnosti[23].first = "Spěch";
            vlastnosti[24].first = "Běh";
            vlastnosti[25].first = "Sprint";

            vlastnosti[26].first = "Max náklad";

            for (int i = 0; i < 6; i++)
            {
                zvyseniVlastnosti[i] = new Pair<string, int>();
                zvyseniVlastnosti[i].second = 0;
            }
            zvyseniVlastnosti[0].first = "Sil";
            zvyseniVlastnosti[1].first = "Obr";
            zvyseniVlastnosti[2].first = "Zrč";
            zvyseniVlastnosti[3].first = "Vol";
            zvyseniVlastnosti[4].first = "Int";
            zvyseniVlastnosti[5].first = "Chr";

            zbrojMgr = new ZbrojMgr(this);
            kombinaceZbrani = new KombinaceMgr((FlowLayoutPanel)Program.getMainForm().bojFlowPanel, this);
            vybaveniMgr = new VybavaMgr((FlowLayoutPanel)Program.getMainForm().VybaveniFlowPanel, this);
            Main main = Program.getMainForm();

            FlowLayoutPanel p1 = (FlowLayoutPanel)Program.getMainForm().fyzPanel;
            FlowLayoutPanel p2 = (FlowLayoutPanel)Program.getMainForm().psyPanel;
            FlowLayoutPanel p3 = (FlowLayoutPanel)Program.getMainForm().kombPanel;
            Panel det = (Panel)Program.getMainForm().dovednostiDetails;
            dovednostiMgr = new DovednostiMgr(p1, p2, p3, det, this);

            zivotyMgr = new ZivotyMgr(this, main.mezZraneniL, main.zraneniN, main.zivotyBars, main.zivotyLabels, main.postihZLink, main.postihZL);
            unavaMgr = new UnavaMgr(this, main.mezUnavyL, main.unavaN, main.unavaBars, main.unavaLabels, main.postihULink, main.postihUL);

            vybaveniMgr.InsertBlank();
        }

        public void setUroven(int uroven)
        {
            this.uroven = uroven;
            databaseDataSet db = Program.getDB();
            this.zkusenosti = zkusenosti - (int)Program.getTabZraneniUnavyCell(15 + uroven);
            this.zkusenostiNeeded = (int)Program.getTabZraneniUnavyCell(15+uroven);
        }

        public void setZkusenosti(int zkus)
        {
            zkusenosti = zkus;
        }

        public void Save()
        {
            if (xmlFileName == String.Empty)
            {
                Main form = Program.getMainForm();
                form.saveDialog.FileName = jmeno;
                if (form.saveDialog.ShowDialog(form) == DialogResult.OK)
                {
                    TreeNode tnode = form.postavyMgr.GetNode("", jmeno);
                    tnode.Name = form.saveDialog.FileName;
                    xmlFileName = form.saveDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", ""));
            System.Xml.XmlElement root = doc.CreateElement("postava");
            System.Xml.XmlNode node = doc.CreateElement("jmeno");
            node.AppendChild(doc.CreateTextNode(jmeno));
            root.AppendChild(node);

            node = doc.CreateElement("rasa");
            node.AppendChild(doc.CreateTextNode(rasa));
            root.AppendChild(node);

            node = doc.CreateElement("pohlavi");
            node.AppendChild(doc.CreateTextNode(zena == true ? "Žena" : "Muž"));
            root.AppendChild(node);

            node = doc.CreateElement("povolani");
            node.AppendChild(doc.CreateTextNode(povolani));
            root.AppendChild(node);

            node = doc.CreateElement("uroven");
            node.AppendChild(doc.CreateTextNode(uroven.ToString()));
            root.AppendChild(node);

            node = doc.CreateElement("zkusenosti");
            node.AppendChild(doc.CreateTextNode(zkusenosti.ToString()));
            root.AppendChild(node);

            node = doc.CreateElement("zraneni");
            node.AppendChild(doc.CreateTextNode(zraneni.ToString()));
            root.AppendChild(node);

            node = doc.CreateElement("zpostih");
            node.AppendChild(doc.CreateTextNode(postihZ.ToString()));
            root.AppendChild(node);

            node = doc.CreateElement("unava");
            node.AppendChild(doc.CreateTextNode(unava.ToString()));
            root.AppendChild(node);

            node = doc.CreateElement("upostih");
            node.AppendChild(doc.CreateTextNode(postihU.ToString()));
            root.AppendChild(node);

            node = doc.CreateElement("penize");
            node.AppendChild(doc.CreateTextNode(penize.ToString()));
            root.AppendChild(node);

            int i = 0;
            foreach (Pair<String, int> vlast in vlastnosti)
            {
                if (i > 5) break;
                node = doc.CreateElement("vlastnost");

                System.Xml.XmlAttribute att = doc.CreateAttribute("nazev");
                att.Value = vlast.first;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("hodnota");
                att.Value = vlast.second.ToString();
                node.Attributes.Append(att);

                att = doc.CreateAttribute("zvyseni");
                att.Value = zvyseniVlastnosti[i].second.ToString();
                node.Attributes.Append(att);

                root.AppendChild(node);
                i++;
            }
            //:::::::::::::::::::::::::::::::  KONSTITUCE  :::::::::::::::::::::::::::::::::::::::::::
            node = doc.CreateElement("vel");
            node.AppendChild(doc.CreateTextNode(getVlastnost("Vel").ToString()));
            root.AppendChild(node);

            node = doc.CreateElement("hmp");
            node.AppendChild(doc.CreateTextNode(getVlastnost("Hmp").ToString()));
            root.AppendChild(node);

            node = doc.CreateElement("vyska");
            node.AppendChild(doc.CreateTextNode(getVlastnost("Výška").ToString()));
            root.AppendChild(node);
            //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            node = doc.CreateElement("zbroj");
            node.AppendChild(doc.CreateTextNode(zbrojMgr.zJmeno));
            root.AppendChild(node);

            node = doc.CreateElement("prilba");
            node.AppendChild(doc.CreateTextNode(zbrojMgr.pJmeno));
            root.AppendChild(node);

            foreach (Kombinace kombo in kombinaceZbrani.kombinaceList)
            {
                node = doc.CreateElement("kombinace");

                System.Xml.XmlAttribute att = doc.CreateAttribute("nazev");
                att.Value = kombo.nazev;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("zbran");
                att.Value = kombo.zbran;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("stit");
                att.Value = kombo.stit;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("obourucne");
                att.Value = kombo.obouruc.ToString();
                node.Attributes.Append(att);

                att = doc.CreateAttribute("typ");
                att.Value = "naBlizko";
                node.Attributes.Append(att);

                root.AppendChild(node);
            }
            foreach (Strelna kombo in kombinaceZbrani.strelneList)
            {
                node = doc.CreateElement("kombinace");

                System.Xml.XmlAttribute att = doc.CreateAttribute("nazev");
                att.Value = kombo.nazev;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("zbran");
                att.Value = kombo.zbran;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("typ");
                att.Value = "naDalku";
                node.Attributes.Append(att);

                root.AppendChild(node);
            }

            foreach (Predmet p in vybaveniMgr.vybavaList)
            {
                if (p.predmet == "") continue;

                node = doc.CreateElement("vybaveni");

                System.Xml.XmlAttribute att = doc.CreateAttribute("predmet");
                att.Value = p.predmet;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("pocet");
                att.Value = p.pocet.ToString();
                node.Attributes.Append(att);

                att = doc.CreateAttribute("vlNazev");
                att.Value = p.ownName;
                node.Attributes.Append(att);

                foreach (Oprava oprr in p.opravy)
                {
                    System.Xml.XmlNode opr = doc.CreateElement("oprava");

                    att = doc.CreateAttribute("nazev");
                    att.Value = oprr.name;
                    opr.Attributes.Append(att);

                    att = doc.CreateAttribute("vlast");
                    att.Value = oprr.vlastnost;
                    opr.Attributes.Append(att);

                    att = doc.CreateAttribute("hodnota");
                    att.Value = oprr.bonus.ToString();
                    opr.Attributes.Append(att);

                    node.AppendChild(opr);
                }

                root.AppendChild(node);
            }

            foreach (Dovednost d in dovednostiMgr.fyzList)
            {
                node = doc.CreateElement("fyz");

                System.Xml.XmlAttribute att = doc.CreateAttribute("dovednost");
                att.Value = d.dovednost;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("stupen");
                att.Value = d.stupen.ToString();
                node.Attributes.Append(att);

                root.AppendChild(node);
            }
            foreach (Dovednost d in dovednostiMgr.psyList)
            {
                node = doc.CreateElement("psy");

                System.Xml.XmlAttribute att = doc.CreateAttribute("dovednost");
                att.Value = d.dovednost;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("stupen");
                att.Value = d.stupen.ToString();
                node.Attributes.Append(att);

                root.AppendChild(node);
            }
            foreach (Dovednost d in dovednostiMgr.kombList)
            {
                node = doc.CreateElement("komb");

                System.Xml.XmlAttribute att = doc.CreateAttribute("dovednost");
                att.Value = d.dovednost;
                node.Attributes.Append(att);

                att = doc.CreateAttribute("stupen");
                att.Value = d.stupen.ToString();
                node.Attributes.Append(att);

                root.AppendChild(node);
            }

            foreach (Oprava opr in opravy)
            {
                if (opr.custom == true)
                {
                    node = doc.CreateElement("coprava");

                    System.Xml.XmlAttribute att = doc.CreateAttribute("vlastnost");
                    att.Value = opr.vlastnost;
                    node.Attributes.Append(att);

                    att = doc.CreateAttribute("name");
                    att.Value = opr.name;
                    node.Attributes.Append(att);

                    att = doc.CreateAttribute("bonus");
                    att.Value = opr.bonus.ToString();
                    node.Attributes.Append(att);

                    root.AppendChild(node);
                }
            }

            node = doc.CreateElement("poznamky");
            {
                System.Xml.XmlNode pozn;

                for (int j = 0; j < pozn_names.Length; j++)
                {
                    if (poznamky[j].Trim() != "")
                    {
                        pozn = doc.CreateElement(pozn_names[j]);
                        pozn.InnerText = poznamky[j];
                        node.AppendChild(pozn);
                    }
                }
            }
            root.AppendChild(node);

            node = doc.CreateElement("listPovolani");
            SavePovolaniSheet(doc, node);
            root.AppendChild(node);

            doc.AppendChild(root);
            doc.Save(xmlFileName);
        }

        public int Load(string filename)
        {
            Program.Log("Loading " + filename);
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filename);

                System.Xml.XmlElement pos = (System.Xml.XmlElement)doc.GetElementsByTagName("postava")[0];

                System.Xml.XmlElement el = (System.Xml.XmlElement)pos.GetElementsByTagName("jmeno")[0];
                jmeno = el.FirstChild.Value;

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("rasa")[0];
                rasa = el.FirstChild.Value;
                if (Program.getDB().rasy.FindByjmeno(rasa) == null)
                {
                    MessageBox.Show("Rasa " + rasa + " v databázi neexistuje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("pohlavi")[0];
                zena = el.FirstChild.Value == "Žena" ? true : false;

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("povolani")[0];
                povolani = el.FirstChild.Value;
                if (Program.getDB().povolani.FindByjmeno(povolani) == null)
                {
                    MessageBox.Show("Povolání " + povolani + " v databázi neexistuje", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("uroven")[0];
                uroven = int.Parse(el.FirstChild.Value);

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("zkusenosti")[0];
                zkusenosti = int.Parse(el.FirstChild.Value);

                zkusenostiNeeded = (int)Program.getTabZraneniUnavyCell(15 + uroven);

                //zraneni
                el = (System.Xml.XmlElement)pos.GetElementsByTagName("zraneni")[0];
                zraneni = int.Parse(el.FirstChild.Value);
                foreach (System.Xml.XmlElement elm in pos.GetElementsByTagName("zpostih"))
                {
                    postihZ = int.Parse(elm.FirstChild.Value);
                }

                //unava
                foreach (System.Xml.XmlElement elm in pos.GetElementsByTagName("unava"))
                {
                    unava = int.Parse(elm.FirstChild.Value);
                }
                foreach (System.Xml.XmlElement elm in pos.GetElementsByTagName("upostih"))
                {
                    postihU = int.Parse(elm.FirstChild.Value);
                }

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("penize")[0];
                if(el != null)
                    penize = float.Parse(el.FirstChild.Value);

                int i = 0;
                System.Xml.XmlNodeList list = pos.GetElementsByTagName("vlastnost");
                foreach (System.Xml.XmlNode node in list)
                {
                    if (i >= 6) break;
                    el = (System.Xml.XmlElement)node;
                    String name = el.GetAttribute("nazev");
                    int value = int.Parse(el.GetAttribute("hodnota"));
                    zvyseniVlastnosti[i].second = int.Parse(el.GetAttribute("zvyseni"));
                    setVlastnost(name, value);
                    i++;
                }

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("vel")[0];
                setVlastnost("Vel", int.Parse(el.FirstChild.Value));

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("hmp")[0];
                setVlastnost("Hmp", int.Parse(el.FirstChild.Value));

                el = (System.Xml.XmlElement)pos.GetElementsByTagName("vyska")[0];
                setVlastnost("Výška", int.Parse(el.FirstChild.Value));

                dovednostiMgr.Clear();
                
                Calculate();

                list = pos.GetElementsByTagName("fyz");
                foreach (System.Xml.XmlNode node in list)
                {
                    el = (System.Xml.XmlElement)node;
                    String dov = el.GetAttribute("dovednost");
                    int st = int.Parse(el.GetAttribute("stupen"));
                    dovednostiMgr.AddFyz(dov, st);
                }

                list = pos.GetElementsByTagName("psy");
                foreach (System.Xml.XmlNode node in list)
                {
                    el = (System.Xml.XmlElement)node;
                    String dov = el.GetAttribute("dovednost");
                    int st = int.Parse(el.GetAttribute("stupen"));
                    dovednostiMgr.AddPsy(dov, st);
                }

                list = pos.GetElementsByTagName("komb");
                foreach (System.Xml.XmlNode node in list)
                {
                    el = (System.Xml.XmlElement)node;
                    String dov = el.GetAttribute("dovednost");
                    int st = int.Parse(el.GetAttribute("stupen"));
                    dovednostiMgr.AddKomb(dov, st);
                }

                {
                    el = (System.Xml.XmlElement)pos.GetElementsByTagName("zbroj")[0];
                    String zb = el.FirstChild.Value;

                    el = (System.Xml.XmlElement)pos.GetElementsByTagName("prilba")[0];
                    String pr = el.FirstChild.Value;

                    zbrojMgr.Load(zb, pr);
                }

                list = pos.GetElementsByTagName("kombinace");
                foreach (System.Xml.XmlNode node in list)
                {
                    el = (System.Xml.XmlElement)node;
                    String name = el.GetAttribute("nazev");
                    String zbran = el.GetAttribute("zbran");
                    if (el.GetAttribute("typ") == "naBlizko")
                    {
                        String stit = el.GetAttribute("stit");
                        bool obouruc = bool.Parse(el.GetAttribute("obourucne"));
                        kombinaceZbrani.AddKomb(name, zbran, stit, obouruc);
                    }
                    else
                    {
                        kombinaceZbrani.AddKomb(name, zbran);
                    }
                }

                vybaveniMgr.Clear();
                list = pos.GetElementsByTagName("vybaveni");
                foreach (System.Xml.XmlNode node in list)
                {
                    el = (System.Xml.XmlElement)node;
                    String predmet = el.GetAttribute("predmet");
                    int pocet = int.Parse(el.GetAttribute("pocet"));
                    String ownName = el.GetAttribute("vlNazev");

                    List<Oprava> oprs = new List<Oprava>();
                    foreach (System.Xml.XmlNode opr in el.GetElementsByTagName("oprava"))
                    {
                        System.Xml.XmlElement opEl = (System.Xml.XmlElement)opr;
                        oprs.Add(new Oprava(opEl.GetAttribute("vlast"), opEl.GetAttribute("nazev"), int.Parse(opEl.GetAttribute("hodnota"))));
                    }

                    vybaveniMgr.AddPredmetOnLoad(predmet, pocet, ownName, oprs);
                }
                vybaveniMgr.InsertBlank();

                list = pos.GetElementsByTagName("coprava");
                foreach (System.Xml.XmlNode node in list)
                {
                    el = (System.Xml.XmlElement)node;
                    Oprava opr = new Oprava(el.GetAttribute("vlastnost"), el.GetAttribute("name"), int.Parse(el.GetAttribute("bonus")), true);
                    setOprava(opr);
                }
                
                foreach (System.Xml.XmlNode node in pos.GetElementsByTagName("poznamky"))
                {
                    foreach (System.Xml.XmlNode child in node.ChildNodes)
                    {
                        for (int j = 0; j < pozn_names.Length; j++)
                        {
                            if (pozn_names[j] == child.Name)
                            {
                                poznamky[j] = child.InnerText;
                            }
                        }
                    }
                }

                LoadPovolaniSheet(doc);

                xmlFileName = filename;
                Program.getMainForm().AddRecent(filename);
                Program.Log("Loading succesful");
            }
            catch (Exception e)
            {
                MessageBox.Show("Při načítání souboru '" + filename + "' se vyskytla chyba.\n\n" + e.Message + e.Source, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.Log("Loading failed. Something is wrong in " + filename);
                return -1;
            }
            return 0;
        }

        public void LoadPovolaniSheet(System.Xml.XmlDocument pos)
        {
            sheet.Controls.Clear();
            sheet.Dock = DockStyle.Fill;

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            String sheetfn = Program.getDB().povolani.FindByjmeno(povolani).sheetLayout;
            if (sheetfn == "") return;
            try
            {
                doc.Load(sheetfn);
            }
            catch
            {
                MessageBox.Show("Soubor s listem povolání nemohl být nalezen.", "Soubor nenalezen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Xml.XmlNode node;
            System.Xml.XmlAttribute att;

            foreach (System.Xml.XmlNode nod in doc.GetElementsByTagName("label"))
            {
                Label l = new Label();
                l.AutoSize = true;
                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("size");
                if (att != null)
                {
                    l.Font = new Font(l.Font.FontFamily, 9.75f);
                    l.Font = new Font(l.Font, FontStyle.Bold);
                }
                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("left");
                if (att != null)
                {
                    l.Left = int.Parse(att.Value);
                }
                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("top");
                if (att != null)
                {
                    l.Top = int.Parse(att.Value);
                }
                if (att != null)
                {
                    l.Text = nod.InnerText;
                }
                sheet.Controls.Add(l);
            }
            foreach (System.Xml.XmlNode nod in doc.GetElementsByTagName("checkbox"))
            {
                CheckBox l = new CheckBox();
                l.AutoSize = true;

                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("left");
                if (att != null)
                {
                    l.Left = int.Parse(att.Value);
                }
                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("top");
                if (att != null)
                {
                    l.Top = int.Parse(att.Value);
                }
                if (att != null)
                {
                    l.Text = nod.InnerText;
                }
                sheet.Controls.Add(l);
            }
            foreach (System.Xml.XmlNode nod in doc.GetElementsByTagName("textbox"))
            {
                TextBox l = new TextBox();

                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("left");
                if (att != null)
                {
                    l.Left = int.Parse(att.Value);
                }
                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("top");
                if (att != null)
                {
                    l.Top = int.Parse(att.Value);
                }
                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("width");
                if (att != null)
                {
                    l.Width = int.Parse(att.Value);
                }
                att = (System.Xml.XmlAttribute)nod.Attributes.GetNamedItem("height");
                if (att != null)
                {
                    l.Multiline = true;
                    l.Height = int.Parse(att.Value);
                }
                if (att != null)
                {
                    l.Text = nod.InnerText;
                }
                sheet.Controls.Add(l);
            }

            try
            {
                System.Xml.XmlNodeList list = pos.GetElementsByTagName("listPovolani");
                if (list.Count > 0)
                {
                    node = list[0];
                    int i = 0;
                    foreach (Control con in sheet.Controls)
                    {
                        System.Xml.XmlNode child = node.ChildNodes[i];
                        if (child.Name == "checkbox" && con.GetType() == typeof(CheckBox))
                        {
                            ((CheckBox)con).Checked = bool.Parse(child.InnerText);
                            i++;
                        }
                        else if (child.Name == "textbox" && con.GetType() == typeof(TextBox))
                        {
                            ((TextBox)con).Text = child.InnerText;
                            i++;
                        }
                    }
                }
            }
            catch
            {
                /* ... */
            }
        }

        public void SetPovolaniSheet()
        {
            Panel panel = Program.getMainForm().povolaniPanel;
            if (panel.Controls.Count > 0)
            {
                panel.Controls[0].Parent = null;
            }
            panel.Controls.Add(sheet);
        }

        public void SavePovolaniSheet(System.Xml.XmlDocument doc, System.Xml.XmlNode root)
        {
            System.Xml.XmlNode node;
            foreach (Control con in sheet.Controls)
            {
                Type type = con.GetType();
                if (type == typeof(CheckBox))
                {
                    node = doc.CreateElement("checkbox");
                    node.AppendChild(doc.CreateTextNode(((CheckBox)con).Checked.ToString()));
                    root.AppendChild(node);
                }
                else if (type == typeof(TextBox))
                {
                    node = doc.CreateElement("textbox");
                    node.AppendChild(doc.CreateTextNode(((TextBox)con).Text));
                    root.AppendChild(node);
                }
            }
        }

        public void Calculate()
        {
            databaseDataSet db = Program.getDB();

            String oprava = "";

            // Odl = Sil
            String name = "Odl";
            setVlastnost(name, parseMath(Program.getIniEx(name)));
            oprava = Program.getRasyCell(rasa, "oodl").ToString();
            if (oprava != "")
            {
                setOprava("Odl", "za rasu", int.Parse(oprava));
            }

            // Vdr = (Sil+Vol)/2
            name = "Vdr";
            setVlastnost(name, parseMath(Program.getIniEx(name)));
            oprava = Program.getRasyCell(rasa, "ovdr").ToString();
            if (oprava != "")
            {
                setOprava("Vdr", "za rasu", int.Parse(oprava));
            }

            // Rch = (Sil+Obr)/2
            name = "Rch";
            int value = parseMath(Program.getIniEx(name));
            setVlastnost(name, value);
            int vyska = getVlastnostO("Výška");
            if (vyska <= 3)
            {
                this.setOprava("Rch", "za výšku", -1);
            }
            else if (vyska >= 7)
            {
                this.setOprava("Rch", "za výšku", 1);
            }
            

            // Sms = Zrč
            name = "Sms";
            setVlastnost(name, parseMath(Program.getIniEx(name)));
            oprava = Program.getRasyCell(rasa, "osms").ToString();
            if (oprava != "")
            {
                setOprava("Sms", "za rasu", int.Parse(oprava));
            }

            // Boj = zalezi na povolani
            name = "Boj";
            value = parseMath(Program.getDB().povolani.FindByjmeno(povolani).oboj);
            setVlastnost(name, value);
            vyska = getVlastnostO("Výška");
            if (vyska <= 3)
            {
                this.setOprava("Boj", "za výšku", -1);
            }
            else if (vyska >= 7)
            {
                this.setOprava("Boj", "za výšku", 1);
            }
            
            // Boj = zalezi na povolani
            setVlastnost("Útok", parseMath(Program.getIniEx("Útok")));
            setVlastnost("Obrana", parseMath(Program.getIniEx("Obrana")));
            setVlastnost("Střelba", parseMath(Program.getIniEx("Střelba")));
            setVlastnost("Mez zranění", (int)Program.getTabZraneniUnavyCell(parseMath("Odl+10")));
            setVlastnost("Mez únavy", (int)Program.getTabZraneniUnavyCell(parseMath("Vdr+10")));
            
            // Krs = Zrč
            name = "Krs";
            setVlastnost(name, parseMath(Program.getIniEx(name)));
            /*oprava = db.rasy.Rows.Find(rasa).ItemArray[17].ToString();
            if (oprava != "")
            {
                vlast = Program.parseMath(oprava, odvozeneVlastnosti);
                setVlastnost(name, vlast);
            }*/

            // Nbz = Zrč
            name = "Nbz";
            setVlastnost(name, parseMath(Program.getIniEx(name)));
            /*oprava = db.rasy.Rows.Find(rasa).ItemArray[17].ToString();
            if (oprava != "")
            {
                vlast = Program.parseMath(oprava, odvozeneVlastnosti);
                setVlastnost(name, vlast);
            }*/

            // Dst = Zrč
            name = "Dst";
            setVlastnost(name, parseMath(Program.getIniEx(name)));
            /*oprava = db.rasy.Rows.Find(rasa).ItemArray[17].ToString();
            if (oprava != "")
            {
                vlast = Program.parseMath(oprava, odvozeneVlastnosti);
                setVlastnost(name, vlast);
            }*/

            kombinaceZbrani.UpdateAll();

            name = "Chůze";
            setVlastnost(name, parseMath(Program.getIniEx(name)));

            name = "Spěch";
            setVlastnost(name, parseMath(Program.getIniEx(name)));

            name = "Běh";
            setVlastnost(name, parseMath(Program.getIniEx(name)));

            name = "Sprint";
            setVlastnost(name, parseMath(Program.getIniEx(name)));

            //max naklad = Sil+21 [+ Atletika]
            setVlastnost("Max náklad", getVlastnostO("Sil") + 21 + dovednostiMgr.getDovednost("Atletika"));

        }

        public void setZakladniVlastnosti(int[] vlastnosti)
        {
            for (int i = 0; i < 6; i++)
            {
                this.vlastnosti[i].second = vlastnosti[i];
            }
        }

        public void setVlastnost(String vlast, int stupen)
        {
            for (int i = 0; i < vlastnosti.Length; i++)
            {
                if (vlastnosti[i].first == vlast)
                {
                    vlastnosti[i].second = stupen;
                    return;
                }
            }
        }

        public int getVlastnost(String vlast)
        {
            for (int i = 0; i < vlastnosti.Length; i++)
            {
                if (vlastnosti[i].first == vlast)
                {
                    return vlastnosti[i].second;
                }
            }
            return -1;
        }

        public int getVlastnostO(String vlast)
        {
            for (int i = 0; i < vlastnosti.Length; i++)
            {
                if (vlastnosti[i].first == vlast)
                {
                    int value = getVlastnost(vlast);
                    foreach (Oprava oprava in opravy)
                    {
                        if (oprava.vlastnost == vlast)
                        {
                            value += oprava.bonus;
                        }
                    }
                    return value;
                }
            }
            return -1;
        }

        public Pair<String, int>[] getAllVlastnosti()
        {
            Pair<String, int>[] vlastiO = new Pair<string, int>[vlastnosti.Length];
            int i = 0;
            foreach (Pair<String, int> vlast in vlastnosti)
            {
                int value = getVlastnostO(vlast.first);
                vlastiO[i] = new Pair<string, int>();
                vlastiO[i].first = vlast.first;
                vlastiO[i].second = value;
                i++;
            }
            return vlastiO;
        }

        public Oprava getOprava(String name)
        {
            foreach(Oprava oprava in opravy)
            {
                if (oprava.name == name)
                {
                    return oprava;
                }
            }
            return null;
        }

        public void setOprava(String vlast, String desc, int bon)
        {
            String name = vlast + "|" + desc;

            Oprava op;
            if ((op = getOprava(name)) == null)
            {
                if (bon == 0)
                    return;
                op = new Oprava(vlast, name, bon);
                opravy.Add(op);
            }
            else
            {
                if (bon == 0)
                {
                    deleteOprava(op);
                    return;
                }
                op.bonus = bon;
            }
        }

        public void setOprava(Oprava opr)
        {
            Oprava op;
            if ((op = getOprava(opr.name)) == null)
            {
                if (opr.bonus == 0)
                    return;
                opravy.Add(opr);
            }
            else
            {
                if (opr.bonus == 0)
                {
                    deleteOprava(opr);
                    return;
                }
                op.bonus = opr.bonus;
            }
        }

        public List<Pair<String, int>> getOpravyByVlast(String vlast)
        {
            List<Pair<String, int>> list = new List<Pair<string, int>>();
            
            foreach (Oprava oprava in opravy)
            {
                if (oprava.vlastnost == vlast)
                {
                    Pair<String, int> p = new Pair<string, int>();
                    p.first = oprava.name;
                    p.second = oprava.bonus;
                    list.Add(p);
                }
            }
            return list;
        }

        public void deleteOprava(String name)
        {
            foreach (Oprava pair in opravy)
            {
                if (pair.name == name)
                {
                    opravy.Remove(pair);
                }
            }
        }

        public void deleteOprava(Oprava opr)
        {
            for (int i = opravy.Count - 1; i >= 0; i--)
            {
                if (opravy[i].name == opr.name)
                {
                    opravy.RemoveAt(i);
                }
            }
            //if (Program.getMainForm().postavyMgr.GetOpened().Equals(this))
            //  Program.getMainForm().setNew(this);
            
        }

        public int parseMath(String equation)
        {
            if (vlastnosti == null) return 0;
            for (int j = 0; j < vlastnosti.Length; j++)
            {
                equation = equation.Replace(vlastnosti[j].first.ToString(), getVlastnostO(vlastnosti[j].first.ToString()).ToString());
            }
            equation = equation.Replace(" ", "");
            int x = Program.parseEquation(equation);
            return x;
        }

        public void LevelUp()
        {
            if (zkusenosti >= zkusenostiNeeded)
            {
                uroven++;
                zkusenosti = zkusenosti - zkusenostiNeeded;
                zkusenostiNeeded = (int)Program.getTabZraneniUnavyCell(15 + uroven);
            }
        }

        public void setPoznamka(object pozn)
        {
            Control con = (Control)pozn;
            for (int i = 0; i < pozn_names.Length; i++)
            {
                if ("poz_" + pozn_names[i] == con.Name)
                {
                    if (con.GetType() == typeof(TextBox))
                        poznamky[i] = con.Text;
                    else if (con.GetType() == typeof(NumericUpDown))
                        poznamky[i] = ((NumericUpDown)con).Value.ToString();
                }
            }
        }
    }
}
