﻿using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChangedDemoProject.Module.BusinessObjects
{
    //[DefaultClassOptions]
    [ModelDefault("Caption", "Unit1")]
    [DefaultProperty(nameof(ShortName))]
    public class Unit1 : DescriptedObjectBase
    {
        public Unit1(Session session) : base(session)
        {

        }


        private string shortName;
        [Size(10)]
        [ModelDefault("Caption", "ShortName")]
        public string ShortName
        {
            get { return shortName; }
            set { SetPropertyValue("ShortName", ref shortName, value); }
        }
    }
}
