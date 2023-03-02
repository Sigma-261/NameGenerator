using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator
{
    internal class MarkovGenerator
    {
        Dictionary<string, Dictionary<string, Dictionary<string, int>>> probsOb;
        Dictionary<string, Dictionary<string, dynamic>> markovOb;
        List<int> seedsLengths;
        List<string> seedsAr;
        int minWordLength;
        int maxWordLength;

        bool mustCreateOnlyNewNames;
        bool mustKeepSmapleLength;

        Random rng;
        public MarkovGenerator()
        {
            probsOb = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
            markovOb = new Dictionary<string, Dictionary<string, dynamic>>();
            seedsLengths = new List<int>();
            seedsAr = new List<string>();
            minWordLength = 0;
            maxWordLength = 30;

            mustCreateOnlyNewNames = true;
            mustKeepSmapleLength = true;

            rng = new Random();
        }

        public void Init(string[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {

                string oneName = ar[i].ToLower();
                string prevPrevCh = "|";
                string prevCh = "|";


                int lenName = oneName.Length;
                for (int j = 0; j <= lenName; j++)
                {
                    string ch;

                    Dictionary<string, Dictionary<string, int>> ob = new Dictionary<string, Dictionary<string, int>>();
                    Dictionary<string, int> ob2 = new Dictionary<string, int>();
                    if (j < lenName)
                    {
                        ch = oneName[j].ToString();
                    }
                    else
                    {
                        ch = "|";
                    }

                    if (probsOb.ContainsKey(prevPrevCh))
                    {
                        ob = probsOb[prevPrevCh];
                    }
                    else
                    {

                        probsOb[prevPrevCh] = ob;
                    }

                    if (ob.ContainsKey(prevCh))
                    {
                        ob2 = ob[prevCh];
                    }
                    else
                    {
                        ob[prevCh] = ob2;
                    }

                    if (ob2.ContainsKey(ch))
                    {
                        ob2[ch]++;
                    }
                    else
                    {
                        ob2[ch] = 1;
                    }

                    prevPrevCh = prevCh;
                    prevCh = ch;

                }

                while (lenName >= seedsLengths.Count)
                {
                    seedsLengths.Add(0);
                }
                seedsLengths[lenName]++;
            }

            
            foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> ch1 in probsOb)
            {
                foreach (KeyValuePair<string, Dictionary<string, int>> ch2 in probsOb[ch1.Key])
                {
                    Dictionary<string, int> ob3;
                    ob3 = probsOb[ch1.Key][ch2.Key];
                    List<string> charsAr = new() { };
                    List<int> weightAr = new() { };
                    foreach (KeyValuePair<string, int> ch3 in ob3)
                    {
                        charsAr.Add(ch3.Key);
                        weightAr.Add(ob3[ch3.Key]);

                    }
                    string[] chars = { ch1.Key, ch2.Key };
                    string s = String.Concat(chars);
                    markovOb[s] = new Dictionary<string, dynamic>
                    {
                        ["charsAr"] = charsAr,
                        ["weightAr"] = weightAr
                    };
                    //var v = markovOb[s]["weightAr"][0];
                }
            }

            //defining the lengths of 95% smaple strings
            float percVal = 0.025f;
            var percNum = Math.Round(percVal * ar.Length);
            int id = 0;
            int sum = 0;
            while (sum < percNum)
            {
                sum += seedsLengths[id];
                id++;
            }

            minWordLength = id - 1;

            id = seedsLengths.Count - 1;
            sum = 0;
            while (sum < percNum)
            {
                sum += seedsLengths[id];
                id--;
            }

            maxWordLength = id + 1;
        }

        public string Generate()
        {
            string res = "";
            int numAttempts = 0;
            bool mustMakeNextAttempt = true;
            while (mustMakeNextAttempt)
            {
                mustMakeNextAttempt = false;
                numAttempts++;

                res = "";
                string prevPrevCh = "|";
                string prevCh = "|";
                bool need1More = true;

                while (need1More)
                {
                    var ob = markovOb[prevPrevCh + prevCh];
                    var u = ob[key: "weightAr"];
                    int id = GetRandomIndexFromWeightedAr(u);
                    string ch = ob[key: "charsAr"][id];
                    if (ch != "|")
                    {
                        res += ch;
                    }
                    else
                    {
                        need1More = false;
                    }
                    prevPrevCh = prevCh;
                    prevCh = ch;        
                }

                if (numAttempts < 10)
                {
                    if (mustCreateOnlyNewNames)
                    {
                        if (seedsAr.IndexOf(res) != -1)
                        {
                            mustMakeNextAttempt = true;
                        }
                    }

                    if (!mustMakeNextAttempt)
                    {
                        if (mustKeepSmapleLength)
                        {
                            if ((res.Length < minWordLength) || (res.Length > maxWordLength))
                            {
                                mustMakeNextAttempt = true;
                            }
                        }
                    }
                }
            }
            return res;
        }

        public int GetRandomIndexFromWeightedAr(List<int> ar)
        {
            if (ar.Count == 1)
            {
                if (ar[0] == 0)
                {
                    return -1;

                }
                else
                {
                    return 0;
                }
            }
            int res = -1;
            int s = 0;
            for (int i = 0; i < ar.Count; i++)
            {
                s += ar[i];
            }
            if (s > 0)
            {
                double rnd = s * rng.NextDouble();
                int rid = 0;
                while (rnd >= ar[rid])
                {
                    rnd -= ar[rid];
                    rid++;
                }
                res = rid;
            }
            else
            {
                res = -1;
            }
            return res;
        }
            
    }
}
