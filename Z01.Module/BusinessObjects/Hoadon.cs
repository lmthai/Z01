using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Z01.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("bill")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Hoadon : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Hoadon(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            if(Session.IsNewObject(this))
            {
                Ngay = DateTime.Now;
            }
        }

        private DateTime _Ngay;
        [XafDisplayName("Ngày"), ModelDefault("DisplayFormat","{0:dd/MM/yyyy HH:mm}")]
        public DateTime Ngay
        {
            get { return _Ngay; }
            set { SetPropertyValue<DateTime>(nameof(Ngay), ref _Ngay, value); }
        }

        private int _Soban;
        [XafDisplayName("Số bàn")]
        public int Soban
        {
            get { return _Soban; }
            set { SetPropertyValue<int>(nameof(Soban), ref _Soban, value); }
        }
        [XafDisplayName("Tổng tiền")]
        [ModelDefault("DisplayFormat", "### ### ###")]
        public decimal Tongtien
        {
            get
            {
                decimal tien = 0;
                foreach(var item in HoadonCTs)
                {
                    tien += item.Thanhtien;
                }
                return tien;
            }
        }
        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Các món")]
        public XPCollection<HoadonCT> HoadonCTs
        {
            get { return GetCollection<HoadonCT>(nameof(HoadonCTs)); }
        }



    }
}