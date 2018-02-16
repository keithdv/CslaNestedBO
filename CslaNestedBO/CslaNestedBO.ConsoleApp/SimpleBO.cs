using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaNestedBO.ConsoleApp
{
    [Serializable]
    public class SimpleBO : BusinessBase<SimpleBO>
    {

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<SimpleBO> ChildProperty = RegisterProperty<SimpleBO>(c => c.Child);
        public SimpleBO Child
        {
            get { return GetProperty(ChildProperty); }
            set { SetProperty(ChildProperty, value); }
        }

        public static readonly PropertyInfo<int> DepthProperty = RegisterProperty<int>(c => c.Depth);
        public int Depth
        {
            get { return GetProperty(DepthProperty); }
            set { SetProperty(DepthProperty, value); }
        }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(NameProperty));
        }

        private void DataPortal_Fetch()
        {
            LoadProperty(DepthProperty, 0);
            LoadProperty(ChildProperty, Csla.DataPortal.FetchChild<SimpleBO>(Depth + 1));
        }

        private void Child_Fetch(int depth)
        {
            LoadProperty(DepthProperty, depth);
            if (depth < 13)
            {
                LoadProperty(ChildProperty, Csla.DataPortal.FetchChild<SimpleBO>(Depth + 1));
            }
        }

    }
}
