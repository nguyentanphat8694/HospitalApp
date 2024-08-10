﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Hospital.App
{
    public class KeysListObRecord : ObservableCollection<ObRecord>
    {
        public bool AddOb(ObRecord ob)
        {
            return NTPObRecord.Insert(ob) != 0;
        }
        public KeysListObRecord GetMax()
        {
            return NTPObRecord.GetMax();
        }

    }
}