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
    [NavigationItem(false)]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HoadonCT : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public HoadonCT(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private Hoadon _Phieu;
        [Association]
        public Hoadon Phieu
        {
            get { return _Phieu; }
            set { SetPropertyValue<Hoadon>(nameof(Phieu), ref _Phieu, value); }
        }

        private Sanpham _Hang;
        [Association]
        [XafDisplayName("Món")]
        public Sanpham Hang
        {
            get { return _Hang; }
            set 
            { 
                bool isModified = SetPropertyValue<Sanpham>(nameof(Hang), ref _Hang, value); 
                if(isModified && !IsLoading && value!=null)
                {
                    Dongia = value.Giaban;
                }
            }
        }

        private double _Soluong;
        [XafDisplayName("Số lượng")]
        public double Soluong
        {
            get { return _Soluong; }
            set { SetPropertyValue<double>(nameof(Soluong), ref _Soluong, value); }
        }

        private decimal _Dongia;
        [XafDisplayName("Đơn giá")]
        [ModelDefault("DisplayFormat", "### ### ###")]
        public decimal Dongia
        {
            get { return _Dongia; }
            set { SetPropertyValue<decimal>(nameof(Dongia), ref _Dongia, value); }
        }
        [XafDisplayName("Thành tiền")]
        [ModelDefault("DisplayFormat", "### ### ###")]
        public decimal Thanhtien
        {
            get
            {
                //decimal tien = (decimal)Soluong * Dongia;
                //return tien;
                return  (decimal)Soluong * Dongia;
            }
        }




    }
}